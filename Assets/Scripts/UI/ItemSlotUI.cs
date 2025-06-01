using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemSlotUI : MonoBehaviour
{
    public GameObject[] buffUIs;
    public GameObject[] curtItems;
    int slotIndex;

    void Start()
    {
        curtItems = new GameObject[transform.childCount];
    }

    void Update()
    {
        int num = -1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            num = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            num = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            num = 2;

        if (num != -1)
        {
            GameObject curtItem = curtItems[num];
            if (curtItem != null)
            {
                BuffUI buff = curtItem.GetComponent<BuffUI>();
                if (buff.IsBuffOn() == false)
                    buff.StartBuff();
            }
        }
    }

    public void AddItem(string itemName)
    {
        if (slotIndex < transform.childCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (curtItems[i] == null)
                {
                    foreach(GameObject buffUI in buffUIs)
                    {
                        if (buffUI.GetComponent<BuffUI>().buffName == itemName)
                        {
                            GameObject inst = Instantiate(buffUI, transform.GetChild(i));
                            inst.GetComponent<BuffUI>().Initialize(this);
                            curtItems[i] = inst;
                        }
                    }

                    slotIndex++;
                    break;
                }
            }
        }
        else
            Debug.Log($"버프 가능 개수가 최대이므로 {itemName} 버프를 얻지 못했습니다.");
    }

    public void RemoveItem(GameObject item)
    { 
        for(int i = 0; i < curtItems.Length; i++)
        {
            if (curtItems[i] == item)
            {
                curtItems[i] = null;
                break;
            }
        }
    }
}
