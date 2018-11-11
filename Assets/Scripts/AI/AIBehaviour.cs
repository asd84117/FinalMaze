using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public void Awake()
    {
        AIBase tmpBase = gameObject.GetComponentInParent<AIBase>();
        AIManager.Instance.RegistAI(tmpBase.name, transform.name, gameObject);
    }
}
