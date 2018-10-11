using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    static int MaxHP;
    static int hp;
    public HP(int hpNew)
    {
        MaxHP = hpNew;
        hp = MaxHP;
    }
    public int HPChange
    {
        get { return Mathf.Clamp(hp,0,MaxHP); }
        set { hp -= value; }
    }
}