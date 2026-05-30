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
    //[SerializeField] private Camera _mainCamera;

    public int _shift;
    public int _shiftPatientNumber;

    public ShiftQuality shiftQuality;
    public bool _examTime;

    // attributes marked 
    public float _attributesFound;
    // total attributes existing
    public float _maxAttributes;

    public float _humanIdentifications;
    public float _figureIdentificaitons;

    public float _totalFigures = 1;
    public float _totalHumans = 0;

    public float _incorrectIdentifications;
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
        _totalHumans = 1;
        _totalFigures = 1;
        // move to switch statement assessing which shift currently on
    }
    void Start()
    {
        _shift = 1;

        _currentPatientObject.GetComponent<Galatea>().GalateaFinished += UpdateCurrentPatient;


    }

    void Update()
    {

    }

    public void UpdateCurrentPatient(GameObject nextPatientObj, string name)
    {
        _currentPatientObject = nextPatientObj;
        _currentPatient = name;
        _currentPatientObject.SetActive(true);
        _shiftPatientNumber++;
        _examTime = false;
        // use in state graph later to determine if it should transition to assessing shift quality
    }

    public void StartExam()
    {
        _examTime = true;
        Locator.Instance._ui._endButton.SetActive(true);
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
            ; break;

            case "Gary":
                if(identity == _currentPatientObject.GetComponent<Gary>()._npcIdentity.ToString())
                {

                }
            ; break;
        }

        _currentPatientObject.GetComponent<Galatea>().NextPatient();
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

        if ((_attributesFound == _maxAttributes) && ((_figureIdentificaitons == _totalFigures) && _incorrectIdentifications == 0))
        {
            Debug.Log("Good Job");
            shiftQuality = ShiftQuality.Excellent;
        }
        else if((_attributesFound < _maxAttributes) || (_incorrectIdentifications > 0))
        {
            if ((_totalFigures > 1) && (_figureIdentificaitons < _totalFigures/2))
            {
                Debug.Log("Poor 1");
                shiftQuality = ShiftQuality.Poor;
            }
            else if (_attributesFound < _maxAttributes/2)
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

        Locator.Instance._ui._shiftQualityText.SetActive(true);
        Locator.Instance._ui._shiftQualityPanel.SetActive(true);
        Locator.Instance._ui._shiftQualityText.GetComponent<TextMeshProUGUI>().text = "Shift Quality:" + " " + shiftQuality.ToString();
    }

}
