using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

    public Transform starShadow;
    public Transform background;

    public float starSpawnTime;
    public float backgroundSpawnTime;
    public float starSpawnTimer;
    public float backgroundSpawnTimer;

    public static bool spawnStars;

    private void Start()
    {
        starSpawnTime = 2f;
        backgroundSpawnTime = 18f;
    }

    private void Update()
    {
        starSpawnTimer += Time.deltaTime;
        if(starSpawnTimer >= starSpawnTime)
        {
            starSpawnTimer = 0;
            if (spawnStars)
            {
                SpawnStar();
            }
            starSpawnTime = Random.Range(2f, 5f);
        }
        backgroundSpawnTimer += Time.deltaTime;
        if(backgroundSpawnTimer >= backgroundSpawnTime)
        {
            backgroundSpawnTimer = 0;
            SpawnBackground();
        }
    }

    public void SpawnStar()
    {
        float randX = Random.Range(-2.5f, 2.5f);
        Vector3 position = new Vector3(randX, 5f);
        Instantiate(starShadow, position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
    }

    public void SpawnBackground()
    {
        Vector3 position = new Vector3(0, 12f);
        Instantiate(background, position, Quaternion.identity);
    }
}
