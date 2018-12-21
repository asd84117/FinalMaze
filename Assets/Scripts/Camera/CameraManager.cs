using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;
    private void Awake()
    {
        //target = PlayerManager.Instance.Player;
        //transform.rotation = Quaternion.Euler(45, 0, 0);
    }
    //Vector3 vector = Vector3.one;
    public Vector3 distance = new Vector3(0, 3.5f, -2.5f);
    //float fllowSpeed = 0.25f;
    //float timeCount;
    private void LateUpdate()
    {
        if (target==null)
        {
            target = PlayerManager.Instance.Player;
            transform.rotation = Quaternion.Euler(45, 0, 0);

        }
        else
        {
            transform.position = target.position + distance;
        }

        //timeCount += Time.deltaTime;
        //if(timeCount<1.5f)
        //{
        //    transform.position = Vector3.SmoothDamp(transform.position, target.position + distance, ref vector, fllowSpeed);
        //}
        //else
        //{
        //    transform.position = target.position + distance;
        //}

    }

}
