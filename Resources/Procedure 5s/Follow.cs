using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the transform of the object to which this script is attached (i.e. spotlight) should be updated to that of the target
        transform.LookAt(target);
    }
}
