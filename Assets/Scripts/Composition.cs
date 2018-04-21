using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Composition : MonoBehaviour {
    public Planetary planetary;
    public Gas atmospheric;
    public Solid surface;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
public class Planetary
{
    //%/100 planetary composition
    public float silica = 0;
    public float ice = 0;
    public float metal = 0;
    public float carbon = 0;
    public float gas = 0;
    //Densities in kg/m3
    public float silicaDensity = 2800;
    public float iceDensity = 900;
    public float metalDensity = 8400;
    public float carbonDensity = 2000;
    public float gasDensity = (float)0.2*400; //Assuming STP, oxygen, 400 multiplier to prevent crazy planetary radii
    
    public float getVolume(float mass)
    {
        //V = m/d
        float silicaVolume = silica * mass / silicaDensity;
        float iceVolume = ice * mass / iceDensity;
        float metalVolume = metal * mass / metalDensity;
        float carbonVolume = carbon * mass / carbonDensity;
        float gasVolume = gas * mass / gasDensity;
        float V = silicaVolume + metalVolume + iceVolume + gasVolume + carbonVolume;
        return V;
    }
}
public class Gas
{
    public Dictionary<string, float> dict = new Dictionary<string, float>();
    public void initDict()
    {
        dict.Add("H", H);
        dict.Add("He", He);
        dict.Add("O2", O2);
        dict.Add("H2O", H2O);
        dict.Add("CO2", CO2);
        dict.Add("Ar", Ar);
        dict.Add("Ne", Ne);
        dict.Add("Xe", Xe);
        dict.Add("N", N);
        dict.Add("Methane", Methane);
        dict.Add("H2S", H2S);
        dict.Add("H2SO4", H2SO4);
        dict.Add("Thaumiel", Thaumiel);
        dict.Add("Frisz", Frisz);
        dict.Add("Nitriol", Nitriol);
    }
    public void updateDict()
    {
        dict["H"] = H;
        dict["He"] = He;
        dict["O2"] = O2;
        dict["H2O"] = H2O;
        dict["CO2"] = CO2;
        dict["Ar"] = Ar;
        dict["Ne"] = Ne;
        dict["Xe"] = Xe;
        dict["N"] = N;
        dict["Methane"] = Methane;
        dict["H2S"] = H2S;
        dict["H2SO4"] = H2SO4;
        dict["Thaumiel"] = Thaumiel;
        dict["Frisz"] = Frisz;
        dict["Nitriol"] = Nitriol;

    }
    public void updateValues()
    {
        H = dict["H"];
        He = dict["He"];
        O2 = dict["O2"];
        H2O = dict["H2O"];
        CO2 = dict["CO2"];
        Ar = dict["Ar"];
        Ne = dict["Ne"];
        Xe = dict["Xe"];
        N = dict["N"];
        Methane = dict["Methane"];
        H2S = dict["H2S"];
        H2SO4 = dict["H2SO4"];
        Thaumiel = dict["Thaumiel"];
        Frisz = dict["Frisz"];
        Nitriol = dict["Nitriol"];

    }
    public float H = 0;
    public float He = 0;
    public float O2 = 0;
    public float H2O = 0;
    public float CO2 = 0;
    public float Ar = 0;
    public float Ne = 0;
    public float Xe = 0;
    public float N = 0;
    public float Methane = 0;
    public float H2S = 0;
    public float H2SO4 = 0;
    public float Thaumiel = 0;
    public float Frisz = 0;
    public float Nitriol = 0;
}
public class Solid
{
    public Dictionary<string, float> dict = new Dictionary<string, float>();
    public void initDict()
    {
        dict.Add("Fe", Fe);
        dict.Add("C", C);
        dict.Add("Au", Au);
        dict.Add("Ag", Ag);
        dict.Add("Pt", Pt);
        dict.Add("Pu", Pu);
        dict.Add("U", U);
        dict.Add("He3", He3);
        dict.Add("Shadowmiel", Shadowmiel);
        dict.Add("Akashite", Akashite);
        dict.Add("Chrism", Chrism);
        dict.Add("Clyright", Clyright);
    }
    public void updateDict()
    {
        dict["Fe"] = Fe;
        dict["C"] = C;
        dict["Au"] = Au;
        dict["Ag"] = Ag;
        dict["Pt"] = Pt;
        dict["Pu"] = Pu;
        dict["U"] = U;
        dict["He3"] = He3;
        dict["Shadowmiel"] = Shadowmiel;
        dict["Akashite"] = Akashite;
        dict["Chrism"] = Chrism;
        dict["Clyright"] = Clyright;
    }
    public void updateValues()
    {
        Fe = dict["Fe"];
        C = dict["C"];
        Au = dict["Au"];
        Ag = dict["Ag"];
        Pt = dict["Pt"];
        Pu = dict["Pu"];
        U = dict["U"];
        He3 = dict["He3"];
        Shadowmiel = dict["Shadowmiel"];
        Akashite = dict["Akashite"];
        Chrism = dict["Chrism"];
        Clyright = dict["Clyright"];
    }
    public float Fe = 0;
    public float C = 0;
    public float Au = 0;
    public float Ag = 0;
    public float Pt = 0;
    public float Pu = 0;
    public float U = 0;
    public float He3 = 0;
    public float Shadowmiel = 0;
    public float Akashite = 0;
    public float Chrism = 0;
    public float Clyright = 0;
}
