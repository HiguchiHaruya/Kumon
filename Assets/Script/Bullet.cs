using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Start()
    {

    }
    float x = 0;
    // Update is called once per frame
    void Update()
    {
        x += 0.1f;
        this.transform.position = new Vector2(x, 0);
        if (!GetComponent<Renderer>().isVisible) { Destroy(this.gameObject); }
    }
}
