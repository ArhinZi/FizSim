using UnityEngine;
using System.Collections;

public class Upd_loose : MonoBehaviour {


    //переменная для хранения обьекта main
    public main nMain;



    // Use this for initialization
    void Start()
    {
        //инициализация
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }



    // Update is called once per frame
    void Update()
    {

    }





    void OnMouseEnter()
    {
        if(tag!="Background") nMain.loose = false;
        Debug.Log("123");
    }
    void OnMouseExit()
    {
        if (tag != "Background") nMain.loose = true;
    }
}
