using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{

    //ը������קԤ����
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����o��ը��
        if (Input.GetKeyDown(KeyCode.O))
        {
            //����Ƕ�ָ������ӳ�ȥ�Ľǣ������������
            Instantiate(bomb,transform.position,transform.rotation);
        }
    }
}
