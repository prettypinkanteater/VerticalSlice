using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public bool _examTime;
    public int _attributesFound;
    public int _maxAttributes;
    private PlayableDirector _timeline;

    private void Awake()
    {
        _examTime = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartExam()
    {
        _attributesFound = 0;
        _examTime = true;
    }

}
