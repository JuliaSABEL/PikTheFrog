using UnityEngine;


public class CameraController : MonoBehaviour, ICameraObserver
{
    [SerializeField] private CameraConfig config;

    private Vector3 _targetPosition;
    

    private void LateUpdate()
    {
        if (_targetPosition != Vector3.zero)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, config.smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
    
    
    public void UpdatePosition(Vector3 position) => _targetPosition = position + config.offset;
}
