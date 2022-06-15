using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class DounutsController : MonoBehaviour
{
    private GameObject _stopFlag;
    private bool _donutsStart;
    private bool _secondDonutStart;
    private bool _questionPlateOff;
    private bool _questionPlateReopen;

    private bool _taskNowOn = false;
    
    private GameObject _donuts;
    private GameObject _donuts1;
    private GameObject _donuts2;
    private GameObject _donuts3;
    private GameObject _donuts4;
    private GameObject _donuts5;

    private int _taskCompleteInt;
    private int _taskCompleteInt1;
    private int _taskCompleteInt2;
    private int _taskCompleteInt3;
    private int _taskCompleteInt4;
    private int _taskCompleteInt5;

    [SerializeField] int taskCounter = 0;
    
    private StreamWriter sw;

    private List<string> string_array;

    private int[] quesition_id_list;
    private string[] question_list;

    [SerializeField] private string Q1;
    [SerializeField] private string Q2;
    [SerializeField] private string Q3;
    [SerializeField] private string Q4;
    [SerializeField] private string Q5;
    [SerializeField] private string Q6;

    private int[] shuffled_question_id_list;
    private int[] second_shuffled_question_id_list;

    private string[] shuffled_question_id_array;
    private string[] second_shuffled_question_id_array;

    // Start is called before the first frame update
    void Start()
    {
        _stopFlag = GameObject.Find("stopFlag");
        
        _donuts = GameObject.Find("Donuts");
        _donuts1 = GameObject.Find("Donuts1");
        _donuts2 = GameObject.Find("Donuts2");
        _donuts3 = GameObject.Find("Donuts3");
        _donuts4 = GameObject.Find("Donuts4");
        _donuts5 = GameObject.Find("Donuts5");

        var sampleData = "SampleText";
        CSVSave(sampleData, "sampleFile");

        string_array = new List<string>();

        quesition_id_list = new int[6];

        quesition_id_list[0] = 0;
        quesition_id_list[1] = 1;
        quesition_id_list[2] = 2;
        quesition_id_list[3] = 3;
        quesition_id_list[4] = 4;
        quesition_id_list[5] = 5;

        //シャッフルする
        shuffled_question_id_list = new int[6];
        second_shuffled_question_id_list = new int[6];
        
        shuffled_question_id_list = quesition_id_list.OrderBy(i => Guid.NewGuid()).ToArray();
        second_shuffled_question_id_list = quesition_id_list.OrderBy(i => Guid.NewGuid()).ToArray();

        shuffled_question_id_array = new string[6];
        second_shuffled_question_id_array = new string[6];

        shuffled_question_id_array[0] = shuffled_question_id_list[0].ToString();
        shuffled_question_id_array[1] = shuffled_question_id_list[1].ToString();
        shuffled_question_id_array[2] = shuffled_question_id_list[2].ToString();
        shuffled_question_id_array[3] = shuffled_question_id_list[3].ToString();
        shuffled_question_id_array[4] = shuffled_question_id_list[4].ToString();
        shuffled_question_id_array[5] = shuffled_question_id_list[5].ToString();
        
        second_shuffled_question_id_array[0] = second_shuffled_question_id_list[0].ToString();
        second_shuffled_question_id_array[1] = second_shuffled_question_id_list[1].ToString();
        second_shuffled_question_id_array[2] = second_shuffled_question_id_list[2].ToString();
        second_shuffled_question_id_array[3] = second_shuffled_question_id_list[3].ToString();
        second_shuffled_question_id_array[4] = second_shuffled_question_id_list[4].ToString();
        second_shuffled_question_id_array[5] = second_shuffled_question_id_list[5].ToString();
        
        question_list = new string[6];

        question_list[0] = Q1;
        question_list[1] = Q2;
        question_list[2] = Q3;
        question_list[3] = Q4;
        question_list[4] = Q5;
        question_list[5] = Q6;

        _donuts.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
           .GetComponent<Text>().text = question_list[shuffled_question_id_list[0]];
        _donuts1.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
           .GetComponent<Text>().text = question_list[shuffled_question_id_list[1]];
        _donuts2.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
           .GetComponent<Text>().text = question_list[shuffled_question_id_list[2]];
        _donuts3.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
            .GetComponent<Text>().text = question_list[shuffled_question_id_list[3]];
        _donuts4.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
            .GetComponent<Text>().text = question_list[shuffled_question_id_list[4]];
        _donuts5.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
            .GetComponent<Text>().text = question_list[shuffled_question_id_list[5]];
        
        _donuts.SetActive(false);
        _donuts1.SetActive(false);
        _donuts2.SetActive(false);
        _donuts3.SetActive(false);
        _donuts4.SetActive(false);
        _donuts5.SetActive(false);
        
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _donutsStart = _stopFlag.GetComponent<stopFlag>().donutsStart;
        _secondDonutStart = _stopFlag.GetComponent<stopFlag>().secondDonutsStart;
        _questionPlateOff = _stopFlag.GetComponent<stopFlag>().questionPlateOff;
        _questionPlateReopen = _stopFlag.GetComponent<stopFlag>().questionPlateReopen;
        
        _taskCompleteInt = _donuts.GetComponent<TaskCompleteFlag>().taskCompleteInt;
        _taskCompleteInt1 = _donuts1.GetComponent<TaskCompleteFlag>().taskCompleteInt;
        _taskCompleteInt2 = _donuts2.GetComponent<TaskCompleteFlag>().taskCompleteInt;
        _taskCompleteInt3 = _donuts3.GetComponent<TaskCompleteFlag>().taskCompleteInt;
        _taskCompleteInt4 = _donuts4.GetComponent<TaskCompleteFlag>().taskCompleteInt;
        _taskCompleteInt5 = _donuts5.GetComponent<TaskCompleteFlag>().taskCompleteInt;

        int totalTaskCompleteInt = _taskCompleteInt +
                                   _taskCompleteInt1 +
                                   _taskCompleteInt2 +
                                   _taskCompleteInt3 +
                                   _taskCompleteInt4 +
                                   _taskCompleteInt5;

        if (_donutsStart == true && _taskNowOn == false)
        {
            if (taskCounter == 0)
            {
                _donuts.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else if (taskCounter == 1)
            {
                _donuts1.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else if (taskCounter == 2)
            {
                _donuts2.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else if (taskCounter == 3)
            {
                _donuts3.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else if (taskCounter == 4)
            {
                _donuts4.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else if (taskCounter == 5)
            {
                _donuts5.SetActive(true);
                taskCounter += 1;
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }

            else
            {
                _stopFlag.GetComponent<stopFlag>().donutsStart = false;
            }
        }
        
        else if (_secondDonutStart == true && _taskNowOn == false)
        {
            if (taskCounter == 6)
            {
                _donuts.SetActive(true);
                _donuts.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[0]];
                taskCounter += 1;
                _donuts.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else if (taskCounter == 7)
            {
                _donuts1.SetActive(true);
                _donuts1.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[1]];
                taskCounter += 1;
                _donuts1.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else if (taskCounter == 8)
            {
                _donuts2.SetActive(true);
                _donuts2.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[2]];
                taskCounter += 1;
                _donuts2.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else if (taskCounter == 9)
            {
                _donuts3.SetActive(true);
                _donuts3.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[3]];
                taskCounter += 1;
                _donuts3.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else if (taskCounter == 10)
            {
                _donuts4.SetActive(true);
                _donuts4.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[4]];
                taskCounter += 1;
                _donuts4.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else if (taskCounter == 11)
            {
                _donuts5.SetActive(true);
                _donuts5.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject
                    .GetComponent<Text>().text = question_list[second_shuffled_question_id_list[5]];
                taskCounter += 1;
                _donuts5.transform.GetChild(8).gameObject.SetActive((true));
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
                this.transform.GetChild(0).gameObject.SetActive(true);
                _taskNowOn = true;
            }
            
            else
            {
                _stopFlag.GetComponent<stopFlag>().secondDonutsStart = false;
            }
        }

        else if (_taskCompleteInt > 0)
        {
            string_array.Add(_taskCompleteInt.ToString());
            _donuts.SetActive(false);
            _donuts.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }

        else if (_taskCompleteInt1 > 0)
        {
            string_array.Add(_taskCompleteInt1.ToString());
            _donuts1.SetActive(false);
            _donuts1.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }
        
        else if (_taskCompleteInt2 > 0)
        {
            string_array.Add(_taskCompleteInt2.ToString());
            _donuts2.SetActive(false);
            _donuts2.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }
        
        else if (_taskCompleteInt3 > 0)
        {
            string_array.Add(_taskCompleteInt3.ToString());
            _donuts3.SetActive(false);
            _donuts3.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }
        
        else if (_taskCompleteInt4 > 0)
        {
            string_array.Add(_taskCompleteInt4.ToString());
            _donuts4.SetActive(false);
            _donuts4.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }
        
        else if (_taskCompleteInt5 > 0)
        {
            string_array.Add(_taskCompleteInt5.ToString());
            _donuts5.SetActive(false);
            _donuts5.GetComponent<TaskCompleteFlag>().taskCompleteInt = 0;
            this.transform.GetChild(0).gameObject.SetActive(false);
            _taskNowOn = false;
        }
        
        else if (_taskNowOn == true && _questionPlateOff == true)
        {
            if (_donuts.activeSelf == true)
            {
                if (_donuts.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            else if (_donuts1.activeSelf == true)
            {
                if (_donuts1.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts1.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            else if (_donuts2.activeSelf == true)
            {
                if (_donuts2.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts2.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            else if (_donuts3.activeSelf == true)
            {
                if (_donuts3.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts3.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            else if (_donuts4.activeSelf == true)
            {
                if (_donuts4.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts4.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            else if (_donuts5.activeSelf == true)
            {
                if (_donuts5.transform.GetChild(8)
                        .gameObject.activeSelf == true)
                {
                    _donuts5.transform.GetChild(8).gameObject.SetActive((false));    
                }
            }
            
            _stopFlag.GetComponent<stopFlag>().questionPlateOff = false;
        }
        
        else if (_taskNowOn == true && _questionPlateReopen == true)
        {
            if (_donuts.activeSelf == true)
            {
                _donuts.transform.GetChild(8).gameObject.SetActive((true));
            }
            
            else if (_donuts1.activeSelf == true)
            {
                _donuts1.transform.GetChild(8).gameObject.SetActive((true));
            }

            else if (_donuts2.activeSelf == true)
            {
                _donuts2.transform.GetChild(8).gameObject.SetActive((true));
            }
            
            else if (_donuts3.activeSelf == true)
            {
                _donuts3.transform.GetChild(8).gameObject.SetActive((true));
            }
            
            else if (_donuts4.activeSelf == true)
            {
                _donuts4.transform.GetChild(8).gameObject.SetActive((true));
            }
            
            else if (_donuts5.activeSelf == true)
            {
                _donuts5.transform.GetChild(8).gameObject.SetActive((true));
            }
            
            _stopFlag.GetComponent<stopFlag>().questionPlateReopen = false;
        }
    }
    
    private void CSVSave(string data, string fileName)
    {
        FileInfo fi;
        DateTime now = DateTime.Now;

        fileName = fileName + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(Application.dataPath + "/AnswerData/" + fileName + ".csv");
        sw = fi.AppendText();
        string[] string_array = new string[] { "selected"};
        sw.WriteLine(string.Join(",", string_array));
    }
    
    private void OnApplicationQuit()
    {
        sw.WriteLine((string.Join(",", shuffled_question_id_array)));
        sw.WriteLine((string.Join(",", second_shuffled_question_id_array)));
        sw.WriteLine((string.Join(",", string_array)));
        
        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");
    }
}
