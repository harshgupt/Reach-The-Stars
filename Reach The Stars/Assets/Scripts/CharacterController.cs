using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject player;

    void Update ()
    {
		if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                touchedPos.y = -4f;
                if(touchedPos.x >= -2.8f && touchedPos.x <= 2.8f)
                {
                    transform.position = touchedPos;
                }
                else if(touchedPos.x < -2.8f)
                {
                    Vector3 leftLimit = new Vector3(-2.8f, -4f, 0);
                    transform.position = leftLimit;
                }
                else if(touchedPos.x > 2.8f)
                {
                    Vector3 rightLimit = new Vector3(2.8f, -4f, 0);
                    transform.position = rightLimit;
                }
            }
        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10));
            mousePos.y = -4f;
            transform.position = mousePos;
            if (mousePos.x >= -2.8f && mousePos.x <= 2.8f)
            {
                transform.position = mousePos;
            }
            else if (mousePos.x < -2.8f)
            {
                Vector3 leftLimit = new Vector3(-2.8f, -4f, 0);
                transform.position = leftLimit;
            }
            else if (mousePos.x > 2.8f)
            {
                Vector3 rightLimit = new Vector3(2.8f, -4f, 0);
                transform.position = rightLimit;
            }
        }
    }

    public void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Bouncing Star")
        {
            speed = 0;
            MainScript.isGameOver = true;
            //collision.gameObject.transform.parent = transform;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            collision.tag = "Untagged";
            
        }
    }
}
