using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyBase _base;

    [SerializeField] private string _name;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;

    public EnemyBase Base
    {
        get { return _base; }
        set { _base = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    private void OnEnable()
    {
        LoadInformation();
    }

    private void Reset()
    {
        LoadInformation();
    }

    private void LoadInformation()
    {
        Base = Resources.Load<EnemyBase>($"Base/{this.gameObject.name}");

        Name = _base.Name;
        MoveSpeed = _base.MoveSpeed;
        Health = _base.Health;
        Attack = _base.Attack;
    }
}
