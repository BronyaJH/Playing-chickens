using System.Collections;
using UnityEngine;

public class GameFlowSystem : MonoBehaviour
{
    public static GameFlowSystem instance;
    // Use this for initialization
    public TestCharacterAnimation character;

    public Transform 上香位置1;
    public Transform 上香位置2;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        TogglePlayerControl(false);
        StartCoroutine(PlayCinematic_上香());
    }

    void TogglePlayerControl(bool b)
    {
        character.girl.GetComponent<PlayerJump>().enabled = b;
        character.girl.GetComponent<PlayerMove>().enabled = b;
        //character.girl.GetComponent<PlayerAttackBehaviour>().enabled = b;
        character.girlFight.GetComponent<PlayerJump>().enabled = b;
        character.girlFight.GetComponent<PlayerMove>().enabled = b;
        character.girlFight.GetComponent<PlayerAttackBehaviour>().enabled = b;
    }
    IEnumerator PlayCinematic_上香()
    {
        yield return null;
        //character.boy.
     }

    IEnumerator PlayCinematic_Boss抢男人()
    {
        yield return null;
    }

    IEnumerator PlayCinematic_发誓找男人()
    {
        yield return null;
    }

    IEnumerator PlayCinematic_小怪叫嚣()
    {
        yield return null;
    }

    IEnumerator PlayCinematic_打输的Boss战()
    {
        //玩家被打败
        //boss喊话
        //逐渐黑屏
        //出现女主的话 分三段
        //逐渐亮屏幕 已经在洞穴里了
        yield return null;
    }

    IEnumerator PlayCinematic_宝箱前对话()
    {
        yield return null;
    }

    IEnumerator PlayCinematic_决战()
    {
        yield return null;
    }

    IEnumerator PlayCinematic_结局()
    {
        yield return null;
    }
}