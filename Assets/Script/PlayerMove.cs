using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float x = -8f;
    public GameObject bullet;
    public GameObject enemyBullet;
    private bool isJamp = false;
    private float downspeed = 0;
    private float jampSpeed = 5f;
    private float gravity = 8;
    private Transform _playerPos;
    [HideInInspector]
    public int _playerLife = 5;
    public Transform PlayerPos => _playerPos;
    public static PlayerMove Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        _playerPos = gameObject.transform;
    }
    void Update()
    {
        Debug.Log($"ÉvÉåÉCÉÑÅ[ÇÃHP : {_playerLife}");
        if (_playerLife <= 0) { Destroy(gameObject); }
        if (Input.GetKeyDown(KeyCode.W) && !isJamp)
        {
            downspeed += jampSpeed * Time.deltaTime;
            isJamp = true;
            downspeed = jampSpeed;
        }
        if (isJamp)
        {
            downspeed -= gravity * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, downspeed * Time.deltaTime);
            if (transform.position.y <= 0)
            {
                isJamp = false;
                downspeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.D)) { x += 0.1f; }
        if (Input.GetKey(KeyCode.A)) { x -= 0.1f; }
        if (Input.GetKeyDown(KeyCode.Space)) { Instantiate(bullet, this.transform.position, Quaternion.identity); }
        this.gameObject.transform.position = new Vector2(x, downspeed);
    }
}
