using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Identity {
    Figure, Human
}

public abstract class Patient : MonoBehaviour
{
    protected Identity _npcIdentity;
    protected int _attributes;

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
        Locator.Instance.dialogueUI.InvestigationDefense();
    }
    public virtual void AttributeFound(GameObject attribute)
    {
        Locator.Instance.gameController._attributesFound++;
        attribute.SetActive(false);
        Debug.Log(Locator.Instance.gameController._attributesFound.ToString());
    }
}
