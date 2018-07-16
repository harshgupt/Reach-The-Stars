using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowStarScript : MonoBehaviour {
    

    private void Update()
    {
        transform.Translate(Vector3.down * 0.02f, Space.World);
        if(gameObject.transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
