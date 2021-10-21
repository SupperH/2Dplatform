using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    //UI--image���
    public Image img;
    //��˸ʱ��
    public float time;
    //��˸��ɫ
    public Color flashColor;

    //Ĭ����ɫ
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼĬ����ɫ��������ͼƬ���õ���ɫ
        defaultColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��Ļ��˸
    public void FlashScreen()
    {
        //����Э��
        StartCoroutine(Flash());
    }

    //Э��
    IEnumerator Flash()
    {
        //����ͼƬ��ɫ
        img.color = flashColor;
        //�ȴ����õ�ʱ����ٰ�ͼƬ��ɫ���û�Ĭ����ɫ�ﵽ��˸Ч��
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }
}
