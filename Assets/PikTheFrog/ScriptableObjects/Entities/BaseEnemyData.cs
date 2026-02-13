using UnityEngine;


[CreateAssetMenu(fileName = "NewBaseEnemyData", menuName = "SO/Entities/BaseEnemyData")]
public class BaseEnemyData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    
    public int damage => _damage;
    public float speed => _speed;
}
