using UnityEngine;
//using UnityEngine.CoreModule;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            transform.gameObject.SetActive(false);
            Debug.Log("help me");
        }
        if (Time.fixedDeltaTime > 5)
        {
            //transform.gameObject.SetActive(false);
        }
    }
	void Update () {
	
	}
}
