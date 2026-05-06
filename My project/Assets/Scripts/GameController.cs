using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public bool _examTime;
    public int _attributesFound;
    public int _maxAttributes;
    public int _correctIdentifications;
    public int _incorrectIdentifications;
    public string _currentPatient;
    public GameObject _currentPatientObject;
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
        Locator.Instance._ui._endButton.SetActive(true);
    }

    public void Identification(string identity)
    {
        switch (_currentPatient)
        {
            case "Galatea":
                if (identity == _currentPatientObject.GetComponent<Galatea>()._npcIdentity.ToString())
                {
                    Locator.Instance._ui._identitySelectedText.GetComponent<TextMeshProUGUI>().text = "You note that Galatea is a Figure.";
                    Locator.Instance._ui._identitySelectedText.SetActive(true);
                    _correctIdentifications++;
                }
                else
                {
                    Locator.Instance._ui._identitySelectedText.GetComponent<TextMeshProUGUI>().text = "You note that Galatea is a human.";
                    Locator.Instance._ui._identitySelectedText.SetActive(true);
                    _incorrectIdentifications++;
                }
            ; break;
        }
    }
}
