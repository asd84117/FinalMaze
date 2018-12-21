using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : AIBase
{
    public EnemyData enemyData;
    public override void Initial()
    {
        base.Initial();
        enemyData = new EnemyData();
        //attack = new Attack();
    }
    //掉血，传入掉的血量
    public void ReduceBlood(float reduce)
    {
        enemyData.Blood -= reduce;
    }
    public float timeCount = 0;

    #region 怪物攻击和跟随检测
    public void EnemyAttack()
    {
        if (PlayerManager.Instance.Player==null)
        {
            return; 
        }

        Vector3 distance = PlayerManager.Instance.Player.position - transform.position;
        //检测距离
        if(distance.magnitude< enemyData.FollowDistance&&PlayerData.blood!=0)
        {
            if (distance.magnitude <= enemyData.AttackDistance)
            {
                timeCount += Time.deltaTime;

                if (Time.time - enemyData.LastAttackTime > enemyData.AttackCD)
                {

                    enemyData.LastAttackTime = Time.time;
                    fsmManager.ChangeState((sbyte)Data.AnimationCount.Attack);
                    if (Attack.SquareAttack(transform, PlayerManager.Instance.Player, enemyData.ForwordDistance, enemyData.RightDistance))
                    {
                        PlayerManager.Instance.PlayerCtrl.ReduceBlood(enemyData.Hurt);
                        PlayerData.playerAttacked = true;
                    }

                }
                else
                    fsmManager.ChangeState((sbyte)Data.AnimationCount.Idel);
            }
            else
            {
                transform.LookAt(PlayerManager.Instance.Player);
                fsmManager.ChangeState((sbyte)Data.AnimationCount.Run);
                SimpleMove(distance.normalized* enemyData.MoveSpeed*Time.deltaTime);
            }
        }else
        {
            fsmManager.ChangeState((sbyte)Data.AnimationCount.Idel);
        }
    }
    #endregion


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
