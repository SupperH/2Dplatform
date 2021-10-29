using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{


    //触发密码
    public string easterEggPassword;

    //可以被外部代码修改的当前密码
    public static string Password;

    //生成的对象 这里生成金币
    public GameObject coin;
    //生成数量
    public int coinQuantity;
    //生成速度
    public float coinUpSpeed;
    //生成时间
    public float intervalTime;
    // Start is called before the first frame update
    void Start()
    {
        Password = "";
    }

    // Update is called once per frame
    void Update()
    {
        //如果当前的彩蛋密码等于触发密码 就视为达成彩蛋触发条件
        if (Password == easterEggPassword)
        {
            Debug.Log("生成彩蛋");
            //生成后，重置彩蛋密码
            Password = "";
            StartCoroutine(GenCoins());
        }
    }

    //协程
    IEnumerator GenCoins()
    {
        //生成的时间间隔
        WaitForSeconds wait = new WaitForSeconds(intervalTime);
        for (int i = 0; i < coinQuantity; i++)
        {
            GameObject gb = Instantiate(coin, transform.position, Quaternion.identity);
            //向上生成,计算出方向，然后Random.Range在-0.3f, 0.3f之间随机生成一个x轴的位置当作x坐标
            Vector2 ve = new Vector2(Random.Range(-0.3f, 0.3f), 1.0f);
            //再给金币对象一个速度
            gb.GetComponent<Rigidbody2D>().velocity = ve * coinUpSpeed;
            //返回时间间隔
            yield return intervalTime;

        }
    }
}
