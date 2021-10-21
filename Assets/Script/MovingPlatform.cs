using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    //ƽ̨�ƶ��ٶ�
    public float speed;
    //�ȴ�ʱ��
    public float waitTime;
    //�ƶ�λ������
    public Transform[] movePos;
    //����ָ������Ĳ���
    private int i;

    //��ɫĬ�ϲ�ι�ϵ
    private Transform playerDefTransform;

    // Start is called before the first frame update
    void Start()
    {
        //һ��ʼĬ��ȡ�ڶ���������Ҳ����������unity��ƽ̨���õ��ƶ����е��ҵ�
        i = 1;
        //��ý�ɫ�Ĳ�����ݸ�Ĭ��ֵ
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //�ƶ���������һ������ ��ʼλ�ã��ڶ�������Ŀ��λ�ã������������ٶ�
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);

        //�����ǰλ�ú�����Ҫ�ƶ�����λ��С��0.1 ����Ϊ�ƶ���ָ������
        if (Vector2.Distance(transform.position,movePos[i].position) < 0.1f)
        {
            //����ȴ�ʱ��С��0����˵�������������ƶ���
            if (waitTime <0.0f)
            {
                //���Ŀǰȡ���ǵ�һ��������Ҳ�������
                if (i ==0)
                {
                    //��i��Ϊ1 ȥȡ�ڶ���������Ҳ�����ҵ�����
                    i = 1;
                }
                //��֮
                else
                {
                    i = 0;
                }
                //�������õȴ�ʱ��
                waitTime = 0.5f;
            }
            //����ȴ�ʱ�����0������ʱ��������С
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //������, ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            //�����Һ����ָ����ײ��
            if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
            //�޸Ĳ�ι�ϵ������ұ�Ϊ��ǰ��Ϸ����ƽ̨�Ӷ��󣬴ﵽվ������һ���ƶ���Ч��
            collision.gameObject.transform.parent = gameObject.transform;
            }
        }

    //������,��ɫΪ������ �뿪
    void OnTriggerExit2D(Collider2D collision)
    {
        //��ɫ�뿪ƽ̨���ָ�ԭ����ι�ϵ

        //�����Һ����ָ����ײ��
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            collision.gameObject.transform.parent = playerDefTransform;
        }
    }
}
