using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //都是静态变量，想在哪调用就在哪调
    //音源
    public static AudioSource audioSrc;
    //音频片段 捡金币
    public static AudioClip pickCoin;
    //音频片段 扔金币
    public static AudioClip throwCoin;



    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //根据音频文件的名字 获得声音内容
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //捡金币
    public static void PlayPickCoinClip()
    {
        //PlayOneShot:播放一次
        audioSrc.PlayOneShot(pickCoin);
    }

    //扔金币
    public static void PlayThrowClip()
    {
        audioSrc.PlayOneShot(throwCoin);

    }
}
