using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    private void Start()
    { 
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
    }
}
