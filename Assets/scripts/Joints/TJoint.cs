using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJoint : MonoBehaviour {
    public main nMain;
    Curs nCurs;
    GameObject JObj;
    public TargetJoint2D comp;
    // Use this for initialization
    void Start ()
    {
        nCurs = GameObject.FindObjectOfType(typeof(Curs)) as Curs;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
        JObj = nMain.currObj;
        comp = JObj.AddComponent<TargetJoint2D>();
        comp.anchor = transform.localPosition;
        comp.target = JObj.transform.TransformPoint(comp.anchor);
        nMain.currObj = null;
        nCurs.Current_Tex = nCurs.SelectCursore_nact;
    }

    private void OnDestroy()
    {
        Destroy(comp);
    }
    // Update is called once per frame
    void Update () {
        transform.position = comp.target;
        if (nMain.pause) comp.target = JObj.transform.TransformPoint(comp.anchor);
    }

}
