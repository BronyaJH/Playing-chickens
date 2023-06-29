using System.Collections;
using UnityEngine;

public class PlayerAnimationEventReceiver : MonoBehaviour
{
    public ParticleSystem attackPs;
    public PlayerMove playerMove;
    public PlayerAttackBehaviour playerAttack;
    private void Awake()
    {

    }

    public void OnAttacked()
    {
        Debug.Log("OnAttacked");
        attackPs.Play();
        playerAttack.OnAttacked();
    }
}