using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("get from data")]
    public float MoveSpeed = 5.0f;
    public float JumpHeight = 5.0f;
    public int Health = 100;
    public int CurrentHealth = 100;
    public int Attack = 10;
    //Default
    private float _moveSpeedDefault = 5.0f;
    private float _jumpHeightDefault = 5.0f;
    public int _healthDefault = 100;
    public int _attackDefault = 10;

    public void ResetGame()
    {
        MoveSpeed = _moveSpeedDefault;
        JumpHeight = _jumpHeightDefault;
        Health = _healthDefault;
        Attack = _attackDefault;
    }
}
