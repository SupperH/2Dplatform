using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{


    //回旋镖速度
    public float speed;
    //伤害
    public int damage;
    //旋转速度
    public float rotateSpeed;
    //微调参数
    public float tuning;
    //刚体
    private Rigidbody2D rb;
    //用来获取玩家的坐标
    private Transform playerTransform;
    //回旋镖坐标
    private Transform sickleTransform;
    //回旋镖初始速度
    private Vector2 startSpeed;
    //相机震动方法
    private CameraShake cameraShake;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //设置回旋镖初始速度
        rb.velocity = transform.right * speed;
        startSpeed = rb.velocity;
        //根据tag获取玩家对象的坐标组件
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //获取回旋镖自己本身的坐标组件
        sickleTransform = GetComponent<Transform>();
        //获得相机震动的组件
        cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate:旋转方法，这里是延z轴进行旋转
        transform.Rotate(0,0,rotateSpeed);
        //Lerp线性差值,让回旋镖的y轴跟着角色走然后插入微调的参数比如微调参数是0.1，那么就是根据百分之10 把回旋镖y坐标渐变到角色y坐标 ，可以是正数也可以是负数
        float y = Mathf.Lerp(transform.position.y,playerTransform.position.y,tuning);
        //把设置的y轴坐标赋给回旋镖的坐标体系
        transform.position = new Vector3(transform.position.x,y,0.0f);

        //让回旋镖飞回来，原理就是不断减小回旋镖在x轴的速度
        rb.velocity = rb.velocity - startSpeed * Time.deltaTime;
        //Mathf.Abs绝对值，因为可以往左和右飞，所以有可能距离是负数，所以用绝对值只要判断0.5就行 如果回旋镖和玩家坐标的距离小于0.5视为飞回来了 那么就要停止飞行
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f)
        {
            //飞回来后不显示回旋镖，也就是销毁对象
            Destroy(gameObject);
        }

    }

    //触发器 
    void OnTriggerEnter2D(Collider2D collision)
    {
        //根据tag判断如果碰到tag为enemy的话就视为碰到敌人，然后调用敌人的受伤方法 造成伤害
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
