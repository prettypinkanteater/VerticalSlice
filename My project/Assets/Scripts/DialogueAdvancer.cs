using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueAdvancer : MonoBehaviour
{
    public DialogueNode _currentNode;
    [SerializeField] private DialogueNode _startingNode;
    public int _currentLine;
    [SerializeField] private DialogueUI _dialogueUI;
    
    
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
        if (_currentNode.examNext && (_currentNode._lines.Length == _currentLine))
            {
                _dialogueUI.showExamStartButton();
                Cursor.lockState = CursorLockMode.None;
            }
    }

    

    public void AdvanceDialogue()
    {
        if(_currentLine < _currentNode._lines.Length)
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

    public void ResetDialogueDisplay()
    {
            _currentLine = 1;
            _dialogueUI.updateDialogueText(_currentNode._lines[0]);
            _dialogueUI.updateCharacterName(_currentNode.npcTalking);
    }
}
