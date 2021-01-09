using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform newTarget;
    //public Transform newObject;
    //public Transform refPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            newTarget = GameObject.Find("Cube1").transform;
            //newTarget = GameObject.FindWithTag("Cube").transform;
            GetComponent<Follow>().target = newTarget;
        }

    }
}
