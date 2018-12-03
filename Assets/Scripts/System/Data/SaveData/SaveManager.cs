using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class SaveManager
{
    public static Player SavePlayerData()
    {
        Player player = new Player();
        player.blood = PlayerData.blood;
        player.hurt = PlayerData.hurt;
        player.x = PlayerManager.Instance.Player.position.x;
        player.y = PlayerManager.Instance.Player.position.y;
        player.z = PlayerManager.Instance.Player.position.z;

        return player;
    }
    public static void ReadPlayerData()
    {

    }



    public static string SaveEnemyData(string enemyFilePath)
    {
        //List<Enemy> enemys=new List<Enemy>();
        JsonData enemys = new JsonData();
        enemys["transform"] = new JsonData();
        

        foreach (var item in EnemyManager.allEnemy)
        {
            //enemys.Add(new Enemy { x = item.transform.position.x, y = item.transform.position.y, z = item.transform.position.z });
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
    public static void ReadEnemyData(string path)
    {
        StreamReader sr = new StreamReader(path);
        string jsonStr = sr.ReadToEnd();
        foreach (var item in jsonStr)
        {

        }

    }

}
