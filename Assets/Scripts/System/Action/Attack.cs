using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    //矩形攻击范围，传入攻击者、被攻击者、攻击长度、攻击宽度
    public bool SquareAttack(Transform attacker,Transform attacked,float forwordDistance,float rightDistance)
    {
        Vector3 vector = attacked.position - attacker.position;
        float vectorLong = Vector3.Dot(attacker.forward, vector);
        float vectorShort = Mathf.Abs(Vector3.Dot(attacker.right, vector));
        if(vectorLong>0&&vectorLong<=forwordDistance)
        {
            if(vectorShort<=rightDistance)
            {
                return true;
            }
        }
        return false;
    }
    //扇形攻击 传入攻击者、被攻击者、攻击角度、攻击距离
    public bool SectorAttack(Transform attacker,Transform attacked,float radius, float angle)
    {
        Vector3 vector = attacked.position - attacker.position;
        float tmpAngle = Mathf.Acos(Vector3.Dot(vector.normalized, attacker.forward)) * Mathf.Rad2Deg;
        if(tmpAngle<=angle*0.5f&&vector.magnitude<=radius)
        {
            return true;
        }
        return false;
    }
}
