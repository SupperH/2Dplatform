using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{

    //金币初始数量
    public int startCoinQuantity;

    //UI的Text对象
    public Text coinQuantity;

    //当前金币数量 静态的，外部类可以直接调用修改
    public static int CurrentCoinQuantity;

    // Start is called before the first frame update
    void Start()
    {
        //游戏开始，当前金币数量等于初始数量
        CurrentCoinQuantity = startCoinQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        //修改文本框内容为当前金币数量
        coinQuantity.text = CurrentCoinQuantity.ToString();
    }
}
