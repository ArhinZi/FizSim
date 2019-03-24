using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rect_sett : MonoBehaviour {

    public main nMain;
    public GameObject MInp;
    public GameObject HInp;
    public GameObject WInp;
    public GameObject LDInp;
    public GameObject ADInp;
    public GameObject FInp;
    public GameObject BInp;
    public GameObject RInp;
    public GameObject FPxInp;
    public GameObject FPyInp;
    public GameObject FPzInp;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateSettInfo()
    {
        if(nMain.currObj != null)
        {
            Rigidbody2D rigidcomp = nMain.currObj.GetComponent<Rigidbody2D>();
            MInp.GetComponent<UnityEngine.UI.InputField>().text = rigidcomp.mass.ToString();
            HInp.GetComponent<UnityEngine.UI.InputField>().text = (nMain.currObj.transform.localScale.x*100).ToString();
            WInp.GetComponent<UnityEngine.UI.InputField>().text = (nMain.currObj.transform.localScale.y*100).ToString();
            LDInp.GetComponent<UnityEngine.UI.InputField>().text = rigidcomp.drag.ToString();
            ADInp.GetComponent<UnityEngine.UI.InputField>().text = rigidcomp.angularDrag.ToString();
            FInp.GetComponent<UnityEngine.UI.InputField>().text = rigidcomp.sharedMaterial.friction.ToString();
            BInp.GetComponent<UnityEngine.UI.InputField>().text = rigidcomp.sharedMaterial.bounciness.ToString();
            RInp.GetComponent<UnityEngine.UI.Slider>().value = rigidcomp.rotation / 5;
            FPxInp.GetComponent<UnityEngine.UI.Toggle>().isOn = (rigidcomp.constraints & RigidbodyConstraints2D.FreezePositionX) != 0;
            FPyInp.GetComponent<UnityEngine.UI.Toggle>().isOn = (rigidcomp.constraints & RigidbodyConstraints2D.FreezePositionY) != 0;
            FPzInp.GetComponent<UnityEngine.UI.Toggle>().isOn = (rigidcomp.constraints & RigidbodyConstraints2D.FreezeRotation) != 0;
        }
    }

    public void UpdateSim1()
    {
        nMain.currObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Debug.Log("1");
        Invoke("UpdateSim2",0.5f);
    }
    public void UpdateSim2()
    {
        nMain.currObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("2");
    }

    public void UpdM()
    {
        string i = MInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<Rigidbody2D>().mass = j;
        }
    }

    public void UpdH()
    {
        string i = HInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.localScale = new Vector3(j/100, nMain.currObj.transform.localScale.y, 0);
        }
    }

    public void UpdW()
    {
        string i = WInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.transform.localScale = new Vector3(nMain.currObj.transform.localScale.x, j/100, 0);
        }
    }

    public void UpdLD()
    {
        string i = LDInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<Rigidbody2D>().drag = j;
        }
    }

    public void UpdAD()
    {
        string i = ADInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<Rigidbody2D>().angularDrag = j;
        }
    }

    public void UpdF()
    {
        string i = FInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<Rigidbody2D>().sharedMaterial.friction = j;
        }
    }

    public void UpdB()
    {
        string i = BInp.GetComponent<UnityEngine.UI.InputField>().text;
        float j;
        if (float.TryParse(i, out j))
        {
            nMain.currObj.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = j;
        }
    }

    public void UpdR()
    {
        if(!nMain.pause)
        {
            nMain.currObj.GetComponent<Rigidbody2D>().rotation = RInp.GetComponent<UnityEngine.UI.Slider>().value * 5;
        }
        else
        {
            nMain.currObj.transform.rotation = Quaternion.Euler(0,0, RInp.GetComponent<UnityEngine.UI.Slider>().value * 5);
        }
    }

    public void UpdFPx()
    {
        if(FPxInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePositionX;
        else
            nMain.currObj.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }

    public void UpdFPy()
    {
        if (FPyInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePositionY;
        else
            nMain.currObj.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    public void UpdFPz()
    {
        if (FPzInp.GetComponent<UnityEngine.UI.Toggle>().isOn)
            nMain.currObj.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezeRotation;
        else
            nMain.currObj.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezeRotation;
    }
}
