using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager :MonoBehaviour
{
    public static PlayerManager Instance;
    GameObject tmpPlayer;
    public Transform Player
    {
        get { return tmpPlayer.transform; }
    }
    Transform playerParent;
    public void Initial()
    {
        Object tmpObj = Resources.Load("Model/Player/SapphiArtchan");
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
