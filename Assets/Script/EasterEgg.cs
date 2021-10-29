using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{


    //��������
    public string easterEggPassword;

    //���Ա��ⲿ�����޸ĵĵ�ǰ����
    public static string Password;

    //���ɵĶ��� �������ɽ��
    public GameObject coin;
    //��������
    public int coinQuantity;
    //�����ٶ�
    public float coinUpSpeed;
    //����ʱ��
    public float intervalTime;
    // Start is called before the first frame update
    void Start()
    {
        Password = "";
    }

    // Update is called once per frame
    void Update()
    {
        //�����ǰ�Ĳʵ�������ڴ������� ����Ϊ��ɲʵ���������
        if (Password == easterEggPassword)
        {
            Debug.Log("���ɲʵ�");
            //���ɺ����òʵ�����
            Password = "";
            StartCoroutine(GenCoins());
        }
    }

    //Э��
    IEnumerator GenCoins()
    {
        //���ɵ�ʱ����
        WaitForSeconds wait = new WaitForSeconds(intervalTime);
        for (int i = 0; i < coinQuantity; i++)
        {
            GameObject gb = Instantiate(coin, transform.position, Quaternion.identity);
            //��������,���������Ȼ��Random.Range��-0.3f, 0.3f֮���������һ��x���λ�õ���x����
            Vector2 ve = new Vector2(Random.Range(-0.3f, 0.3f), 1.0f);
            //�ٸ���Ҷ���һ���ٶ�
            gb.GetComponent<Rigidbody2D>().velocity = ve * coinUpSpeed;
            //����ʱ����
            yield return intervalTime;

        }
    }
}
