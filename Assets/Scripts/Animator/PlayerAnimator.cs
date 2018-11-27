using System.Collections;
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


