using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    public float colorVal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onMouseOver()
    {
        Debug.Log("I can see the mouse!");
        colorVal -= (float)0.1 * Time.deltaTime;
        Renderer rend = GetComponent<Renderer>();
        Debug.Log("I will now change the color");
        rend.material.SetColor("_Color", new Color(colorVal, 0, 0));
    }
}
