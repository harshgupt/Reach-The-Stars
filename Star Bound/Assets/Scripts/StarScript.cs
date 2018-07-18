using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarScript : MonoBehaviour {

    public Sprite brightStar;
    public SpriteRenderer spriteRenderer;

    public Animator bubbleAnimator;

    public AudioSource audioSource;
    public AudioClip collectStar1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bubbleAnimator.SetTrigger("bubbleHit");
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow Star")
        {
            audioSource.PlayOneShot(collectStar1);
            spriteRenderer = collision.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brightStar;
            ScoreScript.score += 1;
            collision.gameObject.tag = "Bright Star";
        }
        else if(collision.gameObject.tag == "Wall Bottom")
        {
            MainScript.isGameOver = true;
        }
    }
}
