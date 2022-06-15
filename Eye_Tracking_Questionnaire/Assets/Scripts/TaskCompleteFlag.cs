using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveSR.anipal.Eye;

public class TaskCompleteFlag : MonoBehaviour
{
    [SerializeField] private Color32 original_arc_color;
    [SerializeField] private Color32 changed_arc_color;
    
    private RaycastHit hit;
    private Ray _ray;
    private float _lazerDistance;
                
    private GameObject _fan1;
    private GameObject _fan2;
    private GameObject _fan3;
    private GameObject _fan4;
    private GameObject _fan5;
    private GameObject _fan6;
    private GameObject _fan7;

    private GameObject _ring1;
    private GameObject _ring2;
    private GameObject _ring3;
    private GameObject _ring4;
    private GameObject _ring5;
    private GameObject _ring6;
    private GameObject _ring7;

    private GameObject _smallCircle1;
    private GameObject _smallCircle2;
    private GameObject _smallCircle3;
    private GameObject _smallCircle4;
    private GameObject _smallCircle5;
    private GameObject _smallCircle6;
    private GameObject _smallCircle7;

    private GameObject _background;

    private GameObject _eyeGazeObject;

    private GameObject _donutsController;
    
    public int taskCompleteInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        _fan1 = this.transform.GetChild(0).gameObject;
        _fan2 = this.transform.GetChild(1).gameObject;
        _fan3 = this.transform.GetChild(2).gameObject;
        _fan4 = this.transform.GetChild(3).gameObject;
        _fan5 = this.transform.GetChild(4).gameObject;
        _fan6 = this.transform.GetChild(5).gameObject;
        _fan7 = this.transform.GetChild(6).gameObject;

        _ring1 = _fan1.transform.GetChild(0).gameObject;
        _ring2 = _fan2.transform.GetChild(0).gameObject;
        _ring3 = _fan3.transform.GetChild(0).gameObject;
        _ring4 = _fan4.transform.GetChild(0).gameObject;
        _ring5 = _fan5.transform.GetChild(0).gameObject;
        _ring6 = _fan6.transform.GetChild(0).gameObject;
        _ring7 = _fan7.transform.GetChild(0).gameObject;

        _smallCircle1 = _ring1.transform.GetChild(0).gameObject;
        _smallCircle2 = _ring2.transform.GetChild(0).gameObject;
        _smallCircle3 = _ring3.transform.GetChild(0).gameObject;
        _smallCircle4 = _ring4.transform.GetChild(0).gameObject;
        _smallCircle5 = _ring5.transform.GetChild(0).gameObject;
        _smallCircle6 = _ring6.transform.GetChild(0).gameObject;
        _smallCircle7 = _ring7.transform.GetChild(0).gameObject;

        _background = this.transform.GetChild(7).gameObject;

        _eyeGazeObject = GameObject.Find("Gaze Ray Sample v2");
        _lazerDistance = _eyeGazeObject.GetComponent<SRanipal_GazeRaySample_v2>().laserDistance;
        
        _donutsController = GameObject.Find("DonutsController");
    }

    // Update is called once per frame
    void Update()
    {
        if (_ring1.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 1;
            _ring1.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring2.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 2;
            _ring2.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring3.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 3;
            _ring3.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring4.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 4;
            _ring4.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring5.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 5;
            _ring5.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring6.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 6;
            _ring6.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        else if (_ring7.GetComponent<RuntimeArcMake>().areaAngle > 360)
        {
            taskCompleteInt = 7;
            _ring7.GetComponent<RuntimeArcMake>().areaAngle = 0;
        }
        
        _ray = _eyeGazeObject.GetComponent<SRanipal_GazeRaySample_v2>().ray;
        
        if (Physics.Raycast(_ray, out hit, _lazerDistance))
        {

            if (hit.collider.name == _fan1.name)
            {
                _fan1.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan2.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan3.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan4.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan5.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan6.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = changed_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = changed_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = true;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }

            else if (hit.collider.name == _fan7.name)
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = changed_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = changed_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = true;
            }

            else
            {
                _fan1.GetComponent<Renderer>().material.color = original_arc_color;
                _fan2.GetComponent<Renderer>().material.color = original_arc_color;
                _fan3.GetComponent<Renderer>().material.color = original_arc_color;
                _fan4.GetComponent<Renderer>().material.color = original_arc_color;
                _fan5.GetComponent<Renderer>().material.color = original_arc_color;
                _fan6.GetComponent<Renderer>().material.color = original_arc_color;
                _fan7.GetComponent<Renderer>().material.color = original_arc_color;

                _smallCircle1.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle2.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle3.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle4.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle5.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle6.GetComponent<Renderer>().material.color = original_arc_color;
                _smallCircle7.GetComponent<Renderer>().material.color = original_arc_color;

                _ring1.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring2.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring3.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring4.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring5.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring6.GetComponent<RuntimeArcMake>()._ringRunOn = false;
                _ring7.GetComponent<RuntimeArcMake>()._ringRunOn = false;
            }
        }
    }
}
