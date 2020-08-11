using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead,shoot;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnJump, OnDead, OnAddPoint;
    [SerializeField] private Text scoreText;


    private Rigidbody2D rigidbody2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //medapatkan komponen ketika game dimulai
        rigidbody2D = GetComponent<Rigidbody2D>();

        //mendapatkan komponen animator pada game object
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            //Burung meloncat
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //menghentikan animasi ketika burung bertabrakan dengan object lain
        animator.enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        //pengecekan jika belum mati dan value OnDead tidak sama dengan Null
        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }
        isDead = true;

    }

    void Jump()
    {
        //mengecek rigibodi null / tidak
        if (rigidbody2D)
        {
            //menghentikan kecepatan burung ketika jatuh
            rigidbody2D.velocity = Vector2.zero;

            //menambahkan gaya ke arah sumbu y agar burung meloncat
            rigidbody2D.AddForce(new Vector2(0, upForce));
        }

        if (OnJump != null)
        {
            //menjalankan semua event OnJump
            OnJump.Invoke();
        }
    }

    public void AddScore(int value)
    {
        //menambahkan Score value
        score += value;

        //mengubah nilai text pada score text
        scoreText.text = score.ToString();

        //pengecekan null value
        if(OnAddPoint != null)
        {
            //memanggil semya event pada OnAddPoint
            OnAddPoint.Invoke();
        }
    }
}
