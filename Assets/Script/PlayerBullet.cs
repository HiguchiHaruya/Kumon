using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerBullet : MonoBehaviour
{
    Vector2 pos;
    void Start()
    {
        pos = PlayerMove.Instance.PlayerPos.position;
    }
    void Update()
    {
        BulletMove();
        CheckEnemies();
    }
    private void CheckEnemies()
    {
        Rect bulletRect = GetRect(gameObject);
        EnemyController[] enemyies = FindObjectsOfType<EnemyController>();
        foreach (var enemy in enemyies)
        {
            Rect enemyRect = GetRect(enemy.gameObject);
            if (bulletRect.Overlaps(enemyRect))
            {
                enemy.TakeDamage();
                Destroy(gameObject);
                break;
            }
        }
        return;
    }
    Rect GetRect(GameObject obj)
    {
        Vector2 pos = obj.transform.position;
        Vector2 size = obj.GetComponent<SpriteRenderer>().bounds.size;
        return new Rect(pos - size / 2, size);
    }
    private void BulletMove()
    {
        pos.x += 0.1f;
        gameObject.transform.position = pos;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (!GetComponent<Renderer>().isVisible) { Destroy(gameObject); }
    }
}
