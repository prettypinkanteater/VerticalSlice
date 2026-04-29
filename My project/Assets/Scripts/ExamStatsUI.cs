using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExamStatsUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _attributesFoundText;
    [SerializeField] public TextMeshProUGUI _identification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAttributesFoundUI()
    {
        _attributesFoundText.text = Locator.Instance.gameController._attributesFound.ToString();
    }

    public void IdentifyUI(Identity identity)
    {
        _identification.text = identity.ToString();
    }
}
