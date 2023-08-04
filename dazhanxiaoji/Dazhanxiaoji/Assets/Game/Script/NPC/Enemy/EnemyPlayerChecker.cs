﻿using System.Collections;
using UnityEngine;

public class EnemyPlayerChecker : MonoBehaviour
{
    EnemyBehaviour _enemy;
    public float playerCheckDistanceX;
    public float playerCheckDistanceY;
    public bool permanentAlert;
    bool _permanentAlertRes;

    private void Awake()
    {
        _permanentAlertRes = false;
        _enemy = GetComponent<EnemyBehaviour>();
    }

    public bool FoundPlayer()
    {
        if (permanentAlert && _permanentAlertRes)
            return true;

        return PlayerInSight();
    }

    public bool PlayerInSight()
    {
        var pos = PlayerBehaviour.instance.transform.position;
        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;
        if (Mathf.Abs(dy) > playerCheckDistanceY)
            return false;

        var res = true;
        if (_enemy.patrolBehaviour.facingRight)
            res = dx > 0 && dx <= playerCheckDistanceX;
        else
            res = dx < 0 && dx >= -playerCheckDistanceX;

        if (res)
            _permanentAlertRes = true;
        return res;
    }
}