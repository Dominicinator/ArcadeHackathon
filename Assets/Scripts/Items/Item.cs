using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {
    public string itemName;
    public string lore;
    public string type;
    public Engine engine;
    public Armor armor;
    public Weapon weapon;
	// Use this for initialization
	void Start () {
	    if (type == "weapon")
        {
            weapon = transform.gameObject.GetComponent<Weapon>();
            weapon.user = GameObject.Find("Player").GetComponent<Player>();
        }
        if (type == "engine")
        {
            engine = GetComponent<Engine>();
            engine.user = GameObject.Find("Player").GetComponent<Player>();
        }
        if (type == "armor")
        {
            armor = GetComponent<Armor>();
            armor.user = GameObject.Find("Player").GetComponent<Player>();
            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}



