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
   
    public bool enterGameObject;
    [SerializeField] Vector3 dir;
    public float speed = 10f;
    public float speed2 = 0.3f;

    int currentdile = 1;


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
        currentdile = keypuzzel.instance.currentdilel;
        if (enterGameObject == true)
        {

            if (hold.IsPressed())
            {
                Debug.Log(gameObject.tag);
                if (this.gameObject.tag == "KeyDile1" || this.gameObject.tag == "KeyDile2" || this.gameObject.tag == "KeyDile3")
                {

                    Vector3 mouspos = Input.mousePosition;
                    Debug.Log(mouspos);
                    mouspos.z = 10.0f;

                    Vector3 worldpos = Camera.main.ScreenToWorldPoint(mouspos);


                    dir = (worldpos - transform.position).normalized;
                    //float singleStep = speed * Time.deltaTime;



                    Debug.Log(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), speed2 * Time.deltaTime * speed);


                }

            }
        }
        float zRot = transform.eulerAngles.z;
        if (Mathf.Clamp(zRot, 0f, 5f) == zRot)
        {
            Debug.Log("asdasas");
            switch (this.gameObject.tag)
            {
                case "KeyDile1":
                    keypuzzel.instance.dile1 = true;
                    break;
                case "KeyDile2":
                    keypuzzel.instance.dile2 = true;
                    break;
                case "KeyDile3":
                    keypuzzel.instance.dile3 = true;
                    break;
            }

            // dile1 = true;//  puzzlecomplyt = true;






        }
        else
        {
            switch (this.gameObject.tag)
            {
                case "KeyDile1":
                    keypuzzel.instance.dile1 = false;
                    break;
                case "KeyDile2":
                    keypuzzel.instance.dile2 = false;
                    break;
                case "KeyDile3":
                    keypuzzel.instance.dile3 = false;
                    break;
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
