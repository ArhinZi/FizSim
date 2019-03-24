using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class main : MonoBehaviour {
    //список инструментов
    public enum Tool { select, drag, del, rect, circle, water, tjoint, djoint };


	//свободно ли место для заполнения
    public bool loose;
    public bool looseUI;
    //айди текущего инструмента
    public int Tool_id;

    public GameObject curs;
    public GameObject currObj;
    public List<GameObject> allObj;

    public bool pause;
    public GameObject pauseIm;


    // Use this for initialization
    void Start ()
    {
        //инициализация 
        Tool_id = (int)Tool.select;
        loose = true;
        looseUI = true;
        //отключение системного курсора
        Cursor.visible = false;
        //выбор курсора при старте
        Select_Cursor(0);
        UnityEngine.Physics2D.gravity = new Vector2(0,-9.8f);
    }
	


	// Update is called once per frame
	void Update () 
	{
        //pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause = true;
                pauseIm.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
                pauseIm.SetActive(false);
            }
        }
    
    }


    /// <summary>
    /// смена режима курсора
    /// </summary>
    public void Select_Cursor(int i)
    {
        curs.GetComponent<Cursor_Select>().enabled = false;
        curs.GetComponent<Cursor_Drag>().enabled =   false;
        curs.GetComponent<Cursor_Del>().enabled =    false;
        curs.GetComponent<Cursor_Rect>().enabled =   false;
        curs.GetComponent<Cursor_Circle>().enabled = false;
        curs.GetComponent<Cursor_Water>().enabled =  false;
        curs.GetComponent<Cursor_LTJoint>().enabled = false;
        curs.GetComponent<Cursor_LDJoint>().enabled = false;
        switch (i)
        {
            case (int)Tool.select:
                curs.GetComponent<Cursor_Select>().enabled = true;
                break;
            case (int)Tool.drag:
                curs.GetComponent<Cursor_Drag>().enabled = true;
                break;
            case (int)Tool.del:
                curs.GetComponent<Cursor_Del>().enabled = true;
                break;
            case (int)Tool.rect:
                curs.GetComponent<Cursor_Rect>().enabled = true;
                break;
            case (int)Tool.circle:
                curs.GetComponent<Cursor_Circle>().enabled = true;
                break;
            case (int)Tool.water:
                curs.GetComponent<Cursor_Water>().enabled = true;
                break;
            case (int)Tool.tjoint:
                curs.GetComponent<Cursor_LTJoint>().enabled = true;
                break;
            case (int)Tool.djoint:
                curs.GetComponent<Cursor_LDJoint>().enabled = true;
                break;

        }
    }



}
