using System.Collections;
using UnityEngine;

public class EnemyPlayerChecker : MonoBehaviour
{
    EnemyBehaviour _enemy;
    public float playerCheckDistanceX;
    public float playerCheckDistanceY;


    private void Awake()
    {
        _enemy = GetComponent<EnemyBehaviour>();
    }

    public bool PlayerInSight()
    {
        var pos = PlayerBehaviour.instance.transform.position;
        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;
        if (Mathf.Abs(dy) > playerCheckDistanceY)
            return false;

        if (_enemy.patrolBehaviour.facingRight)
            return dx > 0 && dx <= playerCheckDistanceX;
        else
            return dx < 0 && dx >= -playerCheckDistanceX;
        return true;
    }
}