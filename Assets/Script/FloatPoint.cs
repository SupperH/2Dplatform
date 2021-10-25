using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        //当达到播放时间后，销毁当前对象
        Destroy(gameObject, timeDestroy);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
