using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitMap : MonoBehaviour {
    Vector3 pos;
    Vector2 litMap;
    float posX;
    float posY;
    RectTransform Map;
    public Terrain plan;
    GameObject player;
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        Map = transform.parent.GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        pos = player.transform.position - plan.transform.position;
        posX = pos.x / plan.terrainData.size.x;
        posY = pos.z / plan.terrainData.size.z;
        litMap.x = posX * Map.sizeDelta.x;
        litMap.y = posY * Map.sizeDelta.y;
        transform.localPosition = litMap;
	}
}
