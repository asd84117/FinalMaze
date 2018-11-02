﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour
{
    private void Awake()
    {
        Transform[] tmpChild = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tmpChild.Length; i++)
        {
            if (tmpChild[i].name.EndsWith("_N"))
            {
                tmpChild[i].gameObject.AddComponent<UIBehaviour>();
            }
        }
    }
    public GameObject GetControl(string controlName)
    {
        return UIManager.Instance.GetChild(transform.name, controlName);
    }
    public UIBehaviour GetBehaviour(string controlName)
    {
        GameObject tmpObj= GetControl(controlName);
        if (tmpObj!=null)
        {
            return tmpObj.GetComponent<UIBehaviour>();
        }
        return null;
    }
    //点击事件添加方法
    public void AddButtonListen(string controlName, UnityAction action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(controlName);
        if (tmpBehaviour!=null)
        {
            tmpBehaviour.AddButtonListen(action);
        }
    }
    //拖拽事件添加方法
    public void AddDrag(string controlName, UnityAction<BaseEventData> action)
    {
        Debug.Log("UIBase");
        UIBehaviour tmpBehaviour = GetBehaviour(controlName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddDrag(action);
        }
    }

}