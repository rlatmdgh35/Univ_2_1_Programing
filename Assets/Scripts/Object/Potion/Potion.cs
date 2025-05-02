using UnityEngine;

public class Potion : MonoBehaviour
{
    public PlayerController playerController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.JumpingMode(true);
            Destroy(gameObject);
        }
    }

}
