using UnityEngine;
using System.Collections;

public class Cursor_Del : MonoBehaviour {



    public cam nCam;
    Curs nCurs;

    // Use this for initialization
    void Start ()
    {
        nCurs = GetComponent<Curs>();
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
    }
	


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
		{
            nCurs.Current_Tex= nCurs.DelCursore_act;
            GameObject i = nCam.GetObj();
            if (i != null && (i.tag == "Rect" || i.tag == "WatPart" || i.tag == "Circle"))
            {
                Destroy(i);
            }
            /*if (i != null && (i.tag == "WatPart"))
            {
                i.gameObject.SetActive(false);
            }*/
        }
        if (Input.GetMouseButtonUp(0))
		{
            nCurs.Current_Tex = nCurs.DelCursore_nact;
        }
    }





}
