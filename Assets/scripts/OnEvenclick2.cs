using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OnEvenclick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private string Action = "puzzle";
    private InputActionMap map;

    private InputAction hold;
    public float b = 5;
    [SerializeField] Vector3 dir;
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
        if (hold.IsPressed())
        {
            Vector3 mouspos = Input.mousePosition;
            //Debug.Log(mouspos);
            mouspos.z = 10.0f;

            Vector3 worldpos = Camera.main.ScreenToWorldPoint(mouspos);


            dir = (worldpos - transform.position).normalized;

            Debug.Log(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    

}
