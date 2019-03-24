using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgr_coll : MonoBehaviour {
    public List<Vector2> newVerticies = new List<Vector2>();

    // Use this for initialization
    void Start () {
        
        /*EdgeCollider2D ecoll = GetComponent<EdgeCollider2D>();
        //newVerticies.Add(new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).x, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));
        newVerticies.Add(new Vector2(Camera.main.ScreenToWorldPoint(Vector2.zero).x, Camera.main.ScreenToWorldPoint(Vector2.zero).y+0.5f));
        newVerticies.Add(new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).y+0.5f));
        //newVerticies.Add(new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y));
        ecoll.points = newVerticies.ToArray();*/
        
    }

}
