using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{

    //����ָ�������ڶ���
    public GameObject sickle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����U���������
        if (Input.GetKeyDown(KeyCode.U))
        {
            //����һ�������ڶ�������λ��Ϊ������� ���ǶȲ���Ĭ�ϵ� �û����ڱ���ĽǶȣ���Ϊ���Ǹ���������������ת�Ƕ�
            Instantiate(sickle, transform.position, transform.rotation);
        }
    }

}
