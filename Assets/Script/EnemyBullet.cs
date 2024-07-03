using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyBullet : MonoBehaviour
{
    Vector2 pos;
    void Start()
    {
        pos = transform.position;
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

    private void BulletMove()
    {
        pos.x -= 0.1f;
        transform.position = pos;
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        if (!GetComponent<Renderer>().isVisible) { Destroy(this.gameObject); }
    }
    private bool IsColliding()
    {
        Vector2 playerPos = PlayerMove.Instance.PlayerPos.position;
        float playerRadi = PlayerMove.Instance.PlayerPos.localScale.x / 2;
        Vector2 enemyPos = transform.position;
        float enemyRadi = transform.localScale.x / 2;

        float distance = Vector2.Distance(playerPos, enemyPos);
        return distance <= (playerRadi + enemyRadi);
    }
}
