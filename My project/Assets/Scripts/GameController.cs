using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum ShiftQuality
{
    Excellent, Mediocre, Poor
}
public class GameController : MonoBehaviour
{
    public int _shift;
    public int _shiftPatientNumber;

    public ShiftQuality shiftQuality;
    public bool _examTime;
    public bool _newShift = false;
    public bool _tutorialTime = false;

    // attributes marked 
    public float _attributesFound;
    // total attributes existing
    public float _maxAttributes;

    public float _humanIdentifications;
    public float _figureIdentificaitons;

    public float _totalFigures;
    public float _totalHumans;

    public float _incorrectIdentifications;
    public float _incorrectMarkedAttributes;

    //public bool _allAttributesFound;
    public string _currentPatient;
    public GameObject _currentPatientObject;

    [SerializeField] GameObject _nailPrefab;
    public GameObject _currentNail;

    public bool _examEnded;

    private void Awake()
    {
        _examTime = false;
        _examEnded = false;
   
    }
    void Start()
    {
        NewShift();
        _currentPatientObject.GetComponent<Galatea>().EndShift1 += AssessShift;
        _currentPatientObject.GetComponent<Galatea>().GalateaFinished += UpdateCurrentPatient;
        GameObject.Find("Gary").GetComponent<Gary>().GaryFinished += UpdateCurrentPatient;
    }

    
    void Update()
    {

    }

    public void NewShift()
    {
        _attributesFound = 0;
        _incorrectIdentifications = 0;
        _humanIdentifications = 0;
        _figureIdentificaitons = 0;
        _incorrectMarkedAttributes = 0;
        _shiftPatientNumber = 1;
        _shift++;

        switch (_shift)
        {
            case 1:
                _totalFigures = 1;
                _totalHumans = 0;
                _maxAttributes = 2;
                break;

            case 2:
                _totalFigures = 1;
                _totalHumans = 1;
                _maxAttributes = 2;
                break;
        }

        if(_shift != 1)
        {
            _newShift = true;
        }

    }
    public void UpdateCurrentPatient(GameObject nextPatientObj, string nextPatientName)
    {
        _currentPatient = nextPatientName;
        _currentPatientObject = nextPatientObj;
        _currentPatientObject.SetActive(true);
        if(_shiftPatientNumber == 1)
        {
            _shiftPatientNumber++;
        }
        _examTime = false;

    }
    public void StartExam()
    {
        _examTime = true;
        Locator.Instance.dialogueAdvancer._currentLine = 0;
        Locator.Instance._uiController._endButton.SetActive(true);
    }

    public void Identification(string identity)
    {
        // at end of exam!!!!
        switch (_currentPatient)
        {
            case "Galatea":
                if (identity == _currentPatientObject.GetComponent<Galatea>()._npcIdentity.ToString())
                {
                    _figureIdentificaitons++;
                }
                else
                {
                    _humanIdentifications++;
                    _incorrectIdentifications++;
                }
                _examEnded = true;
                ; break;
            case "Gary":
                if (identity == _currentPatientObject.GetComponent<Gary>()._npcIdentity.ToString())
                {
                    _humanIdentifications++;
                }
                else
                {
                    _figureIdentificaitons++;
                    _incorrectIdentifications++;
                }
                _currentPatientObject.GetComponent<Gary>().NextPatient();
                ; break;
            case "Bunny":
                if (identity == _currentPatientObject.GetComponent<Bunny>()._npcIdentity.ToString())
                {
                    _figureIdentificaitons++;
                }
                else
                {
                    _incorrectIdentifications++;
                    _humanIdentifications++;
                }
                _examEnded = true;
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

    public void AssessShift()
    {
        Debug.Log("Assessing Shift");
        _newShift = false;
        _examTime = false;
        if ((_attributesFound == _maxAttributes && _figureIdentificaitons == _totalFigures) 
            && (_incorrectIdentifications == 0 && _incorrectMarkedAttributes == 0))
        {
            Debug.Log("Good Job");
            shiftQuality = ShiftQuality.Excellent;
        }
        else if ((_attributesFound < _maxAttributes) || (_incorrectIdentifications > 0))
        {
            if ((_totalFigures > 1) && (_figureIdentificaitons < _totalFigures / 2))
            {
                Debug.Log("Poor 1");
                shiftQuality = ShiftQuality.Poor;
            }
            else if (_attributesFound < _maxAttributes / 2)
            {
                Debug.Log("Poor 2");
                shiftQuality = ShiftQuality.Poor;
            }
            else if (_incorrectIdentifications > 0)
            {
                Debug.Log("Poor 3");
                shiftQuality = ShiftQuality.Poor;
            }
            else
            {
                Debug.Log("Mediocre");
                shiftQuality = ShiftQuality.Mediocre;
            }
        }

        Locator.Instance._uiController._shiftQualityText.SetActive(true);
        Locator.Instance._uiController._shiftQualityPanel.SetActive(true);
        Locator.Instance._uiController._shiftQualityText.GetComponent<TextMeshProUGUI>().text = "Shift Quality:" + " " + shiftQuality.ToString();

        if (_currentPatientObject == GameObject.Find("Galatea"))
        {
            _currentPatientObject.GetComponent<Galatea>().NextPatient();
        }
        
    }

}
