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
        animator.SetInteger("", 0);
    }
}

public class PlayerCtrl : MonoBehaviour
{
    public enum AnimationCount
    {
        Idel,
        Walk,
        Max
    }
    FSMManager fsmManager = new FSMManager((int)AnimationCount.Max);
    private void Start()
    {
        Animator animator;
        animator = GetComponent<Animator>();
        PlayerIdel playerIdel = new PlayerIdel(animator);
        fsmManager.AddState(playerIdel);
    }
    private void Update()
    {
        fsmManager.Stay();
        if(Input.GetKey(KeyCode.A))
        {
            fsmManager.ChangeState((sbyte)AnimationCount.Idel);
        }
    }
}
