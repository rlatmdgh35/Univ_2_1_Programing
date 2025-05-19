using UnityEngine;

public class Potion : MonoBehaviour
{
    public PlayerController playerController;
    public ItemSlotUI itemSlotUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.JumpingMode(true);
            Destroy(gameObject);

            itemSlotUI.AddItem("Postion");
        }
    }

}
