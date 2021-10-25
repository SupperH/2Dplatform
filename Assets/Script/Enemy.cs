using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //������ֵ���ڸ��࣬����̳��˸������Щ�����ڶ�Ӧ��λ�Ľű����涼������ʾ��������unity�н��в�ͬ������
    //�����˺�ֵ
    public int damage;
    //Ѫ��
    public int health;


    //���SpriteRenderer���
    private SpriteRenderer sprite;

    //ԭʼ��ɫ
    private Color originalColor;

    //��˸ʱ��
    public float flashTime;

    //��Ϸ����
    public GameObject bloodEffect;

    //���Ѫ����
    private PlayerHealth playerHealth;


    //�����ң�Ҫ��Unity��ק��Ҷ������
    public GameObject dropCoin;

    //���˸�����ֵ����Unity��ק�ı��������
    public GameObject floatPoint;

    // Start is called before the first frame update
    public void Start()
    {
        //ͨ��tag��ǩ����ʼ��ʱ��ͻ�ȡ����Ӧ�������
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        sprite = GetComponent<SpriteRenderer>();
        //��ԭʼ��ɫ�ȸ�������
        originalColor = sprite.color;
    }

    // Update is called once per frame
    public void Update()
    {
        //�������Ѫ��С��0�����ٵ�ǰ��Ϸ����
        if (health <= 0)
        {
            //������
            //����һ����Ҫ���ɵĶ��� ��������ʵ����Ԥ������� ��������ʵ����Ԥ�����ת�Ƕ� �ڶ���������������Ĭ�ϵģ�Ҳ����˵ �ڵ��˵�ǰ��������һ����Ҷ���
            Instantiate(dropCoin,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //��������
    public void TakeDamage(int damage)
    {

        //�ֲ����� ��ʾ�˺���ֵ
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
       // GetChild(0)��ȡ��ǰĿ���һ���Ӷ��󣨵�ǰĿ�������unity����ק��public�Ķ��󣩵�TextMesh��������text���ԣ���������˺�ֵ ���ɶ�̬��ʾ�˺�ֵ
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        Debug.Log("��������"+transform.position);
        Debug.Log("��ֵ����"+floatPoint.transform.position);



        //ÿ�ε���������������˾��ܵ������˺�ֵ���˺�
        health -= damage;
        //�������˺���˸
        FlashColor(flashTime);
        //���˺��Ѫ������������ϵͳ
        //����һ����Ҫ���ɵĶ��� ��������ʵ����Ԥ������� ��������ʵ����Ԥ�����ת�Ƕ�
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
        //���þ�ͷ�����Ĵ���
        GameController.cameraShake.Shake();
    }

    //���˺���˸
    //time:��˸ʱ��
    void FlashColor(float time)
    {
        //���ú�ɫ��˸
        sprite.color = Color.red;

        //�ӳٵ���������ɫ�ķ���,�ӳٵ�ʱ�������˸ʱ������
        Invoke("ResetColor", time);
    }

    //������ɫ
    void ResetColor()
    {
        sprite.color = originalColor;
    }

    //��������
   void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag�жϣ�����Ӵ���tag��Ϊplayer,�ҽӴ�������ײ���ǽ����壨CapsuleCollider2D�ǽ�����ײ�򣬸���Ҽӵģ�����Ϊ��������
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //����������˺��������˺�
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);

            }

        }
    }
}
