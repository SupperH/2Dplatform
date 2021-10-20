using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //���Ѫ��
    public int health;

    //��˸����
    public int Blinks;

    //��˸ʱ��
    public float time;

    //�������
    private Animator animator;

    //�ӳٵ��ý�ɫ������ʱ�����
    public float dieTime;

    //Renderer�������˸��
    private Renderer myRender;
    // Start is called before the first frame update
    void Start()
    {
        //ÿ�ν�����Ϸ����Ѫ�������ֵ�͵�ǰѪ��ֵΪĬ��Ѫ��
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;

        myRender = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��ɫ���˺���
    public void DamagePlayer(int damage)
    {
        health -= damage;
        //��ʱ����˹�����Ѫ������С��0 ��������Ѫ������ʾ���������������ж�
        if (health <0)
        {
            health = 0;
        }
        HealthBar.healthCurrent = health;

        //Ѫ��С��0��������������
        if (health <= 0)
        {
            //��ɫ������������������
            animator.SetTrigger("Die");
            //�ӳٵ��ý�ɫ����
            Invoke("KillPlayer", dieTime);
        }

        //���˵�����˸����
        BlinkPlayer(Blinks, time);
    }


    //�������
    void KillPlayer()
    {
        Destroy(gameObject);

    }


    //��˸����������ʱ�䣩
    void BlinkPlayer(int numBlinks,float seconds)
    {
        //����Э��
        StartCoroutine(DoBlinks(numBlinks,seconds));
    }

    //Э��
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        //ѭ����˸
        for (int i =0; i < numBlinks*2; i++)
        {
            //render.enabled��Ϊ��Ӧ�෴��ֵ�ﵽ��˸Ч��
            myRender.enabled = !myRender.enabled;

            //�ȴ�ָ��ʱ���ӳٺ����ִ�У�Ҳ����˵�ȴ���˸ʱ��ﵽ���ٽ�����һ��ѭ��
            yield return new WaitForSeconds(seconds);
        }
        //��˸��󣬰�render.enabled��س�ʼֵ
        myRender.enabled = true;
    }
}
