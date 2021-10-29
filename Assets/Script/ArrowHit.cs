using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    //用来指定弓箭对象
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下k键，发射弓箭
        if (Input.GetKeyDown(KeyCode.K))
        {
            //角度用自己的，不然只会往初始方向右边发射
            Instantiate(arrow,transform.position, transform.rotation);
        }
    }
}
