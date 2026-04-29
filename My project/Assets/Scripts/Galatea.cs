using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Galatea : Patient
{
    [SerializeField] GameObject _attributeCanvas;
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;
    [SerializeField] DialogueNode _investigationDialogue1;
    public bool _attribute1Investigated = false;
    public bool _attribute2Investigated = false;

    [SerializeField] GameObject _investigationDialogueUI;
    [SerializeField] TextMeshProUGUI _investigationDefenseText;

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
        if(_turned == true)
        {
            _attributeCanvas.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _investigationDialogueUI.SetActive(false);
        }

    }

    public override void AttributeInvestigate(GameObject NPCattribute)
    {
        base.AttributeInvestigate(NPCattribute);
        Locator.Instance.dialogueAdvancer._currentNode = _investigationDialogue1;
        _investigationDialogueUI.SetActive(true);
        if(NPCattribute == _attribute1)
        {
            _investigationDefenseText.text = "...I woke up like this.";
            _attribute1Investigated = true;
        }
        if(NPCattribute == _attribute2)
        {
            _investigationDefenseText.text = "My jewelry is stuck to my arm.";
            _attribute2Investigated = true;
        }
        
        //work on making investigation dialogue appear

    }
    public override void AttributeFound(GameObject NPCattribute)
    {
        if (_attribute1Investigated == false)
        {
            AttributeInvestigate(NPCattribute);
        }
        if(_attribute2Investigated == false)
        {
            AttributeInvestigate(NPCattribute);
        }

        if(_attribute2Investigated == true || _attribute1Investigated == true)
        {
            base.AttributeFound(NPCattribute);
        }
        

        // if either attribute is investigated, if the attribute is number 1
        
            
     
        

        //base.AttributeFound(NPCattribute);
            

    }

    public override void Turn(Sprite sprite)
    {
        base.Turn(sprite);

    }

}
