using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class GameFlowSystem : MonoBehaviour
{
    public static GameFlowSystem instance;
    // Use this for initialization
    public TestCharacterAnimation character;


    public CanvasGroup bossHpBarCg;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(PlayCinematic_上香());
        bossHpBarCg.alpha = 0;
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


    public float[] delays_上香;
    public ChatPrototype[] chats_上香;
    public GameObject grabMinion;
    public Transform grab位置1;
    public Transform grab位置2;
    IEnumerator PlayCinematic_上香()
    {
        grabMinion.transform.position = grab位置1.position;
        TogglePlayerControl(false);

       
        character.boy.FlipLeft();
        character.girl.FlipLeft();
        character.boy.SetAnimBool("pride", true);
        yield return new WaitForSeconds(delays_上香[0]);
        character.girl.SetMove(false, true);
        yield return new WaitForSeconds(delays_上香[1]);
        character.boy.SetMove(false, true);

        yield return new WaitForSeconds(delays_上香[2]);
        character.girl.SetMove(false, false);
        yield return new WaitForSeconds(delays_上香[3]);
        character.boy.SetMove(false, false);
        character.girl.FlipRight();
        yield return new WaitForSeconds(delays_上香[4]);
        ChatSystem.instance.ShowChat(chats_上香[0]);

        while (ChatSystem.instance.flag!="boss grab boy")
        {
            yield return null;
        }

        grabMinion.transform.DOMove(grab位置2.position, 2).SetEase(Ease.OutBack);
        //面向左边不动 停留
        //对话
        //转向右边
        //向右走
        yield return new WaitForSeconds(delays_上香[4]);
        //boss从右边进来
        yield return new WaitForSeconds(delays_上香[5]);
        //主角停下
        yield return new WaitForSeconds(delays_上香[6]);
        //boss停下
        yield return new WaitForSeconds(delays_上香[7]);

        yield return new WaitForSeconds(delays_上香[8]);

        yield return new WaitForSeconds(delays_上香[9]);
        //boss对话
        //男主往左跑
        //女主往左转身
        //boss说话
        //boss平移 抓男主
        //一起走掉
        //女主说话
        //女主往前走两步
        //开始可以控制
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