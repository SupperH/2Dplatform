using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorToNextLevel : MonoBehaviour
{
    //图片组件，提示框
    public Image dialogBox;

    private bool isPlayerInSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerInSign)
        {

            //显示对话框
            dialogBox.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N");

            //获取当前活动的场景，然后+1就是到当前场景的下一个场景，注意要把场景拖到BuildSetting中 笔记有图
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        //根据tag判断，如果接触到tag名为player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("接触门");
            isPlayerInSign = true;


        }


    }

    //触发器 离开
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("离开门");

        //角色未接触
        isPlayerInSign = false;
        //关闭提示框
        dialogBox.gameObject.SetActive(false);

    }
}
