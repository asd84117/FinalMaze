using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rgb;
    float speed = 5;
    float x;
    float y;
    Vector3 transformP;
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transformP = new Vector3(x, 0, y);
        rgb.MovePosition(transform.position + transformP*Time.deltaTime*speed);
        Quaternion dir = Quaternion.LookRotation(transformP);
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, speed);
    }
}
