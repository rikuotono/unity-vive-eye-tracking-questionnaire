using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopFlag : MonoBehaviour
{
    public bool donutsStart = false;
    public bool secondDonutsStart = false;
    public bool questionPlateOff = false;
    public bool questionPlateReopen = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            donutsStart = true;
        }
        
        else if (Input.GetKeyDown("b"))
        {
            secondDonutsStart = true;
        }
        
        else if (Input.GetKeyDown("c"))
        {
            questionPlateOff = true;
        }
        
        else if (Input.GetKeyDown("d"))
        {
            questionPlateReopen = true;
        }
    }
}
