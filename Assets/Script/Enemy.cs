using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //这两个值放在父类，子类继承了父类后这些变量在对应单位的脚本下面都会有显示，可以在unity中进行不同的设置
    //敌人伤害值
    public int damage;
    //血量
    public int health;


    //获得SpriteRenderer组件
    private SpriteRenderer sprite;

    //原始颜色
    private Color originalColor;

    //闪烁时间
    public float flashTime;

    // Start is called before the first frame update
    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //把原始颜色先赋给变量
        originalColor = sprite.color;
    }

    // Update is called once per frame
    public void Update()
    {
        //如果敌人血量小于0，销毁当前游戏对象
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //敌人受伤
    public void TakeDamage(int damage)
    {
        //每次调用这个方法，敌人就受到传入伤害值的伤害
        health -= damage;
        //敌人受伤后闪烁
        FlashColor(flashTime);
    }

    //受伤后闪烁
    //time:闪烁时间
    void FlashColor(float time)
    {
        //设置红色闪烁
        sprite.color = Color.red;

        //延迟调用重置颜色的方法,延迟的时间根据闪烁时间来定
        Invoke("ResetColor", time);
    }

    //重置颜色
    void ResetColor()
    {
        sprite.color = originalColor;
    }
}
