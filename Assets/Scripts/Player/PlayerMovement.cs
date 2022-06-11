using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _inputX;
    private bool _isJumpPressed;
    //properties
    //-component
    private Rigidbody2D Rigidbody2D
    {
        get { return PlayerController.Instance.Rigidbody2D; }
    }
    private Animator Animator
    {
        get { return PlayerController.Instance.Animator; }
    }
    //-variables
    public bool IsGrounded
    {
        get { return PlayerController.Instance.GroundSensor.IsGrounded; }
    }
    //-data
    public float MoveSpeed
    {
        get { return PlayerController.Instance.Player.MoveSpeed; }
        private set { PlayerController.Instance.Player.MoveSpeed = value; }
    }
    public float JumpHeight
    {
        get { return PlayerController.Instance.Player.JumpHeight; }
        private set { PlayerController.Instance.Player.JumpHeight = value; }
    }

    private void Update()
    {
        InputManager();
        ChangeAnimation();
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Flip()
    {
        if (_inputX > 0) transform.localScale = Vector3.one;
        if (_inputX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void InputManager()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _isJumpPressed = Input.GetKey(KeyCode.K);
    }
    //Animation - start
    private void ChangeAnimation()
    {
        if (!ConditionChangeAnimation()) return;
        if (!IsGrounded) AnimationJumping();
        if (IsGrounded) AnimationMoving();
    }

    private bool ConditionChangeAnimation()
    {
        if (PlayerController.Instance.PlayerMeleeAttack.IsMeleeAttacking) return false;
        return true;
    }

    private void AnimationMoving()
    {
        if (_inputX == 0) Animator.Play("Idle");
        if (_inputX != 0) Animator.Play("Run");
    }
    private void AnimationJumping()
    {
        Animator.Play("Jump");
    }
    //Animation - end

    private void Move()
    {
        Rigidbody2D.velocity = new Vector2(_inputX * MoveSpeed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (!_isJumpPressed) return;
        _isJumpPressed = false;
        if (!IsGrounded) return;
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, JumpHeight);
    }
}
