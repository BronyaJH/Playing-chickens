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

    public CanvasGroup girlHpBarCg;
    public CanvasGroup bossHpBarCg;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(PlayCinematic_上香());
        bossHpBarCg.alpha = 0;
        girlHpBarCg.alpha = 0;
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
        while (ChatSystem.instance.flag != "grab boy 1")
            yield return null;

        character.girl.FlipLeft();
        yield return new WaitForSeconds(delays_上香[5]);
        grabMinion.transform.DOMove(grab位置2.position, 2).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(delays_上香[6]);
        ChatSystem.instance.ShowChat(chats_上香[1]);
        while (ChatSystem.instance.flag != "grab boy 2")
            yield return null;
        yield return null;
        character.boy.FlipRight();
        character.girl.FlipRight();
        yield return new WaitForSeconds(0.5f);
        character.girl.SetAnimTrigger("afraid");
        yield return new WaitForSeconds(delays_上香[7]);
        character.boy.FlipLeft();
        character.girl.SetAnimTrigger("afraid");

        yield return new WaitForSeconds(delays_上香[8]);

        ChatSystem.instance.ShowChat(chats_上香[2]);
        while (ChatSystem.instance.flag != "grab boy 3")
            yield return null;

        character.boy.SetMove(true, true);
        yield return new WaitForSeconds(delays_上香[9]);
        character.boy.SetMove(true, false);
        yield return new WaitForSeconds(0.7f);
        character.boy.FlipRight();
        yield return new WaitForSeconds(0.7f);
        character.boy.FlipLeft();
        yield return new WaitForSeconds(0.35f);
        character.boy.FlipRight();
        yield return new WaitForSeconds(0.35f);
        character.boy.FlipLeft();
        yield return new WaitForSeconds(0.35f);
        character.boy.FlipRight();
        yield return new WaitForSeconds(0.35f);
        character.boy.FlipLeft();
        yield return new WaitForSeconds(0.8f);
        character.boy.FlipRight();
        character.boy.SetAnimTrigger("sos");
        character.boy.SetAnimBool("pride", false);
        yield return new WaitForSeconds(delays_上香[10]);
       

        ChatSystem.instance.ShowChat(chats_上香[3]);
        while (ChatSystem.instance.flag != "grab boy 4")
            yield return null;
        yield return new WaitForSeconds(delays_上香[11]);
        character.girl.SetAnimTrigger("afraid");
        character.boy.SetMove(false, true);
        
        yield return new WaitForSeconds(delays_上香[12]);
        ChatSystem.instance.ShowChat(chats_上香[4]);
        while (ChatSystem.instance.flag != "grab boy 5")
            yield return null;
        grabMinion.transform.DOMove(character.boy.transform.position, 2.5f).SetEase(Ease.InOutCubic);
        character.boy.SetMove(false, false);
       

        yield return new WaitForSeconds(delays_上香[13]);
        grabMinion.GetComponentInChildren<Animator>().SetTrigger("melee");
        yield return new WaitForSeconds(0.35f);
        character.boy.transform.SetParent(grabMinion.transform);
        character.boy.GetComponent<Rigidbody2D>().isKinematic = true;
        grabMinion.transform.DOMove(grab位置1.position, 3.2f).SetEase(Ease.InCubic);

        yield return new WaitForSeconds(delays_上香[14]);
        character.girl.SetAnimTrigger("afraid");

        yield return new WaitForSeconds(delays_上香[15]);
        character.boy.SetAnimTrigger("sos");
        yield return new WaitForSeconds(delays_上香[16]);

        character.girl.SetAnimTrigger("afraid");
        yield return new WaitForSeconds(delays_上香[17]);
        ChatSystem.instance.ShowChat(chats_上香[5]);

        while (ChatSystem.instance.flag != "grab boy 6")
            yield return null;


        character.girl.SetMove(true, true);
        yield return new WaitForSeconds(delays_上香[18]);
        character.girl.SetMove(true, false);
        character.girl.SetAnimTrigger("jump");
        TogglePlayerControl(true);
        girlHpBarCg.DOFade(1, 1);
        grabMinion.gameObject.SetActive(false);

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