using com;
using DG.Tweening;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public HpbarFixedWidthBehaviour hpbar;
    public int hpMax;
    private int _hp;
    bool _dead;

    public string dieSound;
    public float deathFadeDelay;
    public HeadKickSlay headKickSlay;

    [HideInInspector]
    public NpcController npcController;
    [HideInInspector]
    public EnemyPatrolBehaviour patrolBehaviour;
    [HideInInspector]
    public EnemySkillBehaviour skillBehaviour;


    private void Awake()
    {
        npcController = GetComponent<NpcController>();
        patrolBehaviour = GetComponent<EnemyPatrolBehaviour>();
        skillBehaviour = GetComponent<EnemySkillBehaviour>();
    }

    private void Start()
    {
        _hp = hpMax;
        if (hpbar != null)
            hpbar.Set(1, true);
    }

    private void Update()
    {
        DoRoutineMove();
    }

    public void TakeFatalDamage()
    {
        TakeDamage(hpMax + 1);
    }

    public void TakeDamage(int dmg)
    {
        if (_dead) return;

        Debug.Log(this.name + "TakeDamage " + dmg);

        _hp -= dmg;
        if (_hp < 0)
            _hp = 0;
        float ratio = (float)_hp / hpMax;
        if (hpbar != null)
            hpbar.Set(ratio, false);
        if (_hp <= 0)
            Die();
    }

    void Die()
    {
        _dead = true;
        if (hpbar != null)
            hpbar.Hide();
        SoundSystem.instance.Play(dieSound);
        npcController.SetAnimTrigger("die");

        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in srs)
            sr.DOFade(0, 2).SetDelay(deathFadeDelay + Random.Range(1, 3f));

        Destroy(gameObject, deathFadeDelay + 5);
    }

    void DoRoutineMove()
    {
        if (_dead) return;


    }

    public bool IsDead { get { return _dead; } }
}