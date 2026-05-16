using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using TMPro;
using Unity.VisualScripting;
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

    [SerializeField] GameObject _nailPrefab;
    public GameObject _currentNail;

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
        // if statement to check if ermmmm shift finished
        if(_currentPatient == "Galatea")
        {
            if((_incorrectIdentifications == 1) || _correctIdentifications == 1)
            {

            }
        }
    }

    public void StartExam()
    {
        _attributesFound = 0;
        _examTime = true;
        // Instantiate(_nailPrefab);
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

    public void spawnNail()
    {
        Nail nailScript = _currentNail.GetComponent<Nail>();
        _currentNail.SetActive(true);
        nailScript._nailAnimator.enabled = false;
        nailScript._nailPlayableDirector.enabled = false;
    }

    public void killNail()
    {
        _currentNail.SetActive(false);
    }

}
