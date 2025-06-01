using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointValue;
    public bool isTrigger;
    LastGamemode gamemode;
    float dt = 0f;
    float previewY;

    void Start()
    {
        gamemode = FindAnyObjectByType<LastGamemode>();
        previewY = gameObject.transform.localPosition.y;
    }

    void Update()
    {
        if (isTrigger)
        {
            dt += Time.deltaTime;

            float y = Mathf.Sin(dt * 2);
            gameObject.transform.localPosition = new Vector3(0f, previewY + y, 0f);

            Vector3 rot = new Vector3(90f, 90f * dt, 90f);
            gameObject.transform.rotation = Quaternion.Euler(rot);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isTrigger == false)
        {
            gamemode.AddPoint(pointValue);
            Destroy(gameObject);
        }
    }
}
