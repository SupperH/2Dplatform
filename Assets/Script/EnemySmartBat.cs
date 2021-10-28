using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{

    //速度
    public float speed;
    //蝙蝠的检测半径，玩家进入这个半径就会追击敌人
    public float radius;
    //角色坐标
    private Transform Playertransform;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        Playertransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {


        base.Update();
        //玩家的坐标不为空
        if (Playertransform != null)
        {
            //sqrMagnitude记录两点之间的距离 返回个float变量
            float distance = (transform.position - Playertransform.position).sqrMagnitude;
            //如果玩家和蝙蝠距离小于蝙蝠的检测半径，就追击玩家
            if (distance < radius)
            {
                Debug.Log("进入敌人范围");
                //MoveTowards从一个点往另一个点移动，第三个参数是速度
                transform.position = Vector2.MoveTowards(transform.position,Playertransform.position,speed * Time.deltaTime);
            }
        }
    }
}
