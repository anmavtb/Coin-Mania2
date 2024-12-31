using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField, ReadOnly] float timer;

    public float Timer => timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public string GetTime()
    {
        int minutes = (int)(timer / 60);
        int seconds = (int)(timer % 60);
        string minutesResult = "00";
        string secondsResult = "00";

        if (minutes < 10) minutesResult = "0" + minutes;
        else minutesResult = minutes.ToString();
        if (seconds < 10) secondsResult = "0" + seconds;
        else secondsResult = seconds.ToString();

        return minutesResult + ":" + secondsResult;
    }
}