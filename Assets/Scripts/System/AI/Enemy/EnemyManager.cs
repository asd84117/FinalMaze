using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    Attack attack;

    Transform player =null;
    public Transform Player
    {
        get
        {
            if(player==null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return player;
        }
    }
    List<EnemyAI> allEnemy;

    //检测被攻击
    public void AttackedByPlayer()
    {
        for (int i = 0; i < allEnemy.Count; i++)
        {
            EnemyAI tmpEnemy = allEnemy[i].GetComponent<EnemyAI>();
            if(attack.SquareAttack(player,tmpEnemy.transform,PlayerData.forwordDistance,PlayerData.rightDistance))
            {
                tmpEnemy.ChangeState((sbyte)Data.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(PlayerData.hurt);
            }
            if (attack.SectorAttack(player,tmpEnemy.transform,PlayerData.radius,PlayerData.angle))
            {
                tmpEnemy.ChangeState((sbyte)Data.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(PlayerData.hurt);
            }
        }
    }

    //生成敌人，传入资源路径，父类位置，返回生成的物体
    public GameObject BuildEnemy(string path,Transform parent)
    {
        Object tmpObj = Resources.Load(path);
        GameObject tmpEnemy = GameObject.Instantiate(tmpObj) as GameObject;
        tmpEnemy.transform.SetParent(parent);
        tmpEnemy.AddComponent<EnemyAI>();
        tmpEnemy.AddComponent<EnemyBase>();

        tmpEnemy.transform.position = parent.position;

        EnemyAI tmpEnemyAI = tmpEnemy.GetComponent<EnemyAI>();

        allEnemy.Add(tmpEnemyAI);
        return tmpEnemy;
    }

    //怪物的日常行为
    public void EnemyBehaviour()
    {
        for (int i = 0; i < allEnemy.Count; i++)
        {


            EnemyAI tmpEnemy = allEnemy[i].GetComponent<EnemyAI>();
            tmpEnemy.EnemyAttack();
            //加个巡逻
        }
    }
    Transform enemyTransform;
    private void Awake()
    {

        attack = new Attack();
        allEnemy = new List<EnemyAI>();

        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        BuildEnemy("Model/Player/SapphiArtchan", enemyTransform);

    }

    private void Update()
    {
        EnemyBehaviour();
    }
}
