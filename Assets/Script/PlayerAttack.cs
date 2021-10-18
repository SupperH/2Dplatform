using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //�˺�ֵ
    public int damage;
    
    //������ȡ�������
    private Animator animator;

    //�������ײ���
    private PolygonCollider2D collider2D;

    //������󹥻�����ʧʱ��
    public float disableTime;

    //�����󹥻�������ʱ��
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        //��ö�ӦĿ��Ķ������  FindGameObjectWithTag�Ǹ���tag����ȡ��Ϸ�����Player�������Ҫ�Լ����ã�������������Ҫ��ȡPlayer�����������Ҫȥunityѡ��Player��Player��tag����һ��
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Debug.Log("����");


            //���ö�����trigger����
            animator.SetTrigger("Attack");

            //����Э��
            StartCoroutine(startAttack());
        }
    }

    //Я�̣��򿪹�����ײ��
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(startTime);

        //����ײ������Ϊtrue��Ĭ�Ϲ����Ķ������ײ����ǹرյģ�ֻ�й������Ź���������ʱ��Ż�ʹ��
        collider2D.enabled = true;
        //�������ٿ����رյ�Я��
        //����Э��
        StartCoroutine(disableHitBox());
    }

    //Э��,�رչ�����ײ��
    IEnumerator disableHitBox()
    {
        //��������ù�������ײ����ʧ
        yield return new WaitForSeconds(disableTime);
        collider2D.enabled = false;
    }

    //�����������÷���
     void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ƿ��������˵�tag�����tag�������Ǹ��������õ�tag��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //�����ó����࣬��javaһ�� �ж������Ȼ��ֱ��ָ�����˸���Ϳ����ˣ���ͬ���˵���ֱֵ����untiy���ҵ���Ӧ�Լ��Ľű���Ȼ����ֵ���ɣ���Java������ø��෽������ͬ����һ��
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
