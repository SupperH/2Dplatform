using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //ը����ʼ�ٶ�
    public Vector2 startSpeed;
    //����
    private Rigidbody2D rb;
    //�������������
    private Animator anim;

    //�ӳ�ʱ��
    public float delayExtime;
    //����ʱ��
    public float destroytime;
    //ը����ը��Χ ��unityָ����ը��Χ����
    public GameObject range;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //��ʼ�ٶ�ģ���ӳ�ȥ������
        rb.velocity = transform.right * startSpeed.x + transform.up * startSpeed.y;

        //�ӳٵ��ñ�ը
        Invoke("Explode",delayExtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ը
    void Explode()
    {
        anim.SetTrigger("Explode");
        //����ը���ӳٵ�ը��ը����������
        Destroy(gameObject, destroytime);
    }

    void GetExplosionRange()
    {
        //��ը������λ�ã����ɱ�ը��Χ�˺�
        Instantiate(range,transform.position,Quaternion.identity);
        Debug.Log("��ը"+transform.position);
        Debug.Log("��ըrange" + range.transform.position);

    }

}
