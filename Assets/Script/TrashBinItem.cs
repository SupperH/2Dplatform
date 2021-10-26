using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinItem : MonoBehaviour
{

    //�Ƿ�Ӵ�����Ͱ
    private bool isPlayerInTranshBin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���¼���Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //����Ӵ���������Ͱ
            if (isPlayerInTranshBin)
            {
                //��ý��UI�еĵ�ǰ��Ҳ������������0��
                if (CoinUI.CurrentCoinQuantity > 0)
                {
                    //���Ŷ��������
                    SoundManager.PlayThrowClip();
                    //��������Ͱ�Ľ�ң�����UI�е�ǰ�������
                    TrashBinCoin.coinCurrent++;
                    CoinUI.CurrentCoinQuantity--;
                }

            }
        }
    }

    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�ж��Ƿ���������ң����������ײ��������ǽ�����ײ�壬��Ϊ�����������ײ�壬�ֱ������ڲ�ͬ���ܣ������ý�����ײ���ж� UnityEngine.CapsuleCollider2D�����ÿ�ݼ���ʾ�����Ȼ���ٷŵ���������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //��ɫ�Ӵ�����Ͱ
            isPlayerInTranshBin = true;
        }
    }

    //������ �뿪
    void OnTriggerExit2D(Collider2D collision)
    {
        //��ɫδ�Ӵ�����Ͱ
        isPlayerInTranshBin = false;

    }
}
