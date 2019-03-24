using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Water : MonoBehaviour {

    //переменная для хранения обьекта main
    public main nMain;

    public SPH nSPH;
    //переменные инвокера
    public GameObject Prefab_water;
    public float invoke_start = 0;
    public float invoke_pause = 0.5f;
    public int powerw = 1;
    public int powerh = 1;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Create_Water", invoke_start, invoke_pause);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Create_Water");
        }
    }

    void OnDisable()
    {
        CancelInvoke("Create_Water");
    }
    void Create_Water()
    {
        if (nMain.loose == true && nMain.looseUI == true)
        {
            float dist = 0.5f;
            float shift = 0.1f;
            int w = powerw;
            int h = powerh;
            float stw = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - (dist * w / 2);
            float sth = Camera.main.ScreenToWorldPoint(Input.mousePosition).y + (dist * h / 2);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    nSPH.particles_count++;
                    nSPH.particles.Add(Instantiate(Prefab_water));
                    nSPH.particles[nSPH.particles_count - 1].name = "Water" + nSPH.particles_count;
                    nSPH.particles[nSPH.particles_count - 1].GetComponent<Fluid_particle>().part_id = nSPH.particles_count;
                    nSPH.particles[nSPH.particles_count - 1].transform.position = new Vector2
                        (
                            stw + i * dist + j * shift,
                            sth + j * dist
                        );
                    nSPH.particles[nSPH.particles_count - 1].transform.parent = nSPH.transform;
                }
            }

        }
    }
}
