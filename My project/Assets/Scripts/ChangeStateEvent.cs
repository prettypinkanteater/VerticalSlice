using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventNames
{
    public static string NewStateTriggerEvent = "NewStateTriggerEvent";
}

[UnitTitle("On New State State Trigger Event")]
[UnitCategory("Events\\MyEvents")]
public class ChangeStateEvent : MonoBehaviour
{
    [DoNotSerialize] public ValueOutput result { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EventHook GetHook(GraphReference reference)
    {
        return new EventHook(EventNames.NewStateTriggerEvent);
    }
}
