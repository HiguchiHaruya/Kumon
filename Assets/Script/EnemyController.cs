using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject _bulled;
    float _timer = 0;
    float _interval = 1;
    private int _hp = 3;
    void Update()
    {
        Debug.Log($"“G‚ÌHP : {_hp}");
        _timer += Time.deltaTime;
        if (this.transform.position.x - _player.transform.position.x <= 8)
        {
            if (_timer >= _interval)
            {
                GenarateBulled();
                _timer = 0;
            }
        }
        if(_hp <= 0) { Destroy(gameObject); }
    }
    public void TakeDamage()
    {
        _hp -= 1;
    }
    private void GenarateBulled()
    {
        Instantiate(_bulled, gameObject.transform.position, Quaternion.identity);
    }
}
