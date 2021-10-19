using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //������꣬��unity��ָ��
    public Transform targes;
    //���������Ҫ��������ߵ�ƽ��һ�㣬����ƽ������
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼʱ�ͽ������ã���Ϊ���������ͷ�ĸ���Ŀ����ʵ���൱�ڸ�����ͷ��������
        //ͨ�����õ�tag�ҵ���Ӧ���󲢻�ȡ�����CameraShake����GameController�ľ�̬����
        //�����Ϳ������κεط�ֱ��ʹ����
        GameController.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //������治����update�У�����LateUpdate��
    void LateUpdate()
    {
        //�ж�һ������Ƿ�����û�����͸���
        if (targes != null)
        {
            //��������λ�ò�������ҵ�λ��
            if(transform.position != targes.position){
                Vector3 targePos = targes.position;
                //Lerp���Բ�ֵ ��һ��������������꣬�ڶ����������յ����꣬���������������ȥ�յ��ʱ��
                //Ŀ����������������ƶ�����ҵ�λ��
                transform.position = Vector3.Lerp(transform.position, targePos, smoothing);
            }
        }
    }
}
