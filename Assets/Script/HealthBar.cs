using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //��Щ�����ǵ���Unity��ָ��
    //������ȡUI��Text����
    public Text healthText;
    //��¼��ǰѪ��ֵ ��̬�����������������
    public static int healthCurrent;
    //Ѫ�����ֵ
    public static int healthMax;

    //���UI��ͼ������
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //fillAmount,����Unity��Image�����Fill Amount����
        //Amount�����1���������������ǰѪ���������Ѫ����ôAmountΪ���ֵ����������
        healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
        //�޸�Ѫ���ϵ���Ϣ���� Ҳ�ǻ��Text�е�Text���ݽ����޸�
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
