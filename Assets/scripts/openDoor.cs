using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject door;
    public player player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision");
            if (Input.GetKey(KeyCode.E) && player.haskey)
            {
                Debug.Log("door Opend");
                var s = door.GetComponent<BoxCollider>();
                s.enabled = false;
            }
        }
    }
}