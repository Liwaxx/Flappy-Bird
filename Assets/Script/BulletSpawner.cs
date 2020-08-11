using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Bullet bullet;
    [SerializeField] private int bulletNum;
    [SerializeField] private Text bulletText;
    [SerializeField] private UnityEvent OnShoot;

    // Update is called once per frame
    void Update()
    {
        if (!bird.IsDead() && Input.GetMouseButtonDown(1) && bulletNum != 0 )
        {
            Clone();
            Shoot();
        }

        //amunisi
        bulletText.text = bulletNum.ToString();
    }

    private void Clone()
    {  
            Bullet newBullet = Instantiate(bullet, bird.transform.position, Quaternion.identity);
    
            //set active
            newBullet.gameObject.SetActive(true);
    }
    void Shoot()
    {
        //mengurangi bullet
        bulletNum -= 1;

        //mengubah int to string
        bulletText.text = bulletNum.ToString();

        if (OnShoot != null)
        {
            //menjalankan semua event OnJump
            OnShoot.Invoke();
        }

    }
}
