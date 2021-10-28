using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{

    //���ص�����
    public Transform backDoor;

    //�Ƿ�Ӵ���
    private bool isDoor;
    //�������
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        //�����ҵ�����
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //����Ӵ�����
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //����unity��ָ���ŵ�λ�ã���������ק�����ǶԷ��� ���������Զ����һ����
                playerTransform.position = backDoor.position;

            }
        }
    }



    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�жϣ�����Ӵ���tag��Ϊplayer,�ҽӴ�������ײ���ǽ����壨CapsuleCollider2D�ǽ�����ײ�򣬸���Ҽӵģ�
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //���Դ�
            isDoor = true;
        }
    }

    //������
    void OnTriggerExit2D(Collider2D collision)
    {
        //�뿪�ţ����ɴ�
        isDoor = false;
    }
}
