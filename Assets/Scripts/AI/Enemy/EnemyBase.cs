using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public CharacterController control;

    private void Awake()
    {
        control = transform.GetComponent<CharacterController>();
    }
    private void Start()
    {
        control.center = new Vector3(0, 1, 0);
        control.height = 2;
        control.radius = 0.23f;
    }
}
