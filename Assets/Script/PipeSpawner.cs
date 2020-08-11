using System.Collections;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize;
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;

    //variabel penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        //memulai spawn
        StartSpawn();
    }

    void StartSpawn()
    {
        //menjalankan Cooutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //menghentikan Coroutine IeSpawn jika sebelumnya sudah dijalankan
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //menduplikasi game objehct pipeUp dan menempatkan posisinya saa dengan game object ini tetapi dirotasi 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        //mengaktifkan game object newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //menduplikasi game object pipeDown dan menempatkan posisinya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //mengaktifkan game object newPipeDown
        newPipeDown.gameObject.SetActive(true);

        //random hole size
        holeSize = Random.Range(1.0f, 4f);

        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        //menempatkan posisi pipa yang telah dibentuk agar posisinya menyesuaikan fungsi Sin
        float y = maxMinOffset * Mathf.Sin(Time.time);

        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        //membuat object point trigger di tengah pipe
        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;

    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //jika Burung matu maka menghentikan pembuatan Pipa baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            //membuat pipa baru
            SpawnPipe();

            //menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
