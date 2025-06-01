using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    public GameObject activeObject;
    public bool startActive;
    public bool keepActive;
    bool prevActive;

    void Start()
    {
        prevActive = startActive;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground") == false && prevActive == startActive)
        {
            TriggerSwitch(!prevActive);

            if (keepActive)
                Destroy(GetComponent<CapsuleCollider>());
        }
    }

    void OnTriggerExit(Collider collision)
    {
        TriggerSwitch(prevActive);
    }

    void TriggerSwitch(bool value)
    {
        startActive = value;
        if (activeObject != null)
            activeObject.SetActive(value);
    }
}