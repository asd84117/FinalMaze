using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;
    Dictionary<string, Dictionary<string, GameObject>> allAI;
    public void RegistAI(string baseName,string aiName,GameObject obj)
    {
        if (!allAI.ContainsKey(baseName))
        {
            allAI[baseName] = new Dictionary<string, GameObject>();
        }
        allAI[baseName].Add(aiName, obj);
    }
    public GameObject GetGameobject(string baseName,string aiName)
    {
        if (allAI.ContainsKey(baseName))
        {
            return allAI[baseName][aiName];
        }
        return null;
    }
    public void Awake()
    {
        Instance = this;
        allAI = new Dictionary<string, Dictionary<string, GameObject>>();
    }

}
