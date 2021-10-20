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

    //摄像头能移动的最小位置坐标
    public Vector2 minPostion;
    //摄像头能移动的最大位置坐标
    public Vector2 maxPosition;
    void Start()
    {
        //游戏开始时就进行设置，因为这个是摄像头的父项目，其实就相当于给摄像头进行设置
        //通过设置的tag找到对应对象并获取其组件CameraShake赋给GameController的静态变量
        //这样就可以在任何地方直接使用了
        GameController.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
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
                //限定相机移动范围 第一个参数 要限定的对象 第二个参数起始值，第三个参数终止值
                targePos.x = Mathf.Clamp(targePos.x,minPostion.x,maxPosition.x);
                targePos.y = Mathf.Clamp(targePos.y, minPostion.y, maxPosition.y);

                //Lerp线性插值 第一个参数：起点坐标，第二个参数：终点坐标，第三个参数：起点去终点的时间
                //目的是让相机的坐标移动到玩家的位置
                transform.position = Vector3.Lerp(transform.position, targePos, smoothing);
            }
        }
    }
    //相机限制范围给其他人调用，因为每个场景的限制范围都不一样，所以要让后面的其他场景代码去调用设置摄像头范围
    public void SetCamPosLimit(Vector2 minPos,Vector2 maxPos)
    {
        //把其他类传入的参数赋值给最大最小
        minPostion = minPos;
        maxPosition = maxPos;
    }
}
