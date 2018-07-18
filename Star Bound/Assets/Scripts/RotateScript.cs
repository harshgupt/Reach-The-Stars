using UnityEngine;

public class RotateScript : MonoBehaviour {

    public float speed = 50;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
    }
}
