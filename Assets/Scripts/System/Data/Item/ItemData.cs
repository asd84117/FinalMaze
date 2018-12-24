using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public int ID { get; set; }
    public string Name{ get;set;}
    public ItemType Type { get; set; } 
    //品质
    public ItemQuality Quality { get; set; }
    //描述
    public string Describe { get; set; }
    //容量
    public int Capacity { get; set; }
    //购买价格
    public int BuyPrice { get; set; }
    //出售价格
    public int SellPrice { get; set; }
    public enum ItemType
    {
        //消耗品
        Consumable,
        //装备
        Equipment,
        //武器
        Weapon,
        //材料
        Material
    }
    public enum ItemQuality
    {
        //普通
        Common,
        //良好
        Uncommon,
        //稀有
        Rare,
        //史诗
        Epic,
        //传说
        Legend
    }
    public string Path { get; set; }

    public ItemData(int id, string name, ItemType type, ItemQuality quality, string describe, int capacity, int buyPrice, int sellPrice, string path)
    {
        ID = id;
        Name = name;
        Type = type;
        Quality = quality;
        Describe = describe;
        Capacity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;

        Path = path;
    }
}

public class Consumable:ItemData
{
    public int HP { get; set; }
    public int MP { get; set; }

    public Consumable(int id, string name, ItemType type, ItemQuality quality, string describe, 
        int capacity, int buyPrice, int sellPrice, string path, int hp,int mp)
        :base(id,name,type,quality,describe,capacity,buyPrice,sellPrice,path)
    {
        HP = hp;
        MP = mp;
    }
}

public class Equipment:ItemData
{
    public int Defensive { get; set; }
    public int MaxHP { get; set; }
    public EquipmentType EquipType { get; set; }

    public enum EquipmentType
    {
        //头部
        Head,
        //上衣
        Jacket,
        //裤子
        Pants,
        //鞋子
        Shoes
    }

    public Equipment(int id, string name, ItemType type, ItemQuality quality, 
        string describe, int capacity, int buyPrice, int sellPrice, string path,int defensive,int maxHP,EquipmentType equipType)
        :base(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path)
    {
        Defensive = defensive;
        MaxHP = maxHP;
        EquipType = equipType;
    }
}

public class Weapon : ItemData
{
    public int Hurt { get; set; }


    public Weapon(int id, string name, ItemType type, ItemQuality quality,
        string describe, int capacity, int buyPrice, int sellPrice, string path, int hurt)
        : base(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path)
    {
        Hurt = hurt;
    }
}

public class Material:ItemData
{
    public Material(int id, string name, ItemType type, ItemQuality quality, string describe, int capacity, int buyPrice, int sellPrice, string path)
        : base(id, name, type, quality, describe, capacity, buyPrice, sellPrice, path)
    {

    }
}