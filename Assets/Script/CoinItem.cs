using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断是否碰到了玩家，而且这个碰撞体的类型是胶囊碰撞体，因为玩家有三个碰撞体，分别作用于不同功能，胶囊碰撞体用来判断收集对象 UnityEngine.CapsuleCollider2D可以用快捷键提示打出来然后再放到引号里面
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //碰到了的话，金币数量加1 调用静态变量直接修改
            CoinUI.CurrentCoinQuantity += 1;
            //播放捡金币声音
            SoundManager.PlayPickCoinClip();

            //捡起来后，销毁当前金币对象，也可以加一个捡起动画，再消除对象
            Destroy(gameObject);
        }
    }
}
