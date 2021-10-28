using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{

    //�ٶ�
    public float speed;
    //����ļ��뾶����ҽ�������뾶�ͻ�׷������
    public float radius;
    //��ɫ����
    private Transform Playertransform;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        Playertransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {


        base.Update();
        //��ҵ����겻Ϊ��
        if (Playertransform != null)
        {
            //sqrMagnitude��¼����֮��ľ��� ���ظ�float����
            float distance = (transform.position - Playertransform.position).sqrMagnitude;
            //�����Һ��������С������ļ��뾶����׷�����
            if (distance < radius)
            {
                Debug.Log("������˷�Χ");
                //MoveTowards��һ��������һ�����ƶ����������������ٶ�
                transform.position = Vector2.MoveTowards(transform.position,Playertransform.position,speed * Time.deltaTime);
            }
        }
    }
}
