using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;


    // Update is called once per frame
    void Update()
    {
        //melakukan pengecekan burung mati atau tidak
        if (!bird.IsDead())
        {
            //menggerakkan game object ke kiri dg kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        //mendapatkan komponen BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        //pengecekan Null variabel
        if(collider != null)
        {
            //mengubah ukuran collider sesuai dengan parameter
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //mendapatkan komponen Bird
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //menambahkan score juka burung tidak null dan belum mati
        if(bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
