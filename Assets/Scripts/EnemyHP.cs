using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public HP LaoHu = new HP(100);
    public void OnPlayerAttack(int hurt)
    {
        LaoHu.HPChange = hurt;
        Debug.Log("敌人生命值减少" + hurt + "，敌人剩余生命为" + LaoHu.HPChange);
        if(LaoHu.HPChange==0)
        {
            Destroy(gameObject);
            Debug.Log("敌人死亡");
        }
    }    
}
