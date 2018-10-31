using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //public float ScrollSpeed=0.1f;
    Vector3 direction;
    Transform PlayerPosition;
    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.LookAt(PlayerPosition.position+new Vector3(0,0.5f,0));
        direction = transform.position - PlayerPosition.position;
    }
    private void LateUpdate()
    {
        transform.position = direction + PlayerPosition.position;
        //GUN();
    }
    //void GUN()
    //{
    //    float distance = direction.magnitude;
    //    distance = distance - Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
    //    distance = Mathf.Clamp(distance, 2, 4);
    //    direction = direction.normalized * distance;
    //}
}
