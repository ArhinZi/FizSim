using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Circle : MonoBehaviour {

    //переменная для хранения обьекта main
    public main nMain;

    public Texture2D arr;
    public GUIStyle St;

    public Vector2 pos1 = Vector2.zero;
    public Vector2 pos2 = Vector2.zero;
    public float Rad=0;

    public GameObject CirclePref;
    public int numCircle = 0;

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
            Rad = Vector2.Distance(pos1, pos2);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isset)
            {
                if (Rad > 0.5)
                {
                    numCircle++;
                    GameObject temp = Instantiate(CirclePref, new Vector3(Camera.main.ScreenToWorldPoint(pos1).x, Camera.main.ScreenToWorldPoint(pos1).y, 0), new Quaternion(0, 0, 0, 0));
                    nMain.allObj.Add(temp);
                    temp.name = "Circle_" + numCircle;
                    temp.transform.localScale = new Vector3(Rad / 100, Rad / 100, 0);
                    temp.AddComponent<CircleCollider2D>();
                    temp.AddComponent<Rigidbody2D>();
                    temp.GetComponent<Rigidbody2D>().mass = 1;
                    temp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                    temp.transform.localScale /= 2.5f;

                    PhysicsMaterial2D iMat = new PhysicsMaterial2D();
                    iMat.name = "Mat_Rect_" + numCircle;
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
        if (isset)
            GUI.Box(GetRect(pos1), new GUIContent("", "Tool_panel"), St);
    }

    Rect GetRect(Vector3 p1)
    {
        p1.y = Screen.height - p1.y;

        return Rect.MinMaxRect(p1.x-Rad, p1.y+Rad, p1.x+Rad, p1.y-Rad);
    }
}
