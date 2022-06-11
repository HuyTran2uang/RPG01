using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private bool _isMeleeAttackPressed;
    private float _timer;
    private float _cooldown = 1.0f;
    private float _timeCompleteAttack = 0.5f;
    private float _timeDelayDamage = 0.2f;

    [SerializeField] private float _areaDamage;
    [SerializeField] private LayerMask _enemiesLayer;

    //properties
    //
    public Animator Animator
    {
        get { return PlayerController.Instance.Animator; }
    }
    public Transform PointMeleeDamage
    {
        get { return PlayerController.Instance.PointMeleeDamage; }
    }
    //
    public bool IsMeleeAttacking { get; private set; }
    //-data
    public int Damage
    {
        get { return PlayerController.Instance.Player.Attack; }
    }

    private void Start()
    {
        _areaDamage = 0.67f;
        _enemiesLayer = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        InputManager();
        Attack();
        ChangeAnimation();
    }

    private void FixedUpdate()
    {
        if (_timer > 0) _timer -= Time.deltaTime;
        else _timer = 0;
    }

    private void InputManager()
    {
        _isMeleeAttackPressed = Input.GetKey(KeyCode.J);
    }

    private void Attack()
    {
        if (!_isMeleeAttackPressed) return;
        _isMeleeAttackPressed = false;
        if (!IsMeleeAttacking && _timer <= 0)
        {
            IsMeleeAttacking = true;
            _timer = _cooldown;
            StartCoroutine(CompletedAttack(_timeCompleteAttack));
            StartCoroutine(DelayDamage(_timeDelayDamage));
        }
    }

    private IEnumerator CompletedAttack(float time)
    {
        yield return new WaitForSeconds(time);
        IsMeleeAttacking = false;
    }

    private IEnumerator DelayDamage(float time)
    {
        yield return new WaitForSeconds(time);
        Collider2D[] hits = Physics2D.OverlapCircleAll(PointMeleeDamage.transform.position, _areaDamage, _enemiesLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.layer == 7)
            {
                hit.GetComponent<EnemyController>().EnemyHealth.TakeDamage(Damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PointMeleeDamage.transform.position, _areaDamage);
    }

    private void ChangeAnimation()
    {
        if (!IsMeleeAttacking) return;
        Animator.Play("Attack");
    }
}