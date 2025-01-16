using UnityEngine;


public class CameraController : MonoBehaviour, IObserver
{
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private float smoothSpeed = 0.125f;

    private Vector3 _targetPosition;


    public void UpdatePosition(Vector3 position)
    {
        _targetPosition = position + offset;
    }


    private void Start()
    {
        var player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.AddObserver(this);
        }
    }

    private void LateUpdate()
    {
        if (_targetPosition != Vector3.zero)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
