using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curs : MonoBehaviour {

    public Sprite SelectCursore_act;
    public Sprite SelectCursore_nact;
           
    public Sprite DragCursore_act;
    public Sprite DragCursore_nact;
           
    public Sprite DelCursore_act;
    public Sprite DelCursore_nact;

    public Sprite Rect_Tex;


    public Sprite Current_Tex;

    main nMain;
    UnityEngine.UI.Image nImage;

    // Use this for initialization
    void Start () {
        nMain = transform.parent.GetComponent<main>();
        nImage = GetComponent<UnityEngine.UI.Image>();

	}
	
	// Update is called once per frame
	void Update () {

        if (nMain.Tool_id == (int)main.Tool.drag) transform.position = Input.mousePosition;
        else transform.position = Input.mousePosition + (new Vector3(15, -15));
        nImage.sprite = Current_Tex;

    }

    public void Sel()
    {
        nMain.Tool_id = (int)main.Tool.select;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.select);
    }
    public void Drag()
    {
        nMain.Tool_id = (int)main.Tool.drag;
        nImage.sprite = Current_Tex = DragCursore_nact;
        nMain.Select_Cursor((int)main.Tool.drag);
    }
    public void Del()
    {
        nMain.Tool_id = (int)main.Tool.del;
        nImage.sprite = Current_Tex = DelCursore_act;
        nMain.Select_Cursor((int)main.Tool.del);
    }
    public void Rect()
    {
        nMain.Tool_id = (int)main.Tool.rect;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.rect);
    }
    public void Circle()
    {
        nMain.Tool_id = (int)main.Tool.circle;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.circle);
    }
    public void Water()
    {
        nMain.Tool_id = (int)main.Tool.water;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.water);
    }
    public void TJoint()
    {
        nMain.Tool_id = (int)main.Tool.tjoint;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.tjoint);
    }
    public void DJoint()
    {
        nMain.Tool_id = (int)main.Tool.djoint;
        nImage.sprite = Current_Tex = SelectCursore_nact;
        nMain.Select_Cursor((int)main.Tool.djoint);
    }
}
