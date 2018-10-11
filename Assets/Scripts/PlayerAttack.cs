﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    bool attack;//是否有敌人
    float PkillRange = 3;//扇形检测距离
    float PkillAngle = 60;//扇形检测角度
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SendMessage("Attack");
        }
    }
    public void Attack()
    {
        //判断前方扇形范围内是否有敌人
        Collider[] Enemys = Physics.OverlapSphere(transform.position, PkillRange, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < Enemys.Length; i++)
        {
            Vector3 XiangLiang = Enemys[i].transform.position - transform.position;
            //float distance = Vector3.Distance(Enemys[i].transform.position,transform.position);
            float JiaJiao = Vector3.Angle(XiangLiang, transform.forward);
            if (JiaJiao < PkillAngle)
            {
                //按键攻击造成伤害,调用EnemyHP
                Debug.Log("角色进行攻击");
                Enemys[i].GetComponent<EnemyAI>().OnPlayerAttack(5);
            }
        }           
    }
}
