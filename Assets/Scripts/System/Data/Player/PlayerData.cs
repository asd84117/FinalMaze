using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    #region 玩家是否被普通攻击
    public static bool playerAttacked = false;
    #endregion

    #region 模型路径
    public static string path= "Model/Player/SapphiArtchan";
    #endregion
    #region 玩家血量
    public static float bloodMax = 100;
    public static float blood = 100;
    #endregion
    #region 玩家攻击伤害
    public static float hurt = 25;
    #endregion
    #region 移动速度
    public static float moveSpeed = 100;
    #endregion
    #region 扇形攻击数据
    //攻击半径
    public static float radius = 5;
    //攻击角度
    public static float angle = 60;
    #endregion
    #region 矩形攻击数据
    //攻击长度
    public static float forwordDistance = 5;
    //攻击宽度
    public static float rightDistance = 1;
    #endregion

}
