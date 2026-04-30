using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nail : MonoBehaviour
{
    Vector3 _mousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition.z = 0;
        OnMouseOver();
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
        }
    }
}
