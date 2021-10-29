using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{

    private BoxCollider2D bx2D;
    private Animator anim;    // Start is called before the first frame update
    void Start()
    {
        bx2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag名判断是否触碰到了玩家
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("Collapse");

        }
    }

    //关闭碰撞体 用动画事件调用
    void enabledOffPlatform()
    {
        //关闭碰撞体，其实就是把unity指定组件的勾给去掉
        bx2D.enabled = false;
    }

    //销毁碰撞体 用动画事件调用
    void DestoryPlatform()
    {
        //动画播放完再销毁碰撞体
        Destroy(gameObject);
    }
}
