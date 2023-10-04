using com;
using UnityEngine;

public class GameFlowSystem : MonoBehaviour
{
    public static GameFlowSystem instance;
    [HideInInspector]
    public TestCharacterAnimation character;

    public CanvasGroup girlHpBarCg;
    public CanvasGroup bossHpBarCg;

    public GameProcess gameProcess;


    private void Awake()
    {
        instance = this;
    }

    protected void TogglePlayerControl(bool b)
    {
        character.girl.GetComponent<PlayerJump>().enabled = b;
        character.girl.GetComponent<PlayerMove>().enabled = b;
        character.girl.GetComponent<PlayerAttackBehaviour>().enabled = b;
        character.girl.GetComponent<NpcController>().enabled = !b;
    }
}