using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    //UI--image组件
    public Image img;
    //闪烁时间
    public float time;
    //闪烁颜色
    public Color flashColor;

    //默认颜色
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        //游戏开始默认颜色等于我们图片设置的颜色
        defaultColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //屏幕闪烁
    public void FlashScreen()
    {
        //调用协程
        StartCoroutine(Flash());
    }

    //协程
    IEnumerator Flash()
    {
        //设置图片颜色
        img.color = flashColor;
        //等待设置的时间后，再把图片颜色设置回默认颜色达到闪烁效果
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }
}
