using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    //���˸���
    private Rigidbody2D rb;
    //�ƶ�����������
    public Transform[] pos;
    //�ٶ�
    public float speed;
    //������ȡ���������xֵ
    private float x0;
    private float x1;

    //�Ƿ�����
    private bool faceRight = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //��Ϸ��ʼ��ȡ�õ㷶Χ��xֵ��������������ǵ����Ӷ���Ļ���������һ���ƶ� �޷������ж�
        x0 = pos[0].position.x;
        x1 = pos[1].position.x;
        
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        //��������ұ�
        if (faceRight)
        {
            //���ٶ�
            rb.velocity = new Vector2(speed, 0);
            //��������ƶ��ĵ㷶Χ
            if (transform.position.x > x0)
            {
                //localScale����ת�򣬶�Ӧtransform�е�scale ��unity��
                transform.localScale = new Vector3(-1, 1, 1);
                //������
                faceRight = false;

            }

        }
        //���������
        else
        {
            //�ٶ�Ϊ�����������������ң�������������
            rb.velocity = new Vector2(-speed, 0);
            //��������ƶ��ĵ㷶Χ
            if (transform.position.x < x1)
            {  
                //localScale����ת�򣬶�Ӧtransform�е�scale ��unity��
                transform.localScale = new Vector3(1, 1, 1);

                //������
                faceRight = true;
            }
        }


    }
}
