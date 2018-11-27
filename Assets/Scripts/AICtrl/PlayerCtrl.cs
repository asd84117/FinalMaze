using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerCtrl :AIBase
{
    PlayerData playerData;
    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);

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
            fsmManager.ChangeState((sbyte)Data.AnimationCount.Run);
            SimpleMove(transform.forward * Time.deltaTime * playerData.MoveSpeed);
        }else
        {
            fsmManager.ChangeState((sbyte)Data.AnimationCount.Idel);
        }
    }
}
