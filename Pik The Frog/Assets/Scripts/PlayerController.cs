using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float frogSpeed = 3f;

    public int toadHeart = 3;

    public bool isInvulnerabilityState;

    private float horizontalMove, verticalMove;

    public Rigidbody2D frogRigidBody;

    void Start()
    {
        frogRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void FrogControll()
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

    public void PlayerInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        FrogControll();
        PlayerInput();
    }
}
