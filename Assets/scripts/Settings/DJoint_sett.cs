using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJoint_sett : MonoBehaviour
{
    public main nMain;
    public GameObject A0XInp;
    public GameObject A0YInp;
    public GameObject A1XInp;
    public GameObject A1YInp;
    public GameObject DInp;
    public GameObject CSInp;
    public GameObject CDInp;
    public GameObject MDOInp;
    public GameObject FInp;

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

            DJoint jointcomp = nMain.currObj.transform.parent.GetComponent<DJoint>();
            A0XInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.anchor.x.ToString();
            A0YInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.anchor.y.ToString();
            A1XInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.connectedAnchor.x.ToString();
            A1YInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.connectedAnchor.y.ToString();
            DInp.GetComponent<UnityEngine.UI.InputField>().text = jointcomp.comp.distance.ToString();
            CSInp.GetComponent<UnityEngine.UI.Toggle>().isOn = jointcomp.comp.enableCollision;
            CDInp.GetComponent<UnityEngine.UI.Toggle>().isOn = !nMain.currObj.GetComponent<Collider2D>().isTrigger;
            MDOInp.GetComponent<UnityEngine.UI.Toggle>().isOn = jointcomp.comp.maxDistanceOnly;
            FInp.GetComponent<UnityEngine.UI.Toggle>().isOn = jointcomp.comp.enableCollision;
        }
    }

    public void UpdateSim1()
    {
        Time.timeScale = 0;
        nMain.currObj.transform.parent.GetComponent<DJoint>().enabled = false;
        Debug.Log("1");
        Invoke("UpdateSim2", 0.5f);
    }
    public void UpdateSim2()
    {
        if (nMain.pause != true)Time.timeScale = 1;
        nMain.currObj.transform.parent.GetComponent<DJoint>().enabled = true;
        Debug.Log("2");
    }

    public void UpdA0X()
    {
        string i = A0XInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.anchor = new Vector2(j, nMain.currObj.transform.parent.GetComponent<DJoint>().comp.anchor.y);
        }
    }
    public void UpdA0Y()
    {
        string i = A0YInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.anchor = new Vector2(j, nMain.currObj.GetComponent<DJoint>().comp.anchor.y);
        }
    }
    public void UpdA1X()
    {
        string i = A1XInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.connectedAnchor = new Vector2(j, nMain.currObj.transform.parent.GetComponent<DJoint>().comp.connectedAnchor.y);
        }
    }
    public void UpdA1Y()
    {
        string i = A1YInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.connectedAnchor = new Vector2(j, nMain.currObj.transform.parent.GetComponent<DJoint>().comp.connectedAnchor.y);
        }
    }
    public void UpdD()
    {
        string i = DInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.distance = j;
        }
    }
    public void UpdCS()
    {
        if (CSInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.enableCollision = true;
        else
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.enableCollision = false;
    }
    public void UpdCD()
    {
        if (CDInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.GetComponent<Collider2D>().isTrigger = false;
        else
            nMain.currObj.GetComponent<Collider2D>().isTrigger = true;
    }
    public void UpdMDO()
    {
        if (MDOInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.maxDistanceOnly = true;
        else
            nMain.currObj.transform.parent.GetComponent<DJoint>().comp.maxDistanceOnly = false;
    }
    public void UpdF()
    {
        if (FInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.transform.parent.GetComponent<DJoint>().Flexibility = true;
        else
            nMain.currObj.transform.parent.GetComponent<DJoint>().Flexibility = false;
        nMain.currObj.transform.parent.GetComponent<DJoint>().FlexUpd();
    }
    public void UpdDEL()
    {

        Destroy(nMain.currObj.transform.parent);
        nMain.currObj = null;
    }
}
