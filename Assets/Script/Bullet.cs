using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        pos.x += 0.1f;
        transform.position = pos;
        this.transform.position = new Vector2(this.transform.position.x, 0);
        if (!GetComponent<Renderer>().isVisible) { Destroy(this.gameObject); }
    }
}
