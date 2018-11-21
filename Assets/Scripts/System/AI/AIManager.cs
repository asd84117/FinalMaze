using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;

    PlayerData playerData;
    Attack attack;

    Transform player=null;
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
            if(attack.SquareAttack(player,tmpEnemy.transform,playerData.ForwordDistance,playerData.RightDistance))
            {
                tmpEnemy.ChangeState((sbyte)AIBase.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(playerData.Hurt);
            }
            if (attack.SectorAttack(player,tmpEnemy.transform,playerData.Radius,playerData.Angle))
            {
                tmpEnemy.ChangeState((sbyte)AIBase.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(playerData.Hurt);
            }
        }
    }

    //生成敌人，传入资源路径，父类位置，返回生成的物体
    public GameObject BuildEnemy(string path,Transform parent)
    {
        Object tmpObj = Resources.Load(path);
        GameObject tmpEnemy = GameObject.Instantiate(tmpObj) as GameObject;
        tmpEnemy.transform.SetParent(parent);
        EnemyAI tmpEnemyAI= tmpEnemy.AddComponent<EnemyAI>();
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

    private void Awake()
    {
        Instance = this;
        attack = new Attack();
        playerData = new PlayerData();
        allEnemy = new List<EnemyAI>();
    }

    private void Update()
    {
        EnemyBehaviour();
    }
}
