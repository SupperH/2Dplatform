using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    //敌人刚体
    private Rigidbody2D rb;
    //移动的左右坐标
    public Transform[] pos;
    //速度
    public float speed;
    //用来获取左右坐标的x值
    private float x0;
    private float x1;

    //是否向右
    private bool faceRight = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //游戏开始获取好点范围的x值，否则如果坐标是敌人子对象的话会跟随敌人一起移动 无法进行判断
        x0 = pos[0].position.x;
        x1 = pos[1].position.x;
        
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        //如果面向右边
        if (faceRight)
        {
            //正速度
            rb.velocity = new Vector2(speed, 0);
            //如果超出移动的点范围
            if (transform.position.x > x0)
            {
                //localScale设置转向，对应transform中的scale 在unity中
                transform.localScale = new Vector3(-1, 1, 1);
                //面向左
                faceRight = false;

            }

        }
        //如果面向左
        else
        {
            //速度为反方向，正方向是向右，反方向是向左
            rb.velocity = new Vector2(-speed, 0);
            //如果超出移动的点范围
            if (transform.position.x < x1)
            {  
                //localScale设置转向，对应transform中的scale 在unity中
                transform.localScale = new Vector3(1, 1, 1);

                //面向右
                faceRight = true;
            }
        }


    }
}
