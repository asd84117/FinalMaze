using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : AIBase
{
    EnemyData data;
    Attack attack;
    public override void Initial()
    {
        base.Initial();
        data = new EnemyData();
        attack = new Attack();
    }
    //掉血，传入掉的血量
    public void ReduceBlood(float reduce)
    {
        data.Blood -= reduce;
    }
    //怪物攻击和跟随检测
    public void EnemyAttack()
    {
        Vector3 distance = AIManager.Instance.Player.position - transform.position;
        //检测距离
        if(distance.magnitude<data.FollowDistance)
        {
            if(distance.magnitude<data.AttackDistance)
            {
                //攻击
                ChangeState((sbyte)AnimationCount.Attack);
                attack.SectorAttack(transform, AIManager.Instance.Player, data.Radius, data.Angle);
            }
            else
            {
                //跟随
                ChangeState((sbyte)AnimationCount.Run);
                SimpleMove(distance.normalized * data.MoveSpeed);
            }
        }
    }
    private void Awake()
    {
        Initial();
    }
}
