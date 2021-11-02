using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{

    //偏移量 微调
    public float offsetX;
    public float offsetY;

    //tilemap组件
    private Tilemap tilemap;


    private Rigidbody2D rb2d;


    //用来生成周围的八个辅助点
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
        //这里只判断子弹，只有子弹才会破坏地图 刀光的话一个道理 给子弹加一个tag用tag获取
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //获取子弹撞击的点 ClosestPoint得到最近的一个点  collision.transform.position是子弹的点
            Vector3 hitPos = collision.bounds.ClosestPoint(collision.transform.position);
            //通过碰撞点，算出周围的八个点,别问，问就是算法
            pos1  = new Vector3(hitPos.x + offsetX, hitPos.y,0f);
            pos2  = new Vector3(hitPos.x - offsetX, hitPos.y, 0f);
            pos3  = new Vector3(hitPos.x, hitPos.y + offsetY,0f);
            pos4  = new Vector3(hitPos.x, hitPos.y - offsetY, 0f);
            pos5  = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, 0f);
            pos6  = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);
            pos7  = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, 0f);
            pos8  = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);

            //世界坐标转换成cell坐标，就是一个个格子
            Vector3Int position = tilemap.WorldToCell(pos1);
            //通过坐标给坐标内的地图设置为null不显示
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

            //销毁子弹
            Destroy(collision.gameObject);
        }
    }
}
