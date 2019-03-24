using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_LDJoint : MonoBehaviour {

    Curs nCurs;
    public cam nCam;
    public main nMain;
    public int state = 0;
    public GameObject Obj0;
    public GameObject Obj1;
    public Vector2 V0;
    public Vector2 V1;
    public GameObject DJpref;


    // Use this for initialization
    void Start()
    {
        nCurs = GetComponent<Curs>();
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }

    // Update is called once per frame
    void Update ()
    {
        GameObject m = nCam.GetObj();
        if (Input.GetMouseButtonDown(0) && m != null && (m.tag == "Rect" || m.tag == "Circle"))
        {
            if(state == 0)
            {
                nCurs.Current_Tex = nCurs.SelectCursore_act;
                nMain.currObj = m;
                state = 1;
            }
            else if (state == 1)
            {
                if (m == nMain.currObj)
                {
                    nCurs.Current_Tex = nCurs.DelCursore_act; ;
                    Obj0 = m;
                    V0 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    state = 2;
                }
                else state = 0;
            }
            else if (state == 2)
            {
                if (m != Obj0)
                {
                    nCurs.Current_Tex = nCurs.SelectCursore_act;;
                    nMain.currObj = m;
                    state = 3;
                }
                else state = 0;
            }
            else if (state == 3)
            {
                if (m == nMain.currObj)
                {
                    Obj1 = m;
                    V1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    GameObject temp = Instantiate(DJpref, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    temp.name = "DistanceJoint__" + Obj0.name + "-" + Obj1.name;
                    DJoint tcomp = temp.GetComponent<DJoint>();
                    tcomp.Obj0 = Obj0;
                    tcomp.Obj1 = Obj1;
                    tcomp.V0 = V0;
                    tcomp.V1 = V1;
                }
                else state = 0;
            }

        }

        if (Input.GetMouseButtonUp(0) && state == 0)
        {
            Obj0 = null;
            V0 = Vector2.zero;
            Obj1 = null;
            V1 = Vector2.zero;
            nCurs.Current_Tex = nCurs.SelectCursore_nact;
        }
    }
}
