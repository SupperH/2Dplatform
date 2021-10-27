using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{

    //炸弹，拖拽预制体
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下o扔炸弹
        if (Input.GetKeyDown(KeyCode.O))
        {
            //这里角度指定玩家扔出去的角，否则会有问题
            Instantiate(bomb,transform.position,transform.rotation);
        }
    }
}
