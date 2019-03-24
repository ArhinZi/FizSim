using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJoint_sett : MonoBehaviour {
    public main nMain;
    public GameObject AXInp;
    public GameObject AYInp;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateSettInfo()
    {
        if (nMain.currObj != null)
        {
            TJoint jointcomp = nMain.currObj.GetComponent<TJoint>();
            AXInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.anchor.x.ToString();
            AYInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.anchor.y.ToString();
        }
    }

    public void UpdateSim1()
    {
        nMain.currObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Debug.Log("1");
        Invoke("UpdateSim2", 0.5f);
    }
    public void UpdateSim2()
    {
        nMain.currObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("2");
    }

    public void UpdAX()
    {
        string i = AXInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<TJoint>().comp.anchor = new Vector2(j, nMain.currObj.GetComponent<TJoint>().comp.anchor.y);
        }
    }

    public void UpdAY()
    {
        string i = AYInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<TJoint>().comp.anchor = new Vector2(nMain.currObj.GetComponent<TJoint>().comp.anchor.y, j);
        }
    }
    public void UpdDEL()
    {
        
        Destroy(nMain.currObj);
        nMain.currObj = null;
    }


}
