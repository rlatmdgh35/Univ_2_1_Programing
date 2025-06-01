using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem ptc_move;
    public int hp;
    public int speed;
    public int jumpValue;
    bool isJumping;
    bool isStand;
    float pushValue;
    int groundOverlapCount = 0;
    int boxOverlapCount = 0;

    Animator animator;
    Rigidbody rigid;
    Vector3 direction;
    Vector3 ptc_loc;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Gamemode.sgtn.IsStart() && Gamemode.sgtn.IsEndGame() == false)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && isJumping && isStand)
            {
                isStand = false;
                animator.SetBool("IsJump", true);
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            }
        }
        else // Game Not Start or Game End
        {
            ptc_move.Stop();
            animator.SetBool("IsRun", false);
        }

        pushValue = Mathf.Clamp(pushValue, 0f, 1f);
        animator.SetFloat("PushValue", pushValue);
    }

    void LateUpdate()
    {
        ptc_loc = transform.position + new Vector3(0f, -0.5f, -0.5f);
        ptc_move.gameObject.transform.position = ptc_loc;
        ptc_move.transform.rotation = Quaternion.LookRotation(-transform.forward);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (groundOverlapCount == 0)
            {

                isStand = true;
                animator.SetBool("IsJump", false);
            }
            groundOverlapCount++;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            if (boxOverlapCount == 0)
                animator.SetBool("IsPush", true);
            boxOverlapCount++;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundOverlapCount--;

            if (groundOverlapCount <= 0)
                isStand = false;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            boxOverlapCount--;

            if (boxOverlapCount <= 0)
                animator.SetBool("IsPush", false);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            direction = new Vector3(x, 0f, z).normalized;

            if (direction != Vector3.zero)
            {
                if (!ptc_move.isPlaying)
                    ptc_move.Play();

                Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
                rigid.MoveRotation(rot);

                Vector3 loc = rigid.position + direction * speed * Time.deltaTime;
                rigid.MovePosition(loc);

                if (isStand)
                {
                    animator.SetBool("IsRun", true);
                    pushValue += Time.deltaTime * 10f;
                }
                else
                {
                    animator.SetBool("IsRun", false);
                    pushValue -= Time.deltaTime * 10f;
                }
            }
        }
        else
        {
            animator.SetBool("IsRun", false);
            pushValue -= Time.deltaTime * 2f;
        }
    }

    public void StrongMode(bool type)
    {
        if (type)
            rigid.mass = 10f;
        else
            rigid.mass = 1f;
    }

    public void JumpingMode(bool type)
    {
        isJumping = type;
    }

    public void GameOver()
    {
        Destroy(rigid);
        animator.SetBool("IsDead", true);
    }

    public void GameClear()
    {
        Destroy(rigid);
    }
}