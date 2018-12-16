using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInterfaceCtrl : UIBase
{
    private void Start()
    {
        GetControl("SetInterface_N").SetActive(false);
    }

    public void InterfaceSetActive(bool tmpBool)
    {
        GetControl("SetInterface_N").SetActive(tmpBool);
    }
}
