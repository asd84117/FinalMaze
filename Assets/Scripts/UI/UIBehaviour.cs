using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIBehaviour : MonoBehaviour
{
    private void Awake()
    {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        UIManager.Instance.RegistControl(tmpBase.name, transform.name, gameObject);
    }
    public void AddButtonListen(UnityAction action)
    {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn!=null)
        {
            tmpBtn.onClick.AddListener(action);
        }
    }

}
