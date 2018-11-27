using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerParent");
        player.AddComponent<PlayerManager>();
        

        Camera.main.gameObject.AddComponent<CameraManager>();
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<EnemyManager>();
        DontDestroyOnLoad(gameObject);
    }
}
