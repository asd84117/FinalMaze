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

    void Start ()
    {
        GameObject tmpEasyTouch = GetControl("Image_N");
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position,tmpEasyTouch,75,PlayerManager.Instance.Player.gameObject);
        AddDrag("Image_N", easyTouch.OnDrag);
        AddOnEndDrag("Image_N", easyTouch.OnEndDrag);
        AddPointClick("Attack_N", OnClick);
    }
}
