using System.Collections;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [Range(0.8f, 3f)]
    public float attackInterval;

    private float nextCanAttackTimestamp;

    private Animator _animator;
    private PlayerJump _jump;

    public Transform damageOrigin;
    public float damageRadius = 1.5f;
    public int damage = 10;

    private void Awake()
    {
        nextCanAttackTimestamp = 0;
        _animator = GetComponentInChildren<Animator>();
        _jump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TryAttack();
        }
    }

    public bool isAttacking { get { return Time.time < nextCanAttackTimestamp; } }

    void TryAttack()
    {
        if (isAttacking)
            return;

        PerformAttack();
    }

    void PerformAttack()
    {
        _animator.SetTrigger("attack");
        nextCanAttackTimestamp = Time.time + attackInterval;
    }

    public void OnAttacked()
    {
        Debug.Log("OnAttacked");
        //test enemy distance
        var targets = Physics2D.OverlapCircleAll(damageOrigin.position, damageRadius);
        foreach (var t in targets)
        {
            var ene = t.GetComponent<EnemyBehaviour>();
            if (ene != null)
                ene.TakeDamage(damage);
        }
    }
}