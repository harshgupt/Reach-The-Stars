using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject player;

    public static float speed = 100f;

    void Update ()
    {
        gameObject.transform.localScale = new Vector3(2, 2);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                touchedPos.y = -4f;
                if (touchedPos.x >= -2.8f && touchedPos.x <= 2.8f)
                {
                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * speed);
                    //transform.position = touchedPos;
                }
                else if (touchedPos.x < -2.8f)
                {
                    Vector3 leftLimit = new Vector3(-2.8f, -4f, 0);
                    transform.position = Vector3.Lerp(transform.position, leftLimit, Time.deltaTime * speed);
                    //transform.position = leftLimit;
                }
                else if (touchedPos.x > 2.8f)
                {
                    Vector3 rightLimit = new Vector3(2.8f, -4f, 0);
                    transform.position = Vector3.Lerp(transform.position, rightLimit, Time.deltaTime * speed);
                    //transform.position = rightLimit;
                }
            }
        }
        else
        {
            if(speed != 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10));
                mousePos.y = -4f;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bright Star")
        {
            Destroy(collision.gameObject);
            ScoreScript.score += 1;
        }
    }
}
