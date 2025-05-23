using UnityEngine;

public class PlayerAC : MonoBehaviour
{
    Animator anim;
    bool isPushMode;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsRun", true);
        }
        else
            anim.SetBool("isRun", false);





    }

    public void StartPush()
    {
        anim.SetBool("IsPush", true);
    }






}
