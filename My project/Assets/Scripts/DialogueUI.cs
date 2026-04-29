using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _dialogueText;
    [SerializeField] public TextMeshProUGUI _characterName;
    [SerializeField] public GameObject _startExamButtonUI;
    [SerializeField] public GameObject _dialoguePanel;
    [SerializeField] public GameObject _namePanel;

    void Start()
    {
        _startExamButtonUI.SetActive(false);
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

    public void InvestigationDefense()
    {
        _namePanel.SetActive(true);
        _dialoguePanel.SetActive(true);
        _startExamButtonUI.SetActive(false);
    }
}
