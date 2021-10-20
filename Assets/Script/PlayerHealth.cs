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
    // Start is called before the first frame update
    void Start()
    {
        //每次进入游戏赋给血量条最大值和当前血量值为默认血量
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;

        myRender = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //角色受伤函数
    public void DamagePlayer(int damage)
    {
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
            //角色死亡，设置死亡动画
            animator.SetTrigger("Die");
            //延迟调用角色死亡
            Invoke("KillPlayer", dieTime);
        }

        //受伤调用闪烁函数
        BlinkPlayer(Blinks, time);
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
