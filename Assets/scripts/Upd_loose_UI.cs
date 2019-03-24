using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upd_loose_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private void Start()
    {
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }
    public main nMain;
    public void OnPointerEnter(PointerEventData eventData)
    {
        nMain.looseUI = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nMain.looseUI = true;
    }
}
