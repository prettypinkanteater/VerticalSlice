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

    void Start()
    {
        _startExamButtonUI.SetActive(false);
        _turnButton.SetActive(false);
        _endButton.SetActive(false);
        _examWindow.SetActive(false);
        _identitySelectedText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void investigationDefense()
    {
        _namePanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _startExamButtonUI.SetActive(false);
    }

    public void showIdentificationWindow()
    {
        _examWindow.SetActive(true);
        _turnButton.SetActive(false);
        _endButton.SetActive(false);
    }
}
