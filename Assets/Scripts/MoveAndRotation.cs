using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotation : MonoBehaviour {
    Rigidbody player;
    Vector3 PlayerPostion;
    public float MoveSpeed = 4;
    public float RotateSpeed = 10;
	void Start () {
        player = GetComponent<Rigidbody>();
	}
    void Rotate()
    {
        Quaternion dir = Quaternion.LookRotation(PlayerPostion, Vector3.up);
        player.MoveRotation( Quaternion.Slerp(player.rotation, dir, RotateSpeed * Time.deltaTime));
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        PlayerPostion = new Vector3(x, 0f, z);
        player.MovePosition(player.position + PlayerPostion * Time.deltaTime * MoveSpeed);
        if (x != 0 || z != 0)
        {
            Rotate();
        }
    }
}
