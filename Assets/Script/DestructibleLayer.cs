using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{

    //ƫ���� ΢��
    public float offsetX;
    public float offsetY;

    //tilemap���
    private Tilemap tilemap;


    private Rigidbody2D rb2d;


    //����������Χ�İ˸�������
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //����ֻ�ж��ӵ���ֻ���ӵ��Ż��ƻ���ͼ ����Ļ�һ������ ���ӵ���һ��tag��tag��ȡ
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //��ȡ�ӵ�ײ���ĵ� ClosestPoint�õ������һ����  collision.transform.position���ӵ��ĵ�
            Vector3 hitPos = collision.bounds.ClosestPoint(collision.transform.position);
            //ͨ����ײ�㣬�����Χ�İ˸���,���ʣ��ʾ����㷨
            pos1  = new Vector3(hitPos.x + offsetX, hitPos.y,0f);
            pos2  = new Vector3(hitPos.x - offsetX, hitPos.y, 0f);
            pos3  = new Vector3(hitPos.x, hitPos.y + offsetY,0f);
            pos4  = new Vector3(hitPos.x, hitPos.y - offsetY, 0f);
            pos5  = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, 0f);
            pos6  = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);
            pos7  = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, 0f);
            pos8  = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);

            //��������ת����cell���꣬����һ��������
            Vector3Int position = tilemap.WorldToCell(pos1);
            //ͨ������������ڵĵ�ͼ����Ϊnull����ʾ
            tilemap.SetTile(position,null);

            position = tilemap.WorldToCell(pos2);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos3);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos4);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos5);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos6);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos7);
            tilemap.SetTile(position, null);
            position = tilemap.WorldToCell(pos8);
            tilemap.SetTile(position, null);

            //�����ӵ�
            Destroy(collision.gameObject);
        }
    }
}
