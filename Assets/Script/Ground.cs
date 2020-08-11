using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//komponen akan ditambahkan jika tidak ada dan komponen tersebut tidak dapat dibuang
[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;


    // Update is called once per frame
    void Update()
    {
        //melakukan pengecekan jika burung null atau belum mati
        if(bird == null || (bird != null && !bird.IsDead()))
        {
            //membuat pipa bergerak kesebelah kiri dengan kecepatan dari variabel speed
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //Method untuk menempatkan game object pada posisi next ground
    public void SetNextGround(GameObject ground)
    {
        //Pengecekam Null value
        if(ground != null)
        {
            //Menempatakan ground berikutnya pada posisi nextground
            ground.transform.position = nextPos.position;
        }
    }

    //Dipanggil ketika game object bersentuhan dengan game object yang lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //membuat burung mati ketika bersentuhan dengan game object ini 
        if(bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}
