using System.Collections;
using UnityEngine;

public class EnemySkillBehaviour : MonoBehaviour
{

    public EnemySkill[] skills;

    EnemyBehaviour enemyBehaviour;

    private void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    public bool IsCasting
    {
        get
        {
            return false;
        }
    }

    void Update()
    {
        if (enemyBehaviour.IsDead)
            return;


    }
}