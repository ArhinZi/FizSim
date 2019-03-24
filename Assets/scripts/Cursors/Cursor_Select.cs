using UnityEngine;
using System.Collections;

public class Cursor_Select : MonoBehaviour {


    Curs nCurs;
    public cam nCam;
    public main nMain;

    public GameObject sRectangle;
    public GameObject sCircle;
    public GameObject sTJoint;
    public GameObject sDJoint;

    // Use this for initialization
    void Start()
    {
        Select_Settings("0");
        nCurs = GetComponent<Curs>();
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && nMain.looseUI == true)
        {
            nCurs.Current_Tex = nCurs.SelectCursore_act;
            nMain.currObj = nCam.GetObj();
            if (nMain.currObj != null) Select_Settings(nMain.currObj.tag);
            else Select_Settings("0");
        }
        if (Input.GetMouseButtonUp(0))
        {
            nCurs.Current_Tex = nCurs.SelectCursore_nact;
        }
    }
    private void OnDisable()
    {
        nMain.currObj = null;
        Select_Settings("0");
    }
    public void Select_Settings(string i)
    {
        if (sRectangle == null) return;
        sRectangle.SetActive(false);
        sCircle.SetActive(false);
        sTJoint.SetActive(false);
        sDJoint.SetActive(false);
        switch (i)
        {
            case "Rect":
                sRectangle.SetActive(true);
                sRectangle.GetComponent<Rect_sett>().UpdateSettInfo();
                break;
            case "Circle":
                sCircle.SetActive(true);
                sCircle.GetComponent<Circle_sett>().UpdateSettInfo();
                break;
            case "TJoint":
                sTJoint.SetActive(true);
                sTJoint.GetComponent<TJoint_sett>().UpdateSettInfo();
                break;
            case "DJoint":
                sDJoint.SetActive(true);
                sDJoint.GetComponent<DJoint_sett>().UpdateSettInfo();
                break;

            case "0":
                break;

        }
    }



}
