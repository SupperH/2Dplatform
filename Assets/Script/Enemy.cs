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

    // Start is called before the first frame update
    public void Start()
    {
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
            Destroy(gameObject);
        }
    }

    //��������
    public void TakeDamage(int damage)
    {
        //ÿ�ε���������������˾��ܵ������˺�ֵ���˺�
        health -= damage;
        //�������˺���˸
        FlashColor(flashTime);
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
}
