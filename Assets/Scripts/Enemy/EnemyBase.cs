using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseEnemy", menuName = "Enemy/Create new enemy")]
public class EnemyBase : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;

    public string Name
    {
        get { return _name; }
    }
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
    public int Health
    {
        get { return _health; }
    }
    public int Attack
    {
        get { return _attack; }
    }
}
