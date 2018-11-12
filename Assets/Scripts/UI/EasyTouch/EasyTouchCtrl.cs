﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Easy
{
    float tmpRadius;
    Vector2 tmpCore;
    GameObject tmpRocker;
    GameObject tmpPlayer;
    public Easy(Vector2 core,GameObject rocker,float radius,GameObject player)
    {
        tmpPlayer = player;
        tmpCore = core;
        tmpRocker = rocker;
        tmpRadius = radius;
    }

    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData tmpDate = (PointerEventData)eventData;
        Vector2 tmpDistance = tmpDate.position - tmpCore;
        if (tmpDistance.magnitude<tmpRadius)
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
    public void OnEndDrag(BaseEventData eventData)
    {
        tmpRocker.transform.position = tmpCore;
    }
}
public class EasyTouchCtrl : UIBase
{

	void Start ()
    {
        GameObject tmpEasyTouch = GetControl("Image_N");
        GameObject player = AIBase.Instance.GetAI("Player_A");
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position,tmpEasyTouch,75,player);
        AddDrag("Image_N", easyTouch.OnDrag);
        AddOnEndDrag("Image_N", easyTouch.OnEndDrag);
    }
	
	void Update ()
    {
		
	}
}