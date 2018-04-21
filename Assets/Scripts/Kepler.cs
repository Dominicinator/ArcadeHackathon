using UnityEngine;
using System.Collections;

public class Kepler {
    //
    
    //Keplerian elements
    public float a; //Semi major axis in m
    public float b; //Semi minor axis in m
    public float e; //Eccentricity
    public float p; //Period
    public Vector2 ev; //Eccentricity vector
    public float w; //Argument of periapsis
    //
    public void fromEvA(float a_, Vector2 ev_, float mu_)
    {
        ev = ev_;
        a = a_;
        e = ev.magnitude;
        p = Mathf.PI *2 * Mathf.Sqrt((a * a * a )/ mu_);
        //Debug.Log(a);
        w = Mathf.Atan2(ev.x, ev.y); 
        b = a * Mathf.Sqrt(1 - e * e);
    }
    public void setelements(float a_, Vector2 ev_, float p_, float w_)
    {
        e = ev_.magnitude;
        a = a_;
        ev = ev_;
        p = p_;
        w = w_;
    }
    private float findE(float time)
    {
        float M = 2 * Mathf.PI * time / p;
        //Debug.Log(p);
        float E = M;
        float En = 0;
        int l = 0;
        while (l++ < 500)
        {
            En = E + (M - (E - e * Mathf.Sin(E))) / (1 - e * Mathf.Cos(E));
            E = En;
            if (Mathf.Abs(En - E) < 1e-6) break;
        }
        return E;
    }
    public Vector2 r(float time)
    {
        float E = findE(time);
        
        float cosTA = (Mathf.Cos(E) - e) / (1 - e * Mathf.Cos(E));
        float t = 1 - e * Mathf.Cos(E);
        //if (t == 0f)
        //{
        //    t = 0.0001f;
        //}
        float sinTA = Mathf.Sqrt(1 - e * e) * Mathf.Sin(E) / t;
        
        float r_ = a * (1 - e * e) / (1 + e * cosTA);
        Vector2 r = rotate(new Vector2(r_ * cosTA, r_ * sinTA), w);
        return r;
    }
    public Vector2 v ()
    {

        return new Vector2();
    }
    Vector2 rotate(Vector2 aPoint, float aDegree)
    {
        float rad = aDegree * Mathf.Deg2Rad;
        float s = Mathf.Sin(a);
        float c = Mathf.Cos(a);
        return new Vector2(
            aPoint.x * c - aPoint.y * s,
            aPoint.y * c + aPoint.x * s
        );
    }
    public void circularInit(float a_, float mu_)
    {
        p = Mathf.PI * 2 * Mathf.Sqrt((a * a * a) / mu_);
    }
    public Vector2 circularR(float time)
    {
        float angle = time / p;
        Vector2 vect = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return a * vect;
    }
}
public class units
{
    public const float AU = 1.496e+11f;
    public const float ME = 5.972e+24f;
    public const float RE = 6371 * 1000f;
    public const float G = 6.67408e-11f;
    public const float coordinateScale = 15;
}