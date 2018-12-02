using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl :AIBase
{
    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);
    public void ReduceBlood(float reduce)
    {
        PlayerData.blood -= reduce;
        UIManager.Instance.GetChild("GameCanvas", "Blood_N").GetComponent<Slider>().value = PlayerData.blood/PlayerData.bloodMax;
        //GameUICtrl.ReduceBlood(reduce/100f);
    }

    //改变动画状态
    public override void ChangeState(sbyte state)
    {
        fsmManager.ChangeState(state);
    }

    private void Awake()
    {
    }
    private void Start()
    {
        base.Initial();
        Animator animator;
        animator = GetComponent<Animator>();

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

    }
    float timeCount=0;

    private void Update()
    {
        fsmManager.Stay();
        #region 播放玩家死亡动画
        if (PlayerData.blood==0)
        {
            ChangeState((sbyte)Data.AnimationCount.Die);
        }
        #endregion
        #region 播放玩家受攻击动画
        if (PlayerData.playerAttacked)
        {
            timeCount += Time.deltaTime;
            if (timeCount>0.06f)
            {
                timeCount = 0;
                PlayerData.playerAttacked = false;
                ChangeState((sbyte)Data.AnimationCount.Attacked);

            }
        }
        #endregion
        #region 播放玩家移动动画
        if (Data.EasyTouch)
        {
            ChangeState((sbyte)Data.AnimationCount.Run);
            SimpleMove(transform.forward * Time.deltaTime * PlayerData.moveSpeed);
        }
        #endregion
    }
}
