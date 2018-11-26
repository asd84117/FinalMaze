using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdel:FSMBase
{
    Animator animator;
    public PlayerIdel(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //改参数作动画
        animator.SetInteger("Index", 0);
    }
}
public class PlayerWalk : FSMBase
{
    Animator animator;
    public PlayerWalk(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //改参数作动画
        animator.SetInteger("Index", 1);
    }
}
public class PlayerRun : FSMBase
{
    Animator animator;
    public PlayerRun(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //改参数作动画
        animator.SetInteger("Index",2);
    }
}
public class PlayerAttack : FSMBase
{
    Animator animator;
    public PlayerAttack(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //改参数作动画
        animator.SetInteger("Index", 3);
    }
}



public class PlayerCtrl :AIBase
{
    PlayerData playerData;
    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);

    private void Awake()
    {
        playerData = new PlayerData();
    }
    private void Start()
    {
        base.Initial();
        Animator animator;

        animator = GetComponent<Animator>();
        PlayerIdel playerIdel = new PlayerIdel(animator);
        fsmManager.AddState(playerIdel);
        PlayerWalk playerWalk = new PlayerWalk(animator);
        fsmManager.AddState(playerWalk);
        PlayerRun playerRun = new PlayerRun(animator);
        fsmManager.AddState(playerRun);
        PlayerAttack playerAttack = new PlayerAttack(animator);
        fsmManager.AddState(playerAttack);
    }
    private void Update()
    {
        fsmManager.Stay();
        if(Data.EasyTouch)
        {
            fsmManager.ChangeState((sbyte)Data.AnimationCount.Run);
            SimpleMove(transform.forward * Time.deltaTime * playerData.MoveSpeed);
        }else
        {
            fsmManager.ChangeState((sbyte)Data.AnimationCount.Idel);
        }
    }
}
