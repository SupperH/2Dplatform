using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //�ӵ�����
    public GameObject bullet;
    //ǹ������
    public Transform muzzleTransform;
    //���
    public Camera cam;
    //��¼���λ��
    private Vector3 mousePos;
    //ǹ�ڷ���
    private Vector2 gunDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��������ͷ����Ļ����ת����������������������
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //����ǹ�ڷ���������������ȥ����������һ������ normalized�ǵ�λ����ֻ�������� ����Ϊ1
        gunDirection = (mousePos - transform.position).normalized;

        //����ǹ��Ҫ��ת�ĽǶ�  Atan2��������y��x����������һ������ֵ��Ȼ��ͨ������Mathf.Rad2Deg����ת�Ƕȵĳ����Ϳ��Եõ�һ��׼ȷ�ĽǶ�ֵ
        float angle = Mathf.Atan2(gunDirection.y , gunDirection.x) * Mathf.Rad2Deg;

        //�ѽǶȸ�ǹ
        transform.eulerAngles = new Vector3(0,0,angle);

        //������������
        if (Input.GetMouseButtonDown(0))
        {
            //�����ӵ� ��ǹ�ڵ�λ�� �����Ǽ������ǹ����ת�ĽǶȣ�����һ���ӵ�
            Instantiate(bullet,muzzleTransform.position,Quaternion.Euler(transform.eulerAngles));
        }
    }
}
