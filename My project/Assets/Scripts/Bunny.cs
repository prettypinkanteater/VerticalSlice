using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bunny : Patient
{
    
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;

    public bool _attribute1Investigated = false;
    public bool _attribute2Investigated = false;

    [SerializeField] GameObject _investigationDialogueUI;
    [SerializeField] TextMeshProUGUI _investigationDefenseText;

    // Start is called before the first frame update
    void Start()
    {
        _npcIdentity = Identity.Figure;
        _attributes = 2;
        _patientName = "Bunny";
    }

    // Update is called once per frame
    void Update()
    {
        if(Locator.Instance.gameController._currentPatientObject == gameObject)
        {
            if (Locator.Instance.gameController._examTime == true && _turned == false)
            {
                _attributeCanvas.SetActive(true);
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



    }
    public override void AttributeFound(GameObject NPCattribute)
    {
        Debug.Log("found");
        base.AttributeFound(NPCattribute);
    }

    public override void NextPatient()
    {
        // lalal
        base.NextPatient();
    }

}
