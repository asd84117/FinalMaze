using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    static float lastTime = 0;
    public static bool TimeCount(float time)
    {
        if (Time.time-lastTime>time)
        {
            lastTime = Time.time;
            return true;
        }
        return false;
    }
}
