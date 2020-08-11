using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    //menampung ground yang ingin dibuat
    [SerializeField] private Ground groundRef;

    //menampung ground yang sebelumnya
    private Ground prevGround;

    //method ini kan membuat Ground game object baru
    private void SpawnGround()
    {
        //pengecekan null variable
        if(prevGround != null)
        {
            //menduplikasi Groundref
            Ground newGround = Instantiate(groundRef);

            //mengaktifkan game object
            newGround.gameObject.SetActive(true);

            //menempatkan new ground dengan posisi nextground dari prevground agar posisinya sejajar dengan ground sebelumnya
            prevGround.SetNextGround(newGround.gameObject);
        }
    }

    //Method ini akan dipanggil ketika terdapat game object lain yang memiliki komponen collider kerluar dari area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        //mencari komponen ground dari object yang keluar dari area trigger
        Ground ground = collision.GetComponent<Ground>();

        //pengecekan null variabel
        if (ground)
        {
            //mengisi variabel prevGround
            prevGround = ground;

            //membuat ground baru
            SpawnGround();
        }
    }
}
