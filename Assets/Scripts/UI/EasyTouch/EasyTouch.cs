using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Easy
{
    float tmpRadius;
    Vector2 tmpCore;
    GameObject tmpRocker;
    GameObject tmpPlayer;
    //构造时写入圆心位置、摇杆物体、摇杆移动半径、摇杆控制的玩家
    public Easy(Vector2 core, GameObject rocker, float radius, GameObject player)
    {
        tmpPlayer = player;
        tmpCore = core;
        tmpRocker = rocker;
        tmpRadius = radius;
    }
    //摇杆拖拽事件
    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData tmpDate = (PointerEventData)eventData;
        Vector2 tmpDistance = tmpDate.position - tmpCore;
        if (tmpDistance.magnitude < tmpRadius)
        {
            tmpRocker.transform.position = tmpDate.position;
        }
        else
        {
            tmpRocker.transform.position = tmpCore + tmpDistance.normalized * tmpRadius;
        }
        Vector2 rocker = tmpPlayer.transform.localEulerAngles;
        rocker.y = 90 - Mathf.Atan2(tmpDistance.y, tmpDistance.x) * Mathf.Rad2Deg;
        tmpPlayer.transform.localEulerAngles = rocker;
    }
    //摇杆结束拖拽时归位
    public void OnEndDrag(BaseEventData eventData)
    {
        tmpRocker.transform.position = tmpCore;
    }
}