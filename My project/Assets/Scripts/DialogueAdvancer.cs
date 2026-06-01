using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueAdvancer : MonoBehaviour
{
    public DialogueNode _currentNode;
    public DialogueNode _tutorialNode;
    [SerializeField] private DialogueNode _startingNode;
    public int _currentLine;
    [SerializeField] private uiController _dialogueUI;
    
    
    
    //_currentNode._examTime;
    // Start is called before the first frame update
    void Start()
    {
        _currentNode = _startingNode;
        _dialogueUI.updateDialogueText(_currentNode._lines[0]);
        _dialogueUI.updateCharacterName(_currentNode.npcTalking);
        _currentLine = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _dialogueUI._tutorialPanel.activeSelf == true)
        {
            AdvanceTutorial();
        }

        if(Locator.Instance.gameController._examTime == false)
        {
            _dialogueUI.killTutorialUI();
        }

        if (_currentNode.examNext && (_currentNode._lines.Length == _currentLine))
        {
            _dialogueUI.showExamStartButton();
            Cursor.lockState = CursorLockMode.None;
            _currentNode = null;
        }
    }

    public void BeginTutorial()
    {
        _currentNode = _tutorialNode;
        _dialogueUI._tutorialText.GetComponent<TextMeshProUGUI>().text = _currentNode._lines[0];
        _dialogueUI.showTutorialUI();
        _currentLine = 1;
    }

    public void AdvanceTutorial()
    {
        if (_currentNode._lines.Length >= _currentLine)
        {
            _dialogueUI.updateTutorialText(_currentNode._lines[_currentLine]);
            _currentLine++;

            if(_currentLine == _currentNode._lines.Length && _currentLine != 3)
            {
                Debug.Log("Death");
                _dialogueUI.killTutorialUI();
            }
        }

        // YEAHH WE DID IT!!!

    }

    public void AdvanceDialogue()
    {
        if (_dialogueUI._tutorialPanel.activeSelf == false) 
        { 
            if (_currentLine < _currentNode._lines.Length)
            {
                _dialogueUI.updateDialogueText(_currentNode._lines[_currentLine]);
                _currentLine++;
            }
            else
            {
                _currentNode = _currentNode._nextNode[0];
                ResetDialogueDisplay();
            }
        }
        

    }

    public void ResetDialogueDisplay()
    {
        _currentLine = 1;
        _dialogueUI.updateDialogueText(_currentNode._lines[0]);
        _dialogueUI.updateCharacterName(_currentNode.npcTalking);
    }

    public void ResetStartingDialogueNode(DialogueNode dialogueNode)
    {
        _currentNode = dialogueNode;
        _currentLine = 1;
        _dialogueUI.updateDialogueText(_currentNode._lines[0]);
        _dialogueUI.updateCharacterName(dialogueNode.npcTalking);
    }

}
