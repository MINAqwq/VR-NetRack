using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class dynamic_line : MonoBehaviour
{
    public GameObject line;
    public GameObject plug1;
    public GameObject plug2;

    LineRenderer line_renderer;

    // Start is called before the first frame update
    void Start()
    {
        // Don't ever move this object from 0,0,0!!
        line_renderer = line.GetComponent<LineRenderer>();
        line_renderer.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 point_start = plug1.transform.position;
        Vector3 point_end = plug2.transform.position;

        line_renderer.SetPosition(0, point_start);
        line_renderer.SetPosition(1, point_end);
    }
}
