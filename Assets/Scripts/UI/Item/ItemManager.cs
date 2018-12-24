using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemManager : MonoBehaviour
{
    #region 单例模式
    private ItemManager instance;
    public ItemManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
        RegistItem();
    }
    #endregion

    #region 将物品信息注册进游戏
    List<ItemData> items;
    private void RegistItem()
    {
        //将信息读取成string类型
        string tmpPath = Application.dataPath + "/Resources" + "/Data" + "/ItemData.json";
        StreamReader sr = new StreamReader(tmpPath);
        string tmpItem = sr.ReadToEnd();
        sr.Close();
        //将string类型信息转成jsondata
        JsonData itemJson = JsonMapper.ToObject(tmpItem);
        //将JsonData变成一个个的ItemData类型的格式
        foreach (JsonData item in itemJson)
        {
            int id = (int)item["id"];
            string name = (string)item["name"];
            string tmpType = (string)item["type"];
            string tmpQuality = (string)item["quality"];
            string describe = (string)item["describe"];
            int capacity = (int)item["capacity"];
            int buyPrice = (int)item["buyPrice"];
            int sellPrice = (int)item["sellPrice"];
            string path = (string)item["path"];
            //将string强转成枚举类型
            ItemData.ItemType type = (ItemData.ItemType)System.Enum.Parse(typeof(ItemData.ItemType), tmpType);
            ItemData.ItemQuality quality = (ItemData.ItemQuality)System.Enum.Parse(typeof(ItemData.ItemQuality), tmpQuality);
            ItemData newItem = null;
            //根据不同的类型提供不同的构造方法
            switch (type)
            {
                case ItemData.ItemType.Consumable:
                    int hp = (int)item["hp"];
                    int mp = (int)item["mp"];
                    newItem = new Consumable(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path, hp, mp);
                    items.Add(newItem);
                    break;
                case ItemData.ItemType.Equipment:
                    int defensive = (int)item["defensive"];
                    int maxHP = (int)item["maxHP"];
                    string tmpEquipType = (string)item["equipType"];
                    Equipment.EquipmentType equipType = (Equipment.EquipmentType)System.Enum.Parse(typeof(Equipment.EquipmentType), tmpEquipType);
                    newItem = new Equipment(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path, defensive, maxHP, equipType);
                    items.Add(newItem);
                    break;
                case ItemData.ItemType.Weapon:
                    int hurt = (int)item["hurt"];
                    newItem = new Weapon(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path, hurt);
                    items.Add(newItem);
                    break;
                case ItemData.ItemType.Material:
                    newItem = new Material(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path);
                    items.Add(newItem);
                    break;
            }

        }
    }
    #endregion

    #region 根据物品id或名称查找物品
    public ItemData GetItem(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID==id)
            {
                return items[i];
            }
        }
        Debug.LogWarning("查找的物品ID不存在");
        return null;
    }
    public ItemData GetItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Name == name)
            {
                return items[i];
            }
        }
        Debug.LogWarning("查找的物品名称不存在");
        return null;
    }
    #endregion
}
