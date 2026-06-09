using UnityEngine;

public class idk23 : MonoBehaviour
{
    public GameObject burnebleprefab;
    Vector3 pos;
    private void Awake()
    {
       
    }
    void Start()
    {
        pos = new Vector3(2.11025f, 2.33918f, -12.38297f);
        Instantiate(burnebleprefab, pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
