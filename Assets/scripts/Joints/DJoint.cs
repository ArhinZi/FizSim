using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJoint : MonoBehaviour {
    public main nMain;
    public GameObject Obj0;
    public GameObject Obj1;
    public Vector2 V0;
    public Vector2 V1;
    public DistanceJoint2D comp;

    public bool Flexibility = false;
    public GameObject segmPref;
    public GameObject Flex;
    public GameObject Inflex;
    // Use this for initialization
    void Start()
    {
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
        comp = Obj0.AddComponent<DistanceJoint2D>();
        V0 = Obj0.transform.InverseTransformPoint(V0);
        V1 = Obj1.transform.InverseTransformPoint(V1);
        comp.enableCollision = true;
        comp.connectedBody = Obj1.GetComponent<Rigidbody2D>();
        comp.anchor = V0;
        comp.connectedAnchor = V1;
        Physics2D.IgnoreCollision(Obj0.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(Obj1.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
        FlexUpd();
    }

    private void OnDestroy()
    {
        Destroy(comp);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void FlexUpd()
    {
        Flex.SetActive(false);
        Inflex.SetActive(false);
        if(Flexibility)
        {
            Flex.SetActive(true);
        }
        else
        {
            Inflex.SetActive(true);
        }
    }

}
