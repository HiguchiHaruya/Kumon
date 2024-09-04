using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    float _radian;
    float x = -8f;
    public GameObject bullet;
    public GameObject enemyBullet;
    private bool isJamp = false;
    private float downspeed = 0;
    private float jampSpeed = 5f;
    private float gravity = 8;
    private Vector3 _playerPos;
    [HideInInspector]
    public int _playerLife = 5;
    public Vector3 PlayerPos => _playerPos;
    public float Radian => _radian;
    public static PlayerMove Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

    }
    void Update()
    {
        _playerPos = transform.position;
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.WorldToScreenPoint(mousePos);
        _radian = Mathf.Atan2(worldMousePos.y - _playerPos.y, worldMousePos.x - _playerPos.x);
        transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI,//radianから度に変換
            new Vector3(0, 0, 1));


        Debug.Log($"プレイヤーのHP : {_playerLife}");
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
        if (Input.GetKeyDown(KeyCode.Space)) { Instantiate(bullet, this.transform.position, transform.rotation); }
        this.gameObject.transform.position = new Vector2(x, downspeed);
    }
}
