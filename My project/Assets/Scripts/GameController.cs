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
        _totalHumans = 0;
        _totalFigures = 1;
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
                    _figureIdentificaitons++;
                }
                else
                {
                    _humanIdentifications++;
                    _incorrectIdentifications++;
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
        if((_attributesFound == _maxAttributes) && ((_figureIdentificaitons == _totalFigures) && _incorrectIdentifications == 0))
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
                // attributes found less than one half of total
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
        Locator.Instance._ui._shiftQualityText.GetComponent<TextMeshProUGUI>().text = "Shift Quality:" + shiftQuality.ToString();
    }

}
