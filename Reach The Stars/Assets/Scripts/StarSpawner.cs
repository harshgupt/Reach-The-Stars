using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

    public Transform starShadow;

    public float starSpawnTime;
    public float spawnTimer;

    private void Start()
    {
        starSpawnTime = 2f;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= starSpawnTime)
        {
            spawnTimer = 0;
            SpawnStar();
            starSpawnTime = Random.Range(2f, 5f);
        }
    }

    public void SpawnStar()
    {
        float randX = Random.Range(-2.5f, 2.5f);
        Vector3 position = new Vector3(randX, 5f);
        Instantiate(starShadow, position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
    }
}
