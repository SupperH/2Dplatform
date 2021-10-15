using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移动速度
    public float runSpeed;

    //获得刚体类以进行移动
    private Rigidbody2D Rigidbody2D;

    //动画组件
    private Animator animator;

    //游戏一开始就会执行的方法
    void Start()
    {
        //游戏一开始就获得组件并赋予我们定义的变量
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // 游戏运行时每一帧都会执行的方法，移动放在里面
    void Update()
    {
        Flip();
        Run();

    }

    //翻转角色
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(Rigidbody2D.velocity.x) > Mathf.Epsilon;

        //如果有速度 就判断是否翻转
        if (playerHasXAxisSpeed)
        {
            //向左x轴是增加也就是说会大于0 所以这里用x轴的力大于0.1 判断向左
            if (Rigidbody2D.velocity.x > 0.1f)
            {
                //默认向左不需要翻转，所以参数都是0
                //这里就是获取角色的transform值，在Inspector窗口上面就可以看到 Position是角色坐标，Rotation控制角色朝对应轴旋转多少 可以用来设置翻转角色
                //Quaternion.Euler返回一个旋转，它围绕 z 轴旋转 z 度、围绕 x 轴旋转 x 度、围绕 y 轴旋转 y 度（按该顺序应用）。
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            //向右和向左反着来
            if (Rigidbody2D.velocity.x < -0.1f)
            {
                //默认向左不需要翻转，所以参数都是0
                //角色左右翻转是围绕Y轴做旋转，并不是围绕X轴，围绕X轴是上下翻转，这里千万不要搞混了
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
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

        //mathf：C#中的计算函数 这里判断玩家是否有x轴的力，如果有就说明不是静止的在移动那么后面就可以用这个来判断是否切换移动动画
        //这里用大于Mathf.Epsilon而不是大于0 Mathf.Epsilon是一个非常非常小的值
        bool playerHasXAxisSpeed = Mathf.Abs(Rigidbody2D.velocity.x) > Mathf.Epsilon;
        //给我们在unity中动画切换的条件参数赋值，第一个参数就是我们在Animator窗口设置的参数名，第二个就传需要的值，bool是setbool其他参数的set方法名大同小异
        animator.SetBool("Run",playerHasXAxisSpeed);


    }
}
