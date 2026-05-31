using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gary : Patient
{
    
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;

    public bool _attribute1Investigated = false;
    public bool _attribute2Investigated = false;

    [SerializeField] GameObject _investigationDialogueUI;
    [SerializeField] TextMeshProUGUI _investigationDefenseText;
    // this would lowk be easier to put in the damn parent class smh

    public delegate void nextPatient(GameObject nextPatientObj, string nextPatientName);
    public event nextPatient GaryFinished;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _forwardSprite;
        //_attributeCanvas.SetActive(false);
        _npcIdentity = Identity.Human;
        _attributes = 0;
        _patientName = "Gary";
        _nextPatientObj.GetComponent<Bunny>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Locator.Instance.gameController._currentPatientObject == gameObject && Locator.Instance._uiController._examWindow.activeSelf == false)
        {
            if (_turned == true && Locator.Instance.gameController._examTime == true)
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
    }

    public override void AttributeInvestigate(GameObject NPCattribute)
    {
        _investigationDialogueUI.SetActive(true);
        if (Locator.Instance._uiController._examWindow.activeSelf == false)
        {
            if (NPCattribute == _attribute1)
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
                    if (NPCattribute == _attribute2)
                    {
                        if (_attribute2Investigated == true)
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
        else if(Locator.Instance._uiController._examWindow.activeSelf == true)
        {
            Debug.Log("nah");
        }
            

    }
    public override void AttributeFound(GameObject NPCattribute)
    {
        Debug.Log("found");
        Locator.Instance.gameController._incorrectMarkedAttributes++;
        base.AttributeFound(NPCattribute);
    }

    public override void NextPatient()
    {
        _investigationDialogueUI.SetActive(false);
        _nextPatientObj.GetComponent<Bunny>().enabled = true;
        Locator.Instance.dialogueAdvancer.ResetStartingDialogueNode(_nextPatientObj.GetComponent<Bunny>()._patientStartingDialogueNode);
        GaryFinished.Invoke(_nextPatientObj, "Bunny");
        _attributeCanvas.SetActive(false);
        base.NextPatient();
    }
}
