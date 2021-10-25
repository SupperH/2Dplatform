using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanChange : MonoBehaviour
{


    //Í¼Ïñ²ÎÊý 2¸öÍ¼Æ¬
    public GameObject img1;
    public GameObject img2;
    //ÇÐ»»µÈ´ýÊ±¼ä
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
        //°´ÏÂEÇÐ»»¶¯»­
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetBool("ChangeToWhite",true);
            Debug.Log("ÇÐ»»Í¼Æ¬");
            //ÇÐ»»±³¾°
            Invoke("ChangeImage", waitTime);
        }
    }

    void ChangeImage()
    {
        img1.SetActive(false);
        img2.SetActive(true);
    }
}
