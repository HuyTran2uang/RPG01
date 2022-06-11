using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    //Component of Unity in Player
    public Rigidbody2D Rigidbody2D { get; private set; }
    public Transform ModelPlayer { get; private set; }
    public Animator Animator { get; private set; }
    //script in Player
    public Player Player { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerMeleeAttack PlayerMeleeAttack { get; private set; }
    //Child script in Player
    public GroundSensor GroundSensor { get; private set; }
    public Transform PointMeleeDamage { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;

        Rigidbody2D = GetComponent<Rigidbody2D>();
        ModelPlayer = transform.Find("Model");
        Animator = ModelPlayer.GetComponent<Animator>();

        Player = GetComponent<Player>();
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerMeleeAttack = GetComponent<PlayerMeleeAttack>();

        PointMeleeDamage = transform.Find("PointMeleeDamage");
        GroundSensor = transform.Find("GroundSensor").GetComponent<GroundSensor>();
    }
}
