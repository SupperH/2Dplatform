using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowStar : MonoBehaviour
{

    //�����������������Щ��Ʒ������
    public GameObject[] gos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenGift()
    {
        //��ȡ�����Ϸ������Ϊ���󶼷��������ֱ����Random.Range�����������������,Ȼ����С���ǵ�λ�ã�����
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        //ɾ����ǰС����
        Destroy(gameObject);
    }
}
