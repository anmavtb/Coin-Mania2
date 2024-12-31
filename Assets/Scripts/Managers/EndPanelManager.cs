using UnityEngine;
using TMPro;

public class EndPanelManager : Singleton<EndPanelManager>
{
    [SerializeField] TMP_Text scoreTextUI;
    [SerializeField] string scoreText = "Score : ";

    [SerializeField] TMP_Text TimerTextUI;
    [SerializeField] string timerText = "Time : ";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateEndPanel()
    {
        scoreTextUI.text = scoreText + Player.Instance.Score;
        TimerTextUI.text = timerText + TimeManager.Instance.GetTime();
    }
}
