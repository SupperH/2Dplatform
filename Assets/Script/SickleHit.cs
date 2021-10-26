using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{

    //用来指定回旋镖对象
    public GameObject sickle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下U发射回旋镖
        if (Input.GetKeyDown(KeyCode.U))
        {
            //生成一个回旋镖对象，生成位置为玩家坐标 ，角度不用默认的 用回旋镖本身的角度，因为我们给回旋镖设置了旋转角度
            Instantiate(sickle, transform.position, transform.rotation);
        }
    }

}
