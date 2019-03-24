using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJInflex_control : MonoBehaviour {

    public DJoint parent;
	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<DJoint>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector2(parent.comp.distance / 5, 0.03f);
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(parent.Obj0.transform.TransformPoint(parent.V0).y - parent.Obj1.transform.TransformPoint(parent.V1).y, parent.Obj0.transform.TransformPoint(parent.V0).x - parent.Obj1.transform.TransformPoint(parent.V1).x)) * Mathf.Rad2Deg);
        transform.position = (parent.Obj0.transform.TransformPoint(parent.V0) + parent.Obj1.transform.TransformPoint(parent.V1)) / 2;
    }
}
