using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    //����ָ����������
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����k�������乭��
        if (Input.GetKeyDown(KeyCode.K))
        {
            //�Ƕ����Լ��ģ���Ȼֻ������ʼ�����ұ߷���
            Instantiate(arrow,transform.position, transform.rotation);
        }
    }
}
