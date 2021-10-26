using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{

    //可以被打开的状态
    private bool canOpen;
    //判断是否被打开
    private bool isOpened;
    //动画组件
    private Animator anim;

    //宝箱掉落内容：这里在unity指定金币，可以让宝箱继承一个物体类，然后每个宝箱单独设置掉落内容。、
    public GameObject coin;
    //延迟掉落物体时间 因为要等宝箱开启才能掉落
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //宝箱默认没被打开
        isOpened = false;
    }



    // Update is called once per frame
    void Update()
    {
        //按下I键打开宝箱
        if (Input.GetKeyDown(KeyCode.I))
        {
            //如果宝箱状态是可以被打开，而且不是打开状态的话，设置宝箱打开动画
            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                //设置宝箱已经打开，后面就不能再反复打开了
                isOpened = true;
                //延迟调用生成金币
                Invoke("GetCoin",time);

            }
        }
    }


    void GetCoin()
    {
        //生成掉落物体--金币
        Instantiate(coin, transform.position, Quaternion.identity);
    }

    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断，如果接触到tag名为player,且接触到的碰撞体是胶囊体（CapsuleCollider2D是胶囊碰撞框，给玩家加的）就视为宝箱接触到玩家
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //可以打开
            canOpen = true;
        }
    }

    //触发器
    void OnTriggerExit2D(Collider2D collision)
    {
            //离开宝箱后，不可打开
            canOpen = false;
    }

}
