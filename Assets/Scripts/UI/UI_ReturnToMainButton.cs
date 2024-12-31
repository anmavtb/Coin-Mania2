using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ReturnToMainButton : UI_GenericButton
{
    string newScene = null;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    protected override void Behaviour()
    {
        newScene = "Level_One";
        SceneManager.LoadScene(newScene);
    }
}