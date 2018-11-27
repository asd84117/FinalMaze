using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdel : FSMBase
{
    Animator animator;
    public EnemyIdel(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 0);
    }
}
public class EnemyWalk : FSMBase
{
    Animator animator;
    public EnemyWalk(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 1);
    }
}
public class EnemyRun : FSMBase
{
    Animator animator;
    public EnemyRun(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 2);
    }
}
public class EnemyAttack : FSMBase
{
    Animator animator;
    public EnemyAttack(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }

    float timeCount;
    public override void OnEnter()
    {
        animator.SetInteger("Index", 3);
    }
    public override void OnStay()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.8f)
        {
            animator.SetInteger("Index", 0);
            timeCount = 0;
        }else
        {
            animator.SetInteger("Index", 3);
        }
    }
}
