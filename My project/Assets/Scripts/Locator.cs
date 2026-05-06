using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public UI _ui { get; private set; }

    public DialogueAdvancer dialogueAdvancer { get; private set; }

    public GameController gameController { get; private set; }

    public ExamStatsUI examStatsUI { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        _ui = GameObject.Find("Canvas").GetComponentInChildren<UI>();
        examStatsUI = GameObject.Find("Canvas").GetComponentInChildren<ExamStatsUI>();
        dialogueAdvancer = GameObject.Find("DialogueController").GetComponent<DialogueAdvancer>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
