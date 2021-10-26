using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinItem : MonoBehaviour
{

    //是否接触垃圾桶
    private bool isPlayerInTranshBin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下键盘Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //如果接触到了垃圾桶
            if (isPlayerInTranshBin)
            {
                //获得金币UI中的当前金币参数，如果大于0：
                if (CoinUI.CurrentCoinQuantity > 0)
                {
                    //播放丢金币声音
                    SoundManager.PlayThrowClip();
                    //增加垃圾桶的金币，减少UI中当前金币数量
                    TrashBinCoin.coinCurrent++;
                    CoinUI.CurrentCoinQuantity--;
                }

            }
        }
    }

    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断是否碰到了玩家，而且这个碰撞体的类型是胶囊碰撞体，因为玩家有三个碰撞体，分别作用于不同功能，这里用胶囊碰撞体判断 UnityEngine.CapsuleCollider2D可以用快捷键提示打出来然后再放到引号里面
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //角色接触垃圾桶
            isPlayerInTranshBin = true;
        }
    }

    //触发器 离开
    void OnTriggerExit2D(Collider2D collision)
    {
        //角色未接触垃圾桶
        isPlayerInTranshBin = false;

    }
}
