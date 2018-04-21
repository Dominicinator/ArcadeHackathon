using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour
{
    public Player user;
    public string fuel;
    public string fuelType;
    public float efficiency; //km/s per unit of fuel
    public float thrust;
    public void burn(float dV)
    {
        float f = 0;
        if (fuelType == "Gas")
            user.inventory.gas.dict[fuel] -= dV / (100f * efficiency);
        {
        }
        if (fuelType == "Solid")
        {
            user.inventory.solid.dict[fuel] -= dV/ (1000f*efficiency);
            
        }
        //float fuelperdt = (thrust / efficiency) * dt;
        //if (f > fuelperdt)
       // {
       //     var m = user.transform.rotation.eulerAngles;//.mult(this.stats.effeciency)
       //                                                 //user.transform.
        //
          //  f += -fuelperdt;
        //}
        //user.inventory.gas.dict[fuel] 
    }
    


}
