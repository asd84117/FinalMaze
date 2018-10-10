using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    static Transform playertransform = null;
    public static Transform PlayerTransform
    {
        get { return playertransform; }
        set { playertransform = value; }
    }
}
