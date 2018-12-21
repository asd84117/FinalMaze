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
        get
        {
            if (tmpPlayer!=null)
            {
                return tmpPlayer.transform;
            }
            return null;
        }
        set { }
    }
    Transform playerParent;

    #region 创建一个玩家角色
    public void BuildPlayer()
    {
        Object tmpObj = Resources.Load(PlayerData.path);
        tmpPlayer = Instantiate(tmpObj) as GameObject;
        tmpPlayer.transform.SetParent(transform);
        tmpPlayer.transform.position = transform.position;
        tmpPlayer.AddComponent<PlayerCtrl>();

    }
    #endregion

    private void Awake()
    {
        Instance = this;
        playerParent = GameObject.FindGameObjectWithTag("PlayerParent").transform;
        BuildPlayer();
    }

}
