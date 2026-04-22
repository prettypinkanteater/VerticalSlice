using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _dialogueText;
    [SerializeField] public TextMeshProUGUI _characterName;

    void Start()
    {
        
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
}
