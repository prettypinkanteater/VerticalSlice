using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Identity {
    Figure, Human
}

public abstract class Patient : MonoBehaviour
{
    public string _patientName;
    public Identity _npcIdentity { get; protected set; }
    protected int _attributes;
    protected bool _turned = false;
    

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
        Locator.Instance._ui.InvestigationDefense();
    }
    public virtual void AttributeFound(GameObject attribute)
    {
        Locator.Instance.gameController._attributesFound++;
        GameObject.Find("AttributesFoundBox").GetComponent<ExamStatsUI>().UpdateAttributesFoundUI();
        attribute.SetActive(false);
        
    }

    public virtual void Turn(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        _turned = true;
    }

}
