using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrashBinCoin : MonoBehaviour
{

    //垃圾桶上显示的text
    public Text coinText;
    //当前金币数量
    public static int coinCurrent;
    //最大金币数量
    public static int coinMax;
    //金币进度条
    private Image trashBinBar;

    // Start is called before the first frame update
    void Start()
    {
        trashBinBar = GetComponent<Image>();
        //初始金币
        coinCurrent = 0;
        //最大金币
        coinMax = 99;
    }

    // Update is called once per frame
    void Update()
    {
        //和血条一样，通过收集的数量修改进度条
        trashBinBar.fillAmount = (float)coinCurrent / (float)coinMax;
        //修改显示的金币数量
        coinText.text = coinCurrent.ToString() + "/"+ coinMax.ToString();
    }
}
