using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        //���ﵽ����ʱ������ٵ�ǰ����
        Destroy(gameObject, timeDestroy);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
