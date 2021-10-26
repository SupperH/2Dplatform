using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrashBinCoin : MonoBehaviour
{

    //����Ͱ����ʾ��text
    public Text coinText;
    //��ǰ�������
    public static int coinCurrent;
    //���������
    public static int coinMax;
    //��ҽ�����
    private Image trashBinBar;

    // Start is called before the first frame update
    void Start()
    {
        trashBinBar = GetComponent<Image>();
        //��ʼ���
        coinCurrent = 0;
        //�����
        coinMax = 99;
    }

    // Update is called once per frame
    void Update()
    {
        //��Ѫ��һ����ͨ���ռ��������޸Ľ�����
        trashBinBar.fillAmount = (float)coinCurrent / (float)coinMax;
        //�޸���ʾ�Ľ������
        coinText.text = coinCurrent.ToString() + "/"+ coinMax.ToString();
    }
}
