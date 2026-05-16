using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attribute : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touching touching omg");
        other.GetComponent<Nail>()._attributeTouching = gameObject;
        other.GetComponent<Nail>().BeginTimeline();
    }
}
   

