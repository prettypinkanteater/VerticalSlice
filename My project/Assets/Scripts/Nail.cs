using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Nail : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public PlayableDirector _nailPlayableDirector;
    public Animator _nailAnimator;
    public bool _playing;

    public GameObject _attributeTouching;

    private void Start()
    {
        _nailPlayableDirector = GameObject.Find("NailTimeline").GetComponent<PlayableDirector>();
        _nailAnimator = GetComponent<Animator>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _nailPlayableDirector.enabled = false;
        _nailAnimator.enabled = false;
    }
    private void Update()
    {
         
    }
    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void BeginTimeline()
    {
        _nailPlayableDirector.enabled = true;
        _nailAnimator.enabled = true;
        _nailPlayableDirector.Play();
    }

    public void AttributeIdentification()
    {
        GameObject.Find("Galatea").GetComponent<Galatea>().AttributeFound(_attributeTouching);
        gameObject.SetActive(false);
    }
}
