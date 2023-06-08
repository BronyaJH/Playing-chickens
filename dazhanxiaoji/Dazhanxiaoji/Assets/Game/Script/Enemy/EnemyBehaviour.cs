using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem attackPs;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestAttack();
        }

    }

    void TestAttack()
    {
        animator.SetTrigger("attack");
    }

    public void PerformAttack()
    {
        Debug.Log("attack");
        attackPs.Play();
    }
}
