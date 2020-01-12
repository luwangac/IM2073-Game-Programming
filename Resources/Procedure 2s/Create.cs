
using UnityEngine;
public class Create : MonoBehaviour
{
    public Transform newObject;
    public Transform refPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(newObject, refPos.position, refPos.rotation);
    }
}
