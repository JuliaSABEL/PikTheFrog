using UnityEngine;

public class FrogController : MonoBehaviour
{
    [SerializeField]
    private float frogSpeed = 3f;

    private float horizontalMove, verticalMove;

    private Rigidbody2D frogRigidBody;

    void Start()
    {
        frogRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (horizontalMove != 0 || verticalMove != 0)
        {
            Vector2 movement = new Vector2(horizontalMove * frogSpeed, verticalMove * frogSpeed);
            frogRigidBody.velocity = movement;
    }
        else
        {
            frogRigidBody.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        verticalMove = Input.GetAxis("Vertical");
    }
}
