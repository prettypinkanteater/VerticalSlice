using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public DialogueUI dialogueUI { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
    void Start()
    {
        dialogueUI = GameObject.Find("DialogueUI").GetComponent<DialogueUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
