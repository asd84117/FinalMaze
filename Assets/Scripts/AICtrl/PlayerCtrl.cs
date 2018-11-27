using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerCtrl :AIBase
{
    PlayerData playerData;
    FSMManager fsmManager = new FSMManager((int)Data.AnimationCount.Max);

    public override void ChangeState(sbyte state)
    {
        fsmManager.ChangeState(state);
    }

    public void AttackOne()
    {
        ChangeState((sbyte)Data.AnimationCount.Attack);
        
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
