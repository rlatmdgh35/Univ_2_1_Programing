using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    public float endTime = 15f;
    public string buffName;

    PlayerController playerController;
    ItemSlotUI itemSlot;
    Image image;
    bool startBuff = false;
    float dt = 0f;

    public void Initialize(ItemSlotUI itemSlot)
    {
        this.itemSlot = itemSlot;
    }

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (startBuff)
        {
            dt += Time.deltaTime;
            float ratio = 1f - (dt / 15f);
            ratio = Mathf.Clamp(ratio, 0f, 1f);
            image.fillAmount = ratio;

            if (dt >= endTime)
                EndBuff();
        }
    }

    public bool IsBuffOn()
    {
        return startBuff;
    }

    public void StartBuff()
    {
        startBuff = true;

        if (buffName == "JumpPotion")
            playerController.JumpingMode(true);
        else if (buffName == "StrongPotion")
            playerController.StrongMode(true);
    }

    void EndBuff()
    {
        if (buffName == "JumpPotion")
            playerController.JumpingMode(false);
        else if (buffName == "StrongPotion")
            playerController.StrongMode(false);
        itemSlot.RemoveItem(gameObject);
        Destroy(gameObject);
    }
}
