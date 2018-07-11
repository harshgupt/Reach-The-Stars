using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour {

    public Transform apple;
    public Transform silverApple;
    public Transform goldenApple;
    public float appleSpawnTime;
    public float silverAppleSpawnTime;
    public float goldenAppleSpawnTime;
    public float timerApple;
    public float timerSilverApple;
    public float timerGoldenApple;

    private void Update()
    {
        //Change spawn times based on score
        appleSpawnTime = 2f / (1 + (int)(ScoreScript.score / 25f));
        silverAppleSpawnTime = 15f / (1 + (int)(ScoreScript.score / 50f));
        goldenAppleSpawnTime = 25f / (1 + (int)(ScoreScript.score / 100f));
        //Timers to spawn apples repeatedly
        timerApple += Time.deltaTime;
        timerSilverApple += Time.deltaTime;
        timerGoldenApple += Time.deltaTime;
        if (timerApple >= appleSpawnTime)
        {
            timerApple = 0;
            SpawnApple();
        }
        if (timerSilverApple >= silverAppleSpawnTime)
        {
            timerSilverApple = 0;
            SpawnSilverApple();
        }
        if (timerGoldenApple >= goldenAppleSpawnTime)
        {
            timerGoldenApple = 0;
            SpawnGoldenApple();
        }
    }

    void SpawnApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(apple, position, Quaternion.identity);
        }
    }

    void SpawnSilverApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(silverApple, position, Quaternion.identity);
        }
    }

    void SpawnGoldenApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(goldenApple, position, Quaternion.identity);
        }
    }
}
