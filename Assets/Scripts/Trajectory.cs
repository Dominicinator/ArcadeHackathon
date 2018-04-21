using UnityEngine;
using System.Collections;

public class Trajectory : MonoBehaviour {
    public Vector2 startpos;
    public Vector2 endpos;
    public float acceleration;
    public float flightTime;
    public float flightdV;
    //if trajectory endpos is within 0.2AU of a planet, that planet will become the ship's new parent
	// Use this for initialization
	void Start () {
        flightTime = getTime();
        flightdV = getdV();
	}
	
	// Update is called once per frame
	void Update () {
        flightTime = getTime();
        flightdV = getdV();
    }
    public float getTime()
    {
        Vector2 v = startpos - endpos;
        float d = v.magnitude*units.AU/units.coordinateScale;
        return 2*Mathf.Sqrt(d/acceleration);
    }
    public float getdV()
    {
        Vector2 v = startpos - endpos;
        float d = v.magnitude*units.AU/units.coordinateScale;
        return 2 * Mathf.Sqrt(d * acceleration);
    }
    public Vector2 getPos(float time)
    {
        float xt = 0.5f * acceleration * time * time;
        Vector2 v = endpos - startpos;
        Vector2 norm = v / v.magnitude;
        Vector2 dX = norm * xt/units.AU;
        Debug.Log(xt/units.AU);
        
        return startpos + dX;
    }
}
