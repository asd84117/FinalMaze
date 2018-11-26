using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTouchCtrl : UIBase
{

	void Start ()
    {
        GameObject tmpEasyTouch = GetControl("Image_N");
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position,tmpEasyTouch,75,AIManager.Instance.Player.gameObject);
        AddDrag("Image_N", easyTouch.OnDrag);
        AddOnEndDrag("Image_N", easyTouch.OnEndDrag);
    }
}
