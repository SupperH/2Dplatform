using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{

    //蝙蝠移动的速度
    public float speed;
    //等待时间
    public float startWaitTime;
    private float waitTime;

    //transform属性 对应的就是Inspector窗口的transform属性，主要是用来设置坐标的 这里当作下一次要移动的位置
    public Transform movePos;

    //飞行的范围 左下角右上角
    public Transform leftDownPos, rightUpPos;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        //把公开的变量赋给私有变量，waitTime是代码里面逻辑处理用，startWaitTime是在unity中定死的数据
        waitTime = startWaitTime;
        //给下一次要移动的位置设置坐标
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        //执行父类的update
        base.Update();
        //MoveTowards （当前位置，目标位置，移动速度）
        //transform.position当前绑定对象的坐标,让当前对象的坐标移动到MoveTowards设置的目标位置
        //关于Time.deltaTime请看笔记：在1秒内，刷新了N帧，但是每帧的时间是不固定的，所以Unity用Time.deltatime表示每1帧所花费的时间。
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,speed * Time.deltaTime);

        //Distance：判断前一个参数和后一个参数的距离，如果距离小于0.1就视为当前绑定对象已经移动到了我们随机设置的坐标
        if (Vector2.Distance(transform.position,movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                //给下一次要移动的位置设置坐标
                movePos.position = GetRandomPos();
                //刷新等待时间
                waitTime = startWaitTime;
            }
            else
            {
                //到达位置后，蝙蝠停留的时间
                //相当于 waitTime = waitTime - Time.deltaTime;
                //关于Time.deltaTime请看笔记：在1秒内，刷新了N帧，但是每帧的时间是不固定的，所以Unity用Time.deltatime表示每1帧所花费的时间。
                waitTime -= Time.deltaTime;
            }
        }
    }

    //获取随机位置
    Vector2 GetRandomPos()
    {
        //获得一个随机坐标，随机的范围就是我们定义的左下角到右上角内任意位置
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
