
using UnityEngine;

public class CubeAnim : MonoBehaviour
{
    Animator anim;
    public enum State { BOUNCING, SCALING, IDLE};
    private State mState;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mState = State.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.Play("Bounce");
            mState = State.BOUNCING;
           //anim.SetTrigger("ChangetoBounce"); this is another way to trigger
        }
        if (Input.GetKeyDown(KeyCode.G))
            anim.SetTrigger("ChangetoScale");


    }
}
