using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    //子弹类 代码和弓箭一样


    //速度
    public float speed;
    //伤害
    public int damage;
    //弓箭飞行距离
    public float destoryDis;
    //刚体
    private Rigidbody2D rb;
    //用来设置生成弓箭的初始坐标的
    private Vector3 ve;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //给刚体一个初始的速度，向右
        rb.velocity = transform.right * speed;
        //设置初始的坐标为弓箭生成的坐标
        ve = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //如果弓箭飞出去后目前的坐标减去初始坐标后，大于 那就视为飞行距离已经达到上限，销毁
        float disPos = (transform.position - ve).sqrMagnitude;
        if (disPos > destoryDis)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断如果碰到tag为enemy的话就视为碰到敌人，然后调用敌人的受伤方法 造成伤害
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //如果射到敌人，子弹就消失
            Destroy(gameObject);
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
