using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Texture2D blood;
    Vector3 birth;//中心点
    Vector3 movePoint;//巡逻目标点
    float moveX;
    float moveZ;
    int ran;
    int walkRange=8;//巡逻距离
    int attackRange;//检测攻击距离
    int thinkTime=2;
    float lastThinkTime;
    float distance;
    Rigidbody rgb;
    Transform player;
    HP LaoHu;
    Image hhhp;
    private void Start()
    {
        birth = transform.position;
        rgb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hhhp = GetComponentInChildren<Image>();
        LaoHu = new HP(100);
    }
    private void FixedUpdate()
    {
        distance = Vector3.Distance(player.position,transform.position);
        if (distance <= 8)
        {
            Vector3 zhuan = player.position - rgb.position;
            zhuan.y = 0;
            Quaternion dir = Quaternion.LookRotation(zhuan,Vector3.up);
            rgb.MoveRotation(Quaternion.Slerp(rgb.rotation, dir, 10 * Time.deltaTime));
            if (distance >= 2)
            { rgb.MovePosition(rgb.position + transform.forward * Time.deltaTime * 4); }
        }else if(distance>5)
        {
            if (Time.time - lastThinkTime > thinkTime)
            {
                lastThinkTime = Time.time;
                moveX = Random.Range(birth.x - walkRange, birth.x + walkRange);
                moveZ = Random.Range(birth.z - walkRange, birth.z + walkRange);
                ran = Random.Range(0, 3);
                //Debug.Log(ran);
            }
            movePoint = new Vector3(moveX,rgb.position.y, moveZ);
            Vector3 xunluozhuan = movePoint - rgb.position;
            xunluozhuan.y = 0;
            Quaternion xunluo;
            if (xunluozhuan != new Vector3(0, 0, 0))
            { xunluo = Quaternion.LookRotation(xunluozhuan); }
            else xunluo = Quaternion.LookRotation(rgb.transform.forward);
            switch (ran)
            {
                case 0:
                    //播放idle动画
                    Debug.Log(ran);
                    break;
                case 1:
                    rgb.MoveRotation(Quaternion.Slerp(rgb.rotation, xunluo, Time.deltaTime * 10));
                    rgb.MovePosition(Vector3.MoveTowards(rgb.position, movePoint, Time.deltaTime * 2));
                    Debug.Log("走"+ran);
                    break;
                case 2:
                    rgb.MoveRotation(Quaternion.Slerp(rgb.rotation, xunluo, Time.deltaTime * 10));
                    rgb.MovePosition(Vector3.MoveTowards(rgb.position, movePoint, Time.deltaTime * 4));
                    Debug.Log("跑"+ran);
                    break;
            }
        }
    }
    public void OnPlayerAttack(int hurt)
    {
        LaoHu.HPChange = hurt;
        Debug.Log("敌人生命值减少" + hurt + "，敌人剩余生命为" + LaoHu.HPChange);
        if (LaoHu.HPChange == 0)
        {
            Destroy(gameObject);
            Debug.Log("敌人死亡");
        }
    }
    private void OnGUI()
    {
        Vector3 ddd = Camera.main.WorldToScreenPoint(transform.position);
        GUI.DrawTexture(new Rect(ddd.x - 25, Screen.height - ddd.y - 50, LaoHu.HPChange /1.8f, 5), blood);
    }
}
