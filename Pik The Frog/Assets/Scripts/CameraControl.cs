using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform frog;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = frog.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
