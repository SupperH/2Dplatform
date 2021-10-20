using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //这些变量记得在Unity中指定
    //用来获取UI的Text内容
    public Text healthText;
    //记录当前血量值 静态变量方便其他类访问
    public static int healthCurrent;
    //血量最大值
    public static int healthMax;

    //获得UI的图像内容
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //fillAmount,就是Unity中Image里面的Fill Amount属性
        //Amount最大是1，做除法，如果当前血量等于最大血量那么Amount为最大值，依此类推
        healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
        //修改血条上的信息内容 也是获得Text中的Text内容进行修改
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
