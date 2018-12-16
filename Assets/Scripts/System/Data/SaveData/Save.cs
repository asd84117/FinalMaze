using System.Collections;
using System.Collections.Generic;
using UnityEngine;



#region 玩家信息
[System.Serializable]
public class Player
{
    public double blood;
    public double hurt;
    public string path;
    public double x;
    public double y;
    public double z;
}
#endregion

#region 怪物信息
[System.Serializable]
public class Enemy
{
    public string name;
    public int number;
    public EnemyTransform enemyTransform;
    public Enemy(string tmpName,int tmpNumber,EnemyTransform  tmpEnemyTransform)
    {
        name = tmpName;
        number = tmpNumber;
        enemyTransform = tmpEnemyTransform;
    }
}
public class EnemyTransform
{
    public double x;
    public double y;
    public double z;
    public EnemyTransform(double tmpX,double tmpY,double tmpZ)
    {
        x = tmpX;
        y = tmpY;
        z = tmpZ;
    }

}
#endregion