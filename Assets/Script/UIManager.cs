using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    //RectTransforms 用于 GUI  这里当作垃圾桶UI的元素
    public RectTransform UI_Element;

    //这里用来指定Canvas，UI和Camara一样 都是视口坐标
    public RectTransform CanvasRect;
    //垃圾桶世界坐标
    public Transform trashBinPos;
    //x轴和y轴的偏移量
    public float xOffset;
    public float yOffset;
    //垃圾桶金币数量
    public Text coinNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //相机跟随在LaterUpdate，那坐标转换也要卸载LateUpdate中
    void LateUpdate()
    {
        //相机跟随在LaterUpdate，那坐标转换也要卸载LateUpdate中
        //WorldToViewportPoint转换坐标，把垃圾桶的世界坐标trashBinPos.position转换成视口坐标，用主相机Camera.main
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(trashBinPos.position);

        //世界物体在屏幕上的坐标
        Vector2 worldOjectScreenPos
            = new Vector2((viewportPos.x * CanvasRect.sizeDelta.x) -
                           (CanvasRect.sizeDelta.x * 0.5f) + xOffset,
                           (viewportPos.y * CanvasRect.sizeDelta.y) -
                           (CanvasRect.sizeDelta.y * 0.5f) + yOffset);

        //垃圾桶UI锚点的位置设置为世界物体在屏幕的坐标
        UI_Element.anchoredPosition = worldOjectScreenPos;

    }
}
