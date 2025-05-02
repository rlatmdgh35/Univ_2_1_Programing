using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 2f;
    Transform target;

    void Start()
    {
        target = GameObject.Find("CloudEndPoint").transform;

        if (target == null)
        {
            Debug.LogError("target is null");
            return;
        }
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

}
