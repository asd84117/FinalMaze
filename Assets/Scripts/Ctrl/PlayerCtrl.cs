using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerCtrl :AIBase
{
    PlayerData playerData;
    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);

    public void ReduceBlood(float reduce)
    {
        playerData.Blood -= reduce;
        GameObject tmpObj = UIManager.Instance.GetPanel("GameInterface_N");
        UICtrl tmpCtrl = tmpObj.GetComponent<UICtrl>();
        tmpCtrl.ReduceBlood(reduce);
    }

    //改变动画状态
    public override void ChangeState(sbyte state)
    {
        fsmManager.ChangeState(state);
    }

    private void Awake()
    {
        playerData = new PlayerData();
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
    }
    private void Update()
    {
        fsmManager.Stay();
        if(Data.EasyTouch)
        {
            ChangeState((sbyte)Data.AnimationCount.Run);
            SimpleMove(transform.forward * Time.deltaTime * playerData.MoveSpeed);
        }
    }
}
