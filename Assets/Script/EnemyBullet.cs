using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyBullet : MonoBehaviour
{
    Vector2 pos;
    private PlayerMove playerobj;
    void Start()
    {
        pos = transform.position;
        playerobj = FindObjectOfType<PlayerMove>();
    }
    void Update()
    {
        if (IsColliding())
        {
            PlayerMove.Instance._playerLife--;
            Destroy(gameObject);
        }
        BulletMove();
    }
    private bool IsColliding()
    {
        Rect player = GetRect(playerobj.gameObject);
        Rect enemy = GetRect(gameObject);
        if (enemy.Overlaps(player))
        {
            return true;
        }
        return false;
    }

    Rect GetRect(GameObject obj)
    {
        Vector2 pos = obj.transform.position;
        Vector2 size = obj.GetComponent<SpriteRenderer>().bounds.size;
        return new Rect(pos - size / 2, size);
    }
    private void BulletMove()
    {
        pos.x -= 0.1f;
        transform.position = pos;
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        if (!GetComponent<Renderer>().isVisible) { Destroy(this.gameObject); }
    }
}
