using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField]
    private GameObject pointerObj;
    void Start()
    {

    }

    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerObj.transform.position = pos;
    }
}
