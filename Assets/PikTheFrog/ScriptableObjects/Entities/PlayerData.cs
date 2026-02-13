using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerData", menuName = "SO/Entities/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int _lives;
    [SerializeField] private float _maxSpeed;
    
    public int lives => _lives;
    public float maxSpeed => _maxSpeed;
}
