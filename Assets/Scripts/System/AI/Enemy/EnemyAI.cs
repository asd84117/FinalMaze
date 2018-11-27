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
        Vector3 distance = PlayerManager.Instance.Player.position - transform.position;

        //检测距离
        if(distance.magnitude<data.FollowDistance)
        {
            if (distance.magnitude <= data.AttackDistance) 
            {
                transform.LookAt(PlayerManager.Instance.Player);

                fsmManager.ChangeState((sbyte)Data.AnimationCount.Attack);
                attack.SectorAttack(transform, PlayerManager.Instance.Player, data.Radius, data.Angle);
                
            }
            else
            {
                transform.LookAt(PlayerManager.Instance.Player);
                fsmManager.ChangeState((sbyte)Data.AnimationCount.Run);
                SimpleMove(transform.forward* data.MoveSpeed*Time.deltaTime);
            }
        }
    }

    FSMManager fsmManager;
    Animator animator;

    public override void ChangeState(sbyte tmpState)
    {
        fsmManager.ChangeState(tmpState);
    }
    private void Awake()
    {
        Initial();
        fsmManager = new FSMManager((int)Data.AnimationCount.Max);
        animator = transform.GetComponent<Animator>();
        

        EnemyIdel enemyIdel = new EnemyIdel(animator);
        fsmManager.AddState(enemyIdel);
        EnemyWalk enemyWalk = new EnemyWalk(animator);
        fsmManager.AddState(enemyWalk);
        EnemyRun enemyRun = new EnemyRun(animator);
        fsmManager.AddState(enemyRun);
        EnemyAttack enemyAttack = new EnemyAttack(animator);
        fsmManager.AddState(enemyAttack);
    }
    private void Update()
    {
        fsmManager.Stay();
    }
}
