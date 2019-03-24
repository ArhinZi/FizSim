using UnityEngine;
using System.Collections;

public class Cursor_Drag : MonoBehaviour {


    Curs nCurs;
    public cam nCam;
    public main nMain;

    Vector3 mp;
    GameObject curr;

    // Use this for initialization
    void Start()
    {
        nCurs = GetComponent<Curs>();
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            curr = nCam.GetObj();
            if (curr != null) mp = Camera.main.ScreenToWorldPoint(Input.mousePosition) - curr.transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            nCurs.Current_Tex = nCurs.DragCursore_act;
            if (curr != null && (curr.tag == "Rect" || curr.tag == "Circle"))
            {
                if(!nMain.pause)
                {
                    Rigidbody2D irigid = curr.GetComponent<Rigidbody2D>();
                    irigid.gravityScale = 0;
                    irigid.velocity = Vector2.zero;
                    irigid.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)-mp);
                }
                else
                {
                    curr.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mp;
                    Rigidbody2D irigid = curr.GetComponent<Rigidbody2D>();
                    irigid.velocity = Vector2.zero;
                }
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (curr != null && (curr.tag == "Rect" || curr.tag == "Circle"))
            {
                nCurs.Current_Tex = nCurs.DragCursore_nact;
                curr.GetComponent<Rigidbody2D>().gravityScale = 1;
                curr = null;
            }
        }
    }

    private void OnDisable()
    {
        curr = null;
    }





}
