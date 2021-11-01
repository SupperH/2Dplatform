using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{

    private Animator anim;

    public int damage;
    //玩家生命值
    private PlayerHealth playerHealth;
    //检测半径
    public float radius;
    //角色坐标
    private Transform Playertransform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //根据tag获取玩家生命值的内容
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

    //用动画事件调用
    public void SpikeHit()
    {
        playerHealth.DamagePlayer(damage);
    }

}
