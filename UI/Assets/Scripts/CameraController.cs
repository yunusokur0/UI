using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 targetOffset;
    private float movementSpeed = 5f;
    void Start()
    {
        targetOffset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + targetOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed);
    }
}
