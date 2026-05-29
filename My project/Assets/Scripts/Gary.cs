using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gary : Patient
{
    [SerializeField] GameObject _attributeCanvas;
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;
    //[SerializeField] DialogueNode _investigationDialogue1;
    public bool _attribute1Investigated = false;
    public bool _attribute2Investigated = false;

    //[SerializeField] GameObject _investigationDialogueUI;
    //[SerializeField] TextMeshProUGUI _investigationDefenseText;

    void Start()
    {
        _npcIdentity = Identity.Human;
        _attributes = 0;
        _patientName = "Gary";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
