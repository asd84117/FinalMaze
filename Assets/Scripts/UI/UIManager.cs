﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    Dictionary<string,Dictionary<string,GameObject>> allChild;
    private void Awake()
    {
        Instance = this;
        allChild = new Dictionary<string, Dictionary<string, GameObject>>();
    }
    public void RegistControl(string panelName,string controlName,GameObject obj)
    {
        if(!allChild.ContainsKey(panelName))
        {
            allChild[panelName] = new Dictionary<string, GameObject>();
        }
        allChild[panelName].Add(controlName, obj);
    }
    //得到UI控件的gameobject
    public GameObject GetChild(string panelName,string controlNmae)
    {

        if (allChild.ContainsKey(panelName))
        {
            return allChild[panelName][controlNmae];
        }
        return null;
    }
    //得到Panel
    public GameObject GetPanel(string panelName)
    {
        return allChild[panelName][panelName];
    }
}
