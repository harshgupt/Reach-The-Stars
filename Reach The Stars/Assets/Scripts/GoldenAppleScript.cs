using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenAppleScript : MonoBehaviour {

    public float speed;
    
	void Start ()
    {
        speed = 0.05f + ((ScoreScript.score / 50f) * (0.01f));
    }
	
	void Update ()
    {
        transform.Translate(Vector3.down * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
