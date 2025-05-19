using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    PlayerController playerController;
    public GameObject[] buffUI;
    public int slotIndex = 0;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    public void AddItem(string itemName)
    {
        if (slotIndex < transform.childCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                BuffUI buff = buffUI[i].GetComponent<BuffUI>();
                if (buff.buffName == itemName)
                {
                    Instantiate(buff, transform.GetChild(i));
                    
                }
                slotIndex++;
            }
        }
        else
            Debug.Log($"버프 가능 개수가 최대이므로 {itemName} 버프를 얻지 못했습니다.");
    }
}
