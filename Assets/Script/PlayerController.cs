using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移动速度
    public float runSpeed;

    //获得刚体类以进行移动
    private Rigidbody2D Rigidbody2D;

    //游戏一开始就会执行的方法
    void Start()
    {
        //游戏一开始就获得组件并赋予我们定义的变量
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // 游戏运行时每一帧都会执行的方法，移动放在里面
    void Update()
    {
        Run();
    }

    //移动
    void Run(){
        // 在unity里面的edit的Project settings里的input manager选项打开axis可以看到Horizontal
        //实际上这段代码就是获取配置 
        //-1代表向左，1代表向右，0代表不动 默认是a=-1 d=1
        float moveDir = Input.GetAxis("Horizontal");

        //给玩家设定速度，使用Vector2这个类和vector3的区别就是一个是2d一个是3d，用3也可以只要把z轴速度设置为0就行
        //x轴速度就是移动方向*移动速度，y轴方向就取默认的原速度就行
        Vector2 playerVel = new Vector2(moveDir*runSpeed,Rigidbody2D.velocity.y);
        //把设定好的速度赋给刚体变量，让角色移动
        Rigidbody2D.velocity = playerVel;
    }
}
