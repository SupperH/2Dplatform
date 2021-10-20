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

    //����ͷ���ƶ�����Сλ������
    public Vector2 minPostion;
    //����ͷ���ƶ������λ������
    public Vector2 maxPosition;
    void Start()
    {
        //��Ϸ��ʼʱ�ͽ������ã���Ϊ���������ͷ�ĸ���Ŀ����ʵ���൱�ڸ�����ͷ��������
        //ͨ�����õ�tag�ҵ���Ӧ���󲢻�ȡ�����CameraShake����GameController�ľ�̬����
        //�����Ϳ������κεط�ֱ��ʹ����
        GameController.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
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
                //�޶�����ƶ���Χ ��һ������ Ҫ�޶��Ķ��� �ڶ���������ʼֵ��������������ֵֹ
                targePos.x = Mathf.Clamp(targePos.x,minPostion.x,maxPosition.x);
                targePos.y = Mathf.Clamp(targePos.y, minPostion.y, maxPosition.y);

                //Lerp���Բ�ֵ ��һ��������������꣬�ڶ����������յ����꣬���������������ȥ�յ��ʱ��
                //Ŀ����������������ƶ�����ҵ�λ��
                transform.position = Vector3.Lerp(transform.position, targePos, smoothing);
            }
        }
    }
    //������Ʒ�Χ�������˵��ã���Ϊÿ�����������Ʒ�Χ����һ��������Ҫ�ú����������������ȥ������������ͷ��Χ
    public void SetCamPosLimit(Vector2 minPos,Vector2 maxPos)
    {
        //�������ഫ��Ĳ�����ֵ�������С
        minPostion = minPos;
        maxPosition = maxPos;
    }
}
