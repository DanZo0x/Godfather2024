using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin = 10f;
    [SerializeField] private float spawnTimeMax = 20f;
    [SerializeField] private GameObject obstacle;
    private float spawnTime;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timer = 0;
        }
    }
}
