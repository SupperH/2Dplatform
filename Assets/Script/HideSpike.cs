using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{

    private Animator anim;

    public int damage;
    //�������ֵ
    private PlayerHealth playerHealth;
    //���뾶
    public float radius;
    //��ɫ����
    private Transform Playertransform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //����tag��ȡ�������ֵ������
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Playertransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Playertransform !=null)
        {
            float disRadius = (transform.position - Playertransform.position).sqrMagnitude;
            if (disRadius < radius)
            {
                anim.SetBool("SpikeHit", true);
            }
            else
            {
                anim.SetBool("SpikeHit", false);

            }
        }
    }

    //�ö����¼�����
    public void SpikeHit()
    {
        playerHealth.DamagePlayer(damage);
    }

}
