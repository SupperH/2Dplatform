using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{

    private BoxCollider2D bx2D;
    private Animator anim;    // Start is called before the first frame update
    void Start()
    {
        bx2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag���ж��Ƿ����������
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("Collapse");

        }
    }

    //�ر���ײ�� �ö����¼�����
    void enabledOffPlatform()
    {
        //�ر���ײ�壬��ʵ���ǰ�unityָ������Ĺ���ȥ��
        bx2D.enabled = false;
    }

    //������ײ�� �ö����¼�����
    void DestoryPlatform()
    {
        //������������������ײ��
        Destroy(gameObject);
    }
}
