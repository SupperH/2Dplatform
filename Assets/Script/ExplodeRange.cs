using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRange : MonoBehaviour
{


    //伤害值
    public int damage;
    //消失时间
    public float destroyTime;
    //玩家血量类
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //根据tag得到玩家对象，然后获得玩家对象下的PlayerHealth对象
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject,destroyTime);
        Debug.Log("生成范围"+transform.position);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //是否碰到敌人的tag，这个tag就是我们给敌人设置的tag名
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("碰到敌人");

            //这里用抽象类，和java一样 有多个敌人然后直接指定敌人父类就可以了，不同敌人的数值直接在untiy中找到对应自己的脚本，然后设值即可，和Java子类调用父类方法传不同参数一样
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }

        //根据tag判断，如果接触到tag名为player,且接触到的碰撞体是胶囊体（CapsuleCollider2D是胶囊碰撞框，给玩家加的）就视为攻击敌人
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("碰到玩家");
            //调用玩家受伤函数传入伤害
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);

            }

        }
    }
}
