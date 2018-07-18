using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundScript : MonoBehaviour {
    
    private void Update()
    {
        transform.Translate(Vector3.down * 0.01f, Space.World);
        if (gameObject.transform.position.y <= -11f)
        {
            Destroy(gameObject);
        }
    }
}
