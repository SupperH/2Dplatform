using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //���Ǿ�̬�����������ĵ��þ����ĵ�
    //��Դ
    public static AudioSource audioSrc;
    //��ƵƬ�� ����
    public static AudioClip pickCoin;
    //��ƵƬ�� �ӽ��
    public static AudioClip throwCoin;



    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //������Ƶ�ļ������� �����������
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����
    public static void PlayPickCoinClip()
    {
        //PlayOneShot:����һ��
        audioSrc.PlayOneShot(pickCoin);
    }

    //�ӽ��
    public static void PlayThrowClip()
    {
        audioSrc.PlayOneShot(throwCoin);

    }
}
