using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gary : Patient
{
    [SerializeField] GameObject _attributeCanvas;
    [SerializeField] GameObject _attribute1;
    [SerializeField] GameObject _attribute2;

    public bool _attribute1Investigated = false;
    public bool _attribute2Investigated = false;

    void Start()
    {
        _attributeCanvas.SetActive(false);
        _npcIdentity = Identity.Human;
        _attributes = 0;
        _patientName = "Gary";
    }

    // Update is called once per frame
    void Update()
    {
        if(Locator.Instance.gameController._currentPatientObject == gameObject)
        {
            if (_turned == true)
            {
                _attributeCanvas.SetActive(true);
            }
            else
            {
                _attributeCanvas.SetActive(false);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //_investigationDialogueUI.SetActive(false);
            }
        }
    }
}
