using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FSMBase
{
    public virtual void OnEnter()
    { }
    public virtual void OnStay()
    { }
    public virtual void OnExit()
    { }
}
public class FSMManager 
{
    FSMBase[] allstate;
    byte stateCount = 0;
    sbyte oldState = -1;
    sbyte newState = -1;

    #region 实例化
    //构造时写入动画数量
    public FSMManager(int count)
    {
        initial(count);
    }
    //将动画数量实例化到数组
    public void initial(int count)
    {
        allstate = new FSMBase[count];
    }
    #endregion
    //添加新动画
    public void AddState(FSMBase tmpBase)
    {
        if (stateCount > allstate.Length)
            return;
        allstate[stateCount] = tmpBase;
        stateCount++;
    }
    //变换动画
    public void ChangeState(sbyte tmpState)
    {
        if (tmpState == oldState)
            return;
        if (oldState!=-1)
        {
            allstate[oldState].OnExit();
        }
        newState = tmpState;
        oldState = newState;
        allstate[newState].OnEnter();
    }
    //持续播放动画
    public void Stay()
    {
        if (newState != -1)
        {
            allstate[newState].OnStay();
        }
            
    }

}
