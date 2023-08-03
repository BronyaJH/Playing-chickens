using DG.Tweening;
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
        _enemy.animator.SetBool("walk", false);

        switch (skl.id)
        {
            case "sky fire":
                _enemy.animator.SetTrigger("sky fire");
                break;

            case "spike":
                _enemy.animator.SetTrigger("spike");
                var spikePos = skl.launchEffect.transform.position;
                spikePos.x = PlayerBehaviour.instance.transform.position.x;
                var spike = Instantiate(skl.prefab, spikePos, Quaternion.identity);
                var spikeImg = spike.GetComponentInChildren<SpriteRenderer>();

                spikeImg.color = new Color(0.4f, 0.27f, 0.7f, 0);
                spikeImg.DOColor(new Color(0.4f, 0.27f, 0.7f, 1), 0.5f).OnComplete(
                    () => { spikeImg.DOColor(new Color(0, 0, 0, 0), 0.4f).SetDelay(0.3f); });

                spike.transform.position = spikePos + new Vector3(0, -2.8f, 0);
                spike.transform.DOMoveY(spikePos.y + 0.7f, 0.75f).SetEase(Ease.OutBounce).SetDelay(0.45f);
                Destroy(spike.gameObject, 2.5f);
                //deal damage
                skl.launchEffect.transform.position = spikePos;
                break;

            case "melee":
                _enemy.animator.SetTrigger("melee");
                break;
        }

        if (skl.launchEffect != null)
            skl.launchEffect.Play();
    }


    void TickSkills()
    {
        if (crtSkill != null && _durationTimer > 0)
            _durationTimer -= Time.deltaTime;

        if (_durationTimer <= 0)
        {
            crtSkill = null;
            _durationTimer = 0;
        }

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