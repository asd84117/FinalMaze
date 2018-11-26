using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//添加角色控制器
[RequireComponent(typeof(CharacterController))]
public class AIBase : MonoBehaviour
{
    FSMManager fsmManager;
    CharacterController control;

    public virtual void Initial()
    {
        fsmManager = new FSMManager((int)Data.AnimationCount.Max);
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
