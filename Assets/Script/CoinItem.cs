using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�ж��Ƿ���������ң����������ײ��������ǽ�����ײ�壬��Ϊ�����������ײ�壬�ֱ������ڲ�ͬ���ܣ�������ײ�������ж��ռ����� UnityEngine.CapsuleCollider2D�����ÿ�ݼ���ʾ�����Ȼ���ٷŵ���������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //�����˵Ļ������������1 ���þ�̬����ֱ���޸�
            CoinUI.CurrentCoinQuantity += 1;
            //���ż�������
            SoundManager.PlayPickCoinClip();

            //�����������ٵ�ǰ��Ҷ���Ҳ���Լ�һ�����𶯻�������������
            Destroy(gameObject);
        }
    }
}
