using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //子弹对象
    public GameObject bullet;
    //枪口坐标
    public Transform muzzleTransform;
    //相机
    public Camera cam;
    //记录鼠标位置
    private Vector3 mousePos;
    //枪口方向
    private Vector2 gunDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //利用摄像头把屏幕坐标转换成世界坐标获得鼠标的坐标
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //设置枪口方向利用鼠标坐标减去对象坐标获得一个向量 normalized是单位向量只保留方向 长度为1
        gunDirection = (mousePos - transform.position).normalized;

        //计算枪口要旋转的角度  Atan2方法传入y和x坐标可以算出一个弧度值，然后通过乘以Mathf.Rad2Deg弧度转角度的常量就可以得到一个准确的角度值
        float angle = Mathf.Atan2(gunDirection.y , gunDirection.x) * Mathf.Rad2Deg;

        //把角度给枪
        transform.eulerAngles = new Vector3(0,0,angle);

        //如果点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            //生成子弹 在枪口的位置 用我们计算出的枪口旋转的角度，生成一颗子弹
            Instantiate(bullet,muzzleTransform.position,Quaternion.Euler(transform.eulerAngles));
        }
    }
}
