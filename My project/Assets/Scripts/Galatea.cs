using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    // event signaling next patient....after gamecontroller updates
    public delegate void nextPatient(string nextPatientName);
    public event nextPatient GalateaFinished;

    void Start()
    {
        _npcIdentity = Identity.Figure;
        _attributes = 2;
        _patientName = "Galatea";

        Locator.Instance.gameController._currentPatient = _patientName;
        Locator.Instance.gameController._maxAttributes = _attributes;
        Locator.Instance.gameController._currentPatientObject = gameObject;

        _attribute1.GetComponent<BoxCollider>().enabled = false;
        _attribute2.GetComponent<BoxCollider>().enabled = false;
        
    }


    void Update()
    {
        if(_turned == true)
        {
            _attributeCanvas.SetActive(true);
        }
        else
        {
            _attributeCanvas.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _investigationDialogueUI.SetActive(false);
        }

    }

    public override void AttributeInvestigate(GameObject NPCattribute)
    {
        _investigationDialogueUI.SetActive(true);
        

        if(NPCattribute == _attribute1)
        {
            if (_attribute1Investigated == true)
            {
                Debug.Log("nail 1");
                AttributeFound(NPCattribute);
                
            }
            else
            {
                Debug.Log("investigating");
                base.AttributeInvestigate(NPCattribute);
                _attribute1Investigated = true;
            }
        }
        if(NPCattribute == _attribute2)
        {
            if(_attribute2Investigated == true)
            {
                Debug.Log("nail 2");
                AttributeFound(NPCattribute);
                
            }
            else
            {
                Debug.Log("investigating 2");
                base.AttributeInvestigate(NPCattribute);
                _attribute2Investigated = true;
            }
        }

    }
    public override void AttributeFound(GameObject NPCattribute)
    {
        Debug.Log("found");
        base.AttributeFound(NPCattribute);
    }

    public override void Turn()
    {
        base.Turn();
    }

    public override void NextPatient()
    {
        GalateaFinished.Invoke("Gary");
        base.NextPatient();
    }

}
