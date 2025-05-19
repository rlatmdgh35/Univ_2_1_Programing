using UnityEngine;

public class BuffUI : MonoBehaviour
{
    public float endTime = 10f;
    public string buffName;

    PlayerController playerController;
    float dt = 0f;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        dt += Time.deltaTime;
        if (dt >= endTime)
            EndBuff();
        
    }

    void GetBuff()
    {
        playerController.JumpingMode(true);
    }

    void EndBuff()
    {
        dt = 0f;
        playerController.JumpingMode(false);
        Destroy(gameObject);
    }
}
