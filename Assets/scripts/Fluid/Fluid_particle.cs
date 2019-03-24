using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid_particle : MonoBehaviour {
    public int part_id;
    public float mass;
    public float ro;
    public float ro_near;
    public float press;
    public float press_near;
    public float sigma;
    public float beta;
    public Vector2 a;
    public Vector2 pos;
    public Vector2 pos_old;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GetComponent<Rigidbody2D>().AddForce(a*mass, ForceMode2D.Force);
    }
}
