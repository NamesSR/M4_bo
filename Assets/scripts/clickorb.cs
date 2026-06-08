using UnityEngine;
using UnityEngine.InputSystem;

public class clickorb : MonoBehaviour
{
    Vector3 Mousepos;
    RaycastHit hit;
    Transform click;
    [SerializeField] private InputActionAsset input;
    [SerializeField] private string Action = "puzzle";
    orb orb;
    public int orbamount = 4;
    int orbdestoryed = 0;
    public int currentid = 0;
    int lastid;

    private InputActionMap map;

    private InputAction hold;
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
        if(orbamount >= orbdestoryed)
        {
            GameManager.Instance.puzzlecompleted();
            this.gameObject.SetActive(false);
        }
        Mousepos = Input.mousePosition;

        Ray mousRay = Camera.main.ScreenPointToRay(Mousepos);



        if (hold.IsPressed())
        {
            click = Physics.Raycast(mousRay.origin, mousRay.direction, out hit) ? hit.collider.transform : null;
           // Debug.Log(click.gameObject.name);
            if (click && click.gameObject.tag == "orb")
            {
                Debug.Log(click.gameObject.name);
                orb = click.gameObject.GetComponent<orb>();
                Debug.Log(orb.id);
                if (currentid == 0)
                {

                    currentid = orb.id;
                }

                if (!GameManager.Instance.wobbs.Contains(click.gameObject))
                {
                    if (GameManager.Instance.wobbs.Count == 0)
                    {
                        GameManager.Instance.wobbs.Add(click.gameObject);

                    }
                    else if (currentid == orb.id)
                    {
                        GameManager.Instance.wobbs.Add(click.gameObject);
                    }

                }

            }
        }
        if (hold.WasReleasedThisFrame())
        {
            if (GameManager.Instance.wobbs.Count > 0)
            {
                foreach (GameObject wobb in GameManager.Instance.wobbs)
                {
                    wobb.SetActive(false);
                    orbdestoryed++;
                }
                GameManager.Instance.wobbs.Clear();
                currentid = 0;
            }
        }
    }

}