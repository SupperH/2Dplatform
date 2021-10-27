using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorToNextLevel : MonoBehaviour
{
    //ͼƬ�������ʾ��
    public Image dialogBox;

    private bool isPlayerInSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerInSign)
        {

            //��ʾ�Ի���
            dialogBox.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N");

            //��ȡ��ǰ��ĳ�����Ȼ��+1���ǵ���ǰ��������һ��������ע��Ҫ�ѳ����ϵ�BuildSetting�� �ʼ���ͼ
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        //����tag�жϣ�����Ӵ���tag��Ϊplayer
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�Ӵ���");
            isPlayerInSign = true;


        }


    }

    //������ �뿪
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�뿪��");

        //��ɫδ�Ӵ�
        isPlayerInSign = false;
        //�ر���ʾ��
        dialogBox.gameObject.SetActive(false);

    }
}
