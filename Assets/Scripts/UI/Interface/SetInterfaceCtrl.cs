﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LitJson;
using System.IO;


public class SetInterfaceCtrl : UIBase
{
    #region 保存事件
    public void SaveListen(BaseEventData data)
    {
        //保存玩家信息
        Player player = SaveManager.SavePlayerData();
        string playerFilePath = Application.dataPath + "/Resources" + "/Data" + "/PlayerData.json";
        string savePlayerData = JsonMapper.ToJson(player);
        StreamWriter pw = new StreamWriter(playerFilePath);
        pw.Write(savePlayerData);
        pw.Close();

        //保存怪物信息
        string enemyFilePath = Application.dataPath + "/Resources" + "/Data" + "/EnemyData.json";
        SaveManager.SaveEnemyData(enemyFilePath);
        Debug.Log("保存成功");
    }
    #endregion


    #region 加载事件
    public void ReadListen()
    {
        //加载玩家信息
        string playerFilePath = Application.dataPath + "/Resources" + "/Data" + "/PlayerData.json";
        if (File.Exists(playerFilePath))
        {
            SaveManager.ReadPlayerData(playerFilePath);
        }

        //加载怪物信息
        string enemyFilePath = Application.dataPath + "/Resources" + "/Data" + "/EnemyData.json";
        if (File.Exists(enemyFilePath))
        {
            SaveManager.ReadEnemyData(enemyFilePath);
        }

    }
    #endregion





    private void Start()
    {
        GetControl("SetInterface_N").SetActive(false);
    }

    #region 设置界面是否激活
    public void InterfaceSetActive(bool tmpBool)
    {
        GetControl("SetInterface_N").SetActive(tmpBool);
    }
    #endregion
}
