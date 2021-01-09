using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float speed = 5.0f;
    public float colorVal;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);
    }
    void onMouseOver()
    {
        colorVal -= (float) 0.1 * Time.deltaTime;
        Renderer rend = GameObject.FindGameObjectWithTag("Cube").GetComponent<Renderer>();
        rend.material.SetColor("_Color", new Color(colorVal, 0,0));
    }
}
