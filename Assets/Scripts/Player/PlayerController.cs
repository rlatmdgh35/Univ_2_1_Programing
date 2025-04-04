using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem ptc_move;
    public int hp;
    public int speed;
    public int jumpValue;
    int power;
    int damage;

    Vector3 direction;
    Vector3 ptc_loc;

    void Update()
    {
        // Move();
        Move2(); // Update 함수에서 프레임마다 실행시킵니다.
    }

    void LateUpdate()
    {
        ptc_loc = transform.position + new Vector3(0f, -0.5f, -0.5f);
        ptc_move.gameObject.transform.position = ptc_loc;
        ptc_move.transform.rotation = Quaternion.LookRotation(-transform.forward);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);   
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void Move2()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            if (!ptc_move.isPlaying)
            {
                ptc_move.Play();
                
            }

            float z = Input.GetAxisRaw("Vertical");
            float x = Input.GetAxisRaw("Horizontal");
            direction = z * Vector3.forward + x * Vector3.right;

            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
    }
}