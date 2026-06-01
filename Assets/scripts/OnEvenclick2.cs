using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class OnEvenclick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private string Action = "puzzle";
    private InputActionMap map;

    private InputAction hold;
    public float b = 5;
    public bool enterGameObject;
    [SerializeField] Vector3 dir;
    public float speed = 10f;
    public float speed2 = 0.3f;
    public bool puzzlecomplyt = false;
    private void Awake()
    {
        map = input.FindActionMap(Action);
        hold = map.FindAction("holdclick");
    }
    private void OnEnable()
    {
        map.Enable();
    }
    private void OnDisable()
    {
        map.Disable();
    }
    private void Update()
    {

        if (enterGameObject == true)
        {

            if (hold.IsPressed())
            {
                if (this.gameObject.tag == "keyPuzzel")
                {

                    Vector3 mouspos = Input.mousePosition;
                    Debug.Log(mouspos);
                    mouspos.z = 10.0f;

                    Vector3 worldpos = Camera.main.ScreenToWorldPoint(mouspos);


                    dir = (worldpos - transform.position).normalized;
                    //float singleStep = speed * Time.deltaTime;
                  
                   

                    Debug.Log(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle,Vector3.forward), speed2 * Time.deltaTime * speed);


                }

            }
        }
        float zRot= transform.eulerAngles.z;
        if (Mathf.Clamp(zRot, 0f, 5f) == zRot)
        {
            Debug.Log("asdasas");
            if (puzzlecomplyt == false)
            {
                puzzlecomplyt = true;

            }




        }
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
