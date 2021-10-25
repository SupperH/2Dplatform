using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    //图片组件，提示框
    public Image dialogBox;
    //文本组件，text
    public Text dialogBoxText;
    //文本框要显示的内容
    public string siginText;
    //是否接触招牌
    private bool isPlayerInSign;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果按下了键盘的E键，而且接触到提示框
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            //给文本赋值
            dialogBoxText.text = siginText;
            //显示对话框
            dialogBox.gameObject.SetActive(true);

        }
    }

    //触发器
     void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断是否碰到了玩家，而且这个碰撞体的类型是胶囊碰撞体，因为玩家有三个碰撞体，分别作用于不同功能，这里用胶囊碰撞体判断 UnityEngine.CapsuleCollider2D可以用快捷键提示打出来然后再放到引号里面
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //角色接触招牌
            isPlayerInSign = true;
        }
    }

    //触发器 离开
     void OnTriggerExit2D(Collider2D collision)
    {
        //角色未接触招牌
        isPlayerInSign = false;
        //关闭提示框
        dialogBox.gameObject.SetActive(false);

    }
}
