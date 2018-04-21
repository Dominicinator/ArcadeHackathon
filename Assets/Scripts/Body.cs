using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {
    public static float deltaTime = 1;
    public static float time = 0;
    //Appearance
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    //Orbital
    public Body parent;
    public Kepler orbit = new Kepler();
    public Vector2 lol;
    public float p;
    public float a;
    public float ttt;
    //Compositions
    public Solid surface = new Solid();
    public Planetary planetary = new Planetary();
    public Gas atmospheric = new Gas();
    //Properties
    public Atmosphere atmosphere = new Atmosphere();
    public float mass;
    public float radius;
    public float density;
    //Classification
    public string classification; //S, T, G
    public Template template;
    public string subclassification;
	// Use this for initialization
	void Start () {
        
        transform.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        //transform.gameObject.
        //spriteRenderer = transform.gameObject.AddComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        Body.time += deltaTime;
        //Debug.Log(Body.time);
        //Vector2 rr = orbit.circularR(time);//orbit.r(Body.time);
        p = orbit.p / 60 / 60 / 24/365;
        a = orbit.a / units.AU;
        Vector2 rr = orbit.r(time);
        //float angle = ((time/60/60/24/365) / p)*360;
        //lol = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        //Vector2 rr = new Vector2(a*lol.x, a*lol.y);
        //ttt = a * lol.y;
        if(float.IsNaN(rr.x) || float.IsNaN(rr.y)) {
            rr = new Vector2(0,0);
        } 
        
        transform.localPosition = rr/units.AU*units.coordinateScale;
        
        
        //transform.position = new Vector2(0, 0);
        //transform.position = (rr);// *units.coordinateScale;
        //float radius_ = radius;
        //transform.localScale = new Vector3(radius_, radius_, radius_);
        //Debug.Log(transform.position.x);
        //Debug.Log(transform.position.y);
	}
    public void generate()
    {
        string[] temp_ = {"Jupiter", "Arcane", "Sulfur", "Methane", "Neptune", "IceGiant", "Earth", "Desert", "Barren", "Water", "Ice", "Carbon"};
        float[] temp_probs = {0.07f,  0.02f,    0.05f,     0.1f,     0.08f,     0.05f,     0.03f,    0.1f,    0.15f,   0.15f,  0.1f,   0.05f};
        int element = probabalisticElement(temp_, temp_probs);
        //subclassification = STG (do later)
        GameObject temp = GameObject.Find(temp_[element]);
        template = temp.GetComponent<Template>();
        sprite = template.sprite;
        planetary.carbon = Random.Range(template.carbon[0], template.carbon[1]);
        planetary.metal = Random.Range(template.metal[0], template.metal[1]);
        planetary.ice = Random.Range(template.ice[0], template.ice[1]);
        planetary.silica = Random.Range(template.silica[0], template.silica[1]);
        planetary.gas = Random.Range(template.gas[0], template.gas[1]);
        //V = M/D
        mass = Random.Range(template.massRange[0], template.massRange[1]);
        density = mass/planetary.getVolume(mass);
        float k = 4 * Mathf.PI / 3;
        //this.radius = pow(volume / k, 1 / 3) / RE;

        radius = Mathf.Pow(planetary.getVolume(mass)/k, 1 / 3);//units.RE;
        //Debug.Log(planetary.getVolume(mass));
        atmospheric.H = Random.Range(template.gasLower[0], template.gasHigher[0]);
        atmospheric.He = Random.Range(template.gasLower[1], template.gasHigher[1]);
        atmospheric.O2 = Random.Range(template.gasLower[2], template.gasHigher[2]);
        atmospheric.H2O = Random.Range(template.gasLower[3], template.gasHigher[3]);
        atmospheric.CO2 = Random.Range(template.gasLower[4], template.gasHigher[4]);
        atmospheric.Ar = Random.Range(template.gasLower[5], template.gasHigher[5]);
        atmospheric.Ne = Random.Range(template.gasLower[6], template.gasHigher[6]);
        atmospheric.Xe = Random.Range(template.gasLower[7], template.gasHigher[7]);
        atmospheric.N = Random.Range(template.gasLower[8], template.gasHigher[8]);
        atmospheric.Methane = Random.Range(template.gasLower[9], template.gasHigher[9]);
        atmospheric.H2S = Random.Range(template.gasLower[10], template.gasHigher[10]);
        atmospheric.H2SO4 = Random.Range(template.gasLower[11], template.gasHigher[11]);
        atmospheric.Thaumiel = Random.Range(template.gasLower[12], template.gasHigher[12]);
        atmospheric.Frisz = Random.Range(template.gasLower[13], template.gasHigher[13]);
        atmospheric.Nitriol = Random.Range(template.gasLower[14], template.gasHigher[14]);
        surface.Fe = Random.Range(template.solidLower[0], template.solidHigher[0]);
        surface.C = Random.Range(template.solidLower[1], template.solidHigher[1]);
        surface.Au = Random.Range(template.solidLower[2], template.solidHigher[2]);
        surface.Ag = Random.Range(template.solidLower[3], template.solidHigher[3]);
        surface.Pt = Random.Range(template.solidLower[4], template.solidHigher[4]);
        surface.Pu = Random.Range(template.solidLower[5], template.solidHigher[5]);
        surface.U = Random.Range(template.solidLower[6], template.solidHigher[6]);
        surface.He3 = Random.Range(template.solidLower[7], template.solidHigher[7]);
        surface.Shadowmiel = Random.Range(template.solidLower[8], template.solidHigher[8]);
        surface.Akashite = Random.Range(template.solidLower[9], template.solidHigher[9]);
        surface.Chrism = Random.Range(template.solidLower[10], template.solidHigher[10]);
        //surface.Clyright = Random.Range(template.solidLower[11], template.solidHigher[11]);
        atmosphere.scaleHeight = Random.Range(template.atmospherescaleHeightRange[0], template.atmospherescaleHeightRange[1]);
        atmosphere.height = Random.Range(template.atmosphereHeightRange[0], template.atmosphereHeightRange[1]);
        atmosphere.pressure = Random.Range(template.atmospherePressureRange[0], template.atmospherePressureRange[1]);

        float radius_ = units.coordinateScale*radius/60;
        transform.localScale = new Vector3(radius_, radius_, 1);
    }
    public void generateStar()
    {
        mass = Random.Range(100000, 500000);
        radius = Random.Range(50, 150);
        float radius_ = units.coordinateScale * radius / 10000;
        transform.localScale = new Vector3(radius_, radius_, 1);
        GameObject temp = GameObject.Find("MainStar");
        template = temp.GetComponent<Template>();
        sprite = template.sprite;
    }
    public void generateOrbit(float systemSizelow, float systemSizehigh)
    {
        orbit.a = Random.Range(systemSizelow*units.AU, systemSizehigh*units.AU);
        //Debug.Log(orbit.a);
        orbit.e = Random.Range(0.00001f, 0.07f);
        float angle = Random.Range(0, Mathf.PI * 2);
        orbit.ev = new Vector2(Mathf.Cos(angle)*orbit.e, Mathf.Sin(angle)*orbit.e);
        //orbit.fromEvA(units.AU, orbit.ev, units.ME*units.G);
        //Debug.Log(orbit.p / 60 / 60 / 24/365);
        //orbit.circularInit(orbit.a, units.G * (mass * units.ME + parent.mass * units.ME));
        orbit.fromEvA(orbit.a, orbit.ev, units.G*(mass*units.ME+parent.mass*units.ME));
        
    }
    public int probabalisticElement(string[] a, float[] b)
    {
        float v = Random.Range(0f, 1f);
        //Debug.Log(v);
        float[] b_ = b;
        float sum = 0;
        for (int i = 0; i < b.Length; i++)
        {
            sum += b[i];
            b_[i] = sum;
        }
        for (int i = 0; i < a.Length; i ++)
        {
            if(v < b_[i])
            {
                return i;
            }
        }
        return 0;
    }
    public static void showGhost()
    {

    }
}
public class Atmosphere
{
    public float height;//atmosphere height in km
    public float scaleHeight;//scaleheight in km (wikipedia scaleheight)
    public float pressure; //surface pressure in kPA
}
