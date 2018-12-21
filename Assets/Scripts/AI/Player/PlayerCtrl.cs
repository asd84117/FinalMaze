using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl :AIBase
{
    public static PlayerCtrl Instance;

    private CharacterController control;

    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);
    public void ReduceBlood(float reduce)
    {
        PlayerData.blood -= reduce;
        GameInterfaceCtrl.Instance.UpdataBlood();
        PlayerData.playerAttacked = true;
        #region 播放玩家受攻击动画
        if(PlayerData.blood>0)
        {
            ChangeState((sbyte)Data.AnimationCount.Attacked);
        }
        #endregion
        #region 播放玩家死亡动画
        if (PlayerData.blood == 0)
        {
            ChangeState((sbyte)Data.AnimationCount.Die);
        }
        #endregion
    }

    //改变动画状态
    public override void ChangeState(sbyte state)
    {
        fsmManager.ChangeState(state);
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        base.Initial();
        Animator animator;
        animator = GetComponent<Animator>();

        #region 设置角色控制器的大小
        control = GetComponent<CharacterController>();
        control.center = new Vector3(0, 1, 0);
        control.height = 2;
        control.radius = 0.23f;
        #endregion

        #region 添加动画
        PlayerIdel playerIdel = new PlayerIdel(animator);
        fsmManager.AddState(playerIdel);
        PlayerWalk playerWalk = new PlayerWalk(animator);
        fsmManager.AddState(playerWalk);
        PlayerRun playerRun = new PlayerRun(animator);
        fsmManager.AddState(playerRun);
        PlayerAttack playerAttack = new PlayerAttack(animator);
        fsmManager.AddState(playerAttack);
        PlayerAttacked playerAttacked = new PlayerAttacked(animator,this);
        fsmManager.AddState(playerAttacked);
        PlayerDie playerDie = new PlayerDie(animator);
        fsmManager.AddState(playerDie);
        #endregion

    }
    private void Update()
    {
        fsmManager.Stay();
        
        #region 播放玩家移动动画并移动
        if (Data.EasyTouch&&PlayerData.playerAttacked==false)
        {
            ChangeState((sbyte)Data.AnimationCount.Run);
            SimpleMove(transform.forward * Time.deltaTime * PlayerData.moveSpeed);
        }
        #endregion
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
