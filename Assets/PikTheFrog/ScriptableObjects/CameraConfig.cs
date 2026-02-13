using UnityEngine;


[CreateAssetMenu(fileName = "NewCameraConfig", menuName = "SO/CameraConfig")]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed;
    
    public Vector3 offset => _offset;
    public float smoothSpeed => _smoothSpeed;
}
