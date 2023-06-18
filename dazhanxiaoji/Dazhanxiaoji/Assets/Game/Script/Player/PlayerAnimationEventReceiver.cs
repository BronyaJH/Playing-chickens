using System.Collections;
using UnityEngine;

public class PlayerAnimationEventReceiver : MonoBehaviour
{
    public ParticleSystem attackPs;
    private PlayerMove playerMove;
    private PlayerAttackBehaviour playerAttack;
    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttackBehaviour>();
    }

    public void OnAttacked()
    {
        Debug.Log("OnAttacked");
        attackPs.Play();
        playerAttack.OnAttacked();
    }
}