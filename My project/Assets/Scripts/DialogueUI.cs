using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _dialogueText;
    [SerializeField] public TextMeshProUGUI _characterName;
    [SerializeField] public GameObject _startExamButtonUI;
    [SerializeField] public GameObject _dialoguePanel;
    [SerializeField] public GameObject _namePanel;

    [SerializeField] public GameObject _turnButton;
    [SerializeField] public GameObject _endButton;

    [SerializeField] public GameObject _examWindow;

    [SerializeField] public GameObject _identitySelectedText;

    [SerializeField] public GameObject _nailPileButton;

    [SerializeField] public GameObject _shiftQualityText;
    [SerializeField] public GameObject _shiftQualityPanel;

    [SerializeField] public DialogueNode _attribute1DefenseNode;
    [SerializeField] public DialogueNode _attribute2DefenseNode;

    [SerializeField] public GameObject _attribute1;
    [SerializeField] public GameObject _attribute2;

    [SerializeField] public GameObject _investigationDefenseText;

    void Start()
    {
        _nailPileButton.SetActive(false);
        _startExamButtonUI.SetActive(false);
        _turnButton.SetActive(false);
        _endButton.SetActive(false);
        _examWindow.SetActive(false);
        _identitySelectedText.SetActive(false);
        _shiftQualityText.SetActive(false);
        _shiftQualityPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDialogueUI()
    {
        _dialogueText.enabled = true;
        _characterName.enabled = true;
        _dialoguePanel.SetActive(true);
        _namePanel.SetActive(true);
    }

    public void updateDialogueText(string line)
    {
        _dialogueText.text = line;

    }

    public void updateCharacterName(string line)
    {
        _characterName.text = line;
    }

    public void showExamStartButton()
    {
        _namePanel.SetActive(false);
        _dialoguePanel.SetActive(false);
        _startExamButtonUI.SetActive(true);
    }

    public void investigationDefense(GameObject attribute)
    {
        if(attribute == _attribute1)
        {
            _investigationDefenseText.GetComponent<TextMeshProUGUI>().text = _attribute1DefenseNode._lines[0];
        }
        else if(attribute == _attribute2)
        {
            _investigationDefenseText.GetComponent<TextMeshProUGUI>().text = _attribute2DefenseNode._lines[0];
        }

        _dialoguePanel.SetActive(true);
    }

    public void showIdentificationWindow()
    {
        _examWindow.SetActive(true);
        _turnButton.SetActive(false);
        _endButton.SetActive(false);
    }
}
