using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private StarSystem starsystem;
    public Inventory inventory = new Inventory();
    //Stats
    public float acceleration = 10f;
    public float health = 100;
    public float currency = 100;
    public float mass = 500 * 1000; //mass in kg
    public float lifeSupport = 250; //Life support time in days
    //Transform
    public Trajectory trajectory;
    public Vector2 velocity = new Vector2(0,0);
    //Animation
    private int count = 0;
    private int samples = 50;
    private bool flying = false;
    //Interaction
    public Shop shop;
    //public GateWay gateway;
    public Body parent;
    //
    void Start () {
        starsystem = GameObject.Find("StarSystem").GetComponent<StarSystem>();
        
        //transform.gameObject.AddComponent<Inventory>();
        inventory = transform.gameObject.GetComponent<Inventory>();
        //transform.gameObject.AddComponent<Trajectory>();
        trajectory = transform.gameObject.GetComponent<Trajectory>();
        inventory.gas.initDict();
        inventory.solid.initDict();
        
        trajectory.startpos.x = transform.position.x;
        trajectory.startpos.y = transform.position.y;
    }
    void FixedUpdate()
    {

        
        //float storeTime = Body.time;

        //10 mil
        if (true)
        {
            //Body.time += 999999;
        }
        if (Input.GetButtonDown("b"))
        {
            if (shop != null)
            {

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            trajectory.acceleration = acceleration;
            trajectory.endpos = Camera.main.transform.position;//*Camera.main.orthographicSize;
            trajectory.flightTime = trajectory.getTime();
            trajectory.flightdV = trajectory.getdV();
            starsystem.viewGhosts(Body.time + trajectory.flightTime);
            //Body.time = trajectory.flightTime; //*50 because fixedupdate runs 50 times per second


        }
        if (Input.GetButtonDown("t"))
        {

            if (trajectory.endpos != trajectory.startpos)
            {
                flying = true;
                acceleration = inventory.propulsion.engine.thrust;
            }
        }
        if(Input.GetButtonDown("m"))
        {
            if (parent != null)
            {
                mine(5, 1);
                scoop(5, 1);
            }
            
        }
        if (count < samples && flying == true)
        {
            count++;
            Vector3 vectorToTarget = new Vector3(trajectory.endpos.x, trajectory.endpos.y, 0) - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg-90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
            transform.position = trajectory.getPos(trajectory.flightTime*2.75f*count/samples);
            Body.time += trajectory.flightTime*50 / samples;
            if (count == samples)
            {
                transform.position = trajectory.endpos;
                for (int i = 0; i < starsystem.planetNum; i++)
                {
                    Vector3 w = starsystem.planets[i].transform.position;
                    Vector3 vv = transform.position - w;
                    Vector2 l = new Vector2(vv.x, vv.y);
                    if (l.magnitude < 0.2)
                    {
                        parent = starsystem.planets[i].GetComponent<Body>();
                    } else
                    {
                        parent = null;
                    }
                    
                }
                lifeSupport -= trajectory.flightTime;
                inventory.propulsion.engine.burn(trajectory.flightdV);
                /*if ((transform.position - shop.transform.position).magnitude < 0.2)
                {
                    shop = starsystem.shop.GetComponent<Shop>();
                }
                else
                {
                    shop = null;
                }*/
                //Debug.Log("Done");
            }
            //Debug.Log(count);
        } else
        {
            trajectory.startpos = transform.position;
            count = 0;
            flying = false;
        }
    }   
	// Update is called once per frame
	void Update () {
        //Debug.Log(inventory);
        inventory.gas.updateDict();
        inventory.solid.updateDict();
    }
    public void scoop(float depth, float time)
    {
        Gas g = parent.atmospheric;
        List<string> keyList = new List<string>(g.dict.Keys);
        string[] gases = keyList.ToArray();
        for(int i = 0; i < gases.Length; i++)
        {
            float value = g.dict[gases[i]];
            inventory.gas.dict[gases[i]] = value * parent.atmosphere.pressure*depth*time/10;
        }
        inventory.gas.updateValues(); //Move the values in the dict to actual
        health -= Random.Range(0f, depth/10);
        lifeSupport -= time;
    }
    public void mine(float depth, float time)
    {
        Solid s = parent.surface;
        List<string> keyList = new List<string>(parent.surface.dict.Keys);
        string[] solids = keyList.ToArray();
        for (int i = 0; i < solids.Length; i++)
        {
            float value = s.dict[solids[i]];
            inventory.solid.dict[solids[i]] = value * parent.mass * depth * time;
        }
        inventory.solid.updateValues(); //Move the values in the dict to actual
        health -= Random.Range(0f, depth / 10);
        lifeSupport -= time;
    }
    public void repair(float repairAmount)
    {
        health += repairAmount;
        inventory.solid.Fe -= repairAmount*30;
    }
    public void repairAtShop(float repairAmount)
    {
        health += repairAmount;
        currency -= repairAmount;
    }
    public void refuelLifeSupport(float refuelAmount)
    {
        inventory.gas.O2 -= refuelAmount * 20;
        lifeSupport += refuelAmount;
    }
    

}
