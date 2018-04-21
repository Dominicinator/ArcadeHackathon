using UnityEngine;
using System.Collections;

public class StarSystem : MonoBehaviour {
    //public GameObject bodyPrefab;
    public int signalNum;
    public int planetNum;
    public float systemSizelow;
    public float systemSizehigh;
    public GameObject shop;
    public Enemy[] enemies;
    public Signal[] signals;
    public GameObject[] planets;
    public GameObject mainStar;
    //public Transform brick;

    //void Start()
    //{
        //for (int y = 0; y < 5; y++)
        //{
            //for (int x = 0; x < 5; x++)
            //{
                //Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);
            //}
        //}
    //}
    // Use this for initialization
    void Start () {
        generate();
	}

    
    private GameObject[] spheres;
    public void generateGhosts()
    {
        spheres = new GameObject[planetNum];
        for (int i = 0; i < planetNum; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.SetActive(false);
            spheres[i] = sphere;
        }
    }
    public void viewGhosts(float time)
    {

        for (int i = 0; i < planets.Length; i++)
        {
            spheres[i].SetActive(true);
            Body b = planets[i].GetComponent<Body>();
            Kepler orbit = b.orbit;
            spheres[i].transform.localScale = new Vector3(units.coordinateScale * b.radius / 60, units.coordinateScale * b.radius / 60, 1);
            spheres[i].transform.localPosition = orbit.r(time)/units.AU * units.coordinateScale;
            //Gizmos.color = new Color(0,255,0);
            //Gizmos.DrawSphere(orbit.r(time), units.coordinateScale*b.radius/60);
            
            //Gizmos.Draw
        }
    }
    public void hideGhosts()
    {
        for(int i = 0; i <spheres.Length; i++)
        {
            spheres[i].SetActive(false);
        }
        
    }
    public void onWarp()
    {
        Destroy(shop);
        Destroy(mainStar);
        /*for (int i = 0; i < planetNum; i++)
        {
            Destroy(planets[i]);
            Destroy(spheres[i]);
            
            
        }*/ //Don't think I need this because destroying mainstar destroys its children??

    }
	void Update () {
        
	
	}

    public void generate()
    {
        generateGhosts();
        Kepler test = new Kepler();
        test.fromEvA(units.AU, new Vector2(0, 0.0001f), units.G * (units.ME + units.ME * 333333));
        Debug.Log(test.r(0).x / units.AU);
        //Generate the mainstar

        mainStar = new GameObject();
        mainStar.AddComponent<Body>();
        mainStar.GetComponent<Body>().generateStar();
        //Generate planets
        planets = new GameObject[planetNum];
        for (int i = 0; i < planetNum; i++)
        {
            planets[i] = new GameObject();
            planets[i].AddComponent<Body>();
            planets[i].transform.SetParent(mainStar.transform);
            Body component = planets[i].GetComponent<Body>();
            component.generate();
            component.parent = mainStar.GetComponent<Body>();
            component.generateOrbit(systemSizelow, systemSizehigh);
        }
        //Generate Signals (events)
        signals = new Signal[signalNum];
        for (int i = 0; i < signalNum; i++)
        {
            signals[i].generate();
        }

        //Generate NPCs (enemies, shops, stations, one warp gate)
        //shop = new GameObject();
        //shop.AddComponent<Shop>();
        //Shop shopcomponent = shop.GetComponent<Shop>();
        //shop.transform.localPosition = new Vector2(Random.Range(2f, 4f), Random.Range(-2f, -4f));
        //ShopTextController stc = GameObject.Find("ShopPrices").GetComponent<ShopTextController>();
        //stc.initThis();
    }
}
