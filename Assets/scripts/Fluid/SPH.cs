﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SPH : MonoBehaviour
{
    public float scale;
    public int particles_count = 0;
    public List<GameObject> particles;
    public Collider2D[][] part_near;
    public float[][] part_d;
    public float[][] part_q;
    public float[][] part_q2;
    public float[][] part_q3;



    public float mass;
    public float h;
    public float k;
    public float k_near;
    public float rest_ro;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        part_near = new Collider2D[particles_count][];
        part_d = new float[particles_count][];
        part_q = new float[particles_count][];
        for (int i = 0; i < particles_count; i++)
        {
            if (particles[i] == null) continue;
            Fluid_particle g = particles[i].GetComponent<Fluid_particle>();
            
            g.ro = 0;
            g.ro_near = 0;
            g.press = 0;
            g.press_near = 0;
            g.a = Vector2.zero;
            g.mass = mass;
            //g.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            g.a += new Vector2(0, -98f*2);
        }
        for (int i = 0; i < particles_count; i++)
        {
            if (particles[i] == null) continue;
            Fluid_particle p = particles[i].GetComponent<Fluid_particle>();
            part_near[i] = (Physics2D.OverlapCircleAll(particles[i].transform.position, h - (scale / 2)-0.2f, 1 << 4));
            part_d[i] = new float[part_near[i].Length];
            part_q[i] = new float[part_near[i].Length];
            //p.ro_near = 0.05f;
            //p.ro = 0.15f;
            for (int j = 0; j < part_near[i].Length; j++)
            {
                if (part_near[i][j] == null) continue;
                part_d[i][j] = Vector2.Distance(particles[i].transform.position, part_near[i][j].transform.position);
                part_q[i][j] = 1 - (part_d[i][j] / h);

                if (part_d[i][j] > 0)
                {
                    
                        p.ro += (part_q[i][j] * part_q[i][j]);
                        p.ro_near += (part_q[i][j] * part_q[i][j] * part_q[i][j]);
                    
                    
                    if (part_near[i][j].gameObject.layer == 9) continue;
                    Fluid_particle q = part_near[i][j].GetComponent<Fluid_particle>();
                    
                        q.ro += (part_q[i][j] * part_q[i][j]);
                        q.ro_near += (part_q[i][j] * part_q[i][j] * part_q[i][j]);
                    

                }
            }
        }
        for (int i = 0; i < particles_count; i++)
        {
            if (particles[i] == null) continue;
            Fluid_particle p = particles[i].GetComponent<Fluid_particle>();
            p.press = k * (p.ro - rest_ro);
            p.press_near = k_near * p.ro_near;
        }
        for (int i = 0; i < particles_count; i++)
        {
            Vector2 s = Vector2.zero;
            if (particles[i] == null) continue;
            Fluid_particle p = particles[i].GetComponent<Fluid_particle>();
            for (int j = 0; j < part_near[i].Length; j++)
            {
                if (part_near[i][j] == null) continue;
                Fluid_particle q = part_near[i][j].GetComponent<Fluid_particle>();
                if (part_near[i][j].gameObject.layer == 4)
                {
                    if (part_d[i][j] > 0)
                    {

                        float q1 = part_q[i][j];
                        float q2 = q1 * q1;
                        Vector2 tmp = (p.transform.position - q.transform.position) * ((p.press + q.press) * q1 + (p.press_near + q.press_near) * q2) / part_d[i][j];
                        q.a += tmp;
                        s += tmp;
                    }
                }
                else if (part_near[i][j].gameObject.layer == 9)
                {
                    float q1 = part_q[i][j];
                    float q2 = q1 * q1;
                    Vector2 tmp = (part_near[i][j].transform.position - p.transform.position) * ((p.press) * q1 + (1000*p.press_near) * q2) / part_d[i][j];
                    s += tmp;
                    //Debug.Log("drgd");
                }

            }
            p.a -= s;
        }

        for (int i = 0; i < particles_count; i++)
        {
            if (particles[i] == null) continue;
            Fluid_particle p = particles[i].GetComponent<Fluid_particle>();
            Vector2 f = p.a;
            //p.a.x = Mathf.Clamp(f.x, -200, 200);
            p.a.y = Mathf.Clamp(f.y, -300, 800);

        }

    }
}
