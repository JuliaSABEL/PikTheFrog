using UnityEngine;


public interface IEnemyState
{
    void UpdateState();
    void OnCollision(Collider2D collider);
}
