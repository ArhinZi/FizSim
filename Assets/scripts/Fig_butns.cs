using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fig_butns : MonoBehaviour {

   public GameObject i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select()
    {
        if (i.activeSelf == true) i.SetActive(false);
        else if (i.activeSelf == false) i.SetActive(true);
    }
}
