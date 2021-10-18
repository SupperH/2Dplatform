using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //伤害值
    public int damage;
    
    //用来获取动画组件
    private Animator animator;

    //多边形碰撞体积
    private PolygonCollider2D collider2D;

    //攻击完后攻击框消失时间
    public float disableTime;

    //攻击后攻击框启动时间
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        //获得对应目标的动画组件  FindGameObjectWithTag是根据tag名获取游戏组件，Player这个名字要自己设置，比如这里我们要获取Player的组件，所以要去unity选择Player把Player的tag设置一下
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Debug.Log("攻击");


            //设置动画的trigger变量
            animator.SetTrigger("Attack");

            //启动协程
            StartCoroutine(startAttack());
        }
    }

    //携程，打开攻击碰撞体
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(startTime);

        //把碰撞体设置为true，默认攻击的多边形碰撞体积是关闭的，只有攻击播放攻击动画的时候才会使用
        collider2D.enabled = true;
        //攻击后再开启关闭的携程
        //启动协程
        StartCoroutine(disableHitBox());
    }

    //协程,关闭攻击碰撞体
    IEnumerator disableHitBox()
    {
        //攻击完后让攻击框碰撞体消失
        yield return new WaitForSeconds(disableTime);
        collider2D.enabled = false;
    }

    //触发器，内置方法
     void OnTriggerEnter2D(Collider2D collision)
    {
        //是否碰到敌人的tag，这个tag就是我们给敌人设置的tag名
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //这里用抽象类，和java一样 有多个敌人然后直接指定敌人父类就可以了，不同敌人的数值直接在untiy中找到对应自己的脚本，然后设值即可，和Java子类调用父类方法传不同参数一样
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
