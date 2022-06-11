using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private float _cooldown;
    public bool IsMeleeAttacking { get; private set; }

    public int Damage
    {
        get { return EnemyController.Instance.Enemy.Attack; }
    }
    public Transform TransformPlayer
    {
        get { return PlayerController.Instance.transform; }
    }

    private void OnEnable()
    {
        _cooldown = 2f;
    }

    private void Update()
    {
        if (TransformPlayer.position.magnitude - EnemyController.Instance.transform.position.magnitude <= 3)
        {
            if (!IsMeleeAttacking)
            {
                IsMeleeAttacking = true;
                PlayerController.Instance.PlayerHealth.TakeDamage(Damage);
                StartCoroutine(CompleteAttack(_cooldown));
            }
        }
    }

    private IEnumerator CompleteAttack(float time)
    {
        yield return new WaitForSeconds(time);
        IsMeleeAttacking = false;
    }
}
