using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private void Awake()
    {
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<AIManager>();
        DontDestroyOnLoad(gameObject);
    }
}
