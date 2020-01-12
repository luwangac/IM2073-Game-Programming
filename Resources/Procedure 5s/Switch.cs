using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform switchToTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //GetComponent<Follow>().target = switchToTarget;
            // OR
            //Transform newTarget = GameObject.Find("Cube1").transform;
            //GetComponent<Follow>().target = newTarget;
            //OR
            Transform newTarget = GameObject.FindWithTag("Cube").transform;
            GetComponent<Follow>().target = newTarget;


        }
        
    }
}
