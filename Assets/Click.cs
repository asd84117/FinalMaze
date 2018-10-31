using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : UIBase {

    public void OnClick()
    {
        Debug.Log("点击了一下按钮");
    }
	// Use this for initialization
	void Start () {
        AddButtonListen("Button_N", OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
