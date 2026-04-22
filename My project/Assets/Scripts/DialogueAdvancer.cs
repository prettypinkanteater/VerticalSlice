using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAdvancer : MonoBehaviour
{
    private DialogueNode _currentNode;
    [SerializeField] private DialogueNode _startingNode;
    private int _currentLine = 0;
    [SerializeField] private DialogueUI _dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        _currentNode = _startingNode;
        //Locator.Instance.dialogueUI.updateDialogueText(_currentNode._lines[_currentLine]);
        _dialogueUI.updateDialogueText(_currentNode._lines[_currentLine]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceDialogue()
    {

    }
}
