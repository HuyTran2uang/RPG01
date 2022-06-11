using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance { get; private set; }

    public Enemy Enemy { get; private set; }
    public EnemyHealth EnemyHealth { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        LoadComponent();
    }

    private void LoadComponent()
    {
        Enemy = GetComponent<Enemy>();
        EnemyHealth = GetComponent<EnemyHealth>();
    }
}
