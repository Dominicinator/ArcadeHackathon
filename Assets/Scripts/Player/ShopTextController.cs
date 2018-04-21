using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopTextController : MonoBehaviour {
    public Shop shop;
    public Text text;
    //public string shopText;
	// Use this for initialization
    public void initThis()
    {
        shop = GameObject.Find("StarSystem").GetComponent<StarSystem>().shop.GetComponent<Shop>();
        text = transform.GetComponent<Text>();
        text.text = shop.shopText;
    }
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
