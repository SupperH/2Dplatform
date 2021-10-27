using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRange : MonoBehaviour
{


    //�˺�ֵ
    public int damage;
    //��ʧʱ��
    public float destroyTime;
    //���Ѫ����
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //����tag�õ���Ҷ���Ȼ������Ҷ����µ�PlayerHealth����
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject,destroyTime);
        Debug.Log("���ɷ�Χ"+transform.position);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ƿ��������˵�tag�����tag�������Ǹ��������õ�tag��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("��������");

            //�����ó����࣬��javaһ�� �ж������Ȼ��ֱ��ָ�����˸���Ϳ����ˣ���ͬ���˵���ֱֵ����untiy���ҵ���Ӧ�Լ��Ľű���Ȼ����ֵ���ɣ���Java������ø��෽������ͬ����һ��
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }

        //����tag�жϣ�����Ӵ���tag��Ϊplayer,�ҽӴ�������ײ���ǽ����壨CapsuleCollider2D�ǽ�����ײ�򣬸���Ҽӵģ�����Ϊ��������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("�������");
            //����������˺��������˺�
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);

            }

        }
    }
}
