using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    //RectTransforms ���� GUI  ���ﵱ������ͰUI��Ԫ��
    public RectTransform UI_Element;

    //��������ָ��Canvas��UI��Camaraһ�� �����ӿ�����
    public RectTransform CanvasRect;
    //����Ͱ��������
    public Transform trashBinPos;
    //x���y���ƫ����
    public float xOffset;
    public float yOffset;
    //����Ͱ�������
    public Text coinNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //���������LaterUpdate��������ת��ҲҪж��LateUpdate��
    void LateUpdate()
    {
        //���������LaterUpdate��������ת��ҲҪж��LateUpdate��
        //WorldToViewportPointת�����꣬������Ͱ����������trashBinPos.positionת�����ӿ����꣬�������Camera.main
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(trashBinPos.position);

        //������������Ļ�ϵ�����
        Vector2 worldOjectScreenPos
            = new Vector2((viewportPos.x * CanvasRect.sizeDelta.x) -
                           (CanvasRect.sizeDelta.x * 0.5f) + xOffset,
                           (viewportPos.y * CanvasRect.sizeDelta.y) -
                           (CanvasRect.sizeDelta.y * 0.5f) + yOffset);

        //����ͰUIê���λ������Ϊ������������Ļ������
        UI_Element.anchoredPosition = worldOjectScreenPos;

    }
}
