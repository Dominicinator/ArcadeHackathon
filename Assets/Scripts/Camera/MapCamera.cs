using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{
    public GameObject system;
    public float zoomSpeed = 50;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 0.01f;
    public float maxOrtho = 1000.0f;
    private Vector3 lastPosition;
    public float mouseSensitivity = 0.001f;
    public int currentPlanet = 0;
    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        system = GameObject.Find("StarSystem");
        
    }

    void FixedUpdate()
    {
        //Camera.main.orthographicSize
        //zoomSpeed = Camera.main.orthographicSize*50;
        //float panX = Input.GetAxis("MouseX");
        //float panY = Input.GetAxis("MouseX");
        //Camera camera = transform.gameObject.GetComponent<Camera>();
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            //Debug.Log("scrolling");
           
            targetOrtho -= scroll * zoomSpeed *targetOrtho;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            //Debug.Log(Camera.main.orthographicSize);
        }
        Camera.main.orthographicSize = targetOrtho;
        //Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            transform.Translate(-(delta.x * mouseSensitivity*Camera.main.orthographicSize/5), -(delta.y * mouseSensitivity * Camera.main.orthographicSize/5), 0);
            lastPosition = Input.mousePosition;
        }
        if (Input.GetButtonDown("["))
        {
            
            currentPlanet-=1;
            
            GameObject[] planets = system.GetComponent<StarSystem>().planets;
            if (currentPlanet < 0)
            {
                currentPlanet = planets.Length-1;
            }

            transform.position = planets[currentPlanet].transform.position;
            transform.Translate(new Vector3(0, 0, -10));

        }
        if (Input.GetButtonDown("]"))
        {
            currentPlanet+=1;
            GameObject[] planets = system.GetComponent<StarSystem>().planets;
            if (currentPlanet >= planets.Length)
            {
                currentPlanet = 0;
            }
            transform.position = planets[currentPlanet].transform.position;
            transform.Translate(new Vector3(0, 0, -10));
        }
        //transform.position = 0;
    }
}
