using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    //平台移动速度
    public float speed;
    //等待时间
    public float waitTime;
    //移动位置数组
    public Transform[] movePos;
    //用来指定数组的参数
    private int i;

    //角色默认层次关系
    private Transform playerDefTransform;

    // Start is called before the first frame update
    void Start()
    {
        //一开始默认取第二个参数，也就是我们在unity给平台设置的移动点中的右点
        i = 1;
        //获得角色的层次内容给默认值
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //移动方法，第一个参数 初始位置，第二个参数目标位置，第三个参数速度
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);

        //如果当前位置和我们要移动到的位置小于0.1 就认为移动到指定点了
        if (Vector2.Distance(transform.position,movePos[i].position) < 0.1f)
        {
            //如果等待时间小于0，就说明该往反方向移动了
            if (waitTime <0.0f)
            {
                //如果目前取的是第一个参数，也就是左点
                if (i ==0)
                {
                    //把i改为1 去取第二个参数，也就是右点坐标
                    i = 1;
                }
                //反之
                else
                {
                    i = 0;
                }
                //重新设置等待时间
                waitTime = 0.5f;
            }
            //如果等待时间大于0，就让时间慢慢减小
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //触发器, 进来
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            //检测玩家和玩家指定碰撞体
            if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
            //修改层次关系，把玩家变为当前游戏对象平台子对象，达到站在上面一起移动的效果
            collision.gameObject.transform.parent = gameObject.transform;
            }
        }

    //触发器,角色为触发器 离开
    void OnTriggerExit2D(Collider2D collision)
    {
        //角色离开平台，恢复原来层次关系

        //检测玩家和玩家指定碰撞体
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            collision.gameObject.transform.parent = playerDefTransform;
        }
    }
}
