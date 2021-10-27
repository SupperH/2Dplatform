using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //炸弹初始速度
    public Vector2 startSpeed;
    //刚体
    private Rigidbody2D rb;
    //动画控制器组件
    private Animator anim;

    //延迟时间
    public float delayExtime;
    //销毁时间
    public float destroytime;
    //炸弹爆炸范围 在unity指定爆炸范围对象
    public GameObject range;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //初始速度模拟扔出去的曲线
        rb.velocity = transform.right * startSpeed.x + transform.up * startSpeed.y;

        //延迟调用爆炸
        Invoke("Explode",delayExtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //爆炸
    void Explode()
    {
        anim.SetTrigger("Explode");
        //销毁炸弹延迟等炸弹炸弹完在销毁
        Destroy(gameObject, destroytime);
    }

    void GetExplosionRange()
    {
        //在炸弹掉落位置，生成爆炸范围伤害
        Instantiate(range,transform.position,Quaternion.identity);
        Debug.Log("爆炸"+transform.position);
        Debug.Log("爆炸range" + range.transform.position);

    }

}
