using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Point point;
    [SerializeField] private float speed = 1;
    private void Update()
    {
        //membuat peluru bergerak
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        Point point = collision.gameObject.GetComponent<Point>();

        if (!bird && !point)
        {
            //memusnahkan object ketika bersentuhan
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
