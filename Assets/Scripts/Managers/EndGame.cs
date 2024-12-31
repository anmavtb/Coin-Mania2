using UnityEngine;

public class EndGame : Singleton<EndGame>
{
    [SerializeField] GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameEnd()
    {
        InputManager.Instance.enabled = false;
        EndPanelManager.Instance.UpdateEndPanel();
        TimeManager.Instance.enabled = false;
        endPanel.SetActive(true);
    }
}