using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;

    void Start()
    {
        GameObject[] objs = FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].CompareTag("CloudEndTarget"))
                target = objs[i].transform;
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
