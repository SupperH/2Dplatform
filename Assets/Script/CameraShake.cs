using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    //����������ͷ��������unity�а�Main Camera�и�����
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�����������������ڵ������˵�λ�õ���
    public void Shake()
    {
        //���ö�����������
        camAnim.SetTrigger("Shake");
    }
}
