using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunction : MonoBehaviour
{
    public bool triggered = false;
    public void OnTriggerEnter(Collider other)
    {

        // Change the cube color to green.
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.green;
        Debug.Log(other.name);
        triggered = true;
    }
}
