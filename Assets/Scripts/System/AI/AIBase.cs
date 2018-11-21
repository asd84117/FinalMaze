using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//添加角色控制器
[RequireComponent(typeof(CharacterController))]
public class AIBase : MonoBehaviour
{
    FSMManager fsmManager;
    CharacterController control;
    public enum AnimationCount
    {
        Idel,
        Walk,
        Run,
        Attack,
        Attacked,

        Max
    }
    public virtual void Initial()
    {
        fsmManager = new FSMManager((int)AnimationCount.Max);
        control = transform.GetComponent<CharacterController>();
    }
    public void SimpleMove(Vector3 speed)
    {
        control.SimpleMove(speed);
    }
    public virtual void ChangeState(sbyte tmpState)
    {
        fsmManager.ChangeState(tmpState);
    }
}
