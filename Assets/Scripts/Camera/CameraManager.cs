using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;
    private void Awake()
    {
        target = PlayerManager.Instance.Player;
    }
    Vector3 vector = Vector3.one;
    public Vector3 distance = new Vector3(0, 1.73f, -3.32f);
    float fllowSpeed = 0.25f;
    float timeCount;
    private void LateUpdate()
    {
        timeCount += Time.deltaTime;
        if(timeCount<1.5f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + distance, ref vector, fllowSpeed);
        }
        else
        {
            transform.position = target.position + distance;
        }

    }

}
