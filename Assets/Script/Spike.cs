using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    //伤害
    public int damage;

    //玩家生命值
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //根据tag获取玩家生命值的内容
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发器
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag名判断是否触碰到了玩家,且只有一个触发器碰到了才调用受伤函数，因为玩家由三个碰撞体组成，如果不这么做的话都碰到了会调多次受伤 所以要限制一下
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            //受伤
            playerHealth.DamagePlayer(damage);
        }
    }
}
