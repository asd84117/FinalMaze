using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float ThinkTime = 2;
    float LastThinkTime;
    float MoveSpeed=4;
    Transform player;
    float distance=5;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,player.position) <= distance&& Vector3.Distance(transform.position, player.position)>=2)
        {
            //run动画

            transform.LookAt(player.position);
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }
        else
        {
            if(Time.time-LastThinkTime>ThinkTime)
            {
                LastThinkTime = Time.time;
                Debug.Log("开始");
                int ran = Random.Range(0, 4);
                switch (ran)
                {
                    case 1:
                        Debug.Log("开始000");
                        //播放idle动画
                        break;
                    case 2:
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, Random.Range(1, 5) * 90, 0), 8);
                        transform.Translate(Vector3.forward * Time.deltaTime * 3);
                        //播放walk动画
                        Debug.Log("开始111");
                        break;
                    case 3:
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, Random.Range(1, 5) * 90, 0), 8);
                        transform.Translate(Vector3.forward * Time.deltaTime * 5);
                        //播放run动画
                        Debug.Log("开始222");
                        break;
                }
            }
        }
    }
}
