using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //玩家坐标，在unity中指定
    public Transform targes;
    //这个参数主要是让相机走的平滑一点，当作平滑因子
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        //游戏开始时就进行设置，因为这个是摄像头的父项目，其实就相当于给摄像头进行设置
        //通过设置的tag找到对应对象并获取其组件CameraShake赋给GameController的静态变量
        //这样就可以在任何地方直接使用了
        GameController.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //相机跟随不放在update中，放在LateUpdate中
    void LateUpdate()
    {
        //判断一下玩家是否死亡没死亡就跟随
        if (targes != null)
        {
            //如果相机的位置不等于玩家的位置
            if(transform.position != targes.position){
                Vector3 targePos = targes.position;
                //Lerp线性插值 第一个参数：起点坐标，第二个参数：终点坐标，第三个参数：起点去终点的时间
                //目的是让相机的坐标移动到玩家的位置
                transform.position = Vector3.Lerp(transform.position, targePos, smoothing);
            }
        }
    }
}
