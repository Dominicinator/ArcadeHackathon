using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {
    public Gas gasPrices = new Gas();
    public Solid solidPrices = new Solid();
    public Gas gasSell = new Gas();
    public Solid solidSell = new Solid();
    public float itemPrice;
    public Item item;
    public Player player;
    public string shopText = "";
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        List<string> keyList = new List<string>(solidPrices.dict.Keys);
        //List<float> valueList = new List<float>(solidPrices.dict.Values);
        string[] solids = keyList.ToArray();
        keyList = new List<string>(gasPrices.dict.Keys);
        string[] gases = keyList.ToArray();
        for (int i = 0; i < gases.Length; i++)
        {
            gasPrices.dict[gases[i]] = Random.Range(1f, 5f);
            gasSell.dict[gases[i]] = Random.Range(0.5f, 2.5f);
            shopText += gases[i] + " sell price is " + gasSell.dict[gases[i]] + ", buy price is " + gasPrices.dict[gases[i]];
        }
        for (int i = 0; i < solids.Length; i++)
        {
            solidPrices.dict[solids[i]] = Random.Range(3f, 10f);
            solidSell.dict[solids[i]] = Random.Range(1.5f, 5f);
            shopText += solids[i] + " sell price is " + solidSell.dict[solids[i]] + ", buy price is " + solidPrices.dict[solids[i]];
        }
        GameObject items = GameObject.Find("Items");
        int itemIndex = Mathf.RoundToInt(Random.Range(0, items.transform.childCount-1));
        item = items.transform.GetChild(itemIndex).gameObject.GetComponent<Item>();
        itemPrice = Random.Range(300f, 500f);
        shopText += item.itemName + " is available for " + itemPrice;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void sellGas(string gas, float amount)
    {
        player.inventory.gas.dict[gas] -= amount;
        player.currency += gasSell.dict[gas] * amount;
        player.inventory.gas.updateValues();
    }
    public void sellSolid(string solid, float amount)
    {
        player.inventory.solid.dict[solid] -= amount;
        player.currency += solidSell.dict[solid] * amount;
        player.inventory.solid.updateValues();
    }
    public void sellItem()
    {

    }
    public void buyGas(string gas, float amount)
    {
        player.inventory.gas.dict[gas] += amount;
        player.currency -= gasPrices.dict[gas] * amount;
        player.inventory.gas.updateValues();
    }
    public void buySolid(string solid, float amount)
    {
        player.inventory.solid.dict[solid] += amount;
        player.currency -= solidSell.dict[solid] * amount;
        player.inventory.solid.updateValues();
    }
    public void buyItem(string itemName, Item slot)
    {
        if(item.itemName == itemName)
        {
            if (item.type == "engine")
            {

            }
            if (item.type == "weapon")
            {

            }
            if (item.type == "armor")
            {

            }
        }
    }
}
