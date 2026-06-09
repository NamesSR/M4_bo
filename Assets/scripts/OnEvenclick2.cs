using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class OnEvenclick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{


    public bool enterGameObject;
   // public static OnEvenclick2 Instance;




    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    private void Update()
    {



    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {


    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        enterGameObject = true;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        enterGameObject = false;
    }


}
