using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{

    //��ҳ�ʼ����
    public int startCoinQuantity;

    //UI��Text����
    public Text coinQuantity;

    //��ǰ������� ��̬�ģ��ⲿ�����ֱ�ӵ����޸�
    public static int CurrentCoinQuantity;

    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼ����ǰ����������ڳ�ʼ����
        CurrentCoinQuantity = startCoinQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        //�޸��ı�������Ϊ��ǰ�������
        coinQuantity.text = CurrentCoinQuantity.ToString();
    }
}
