using UnityEngine;

public class Water : MonoBehaviour
{
    LastGamemode gamemode;

    void Start()
    {
        gamemode = FindAnyObjectByType<LastGamemode>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            gamemode.GameOver();
        else if (other.gameObject.CompareTag("Box"))
            gamemode.AddPoint(20);
    }

}
