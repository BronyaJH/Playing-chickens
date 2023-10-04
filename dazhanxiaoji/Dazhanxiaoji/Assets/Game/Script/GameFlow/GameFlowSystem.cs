using Assets.Game.Script.GameFlow;
using com;
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

    public bool skip_上香;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        bossHpBarCg.alpha = 0;
        ReviveSystem.instance.deathPhase = 0;

        if (!skip_上香)
            StartCoroutine(Cinematic_上香());
        else
            TogglePlayerControl(true);
    }

    void TogglePlayerControl(bool b)
    {
        character.girl.GetComponent<PlayerJump>().enabled = b;
        character.girl.GetComponent<PlayerMove>().enabled = b;
        character.girl.GetComponent<PlayerAttackBehaviour>().enabled = b;
        character.girl.GetComponent<NpcController>().enabled = !b;
    }

    public float[] delays_上香;
    public ChatPrototype[] chats_上香;
    public GameObject grabMinion;
    public Transform grab位置1;
    public Transform grab位置2;
    IEnumerator Cinematic_上香()
    {
        ReviveSystem.instance.deathPhase = 0;
        girlHpBarCg.alpha = 0;
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
        grabMinion.gameObject.SetActive(true);
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

    public float[] delays_打输的Boss战;
    public ChatPrototype[] chats_打输的Boss战;
    public Transform boyTrunk;
    public Coroutine boySosCoroutine;

    public void PlayCinematic_打输的Boss战()
    {
        StartCoroutine(Cinematic_打输的Boss战());
    }

    IEnumerator boySos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            character.boy.SetAnimTrigger("sos");
            yield return new WaitForSeconds(0.8f);
            character.boy.SetAnimTrigger("sos");
        }
    }

    public float[] delays_山洞中;
    public ChatPrototype[] chats_山洞中;
    public ParticleSystem psChange;

    IEnumerator PlayerBecomeWarrior()
    {
        TogglePlayerControl(false);
        yield return new WaitForSeconds(1);

        SoundSystem.instance.Play("change");
        psChange.Play(true);
        ChatSystem.instance.ShowChat(chats_山洞中[0]);
        PlayerBehaviour.instance.ToggleWarrierState(true);

        while (ChatSystem.instance.flag != "change done")
            yield return null;

        character.girl.SetAnimTrigger("attack");
        yield return new WaitForSeconds(0.5f);
        TogglePlayerControl(true);

        ReviveSystem.instance.deathPhase = 2;
    }

    IEnumerator Cinematic_打输的Boss战()
    {
        //对战
        //玩家被打败
        //boss喊话
        //逐渐黑屏
        //出现女主的话 分三段
        //逐渐亮屏幕 已经在洞穴里了
        TogglePlayerControl(true);

        character.boy.GetComponent<Rigidbody2D>().isKinematic = true;
        character.boy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        character.boy.transform.SetParent(boyTrunk);
        character.boy.transform.localPosition = Vector3.zero;
        character.boy.gameObject.SetActive(true);
        boySosCoroutine = StartCoroutine(boySos());
        character.girl.SetAnimTrigger("afraid");
        ReviveSystem.instance.deathPhase = 1;
        while (!character.girl.GetComponent<PlayerHealthBehaviour>().isDead)
            yield return null;

        Debug.Log("player die in 打输的Boss战");

        StopCoroutine(boySosCoroutine);

        ChatSystem.instance.ShowChat(chats_打输的Boss战[0]);
        while (ChatSystem.instance.flag != "before boss fight 1")
            yield return null;



        ChatSystem.instance.ShowChat(chats_上香[2]);
        while (ChatSystem.instance.flag != "grab boy 3")
            yield return null;


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

        while (ChatSystem.instance.flag != "grab boy 6")
            yield return null;


        character.girl.SetMove(true, true);
        yield return new WaitForSeconds(delays_上香[18]);
        character.girl.SetMove(true, false);
        character.girl.SetAnimTrigger("jump");
        TogglePlayerControl(true);
        girlHpBarCg.DOFade(1, 1);
        grabMinion.gameObject.SetActive(false);
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