using com;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public HpbarFixedWidthBehaviour hpbar;
    private PlayerMove _playerMove;
    public int hpMax;
    private int _hp;
    bool _dead;

    public string dieSound;
    public float deathFadeDelay;
    private Animator _animator;
    // Use this for initialization
    private void Start()
    {
        hpbar.Set(1, true);
        _playerMove = GetComponent<PlayerMove>();
        _animator = GetComponentInChildren<Animator>();
        _hp = hpMax;
    }

    private void Update()
    {
        DoRoutineMove();
    }

    public void TakeDamage(int dmg)
    {
        if (_dead) return;

        //Debug.Log(this.name + "TakeDamage " + dmg);
        _hp -= dmg;
        if (_hp < 0)
            _hp = 0;

        float ratio = (float)_hp / hpMax;
        hpbar.Set(ratio, false);
        if (_hp <= 0)
            Die();
    }

    void Die()
    {
        _dead = true;

        SoundSystem.instance.Play(dieSound);
        _animator.SetTrigger("die");

        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in srs)
        {
            sr.DOFade(0, 3).SetDelay(deathFadeDelay + Random.Range(1, 3f));
        }
    }

    void DoRoutineMove()
    {
        if (_dead) return;


    }

    public bool isDead
    {
        get { return _dead; }
    }
}