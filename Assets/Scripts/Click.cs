using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : UIBase
{
    public void OnClick()
    {
        Debug.Log("点击了一下按钮");
    }
    public void Drag(BaseEventData eventData)
    {
        PointerEventData pointerEvent = (PointerEventData)eventData;
        transform.position = pointerEvent.position;
    }
	// Use this for initialization
	void Start () {
        AddButtonListen("Button_N", OnClick);
        AddDrag("Drag_N", Drag);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
