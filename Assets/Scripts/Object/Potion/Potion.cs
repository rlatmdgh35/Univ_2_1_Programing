using UnityEngine;

public class Potion : MonoBehaviour
{
    public ItemSlotUI itemSlotUI;
    public string buffType;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemSlotUI.AddItem(buffType);

            Destroy(gameObject);
        }
    }

}
