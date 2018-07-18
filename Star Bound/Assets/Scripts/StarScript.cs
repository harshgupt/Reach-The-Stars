using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarScript : MonoBehaviour {

    public Sprite brightStar;
    public SpriteRenderer spriteRenderer;

    public AudioSource audioSource;
    public AudioClip collectStar1;

    public static bool decreaseSize;
    public static bool increaseStarCount;


    private void Start()
    {
        decreaseSize = false;
        increaseStarCount = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 250, ForceMode2D.Force);
        }
        else if(collision.gameObject.tag == "Wall Left")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * 100, ForceMode2D.Force);
        }
        else if(collision.gameObject.tag == "Wall Right")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100, ForceMode2D.Force);
        }
        else if(collision.gameObject.tag == "Bouncing Star")
        {
            Vector3 randVector = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            Debug.Log(randVector);
            GetComponent<Rigidbody2D>().AddForce(randVector * 200, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow Star")
        {
            audioSource.PlayOneShot(collectStar1);
            spriteRenderer = collision.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brightStar;
            ScoreScript.score += 1;
            if(ScoreScript.score == 20 || ScoreScript.score == 40 || ScoreScript.score == 60 || ScoreScript.score == 80)
            {
                decreaseSize = true;
            }
            if(ScoreScript.score == 30 || ScoreScript.score == 50 || ScoreScript.score == 70 || ScoreScript.score == 90)
            {
                increaseStarCount = true;
            }
            collision.gameObject.tag = "Bright Star";
        }
        else if(collision.gameObject.tag == "Wall Bottom")
        {
            MainScript.isGameOver = true;
        }
    }
}
