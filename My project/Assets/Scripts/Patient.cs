using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Identity {
    Figure, Human
}

public abstract class Patient : MonoBehaviour
{
    public string _patientName;
    public Identity _npcIdentity { get; protected set; }
    protected int _attributes;
    public bool _turned = false;
    public Sprite _forwardSprite;
    public Sprite _backwardsSprite;

    //public List<bool> _attributesInvestigated = new List <bool>();
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InvestigateOrFound()
    {

    }

    public virtual void AttributeInvestigate(GameObject attribute)
    {
        Locator.Instance._ui.investigationDefense();
        attribute.GetComponent<Button>().enabled = false;
        attribute.GetComponent<BoxCollider>().enabled = true;
        
    }
    public virtual void AttributeFound(GameObject attribute2)
    {
        attribute2.SetActive(false);
        Locator.Instance.gameController._attributesFound++;
        Locator.Instance.examStatsUI.UpdateAttributesFoundUI();
    }

    public virtual void Turn()
    {
        if(_turned)
        {
            GetComponent<SpriteRenderer>().sprite = _forwardSprite;
            _turned = false;
        }
        else if (_turned == false)
        {
            GetComponent<SpriteRenderer>().sprite = _backwardsSprite;
            _turned = true;
        }

        // turned not set back to freaking false 
        // implement attribute fixes to second one.
    }

}
