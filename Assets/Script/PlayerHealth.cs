using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //玩家血量
    public int health;

    //闪烁次数
    public int Blinks;

    //闪烁时间
    public float time;

    //动画组件
    private Animator animator;

    //延迟调用角色死亡的时间参数
    public float dieTime;

    //Renderer组件，闪烁用
    private Renderer myRender;

    //屏幕闪烁组件
    private ScreenFlash screenFlash;

    //角色刚体，死亡的时候重力设为0
    private Rigidbody2D rigidbody2D;

    //玩家持续受伤冷却时间
    public float hitBox;

    //角色多边形碰撞体
    private PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        //每次进入游戏赋给血量条最大值和当前血量值为默认血量
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;

        myRender = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        screenFlash = GetComponent<ScreenFlash>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //角色受伤函数
    public void DamagePlayer(int damage)
    {
        //受伤调用屏幕闪烁
        screenFlash.FlashScreen();
        //扣血
        health -= damage;
        //有时候敌人攻击完血量可能小于0 这样会让血量条显示负数，这里做个判断
        if (health <0)
        {
            health = 0;
        }
        HealthBar.healthCurrent = health;

        //血量小于0，设置死亡动画
        if (health <= 0)
        {
            //死亡后把速度和重力设为0,重力看自己想法，如果想在空中死亡后不掉落到地面就不要设为0
            rigidbody2D.velocity = new Vector2(0,0);
            rigidbody2D.gravityScale = 0.0f;

            //当角色死亡，把存活条件设为false，此时角色无法进行任何操作
            GameController.isGameAlive = false;
            //角色死亡，设置死亡动画
            animator.SetTrigger("Die");
            //延迟调用角色死亡
            Invoke("KillPlayer", dieTime);
        }

        //受伤调用闪烁函数
        BlinkPlayer(Blinks, time);

        //这个代码就是禁用这个碰撞体,然后用协程，过一段时间调用重新打开碰撞体 达到踩在地刺持续扣血
        polygonCollider2D.enabled = false;
        StartCoroutine(ShowPlayerHitBox());
    }

    //玩家持续受伤
    IEnumerator ShowPlayerHitBox()
    {
        //受伤冷却时间到了重新启动碰撞体
        yield return new WaitForSeconds(hitBox);
        polygonCollider2D.enabled = true;
    }


    //销毁玩家
    void KillPlayer()
    {
        Destroy(gameObject);

    }


    //闪烁：（次数，时间）
    void BlinkPlayer(int numBlinks,float seconds)
    {
        //启动协程
        StartCoroutine(DoBlinks(numBlinks,seconds));
    }

    //协程
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        //循环闪烁
        for (int i =0; i < numBlinks*2; i++)
        {
            //render.enabled设为对应相反的值达到闪烁效果
            myRender.enabled = !myRender.enabled;

            //等待指定时间延迟后继续执行，也就是说等待闪烁时间达到后再进行下一次循环
            yield return new WaitForSeconds(seconds);
        }
        //闪烁完后，把render.enabled设回初始值
        myRender.enabled = true;
    }
}
