using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    //ͼƬ�������ʾ��
    public Image dialogBox;
    //�ı������text
    public Text dialogBoxText;
    //�ı���Ҫ��ʾ������
    public string siginText;
    //�Ƿ�Ӵ�����
    private bool isPlayerInSign;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��������˼��̵�E�������ҽӴ�����ʾ��
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            //���ı���ֵ
            dialogBoxText.text = siginText;
            //��ʾ�Ի���
            dialogBox.gameObject.SetActive(true);

        }
    }

    //������
     void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�ж��Ƿ���������ң����������ײ��������ǽ�����ײ�壬��Ϊ�����������ײ�壬�ֱ������ڲ�ͬ���ܣ������ý�����ײ���ж� UnityEngine.CapsuleCollider2D�����ÿ�ݼ���ʾ�����Ȼ���ٷŵ���������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //��ɫ�Ӵ�����
            isPlayerInSign = true;
        }
    }

    //������ �뿪
     void OnTriggerExit2D(Collider2D collision)
    {
        //��ɫδ�Ӵ�����
        isPlayerInSign = false;
        //�ر���ʾ��
        dialogBox.gameObject.SetActive(false);

    }
}
