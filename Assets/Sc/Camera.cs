using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject hero;
    Vector3 offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hero = GameObject.Find("Hero");
        offset = new Vector3(0, 0, 0);
        this.transform.rotation = hero.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse_camera();
        raycast();
    }


    void raycast()
    {
        float panjangRay = 300f;
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * panjangRay, Color.red);
        if (Physics.Raycast(ray, out hit, panjangRay))
        {
            Debug.Log(hit.transform.name);
        }
    
    }
    void Mouse_camera()
    {
        offset = hero.transform.forward * -5f;
        offset += hero.transform.up * 1f;
        this.transform.LookAt(hero.transform);
        this.transform.position = hero.transform.position + offset;
    }
}
