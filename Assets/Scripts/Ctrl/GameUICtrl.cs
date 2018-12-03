using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LitJson;
using System.IO;

public class GameUICtrl : UIBase
{
    #region EasyTouch功能的加载
    public void EasyTouchInitial(string path)
    {
        GameObject tmpEasyTouch = GetControl(path);
        Easy easyTouch = new Easy(tmpEasyTouch.transform.position, tmpEasyTouch, 75, PlayerManager.Instance.Player.gameObject);
        AddDrag(path, easyTouch.OnDrag);
        AddOnEndDrag(path, easyTouch.OnEndDrag);

    }
    #endregion
    #region 角色攻击技能的事件和加载
    public void PlayerAttackInitial()
    {
        AddPointClick("Attack_N", OnClick);
        AddPointClick("Play_N", PlayAudio);
        AddPointClick("Stop_N", StopAudio);
    }
    public void OnClick(BaseEventData tmpBase)
    {
        PlayerManager.Instance.PlayerCtrl.ChangeState((sbyte)Data.AnimationCount.Attack);
    }
    #endregion

    public void PlayAudio(BaseEventData data)
    {
        AudioManager.Instance.StartAudio("A");
    }
    public void StopAudio(BaseEventData data)
    {
        AudioManager.Instance.StopAudio("A");
    }

    #region 小地图开关事件
    public void CloseLitMap(BaseEventData data)
    {
        litMap.SetActive(false);
    }
    public void OpenLitMap(BaseEventData data)
    {
        litMap.SetActive(true);
    }
    public void LitMapListen(string openKey,string closeName)
    {
        AddPointClick(openKey, OpenLitMap);

        AddPointClick(closeName, CloseLitMap);
    }
    #endregion

    #region 设置界面事件
    //打开设置界面
    public void SetOpenOnClick(BaseEventData data)
    {
        set.SetActive(true);
    }
    //关闭设置界面
    public void SetCloseOnClick(BaseEventData data)
    {
        set.SetActive(false);
    }
    //保存事件
    public void SaveListen(BaseEventData data)
    {
        Player player = SaveManager.SavePlayerData();
        string playerFilePath = Application.dataPath + "/Resources"+"/Data" + "/PlayerData.json";
        string savePlayerData = JsonMapper.ToJson(player);
        StreamWriter pw = new StreamWriter(playerFilePath);
        pw.Write(savePlayerData);
        pw.Close();
        
        string enemyFilePath = Application.dataPath + "/Resources" + "/Data" + "/EnemyData.json";
        SaveManager.SaveEnemyData(enemyFilePath);
        Debug.Log("保存成功");
    }
    //加载事件
    public void ReadListen()
    {


        string enemyFilePath = Application.dataPath + "/Resources" + "/Data" + "/EnemyData.json";
        if(File.Exists(enemyFilePath))
        {
            SaveManager.ReadEnemyData(enemyFilePath);
        }

    }


    //加载设置界面的所有事件
    public void SetListen(string openKey,string closeKey,string closePanel,string saveBtn,string readBtn)
    {
        AddPointClick(openKey, SetOpenOnClick);
        AddPointClick(closeKey, SetCloseOnClick);
        AddPointClick(saveBtn, SaveListen);
    }
    #endregion

    GameObject litMap;
    GameObject set;
    void Start ()
    {

        #region 小地图相关事件的加载
        litMap = GetControl("LitMapInterface_N");
        LitMapListen("LitMap_N", "LitMapInterface_N");
        litMap.SetActive(false);
        #endregion

        #region 设置界面的加载
        set = GetControl("SetInterface_N");
        SetListen("Set_N","SetClose_N", "SetInterface_N","Save_N","Read_N");
        set.SetActive(false);
        #endregion

        #region 摇杆的加载
        EasyTouchInitial("Image_N");
        #endregion

        #region 攻击技能的加载
        PlayerAttackInitial();
        #endregion
    }

}
