using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        // just transform (small letter t) refers to the transform of the object to which this script is attached. We have attached this script to Main Camera,
        // so transform is the Transform of the Main Camera
        transform.Translate(x, 0, z);
    }
}
