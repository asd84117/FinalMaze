using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameInterfaceCtrl : UIBase
{
    public static GameInterfaceCtrl Instance;

    #region EasyTouch功能的加载
    private void EasyTouchInitial(string path)
    {
        GameObject tmpEasyTouch = GetControl(path);
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position, tmpEasyTouch, 75, PlayerManager.Instance.Player.gameObject);
        AddDrag(path, easyTouch.OnDrag);
        AddOnEndDrag(path, easyTouch.OnEndDrag);

    }
    #endregion

    #region 角色攻击技能的事件和加载     待完善
    private void PlayerAttackInitial()
    {
        AddPointClick("Attack_N", OnClick);
    }
    private void OnClick(BaseEventData tmpBase)
    {
        PlayerManager.Instance.PlayerCtrl.ChangeState((sbyte)Data.AnimationCount.Attack);
    }
    #endregion

    #region 更新血量显示
    public void UpdataBlood()
    {
        Slider blood = GetControl("Blood_N").GetComponent<Slider>();
        blood.value = PlayerData.blood/PlayerData.bloodMax;
    }
    #endregion

    #region 界面打开事件
    //设置界面的打开
    private void SetInterfaceInitial(string interfaceName,bool tmpBool)
    {
        AddPointClick("Set_N", SetOnClick);
    }
    private void SetOnClick(BaseEventData data)
    {
        GameObject tmpObj = UIManager.Instance.GetChild("SetInterface", "SetInterface_N");
        tmpObj.SetActive(true);
        Time.timeScale = 0;
    }

    #endregion

    private void Start()
    {
        Instance = this;
        EasyTouchInitial("Image_N");
        SetInterfaceInitial("SetInterface_N", true);
        PlayerAttackInitial();
    }

}
