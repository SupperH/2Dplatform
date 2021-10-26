using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{


    //�������ٶ�
    public float speed;
    //�˺�
    public int damage;
    //��ת�ٶ�
    public float rotateSpeed;
    //΢������
    public float tuning;
    //����
    private Rigidbody2D rb;
    //������ȡ��ҵ�����
    private Transform playerTransform;
    //����������
    private Transform sickleTransform;
    //�����ڳ�ʼ�ٶ�
    private Vector2 startSpeed;
    //����𶯷���
    private CameraShake cameraShake;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //���û����ڳ�ʼ�ٶ�
        rb.velocity = transform.right * speed;
        startSpeed = rb.velocity;
        //����tag��ȡ��Ҷ�����������
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //��ȡ�������Լ�������������
        sickleTransform = GetComponent<Transform>();
        //�������𶯵����
        cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate:��ת��������������z�������ת
        transform.Rotate(0,0,rotateSpeed);
        //Lerp���Բ�ֵ,�û����ڵ�y����Ž�ɫ��Ȼ�����΢���Ĳ�������΢��������0.1����ô���Ǹ��ݰٷ�֮10 �ѻ�����y���꽥�䵽��ɫy���� ������������Ҳ�����Ǹ���
        float y = Mathf.Lerp(transform.position.y,playerTransform.position.y,tuning);
        //�����õ�y�����긳�������ڵ�������ϵ
        transform.position = new Vector3(transform.position.x,y,0.0f);

        //�û����ڷɻ�����ԭ����ǲ��ϼ�С��������x����ٶ�
        rb.velocity = rb.velocity - startSpeed * Time.deltaTime;
        //Mathf.Abs����ֵ����Ϊ����������ҷɣ������п��ܾ����Ǹ����������þ���ֵֻҪ�ж�0.5���� ��������ں��������ľ���С��0.5��Ϊ�ɻ����� ��ô��Ҫֹͣ����
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f)
        {
            //�ɻ�������ʾ�����ڣ�Ҳ�������ٶ���
            Destroy(gameObject);
        }

    }

    //������ 
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�ж��������tagΪenemy�Ļ�����Ϊ�������ˣ�Ȼ����õ��˵����˷��� ����˺�
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
