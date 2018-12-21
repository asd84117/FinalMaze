using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

public class SaveManager
{
    #region 保存玩家数据
    public static Player SavePlayerData()
    {
        Player player = new Player();
        player.blood = PlayerData.blood;
        player.hurt = PlayerData.hurt;
        player.path = PlayerData.path;
        player.x = PlayerManager.Instance.Player.position.x;
        player.y = PlayerManager.Instance.Player.position.y;
        player.z = PlayerManager.Instance.Player.position.z;

        return player;
    }
    #endregion

    #region 读取玩家数据
    public static void ReadPlayerData(string playerFilePath)
    {
        StreamReader sr = new StreamReader(playerFilePath);
        string jsonStr = sr.ReadToEnd();
        sr.Close();
        Player playerJson = JsonMapper.ToObject<Player>(jsonStr);
        SetPlayer(playerJson);
        //Debug.Log(playerJson["x"]);
        //Debug.Log(playerJson["y"]);
        //PlayerData.blood = (float)playerJson["blood"];
        //float playerX = (float)playerJson["x"];
        //float playerY = (float)playerJson["y"];
        //float playerZ = (float)playerJson["z"];
        //PlayerData.playerPostion = new Vector3(playerX, playerY, playerZ);
        //PlayerManager.Instance.Player.position = PlayerData.playerPostion;



    }

    private static void SetPlayer()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region 保存怪物数据
    public static string SaveEnemyData(string enemyFilePath)
    {
        //List<Enemy> enemys=new List<Enemy>();
        JsonData enemys = new JsonData();
        enemys["transform"] = new JsonData();
        

        foreach (var item in EnemyManager.allEnemy)
        {
            JsonData enemy = new JsonData();
            enemys["name"] = item.name;
            enemy["x"] = item.transform.position.x;
            enemy["y"] = item.transform.position.y;
            enemy["z"] = item.transform.position.z;
            enemys["transform"].Add(enemy);
        }
        string data = JsonMapper.ToJson(enemys);
        StreamWriter sw = new StreamWriter(enemyFilePath);
        sw.Write(data);
        sw.Close();

        return data;
    }
    #endregion

    #region 读取怪物数据
    public static void ReadEnemyData(string path)
    {
        StreamReader sr = new StreamReader(path);
        string jsonStr = sr.ReadToEnd();
        foreach (var item in jsonStr)
        {

        }

    }
    #endregion

    public static void SetPlayer(Player player)
    {
        PlayerManager.Instance.BuildPlayer();
        PlayerData.blood = (float)player.blood;
        PlayerData.hurt = (float)player.hurt;
        Vector3 tmpPlayer = new Vector3((float)player.x, (float)player.y, (float)player.z);
        PlayerManager.Instance.Player.position = tmpPlayer;
        GameInterfaceCtrl.Instance.UpdataBlood();
    }
}
