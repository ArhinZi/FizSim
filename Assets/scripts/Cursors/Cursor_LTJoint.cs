using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_LTJoint : MonoBehaviour {

    Curs nCurs;
    public cam nCam;
    public main nMain;
    public bool sel = false;
    public GameObject TJpref;
    

    // Use this for initialization
    void Start () {
        nCurs = GetComponent<Curs>();
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && sel == true)
        {
            if(nCam.GetObj() == nMain.currObj)
            {
                GameObject temp = Instantiate(TJpref, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), new Quaternion(0, 0, 0, 0));
                temp.name = "TargetJoint__" + nMain.currObj.name;
                temp.transform.parent = nMain.currObj.transform;
              
            }
            sel = false;
        }
        GameObject m = nCam.GetObj();
        if (Input.GetMouseButtonDown(0) && m != null && (m.tag == "Rect" || m.tag == "Circle"))
        {

            nCurs.Current_Tex = nCurs.SelectCursore_act;
            nMain.currObj = m;
            if (nMain.currObj != null) sel = true;
            else sel = false;
        }

        if (Input.GetMouseButtonUp(0) && sel == false)
        {
            nCurs.Current_Tex = nCurs.SelectCursore_nact;
        }

    }

    private void OnDisable()
    {
        nMain.currObj = null;
    }



}
