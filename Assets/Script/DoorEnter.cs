using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{

    //返回的坐标
    public Transform backDoor;

    //是否接触门
    private bool isDoor;
    //玩家坐标
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        //获得玩家的坐标
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果接触到门
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //传到unity中指定门的位置，两个门拖拽对象都是对方的 所以这个永远是另一个门
                playerTransform.position = backDoor.position;

            }
        }
    }



    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断，如果接触到tag名为player,且接触到的碰撞体是胶囊体（CapsuleCollider2D是胶囊碰撞框，给玩家加的）
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //可以打开
            isDoor = true;
        }
    }

    //触发器
    void OnTriggerExit2D(Collider2D collision)
    {
        //离开门，不可打开
        isDoor = false;
    }
}
