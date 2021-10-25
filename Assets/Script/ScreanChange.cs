using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanChange : MonoBehaviour
{


    //ͼ����� 2��ͼƬ
    public GameObject img1;
    public GameObject img2;
    //�л��ȴ�ʱ��
    public float waitTime;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //����E�л�����
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetBool("ChangeToWhite",true);
            Debug.Log("�л�ͼƬ");
            //�л�����
            Invoke("ChangeImage", waitTime);
        }
    }

    void ChangeImage()
    {
        img1.SetActive(false);
        img2.SetActive(true);
    }
}
