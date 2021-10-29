using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDestory : MonoBehaviour
{
    //判断当前蝙蝠生成的彩蛋密码
    public int batFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //只有当对象销毁才会调用的方法
    void OnDestroy()
    {
        //把当前的彩蛋密码加上当前蝙蝠生成的彩蛋密码
        EasterEgg.Password += batFlag.ToString();
    }
}
