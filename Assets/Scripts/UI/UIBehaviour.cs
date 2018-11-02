using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBehaviour : MonoBehaviour
{
    private void Awake()
    {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        UIManager.Instance.RegistControl(tmpBase.name, transform.name, gameObject);
    }
    //点击事件
    public void AddButtonListen(UnityAction action)
    {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn!=null)
        {
            tmpBtn.onClick.AddListener(action);
        }
    }
    //拖拽事件
    public void AddDrag(UnityAction<BaseEventData> action)
    {
        Debug.Log("UIBehaviour");
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);
    }

}
