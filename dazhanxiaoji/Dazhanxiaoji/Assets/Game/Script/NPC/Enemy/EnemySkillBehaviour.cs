using System.Collections;
using UnityEngine;

public class EnemySkillBehaviour : MonoBehaviour
{
    public EnemySkill[] skills;

    EnemySkill crtSkill;

    EnemyBehaviour _enemy;

    float _durationTimer;
    //float _sklDamageTimer;

    private void Awake()
    {
        _enemy = GetComponent<EnemyBehaviour>();
    }

    public bool isCasting
    {
        get
        {
            return crtSkill != null;
        }
    }

    void Update()
    {
        if (_enemy.IsDead)
            return;

        TickSkills();

        if (!_enemy.playerChecker.PlayerInSight())
            return;

        foreach (var skl in skills)
        {
            var canUse = CanUseSkill(skl);
            if (canUse)
            {
                UseSkill(skl);
                break;
            }
        }
    }

    void UseSkill(EnemySkill skl)
    {
        Debug.Log("UseSkill " + skl.id);
        crtSkill = skl;
        skl.cdTimer = skl.cd;
        _durationTimer = skl.duration;
        switch (skl.id)
        {
            case "sky fire":
                _enemy.animator.SetTrigger("sky fire");
                break;

            case "spike":
                _enemy.animator.SetTrigger("spike");
                break;

            case "melee":
                _enemy.animator.SetTrigger("melee");
                break;
        }
    }


    void TickSkills()
    {
        if (crtSkill != null && _durationTimer > 0)
            _durationTimer -= Time.deltaTime;
        if (_durationTimer <= 0)
            _durationTimer = 0;

        foreach (var skl in skills)
        {
            if (skl.cdTimer > 0)
                skl.cdTimer -= Time.deltaTime;
        }
    }

    bool CanUseSkill(EnemySkill skl)
    {
        if (crtSkill != null && _durationTimer > 0)
            return false;

        if (skl.cdTimer > 0)
            return false;

        var playerPos = PlayerBehaviour.instance.transform.position;
        var dx = Mathf.Abs(playerPos.x - transform.position.x);
        if (dx < skl.minDist || dx > skl.maxDist)
            return false;

        return true;
    }
}