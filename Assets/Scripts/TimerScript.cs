using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timer;
    private float secondsCount;
    private float minutesCount;
    private float hoursCount;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimerUI();
    }

    void updateTimerUI()
    {
        string seconds;
        string minutes;

        secondsCount += Time.deltaTime;
        if ((int)secondsCount < 10)
        {
            seconds = "0" + (int)secondsCount;
        }
        else
        {
            seconds = "" + (int)secondsCount;
        }
        if ((int)minutesCount < 10)
        {
            minutes = "0" + minutesCount;
        }
        else
        {
            minutes = "" + minutesCount;
        }

        timer.text = "Time: " + hoursCount + ":" + minutes + ":" + seconds;
        
        if (secondsCount >= 60)
        {
            minutesCount++;
            secondsCount %= 60;

            if (minutesCount >= 60)
            {
                hoursCount++;
                minutesCount %= 60;
            }
        }
    }
}
