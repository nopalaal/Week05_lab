using UnityEngine;

public class CameraSC : MonoBehaviour
{
    GameObject hero;
    Vector3 offset;

    float defaultDistance = 5f;   
    float currentDistance;        
    float smoothSpeed = 10f;     
    float collisionOffset = 0.3f; 

    void Start()
    {
        hero = GameObject.Find("Hero");
        this.transform.rotation = hero.transform.rotation;
        currentDistance = defaultDistance;
    }

    void Update()
    {
        Mouse_camera();
    }

    void Mouse_camera()
    {
   
        Vector3 dir = (hero.transform.forward * -1f) + (hero.transform.up * 0.2f);
        dir.Normalize();

        float targetDistance = defaultDistance;

        RaycastHit hit;
  
        if (Physics.Raycast(hero.transform.position, dir, out hit, defaultDistance))
        {
            if (hit.transform.name == "Tembok")
            {
                targetDistance = hit.distance - collisionOffset;
            }
        }

        currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * smoothSpeed);

        offset = dir * currentDistance;

        this.transform.LookAt(hero.transform);
        this.transform.position = hero.transform.position + offset;
    }
}