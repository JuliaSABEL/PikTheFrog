using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D))]
public class DynamicPolygonCollider : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider;
    private SpriteRenderer _spriteRenderer;
    private Sprite _lastSprite;


    private void Awake()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        if (_spriteRenderer.sprite != _lastSprite)
        {
            _lastSprite = _spriteRenderer.sprite;
            UpdateColliderShape();
        }
    }


    private void UpdateColliderShape()
    {
        Sprite currentSprite = _spriteRenderer.sprite;

        _polygonCollider.pathCount = currentSprite.GetPhysicsShapeCount();

        for (int i = 0; i < _polygonCollider.pathCount; i++)
        {
            var path = new List<Vector2>();
            currentSprite.GetPhysicsShape(i, path);
            _polygonCollider.SetPath(i, path.ToArray());
        }
    }
}
