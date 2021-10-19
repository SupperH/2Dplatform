using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    //设置主摄像头动画，在unity中把Main Camera托给变量
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //抖动函数，公开，在敌人受伤的位置调用
    public void Shake()
    {
        //设置动画调用条件
        camAnim.SetTrigger("Shake");
    }
}
