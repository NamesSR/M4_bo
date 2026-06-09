using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class keyDIle2 : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private string Action = "puzzle";
    private InputActionMap map;

    private InputAction hold;


    [SerializeField] Vector3 dir;
    public float speed = 10f;
    public float speed2 = 0.3f;
    public bool active;
    public bool enterGameObject;
    int currentdile = 1;
    public OnEvenclick2 OEC2;


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
        if (OEC2.enterGameObject == true)
        {
            Debug.Log("dffsadfdsafsdafsda");
            if (hold.IsPressed())
            {
                Debug.Log(gameObject.tag);
                if (this.gameObject.tag == "KeyDile1" || this.gameObject.tag == "KeyDile2" || this.gameObject.tag == "KeyDile3")
                {
                   if (active)
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
        }
        float zRot = transform.eulerAngles.z;
        if (Mathf.Clamp(zRot, 5f, 15f) == zRot)
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






}
