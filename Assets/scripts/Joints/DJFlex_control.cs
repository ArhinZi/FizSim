using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJFlex_control : MonoBehaviour {

    public DJoint parent;
    public GameObject[] segms;
    // Use this for initialization
    void Start()
    {
        parent = transform.parent.GetComponent<DJoint>();
        Upd();
    }

    // Update is called once per frame
    void Update () {
		
	}
    void Upd()
    {
        int n = (int) (parent.comp.distance / 0.1f);
        float ost = parent.comp.distance - n * 0.1f;
        segms = new GameObject[n];
        for(int i=0;i<n;i++)
        {
            segms[i] = Instantiate(parent.segmPref);
            segms[i].transform.parent = parent.transform;
            if (i!=0)
            {
                segms[i - 1].GetComponent<DistanceJoint2D>().connectedBody = segms[i].GetComponent<Rigidbody2D>();
                segms[i - 1].GetComponent<DistanceJoint2D>().autoConfigureDistance = false;
                segms[i - 1].GetComponent<DistanceJoint2D>().distance = 0.1f;
            }
        }
        DistanceJoint2D temp = segms[0].AddComponent<DistanceJoint2D>();
        temp.connectedBody = parent.Obj0.GetComponent<Rigidbody2D>();
        temp.autoConfigureDistance = false;
        temp.distance = ost / 2;
        temp.connectedAnchor = parent.V0;
        temp = segms[n-1].GetComponent<DistanceJoint2D>();
        temp.connectedBody = parent.Obj1.GetComponent<Rigidbody2D>();
        temp.autoConfigureDistance = false;
        temp.distance = ost / 2;
        temp.connectedAnchor = parent.V1;

    }
}
