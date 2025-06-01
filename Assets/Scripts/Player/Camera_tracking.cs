using UnityEngine;

public class Camera_tracking : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 10, -20);

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}