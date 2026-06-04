using UnityEngine;

public class BounsLight : MonoBehaviour
{
    public float maxLength = 20f;
    public int reflections = 2;
    LineRenderer lr;
    Ray ray;
    RaycastHit hit;
    Vector3 dir;
  
   
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
        float remainingLength = maxLength;
        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);

                if (hit.collider.CompareTag("Mirror"))
                {
                   
                    dir = Vector3.Reflect(ray.direction, hit.normal);
                    ray = new Ray(hit.point + (dir * 0.01f), dir);
                    

                }
                else if (hit.collider.CompareTag("Burnable"))
                {
                    Debug.Log("burning");
                    Destroy(hit.collider.gameObject, 1f);

                }
                else
                {

                }
            }
            else
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }

        }

    }
}
