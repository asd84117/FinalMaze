using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameUICtrl : UIBase
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

    #region 小地图开关事件
    public void CloseLitMap(BaseEventData data)
    {
        litMap.SetActive(false);
    }
    public void OpenLitMap(BaseEventData data)
    {
        litMap.SetActive(true);
    }
    public void LitMapListen(string openKey,string closeName)
    {
        AddPointClick(openKey, OpenLitMap);

        AddPointClick(closeName, CloseLitMap);
    }
    #endregion

    GameObject litMap;
    void Start ()
    {

        #region 小地图相关事件的加载
        litMap = GetControl("LitMapInterface_N");
        LitMapListen("LitMap_N", "LitMapInterface_N");
        litMap.SetActive(false);
        #endregion

        #region 摇杆的加载
        EasyTouchInitial("Image_N");
        #endregion

        #region 攻击技能的加载
        PlayerAttackInitial();
        #endregion
    }

}
