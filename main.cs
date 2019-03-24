using UnityEngine;
using System.Collections;



public class main : MonoBehaviour {
    
    public GameObject nCursor;
    public int Tool_id;
    public enum Tool { none, wall, del};
    public Sprite[] item_sprites = new Sprite[3];
    public Vector2 coord;
    public System.Collections.Generic.List<GameObject> Wall_array;

    float Round_crat(float val, float i)
    {
        if (val / i != 0)
            val = ((float)System.Math.Round(val / i)) * i;
        return val;
    }
    // Use this for initialization
    void Start () {
        Tool_id = (int)Tool.none; // пустой
        Wall_array = new System.Collections.Generic.List<GameObject>();
        Cursor.visible = false;
	}
	


	// Update is called once per frame
	void Update () {
        nCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        coord = new Vector2(
                (float)Round_crat(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0.5f), 
                (float)Round_crat(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.5f)
            );

        switch (Tool_id)
        {
            case (int)Tool.none:
                nCursor.GetComponent<SpriteRenderer>().sprite = item_sprites[Tool_id];
                break;
            case (int)Tool.wall:
                nCursor.GetComponent<SpriteRenderer>().sprite = item_sprites[Tool_id];
                break;
            case (int)Tool.del:
                nCursor.GetComponent<SpriteRenderer>().sprite = item_sprites[Tool_id];
                break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            switch (Tool_id)
            {
                case (int)Tool.none:
                    break;
                case (int)Tool.wall:
                    GameObject tmp = new GameObject();
                    tmp.AddComponent<SpriteRenderer>();
                    tmp.GetComponent<SpriteRenderer>().sprite = item_sprites[Tool_id];
                    tmp.name = "GameObject_Wall";
                    tmp.tag = "Wall";
                    tmp.transform.position = coord;
                    tmp.AddComponent<BoxCollider2D>();
                    break;
            }
        }
    }
}
