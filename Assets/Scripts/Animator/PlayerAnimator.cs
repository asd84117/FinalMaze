﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerIdel : FSMBase
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
        animator.SetInteger("Index", 2);
    }
    public override void OnStay()
    {
        if(!Data.EasyTouch)
        {
            PlayerManager.Instance.PlayerCtrl.ChangeState((sbyte)Data.AnimationCount.Idel);
        }
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
    public override void OnStay()
    {
    }
}

public class PlayerAttacked : FSMBase
{
    Animator animator;
    PlayerCtrl myCtrl;
    public PlayerAttacked(Animator tmpAnimator,PlayerCtrl ctrl)
    {
        animator = tmpAnimator;
        myCtrl = ctrl;
    }
    public override void OnEnter()
    {
        //改参数作动画
        animator.SetInteger("Index", 4);
        PlayerData.playerAttacked = true;
    }
    public override void OnExit()
    {
        isPlaying = false;
    }
    float timeCount;
    bool isPlaying;
    public override void OnStay()
    {
        
        timeCount += Time.deltaTime;
        if (timeCount > 0.35f && !isPlaying)
        {
            PlayerData.playerAttacked = false;
            isPlaying = false;
            myCtrl.ChangeState((sbyte)Data.AnimationCount.Idel);
            timeCount = 0;
        }
    }
}

public class PlayerDie : FSMBase
{
    Animator animator;

    public PlayerDie(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    float timeCount;
    public override void OnEnter()
    {
        PlayerData.playerAttacked = true;
        animator.SetInteger("Index", 5);
    }
    public override void OnStay()
    {

        timeCount += Time.deltaTime;
        if (timeCount > 0.57f)
        {
            timeCount = 0;
            PlayerData.playerAttacked = false;
            PlayerCtrl.Instance.OnDestroy();
        }
    }

}


