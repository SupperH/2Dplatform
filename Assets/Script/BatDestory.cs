using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDestory : MonoBehaviour
{
    //�жϵ�ǰ�������ɵĲʵ�����
    public int batFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ֻ�е��������ٲŻ���õķ���
    void OnDestroy()
    {
        //�ѵ�ǰ�Ĳʵ�������ϵ�ǰ�������ɵĲʵ�����
        EasterEgg.Password += batFlag.ToString();
    }
}
