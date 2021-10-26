using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{

    //���Ա��򿪵�״̬
    private bool canOpen;
    //�ж��Ƿ񱻴�
    private bool isOpened;
    //�������
    private Animator anim;

    //����������ݣ�������unityָ����ң������ñ���̳�һ�������࣬Ȼ��ÿ�����䵥�����õ������ݡ���
    public GameObject coin;
    //�ӳٵ�������ʱ�� ��ΪҪ�ȱ��俪�����ܵ���
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //����Ĭ��û����
        isOpened = false;
    }



    // Update is called once per frame
    void Update()
    {
        //����I���򿪱���
        if (Input.GetKeyDown(KeyCode.I))
        {
            //�������״̬�ǿ��Ա��򿪣����Ҳ��Ǵ�״̬�Ļ������ñ���򿪶���
            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                //���ñ����Ѿ��򿪣�����Ͳ����ٷ�������
                isOpened = true;
                //�ӳٵ������ɽ��
                Invoke("GetCoin",time);

            }
        }
    }


    void GetCoin()
    {
        //���ɵ�������--���
        Instantiate(coin, transform.position, Quaternion.identity);
    }

    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�жϣ�����Ӵ���tag��Ϊplayer,�ҽӴ�������ײ���ǽ����壨CapsuleCollider2D�ǽ�����ײ�򣬸���Ҽӵģ�����Ϊ����Ӵ������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //���Դ�
            canOpen = true;
        }
    }

    //������
    void OnTriggerExit2D(Collider2D collision)
    {
            //�뿪����󣬲��ɴ�
            canOpen = false;
    }

}
