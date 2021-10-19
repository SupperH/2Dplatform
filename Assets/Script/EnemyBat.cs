using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{

    //�����ƶ����ٶ�
    public float speed;
    //�ȴ�ʱ��
    public float startWaitTime;
    private float waitTime;

    //transform���� ��Ӧ�ľ���Inspector���ڵ�transform���ԣ���Ҫ��������������� ���ﵱ����һ��Ҫ�ƶ���λ��
    public Transform movePos;

    //���еķ�Χ ���½����Ͻ�
    public Transform leftDownPos, rightUpPos;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        //�ѹ����ı�������˽�б�����waitTime�Ǵ��������߼������ã�startWaitTime����unity�ж���������
        waitTime = startWaitTime;
        //����һ��Ҫ�ƶ���λ����������
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        //ִ�и����update
        base.Update();
        //MoveTowards ����ǰλ�ã�Ŀ��λ�ã��ƶ��ٶȣ�
        //transform.position��ǰ�󶨶��������,�õ�ǰ����������ƶ���MoveTowards���õ�Ŀ��λ��
        //����Time.deltaTime�뿴�ʼǣ���1���ڣ�ˢ����N֡������ÿ֡��ʱ���ǲ��̶��ģ�����Unity��Time.deltatime��ʾÿ1֡�����ѵ�ʱ�䡣
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,speed * Time.deltaTime);

        //Distance���ж�ǰһ�������ͺ�һ�������ľ��룬�������С��0.1����Ϊ��ǰ�󶨶����Ѿ��ƶ���������������õ�����
        if (Vector2.Distance(transform.position,movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                //����һ��Ҫ�ƶ���λ����������
                movePos.position = GetRandomPos();
                //ˢ�µȴ�ʱ��
                waitTime = startWaitTime;
            }
            else
            {
                //����λ�ú�����ͣ����ʱ��
                //�൱�� waitTime = waitTime - Time.deltaTime;
                //����Time.deltaTime�뿴�ʼǣ���1���ڣ�ˢ����N֡������ÿ֡��ʱ���ǲ��̶��ģ�����Unity��Time.deltatime��ʾÿ1֡�����ѵ�ʱ�䡣
                waitTime -= Time.deltaTime;
            }
        }
    }

    //��ȡ���λ��
    Vector2 GetRandomPos()
    {
        //���һ��������꣬����ķ�Χ�������Ƕ�������½ǵ����Ͻ�������λ��
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
