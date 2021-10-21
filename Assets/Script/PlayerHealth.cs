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

    //��Ļ��˸���
    private ScreenFlash screenFlash;

    //��ɫ���壬������ʱ��������Ϊ0
    private Rigidbody2D rigidbody2D;

    //��ҳ���������ȴʱ��
    public float hitBox;

    //��ɫ�������ײ��
    private PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        //ÿ�ν�����Ϸ����Ѫ�������ֵ�͵�ǰѪ��ֵΪĬ��Ѫ��
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;

        myRender = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        screenFlash = GetComponent<ScreenFlash>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��ɫ���˺���
    public void DamagePlayer(int damage)
    {
        //���˵�����Ļ��˸
        screenFlash.FlashScreen();
        //��Ѫ
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
            //��������ٶȺ�������Ϊ0,�������Լ��뷨��������ڿ��������󲻵��䵽����Ͳ�Ҫ��Ϊ0
            rigidbody2D.velocity = new Vector2(0,0);
            rigidbody2D.gravityScale = 0.0f;

            //����ɫ�������Ѵ��������Ϊfalse����ʱ��ɫ�޷������κβ���
            GameController.isGameAlive = false;
            //��ɫ������������������
            animator.SetTrigger("Die");
            //�ӳٵ��ý�ɫ����
            Invoke("KillPlayer", dieTime);
        }

        //���˵�����˸����
        BlinkPlayer(Blinks, time);

        //���������ǽ��������ײ��,Ȼ����Э�̣���һ��ʱ��������´���ײ�� �ﵽ���ڵش̳�����Ѫ
        polygonCollider2D.enabled = false;
        StartCoroutine(ShowPlayerHitBox());
    }

    //��ҳ�������
    IEnumerator ShowPlayerHitBox()
    {
        //������ȴʱ�䵽������������ײ��
        yield return new WaitForSeconds(hitBox);
        polygonCollider2D.enabled = true;
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
