using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {

    public static float speedLimit;
    public float speed;
    public static bool playAudio = false;
    
	void Start ()
    {
        speedLimit = 0.02f + ((ScoreScript.score / 25) * (0.02f));
        speed = Random.Range(0.02f, speedLimit);
    }
	
	void Update ()
    {
        if (!MainScript.isGameOver)
        {
            transform.Translate(Vector3.down * speed);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playAudio = true;
            Destroy(gameObject);
            ScoreScript.score += 1;
        }
        else if (collision.gameObject.tag == "Player")
        {
            speed = 0;
        }
    }
}
