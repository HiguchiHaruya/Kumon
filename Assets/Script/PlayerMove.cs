using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float x = 0;
    float v = 0;
    public GameObject bullet;
    public Transform bulletpos;
    private bool isJamp = false;
    private float downspeed = 0;
    private float jampSpeed = 5f;
    private float gravity = 8;
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && !isJamp)
        {
            isJamp = true;
            downspeed = jampSpeed;
        }
        if (isJamp)
        {
            downspeed -= gravity * Time.deltaTime;
            transform.position = new Vector2(0, downspeed * Time.deltaTime);
            if(transform.position.y <= 0)
            {
                isJamp = false;
                downspeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.D)) { x += 0.1f; }
        if (Input.GetKey(KeyCode.A)) { x -= 0.1f; }
        if (Input.GetKeyDown(KeyCode.Space)) { Instantiate(bullet, bulletpos.position, Quaternion.identity); }
        this.gameObject.transform.position = new Vector2(x, downspeed);
    }
}
