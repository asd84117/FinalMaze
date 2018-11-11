using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    public static AIBase Instance;
    public GameObject GetAI(string aiName)
    {
        return AIManager.Instance.GetGameobject(transform.name, aiName);
    }
    public AIBehaviour GetAIBehaviour(string aiName)
    {
        GameObject tmpAI = GetAI(aiName);
        AIBehaviour tmpAiBehaviour = tmpAI.GetComponent<AIBehaviour>();
        if (tmpAiBehaviour!=null)
        {
            return tmpAiBehaviour;
        }
        return null;
    }
    public void Awake()
    {
        Instance = this;
        Transform[] allAIbehaviour = GetComponentsInChildren<Transform>();
        for (int i = 0; i < allAIbehaviour.Length; i++)
        {
            if (allAIbehaviour[i].name.EndsWith("_A"))
            {
                allAIbehaviour[i].gameObject.AddComponent<AIBehaviour>();
            }
        }
    }

}
