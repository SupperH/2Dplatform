using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移动速度
    public float runSpeed;
    //跳跃速度
    public float jumpSpeed;
    //二段跳速度
    public float doubleJumpSpeed;

    //获得角色刚体类以进行移动
    private Rigidbody2D rigidbody2D;

    //获取角色的box碰撞体积
    private BoxCollider2D myfeet;

    //判断是否是地面
    private bool isGround;

    //动画组件
    private Animator animator;

    //判断是否二段跳
    private bool canDoubleJump;
    //游戏一开始就会执行的方法
    void Start()
    {
        //游戏一开始就获得组件并赋予我们定义的变量
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myfeet = GetComponent<BoxCollider2D>();
    }

    // 游戏运行时每一帧都会执行的方法，移动放在里面
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGrounded();
        SwitchAnimation();
        //Attack();

    }

    //翻转角色
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;

        //如果有速度 就判断是否翻转
        if (playerHasXAxisSpeed)
        {
            //向左x轴是增加也就是说会大于0 所以这里用x轴的力大于0.1 判断向左
            if (rigidbody2D.velocity.x > 0.1f)
            {
                //默认向左不需要翻转，所以参数都是0
                //这里就是获取角色的transform值，在Inspector窗口上面就可以看到 Position是角色坐标，Rotation控制角色朝对应轴旋转多少 可以用来设置翻转角色
                //Quaternion.Euler返回一个旋转，它围绕 z 轴旋转 z 度、围绕 x 轴旋转 x 度、围绕 y 轴旋转 y 度（按该顺序应用）。
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            //向右和向左反着来
            if (rigidbody2D.velocity.x < -0.1f)
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
        Vector2 playerVel = new Vector2(moveDir*runSpeed, rigidbody2D.velocity.y);
        //把设定好的速度赋给刚体变量，让角色移动
        rigidbody2D.velocity = playerVel;

        //mathf：C#中的计算函数 这里判断玩家是否有x轴的力，如果有就说明不是静止的在移动那么后面就可以用这个来判断是否切换移动动画
        //这里用大于Mathf.Epsilon而不是大于0 Mathf.Epsilon是一个非常非常小的值
        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        //给我们在unity中动画切换的条件参数赋值，第一个参数就是我们在Animator窗口设置的参数名，第二个就传需要的值，bool是setbool其他参数的set方法名大同小异
        animator.SetBool("Run",playerHasXAxisSpeed);


    }

    //跳跃
    void Jump()
    {
        //如果按下跳跃按钮 这里放入Jump是有根据的 不是随便放的 在unity中的Edit点击ProjectSettings点击Input，打开Axes可以看到Jump 这个代码就是获取这里的参数，
        //这个页面也可以看到Jump绑定的按键，可以自行修改
        if (Input.GetButtonDown("Jump"))
        {
            //如果接触地面，才能跳跃
            if (isGround)
            {
                 //设置跳跃条件
                animator.SetBool("Jump",true);
                //跳跃只是y轴变化，所以x速度设置为0，y轴设置我们定义的变量，在unity设置初始值
                Vector2 jumpvel = new Vector2(0.0f, jumpSpeed);
                //把设置好的参数赋予角色刚体,设置跳跃 ，Vector2.up是Vector2(0, 1)的简单写法
                rigidbody2D.velocity = Vector2.up * jumpvel;
                //一段跳后可以二段跳
                canDoubleJump = true;
            }
            else
            {
                   //如果不在地面，就判断是否可以二段跳
                if (canDoubleJump)
                {
                    //设置二段跳跃条件
                    animator.SetBool("DoubleJump", true);
                    //设置二段跳速度
                    Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed);
                    rigidbody2D.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }


         }
    }

    //攻击
    /*  void Attack()
       {
           if (Input.GetButtonDown("Attack"))
           {
               Debug.Log("攻击");
               //设置动画的trigger变量
               animator.SetTrigger("Attack");
           }
      } */

    //检测是否接触地面
    void CheckGrounded()
    {
        //IsTouchingLayers：判断是否接触定义的图层，谁调用就拿谁去判断，因为这个类是角色类绑定在角色身上，所以是判断角色是否和对应图层接触
        //LayerMask.GetMask("Ground") 根据图层名获取对应图层 Ground就是我们给地面定义的图层，然后给地面选中图层后，如果角色接触到地面就会返回true
        isGround = myfeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }

    //切换动画
    void SwitchAnimation()
    {
        //默认idle为false
        animator.SetBool("Idle",false);
        //判断跳跃参数是否为true
        if (animator.GetBool("Jump"))
        {
            //根据y轴的速度判断 上升的话y轴速度是正数，如果下降那么y轴速度会变为负数 所以我们根据速度判断是否正在下落
            if(rigidbody2D.velocity.y < 0.0f){
                //给下落动画的条件赋值
                animator.SetBool("Jump", false);
                animator.SetBool("Fall",true);
            }
        }
        //如果接触到地面
        else if (isGround)
        {
            //设置下落转换站立的动画条件
            animator.SetBool("Fall",false);
            animator.SetBool("Idle",true);
        }



        //二段跳
        //判断跳跃参数是否为true
        if (animator.GetBool("DoubleJump"))
        {
            //根据y轴的速度判断 上升的话y轴速度是正数，如果下降那么y轴速度会变为负数 所以我们根据速度判断是否正在下落
            if (rigidbody2D.velocity.y < 0.0f)
            {
                //给下落动画的条件赋值
                animator.SetBool("DoubleJump", false);
                animator.SetBool("DoubleFall", true);
            }
        }
        //如果接触到地面
        else if (isGround)
        {
            //设置下落转换站立的动画条件
            animator.SetBool("DoubleFall", false);
            animator.SetBool("Idle", true);
        }
    }
}


