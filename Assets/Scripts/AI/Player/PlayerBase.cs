using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public void Initial()
    {
        gameObject.AddComponent<PlayerCtrl>();
    }

    public CharacterController control;

    private void Awake()
    {
        Initial();
        control = GetComponent<CharacterController>();
    }
    private void Start()
    {
        control.center = new Vector3(0, 1, 0);
        control.height = 2;
        control.radius = 0.23f;
    }


}
