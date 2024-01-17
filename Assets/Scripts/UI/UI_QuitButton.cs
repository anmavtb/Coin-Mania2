using UnityEngine;

public class UI_QuitButton : UI_GenericButton
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    protected override void Behaviour()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
