using System.Collections;
using UnityEngine;

public class EnemyPatrolBehaviour : MonoBehaviour
{
    //巡逻
    //设计原则
    //敌人在游戏中会进行左右巡逻

    //巡逻共有4个状态，【GoRight GoLeft StopFacingLeft StopFacingRight】
    //巡逻的模式固定为：【向右走，脸朝右停下，向左走，脸朝左停下】
    //设置左右两个【patrol point】，和左右两个【safe point】

    //当敌人没有发现玩家时走到左右两个patrol point就意味着会进入停下状态，并在接下来转身
    //当敌人发现玩家后，敌人不会在patrol point停下，而是会继续追击
    //【敌人发现玩家的条件是：玩家对敌人造成伤害，或者玩家在敌人的前方不远处】
    //当敌人走到safe point一定会进入停下状态，并在接下来转身，不管有没有发现玩家。这是防止敌人去到不合理的区域
    //敌人会使用普通攻击或者技能攻击在攻击范围附近的玩家，这些行为会让敌人的移动暂时停下，但是不影响巡逻的逻辑

    //example
    //case 1: 无玩家干扰
    //敌人会在左右两个patrol point之间来回巡逻
    //case 2: 玩家在背后攻击敌人
    //敌人会立刻停下，并在过一小段时间后转身
    //case 3: 玩家在敌人面前逃跑
    //敌人会一直追击，直到到达一端的safe point
    //case 4: 玩家跳到敌人后面
    //敌人如果已经超过了patrol point，会停下，否则继续巡逻到下一个patrol point

    EnemyBehaviour enemyBehaviour;

    public Transform patrolPoint_Left;
    public Transform patrolPoint_Right;
    public Transform safePoint_Left;
    public Transform safePoint_Right;
    public float stopDuration = 0.5f;
    public float playerCheckDistanceX;
    public float playerCheckDistanceY;
    public enum PatrolState
    {
        GoRight,
        GoLeft,
        StopFacingLeft,
        StopFacingRight,
    }
    public PatrolState state = PatrolState.GoRight;

    private void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBehaviour.IsDead)
            return;
        if (enemyBehaviour.skillBehaviour.IsCasting)
            return;

        GoPatrol();
    }

    void GoPatrol()
    {

    }

    bool IsAlerted { get { return false; } }

    bool CheckBeyondPoint(bool useSafePoint)
    {
        switch (state)
        {
            case PatrolState.GoRight:
                if (IsAlerted)
                {
                    return true;
                }
                else
                {
                    return true;
                }

            case PatrolState.GoLeft:
                if (IsAlerted)
                {
                    return true;
                }
                else
                {
                    return true;
                }

            case PatrolState.StopFacingLeft:
                Debug.LogWarning("should not execute here");
                break;

            case PatrolState.StopFacingRight:
                Debug.LogWarning("should not execute here");
                break;
        }

        return false;
    }

    bool IsFacingRight
    {
        get
        {
            var flipTrans = enemyBehaviour.npcController.flipTransfrom;
            return flipTrans.localScale.x > 0;
        }
    }
}