using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    //�˺�
    public int damage;

    //�������ֵ
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //����tag��ȡ�������ֵ������
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //������
    void OnTriggerEnter2D(Collider2D collision)
    {
        //����tag���ж��Ƿ����������,��ֻ��һ�������������˲ŵ������˺�������Ϊ�����������ײ����ɣ��������ô���Ļ��������˻��������� ����Ҫ����һ��
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            //����
            playerHealth.DamagePlayer(damage);
        }
    }
}
