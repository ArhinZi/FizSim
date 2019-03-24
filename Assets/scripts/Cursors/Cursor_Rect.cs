using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Rect : MonoBehaviour {



    //переменная для хранения обьекта main
    public main nMain;

    public Texture2D arr;
    public GUIStyle St;

    public Vector2 pos1 = Vector2.zero;
    public Vector2 pos2 = Vector2.zero;

    public GameObject RectPref;
    public int numRect = 0;

    public bool isset;


    // Use this for initialization
    void Start()
    {
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && nMain.loose == true)
        {
            isset = true;
            pos1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && nMain.loose == true)
        {
            pos2 = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isset)
            {
                if (Mathf.Abs(pos1.x-pos2.x)>5 && Mathf.Abs(pos1.y - pos2.y) > 5)
                {
                    numRect++;
                    GameObject temp = Instantiate(RectPref, new Vector3(Camera.main.ScreenToWorldPoint((pos1 + pos2) / 2).x, Camera.main.ScreenToWorldPoint((pos1 + pos2) / 2).y, 0), new Quaternion(0, 0, 0, 0));
                    nMain.allObj.Add(temp);
                    temp.name = "Rectangle_" + numRect;
                    temp.transform.localScale = new Vector3(GetRect(pos1, pos2).width / 200, GetRect(pos1, pos2).height / 200, 0);
                    temp.AddComponent<BoxCollider2D>();
                    temp.AddComponent<Rigidbody2D>();
                    temp.GetComponent<Rigidbody2D>().mass = 1;
                    temp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                    temp.transform.localScale /= 2.5f;

                    PhysicsMaterial2D iMat = new PhysicsMaterial2D();
                    iMat.name = "Mat_Rect_" + numRect;
                    iMat.bounciness = 0;
                    iMat.friction = 1;

                    temp.GetComponent<Rigidbody2D>().sharedMaterial = iMat;
                }
                isset = !isset;
            }
            

        }
    }

    private void OnGUI()
    {
        if(isset)
        GUI.Box(GetRect(pos1,pos2), new GUIContent("", "Tool_panel"), St);
    }

    Rect GetRect(Vector3 p1, Vector3 p2)
    {
        p1.y = Screen.height - p1.y;
        p2.y = Screen.height - p2.y;

        Vector3 TopLeft = Vector3.Min(p1, p2);
        Vector3 BottomRight = Vector3.Max(p1, p2);
        return Rect.MinMaxRect(TopLeft.x, TopLeft.y, BottomRight.x, BottomRight.y);
    }
}
