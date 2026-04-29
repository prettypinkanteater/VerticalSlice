using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galatea : Patient
{
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;
    [SerializeField] DialogueNode _investigationDialogue1;
    private bool _attribute1Investigated = false;
    private bool _attribute2Investigated = false;

    // Start is called before the first frame update
    void Start()
    {
        _npcIdentity = Identity.Figure;
        _attributes = 2;
        Locator.Instance.gameController._maxAttributes = _attributes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AttributeInvestigate(GameObject NPCattribute)
    {
        base.AttributeInvestigate(NPCattribute);
        Locator.Instance.dialogueAdvancer._currentNode = _investigationDialogue1;
        Locator.Instance.dialogueAdvancer.ResetDialogueDisplay();
        //work on making investigation dialogue appear

    }
    public override void AttributeFound(GameObject NPCattribute)
    {
        if (_attribute1Investigated == false || _attribute2Investigated == false)
        {
            AttributeInvestigate(NPCattribute);
        }
        else
        {
            base.AttributeFound(NPCattribute);
        }
            

    }

}
