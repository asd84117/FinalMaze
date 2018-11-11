using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EasyTouch : MonoBehaviour,IDragHandler,IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 tmpVector = eventData.position - core;
        if (tmpVector.magnitude<radius)
        {
            transform.position = eventData.position;
        }else
        {
            transform.position = core + tmpVector.normalized * radius;
        }
        float angle = Mathf.Atan2(tmpVector.y, tmpVector.x) * Mathf.Rad2Deg;
        Vector3 tmpPlayer = playerObj.transform.localEulerAngles;
        tmpPlayer.y = 90-angle;
        playerObj.transform.localEulerAngles = tmpPlayer;

    }
    public Vector2 core;
    public float radius = 100;
    GameObject playerObj;
    void Start ()
    {
        core = transform.position;
        playerObj = AIBase.Instance.GetAI("Player_A");
	}
	
	void Update ()
    {
        
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = core;
    }
}
