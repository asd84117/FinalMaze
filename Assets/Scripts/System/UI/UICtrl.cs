using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICtrl : UIBase
{
    public void OnClick(BaseEventData tmpBase)
    {
        PlayerManager.Instance.PlayerCtrl.AttackOne();
    }
    public void EasyTouchInitial(string path)
    {
        GameObject tmpEasyTouch = GetControl(path);
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position, tmpEasyTouch, 75, PlayerManager.Instance.Player.gameObject);
        AddDrag(path, easyTouch.OnDrag);
        AddOnEndDrag(path, easyTouch.OnEndDrag);

    }
    public void PlayerAttackInitial()
    {
        AddPointClick("Attack_N", OnClick);
    }

    void Start ()
    {
        EasyTouchInitial("Image_N");
        PlayerAttackInitial();
    }
}
