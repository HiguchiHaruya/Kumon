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
    private bool CheckEnemies()
    {
        EnemyController[] enemyies = FindObjectsOfType<EnemyController>();
        foreach (var enemy in enemyies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= (transform.localScale.x / 2 + enemy.transform.localScale.x / 2))
            {
                enemy.TakeDamage();
                Destroy(gameObject);
                break;
            }
        }
        return false;
    }

    private void BulletMove()
    {
        pos.x += 0.1f;
        gameObject.transform.position = pos;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (!GetComponent<Renderer>().isVisible) { Destroy(gameObject); }
    }
}
