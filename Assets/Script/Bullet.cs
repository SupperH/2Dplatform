using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    //�ӵ��� ����͹���һ��


    //�ٶ�
    public float speed;
    //�˺�
    public int damage;
    //�������о���
    public float destoryDis;
    //����
    private Rigidbody2D rb;
    //�����������ɹ����ĳ�ʼ�����
    private Vector3 ve;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //������һ����ʼ���ٶȣ�����
        rb.velocity = transform.right * speed;
        //���ó�ʼ������Ϊ�������ɵ�����
        ve = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //��������ɳ�ȥ��Ŀǰ�������ȥ��ʼ����󣬴��� �Ǿ���Ϊ���о����Ѿ��ﵽ���ޣ�����
        float disPos = (transform.position - ve).sqrMagnitude;
        if (disPos > destoryDis)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�ж��������tagΪenemy�Ļ�����Ϊ�������ˣ�Ȼ����õ��˵����˷��� ����˺�
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //����䵽���ˣ��ӵ�����ʧ
            Destroy(gameObject);
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
