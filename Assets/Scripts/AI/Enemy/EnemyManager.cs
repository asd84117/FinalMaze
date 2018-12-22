using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

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
    public static List<EnemyAI> allEnemy;

    //检测被攻击  在玩家攻击时检测!!!!!
    public void AttackedByPlayer()
    {
        for (int i = 0; i < allEnemy.Count; i++)
        {
            EnemyAI tmpEnemy = allEnemy[i].GetComponent<EnemyAI>();
            if(Attack.SquareAttack(player,tmpEnemy.transform,PlayerData.forwordDistance,PlayerData.rightDistance))
            {
                tmpEnemy.ChangeState((sbyte)Data.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(PlayerData.hurt);
            }
            if (Attack.SectorAttack(player,tmpEnemy.transform,PlayerData.radius,PlayerData.angle))
            {
                tmpEnemy.ChangeState((sbyte)Data.AnimationCount.Attacked);
                tmpEnemy.ReduceBlood(PlayerData.hurt);
            }
        }
    }

    #region 生成敌人，传入资源路径，父类位置，返回生成的物体
    public GameObject BuildEnemy(string path,Transform parent)
    {
        Object tmpObj = Resources.Load(path);
        GameObject tmpEnemy = GameObject.Instantiate(tmpObj) as GameObject;
        tmpEnemy.transform.SetParent(parent);
        tmpEnemy.AddComponent<EnemyAI>();


        tmpEnemy.transform.position = parent.position;

        EnemyAI tmpEnemyAI = tmpEnemy.GetComponent<EnemyAI>();

        allEnemy.Add(tmpEnemyAI);
        return tmpEnemy;
    }
    #endregion

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

        allEnemy = new List<EnemyAI>();

        Transform enemyTransform = GameObject.Find("Enemy").transform;
        BuildEnemy("Model/Player/SapphiArtchan", enemyTransform);
        Transform enemy2Transform = GameObject.Find("Enemy2").transform;
        BuildEnemy("Model/Player/SapphiArtchan", enemy2Transform);

    }

    private void Update()
    {
        EnemyBehaviour();
    }
}
