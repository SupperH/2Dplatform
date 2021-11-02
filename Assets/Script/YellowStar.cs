using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowStar : MonoBehaviour
{

    //用来设置随机掉落那些物品的数组
    public GameObject[] gos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenGift()
    {
        //获取随机游戏对象因为对象都放在数组里，直接用Random.Range随机数方法进行生成,然后在小星星的位置，生成
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        //删除当前小星星
        Destroy(gameObject);
    }
}
