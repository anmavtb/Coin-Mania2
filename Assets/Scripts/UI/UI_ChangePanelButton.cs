using UnityEngine;

public class UI_ChangePanelButton : UI_GenericButton
{
    [SerializeField] GameObject actualPanel = null;
    [SerializeField] GameObject targetPanel = null;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    protected override void Behaviour()
    {
        actualPanel.SetActive(false);
        targetPanel.SetActive(true);
    }
}
