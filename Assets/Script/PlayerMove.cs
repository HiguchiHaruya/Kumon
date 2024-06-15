using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float x = 0;
    float v = 0;
    public GameObject bullet;
    public Transform bulletpos;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) { x += 0.1f; }
        if (Input.GetKey(KeyCode.A)) { x -= 0.1f; }
        if (v >= 0) { v = Input.GetAxis("Vertical"); }
        if (Input.GetKeyDown(KeyCode.Space)) { Instantiate(bullet, bulletpos.position, Quaternion.identity); }
        this.gameObject.transform.position = new Vector3(x, v, 0);
    }
}
