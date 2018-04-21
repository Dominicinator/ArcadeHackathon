using UnityEngine;
using System.Collections;

public class Template : MonoBehaviour {
    public Sprite sprite;

    public float[] atmosphereHeightRange = { 0, 0 };
    public float[] atmospherescaleHeightRange = { 0, 0 };
    public float[] atmospherePressureRange = { 0, 0 };
    //Planetary composition ranges
    public float[] silica = { 0, 0 };
    public float[] carbon = { 0, 0 };
    public float[] metal = { 0, 0 };
    public float[] ice = { 0, 0 };
    public float[] gas = { 0, 0 };
    //Atmospheric composition ranges
    public float[] H = { 0, 0 };
    public float[] He = { 0, 0 };
    public float[] O2 = { 0, 0 };
    public float[] H2O = { 0, 0 };
    public float[] CO2 = { 0, 0 };
    public float[] Ar = { 0, 0 };
    public float[] Ne = { 0, 0 };
    public float[] Xe = { 0, 0 };
    public float[] N = { 0, 0 };
    public float[] Methane = { 0, 0 };
    public float[] H2S = { 0, 0 };
    public float[] H2SO4 = { 0, 0 };
    public float[] Thaumiel = { 0, 0 };
    public float[] Frisz = { 0, 0 };
    public float[] Nitriol = { 0, 0 };
    //Surface composition ranges
    public float[] Fe = { 0, 0 };
    public float[] C = { 0, 0 };
    public float[] U = { 0, 0 };
    public float[] Au = { 0, 0 };
    public float[] Ag = { 0, 0 };
    public float[] Pt = { 0, 0 };
    public float[] Pu = { 0, 0 };
    public float[] He3 = { 0, 0 };
    public float[] Shadowmiel = { 0, 0 };
    public float[] Akashite = { 0, 0 };
    public float[] Chrism = { 0, 0 };
    public float[] Clyright = { 0, 0 };

    //Make a 2d array of surface and atmosphere compositions so I can loop over it
    //public ArrayList<ArrayList> gases = new float[15, 15];
    //public float[,] solids = new float[11, 11];
    public float[] gasLower = new float[16];
    public float[] gasHigher = new float[16];
    public float[] solidLower = new float[13];
    public float[] solidHigher = new float[13];
    //public planetaryRange composition;
    //public atmosphereRange atmosphere;
    //public surfaceRange surface;
    public string classification; //This template's name
    public float[] massRange;
	// Use this for initialization
	void Start () {
        //const gases = ["H", "He", "O2", "H2O", "CO2", "Ar", "Ne", "Xe", "N", "Methane", "H2S", "H2SO4", "Thaumiel", "Frisz", "Nitriol"]
        //gasLower[0] = H[0]
        gasLower[0] = H[0];
        gasLower[1] = He[0];
        gasLower[2] = O2[0];
        gasLower[3] = H2O[0];
        gasLower[4] = CO2[0];
        gasLower[5] = Ar[0];
        gasLower[6] = Ne[0];
        gasLower[7] = Xe[0];
        gasLower[8] = N[0];
        gasLower[9] = Methane[0];
        gasLower[10] = H2S[0];
        gasLower[11] = H2SO4[0];
        gasLower[12] = Thaumiel[0];
        gasLower[13] = Frisz[0];
        gasLower[14] = Nitriol[0];
        gasHigher[0] = H[1];
        gasHigher[1] = He[1];
        gasHigher[2] = O2[1];
        gasHigher[3] = H2O[1];
        gasHigher[4] = CO2[1];
        gasHigher[5] = Ar[1];
        gasHigher[6] = Ne[1];
        gasHigher[7] = Xe[1];
        gasHigher[8] = N[1];
        gasHigher[9] = Methane[1];
        gasHigher[10] = H2S[1];
        gasHigher[11] = H2SO4[1];
        gasHigher[12] = Thaumiel[1];
        gasHigher[13] = Frisz[1];
        gasHigher[14] = Nitriol[1];
        solidLower[0] = Fe[0];
        solidLower[1] = C[0];
        solidLower[2] = Au[0];
        solidLower[3] = Ag[0];
        solidLower[4] = Pt[0];
        solidLower[5] = Pu[0];
        solidLower[6] = U[0];
        solidLower[7] = He3[0];
        solidLower[8] = Shadowmiel[0];
        solidLower[9] = Akashite[0];
        solidLower[10] = Chrism[0];
        //solidLower[11] = 5;//Clyright[0];
        solidHigher[0] = Fe[1];
        solidHigher[1] = C[1];
        solidHigher[2] = Au[1];
        solidHigher[3] = Ag[1];
        solidHigher[4] = Pt[1];
        solidHigher[5] = Pu[1];
        solidHigher[6] = U[1];
        solidHigher[7] = He3[1];
        solidHigher[8] = Shadowmiel[1];
        solidHigher[9] = Akashite[1];
        solidHigher[10] = Chrism[1];
        //solidHigher[11] = 5;// Clyright[1];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
public class planetaryRange
{
    public float[] silica;
    public float[] carbon;
    public float[] metal;
    public float[] ice;
    public float[] gas;
}
public class atmosphereRange
{
    //const gases = ["H", "He", "O2", "H2O", "CO2", "Ar", "Ne", "Xe", "N", "Methane", "H2S", "H2SO4", "Thaumiel", "Frisz", "Nitriol"]
    public float[] H;
    public float[] He;
    public float[] O2;
    public float[] H2O;
    public float[] CO2;
    public float[] Ar;
    public float[] Ne;
    public float[] Xe;
    public float[] N;
    public float[] Methane;
    public float[] H2S;
    public float[] H2SO4;
    public float[] Thaumiel;
    public float[] Frisz;
    public float[] Nitriol;
}
public class surfaceRange
{
    //const solids = ["Fe", "C", "Au", "Ag", "Pt", "Pu", "U", "He3", "Shadowmiel", "Akashite", "Chrism", "Clyright"]
    public float[] Fe;
    public float[] C;
    public float[] Au;
    public float[] Ag;
    public float[] Pt;
    public float[] Pu;
    public float[] He3;
    public float[] Shadowmiel;
    public float[] Akashite;
    public float[] Chrism;
    public float[] Clyright;
}

