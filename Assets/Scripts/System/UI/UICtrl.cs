using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICtrl : UIBase
{

    #region EasyTouch功能的加载
    public void EasyTouchInitial(string path)
    {
        GameObject tmpEasyTouch = GetControl(path);
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position, tmpEasyTouch, 75, PlayerManager.Instance.Player.gameObject);
        AddDrag(path, easyTouch.OnDrag);
        AddOnEndDrag(path, easyTouch.OnEndDrag);

    }
    #endregion
    #region 角色攻击技能的事件和加载
    public void PlayerAttackInitial()
    {
        AddPointClick("Attack_N", OnClick);
        AddPointClick("Play_N", PlayAudio);
        AddPointClick("Stop_N", StopAudio);
    }
    public void OnClick(BaseEventData tmpBase)
    {
        PlayerManager.Instance.PlayerCtrl.ChangeState((sbyte)Data.AnimationCount.Attack);
    }
    #endregion
    public void PlayAudio(BaseEventData data)
    {
        AudioManager.Instance.StartAudio("A");
    }
    public void StopAudio(BaseEventData data)
    {
        AudioManager.Instance.StopAudio("A");
    }

    public void ReduceBlood(float reduce)
    {
        Slider blood = GetSliderListen("Blood_N");
        blood.value -= reduce / 100f;
    }

    void Start ()
    {
        EasyTouchInitial("Image_N");
        PlayerAttackInitial();
    }
}
