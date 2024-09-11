using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float startSpawnTime = 5f;
    private bool start = false;
    [SerializeField] private float spawnTime = 10f;
    [SerializeField] private float spawnZone = 10f;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private Vague[] vagues;
    private int vagueNb = 0;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((!start && timer > startSpawnTime) || timer > spawnTime)
        {
            if (!start) start = true;
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        if (vagueNb < 10)
        {
            for (int i = 0; i < vagues[vagueNb].nbenemy1; i++)
            {
                StartCoroutine(spawnEnemy(enemy1));
            }
            for (int i = 0; i < vagues[vagueNb].nbenemy2; i++)
            {
                StartCoroutine(spawnEnemy(enemy2));
            }
            for (int i = 0; i < vagues[vagueNb].nbenemy3; i++)
            {
                StartCoroutine(spawnEnemy(enemy3));
            }
        }
        else 
        { 
            //Random
        }
        vagueNb++;
    }

    private IEnumerator spawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(Random.Range(0, 9));
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = transform.position + Vector3.up * Random.Range(-spawnZone, spawnZone);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 vector3 = transform.up * spawnZone;
        Gizmos.DrawLine(transform.position, transform.position + vector3);
        vector3 = -transform.up * spawnZone;
        Gizmos.DrawLine(transform.position, transform.position + vector3);
    }
}

[System.Serializable]
public class Vague
{
    public int nbenemy1;
    public int nbenemy2;
    public int nbenemy3;
}