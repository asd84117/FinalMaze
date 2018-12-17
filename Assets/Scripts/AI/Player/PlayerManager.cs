using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager :MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerCtrl PlayerCtrl
    {
        get { return tmpPlayer.GetComponent<PlayerCtrl>(); }
    }

    GameObject tmpPlayer;
    public Transform Player
    {
        get { return tmpPlayer.transform; }
        set { }
    }
    Transform playerParent;
    public void Initial()
    {
        Object tmpObj = Resources.Load(PlayerData.path);
        tmpPlayer = Instantiate(tmpObj) as GameObject;
        tmpPlayer.transform.SetParent(playerParent);
        tmpPlayer.transform.position = GameObject.FindGameObjectWithTag("PlayerParent").transform.position;
        tmpPlayer.AddComponent<PlayerBase>();
    }
    private void Awake()
    {
        Instance = this;
        playerParent = GameObject.FindGameObjectWithTag("PlayerParent").transform;
        Initial();
    }

}
