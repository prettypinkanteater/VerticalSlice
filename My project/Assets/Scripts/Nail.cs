using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Nail : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public PlayableDirector _nailPlayableDirector;
    public Animator _nailAnimator;
    public bool _playing;

    public GameObject _attributeTouching;
    [SerializeField] private Material _outlineMaterial;

    public static bool queriesHitTriggers = false;

    private void Start()
    {
        _nailPlayableDirector = GameObject.Find("NailTimeline").GetComponent<PlayableDirector>();
        _nailAnimator = GetComponent<Animator>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _nailPlayableDirector.enabled = false;
        _nailAnimator.enabled = false;
        //GetComponent<UnityEngine.UI.Image>().material = null;
    }
    private void Update()
    {
         
    }
    public void DragHandler(BaseEventData data)
    {
        GetComponent<UnityEngine.UI.Image>().material = null;
        
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void OnMouseExit()
    {
        Debug.Log("HELPPPs");
    }

    public void BeginTimeline()
    {
        _nailPlayableDirector.enabled = true;
        _nailAnimator.enabled = true;
        _nailPlayableDirector.Play();
    }

    public void AttributeIdentification()
    {
        if (_attributeTouching.tag == "Galatea")
        {
            GameObject.Find("Galatea").GetComponent<Galatea>().AttributeFound(_attributeTouching);
        }
        if (_attributeTouching.tag == "Gary")
        {
            GameObject.Find("Gary").GetComponent<Gary>().AttributeFound(_attributeTouching);
        }
        if(_attributeTouching.tag == "Bunny")
        {
            GameObject.Find("Bunny").GetComponent<Bunny>().AttributeFound(_attributeTouching);
        }

        _nailPlayableDirector.time = 0;
        _nailPlayableDirector.enabled = false;
        _nailAnimator.enabled = false; 
        gameObject.SetActive(false);

    }

    public void playNailInsertSFX()
    {
        Locator.Instance._audioManager.playSound("Insert");
    }
}
