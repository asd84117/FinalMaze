using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    #region 怪物血量
    float blood = 100;
    public float Blood
    {
        get { return blood; }
        set { blood = value; }
    }
    #endregion
    #region 怪物攻击伤害
    float hurt = 25;
    public float Hurt
    {
        get { return hurt; }
        set { hurt = value; }
    }
    #endregion
    #region 移动速度
    float moveSpeed = 3;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    #endregion
    #region 扇形攻击数据
    //攻击半径
    float radius = 5;
    public float Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    //攻击角度
    float angle = 60;
    public float Angle
    {
        get { return angle; }
        set { angle = value; }
    }
    #endregion
    #region 矩形攻击数据
    //攻击长度
    float forwordDistance = 5;
    public float ForwordDistance
    {
        get { return forwordDistance; }
        set { forwordDistance = value; }
    }
    //攻击宽度
    float rightDistance = 1;
    public float RightDistance
    {
        get { return rightDistance; }
        set { rightDistance = value; }
    }
    #endregion
    #region 跟随距离
    float followDistance = 10;
    public float FollowDistance
    {
        get { return followDistance; }
        set { followDistance = value; }
    }
    #endregion
    #region 施放攻击动作的距离
    float attackDistance = 5;
    public float AttackDistance
    {
        get { return attackDistance; }
        set { attackDistance = value; }
    }
    #endregion
}
