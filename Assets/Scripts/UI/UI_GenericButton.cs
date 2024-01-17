using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public abstract class UI_GenericButton : MonoBehaviour
{
    Button button = null;
    AudioSource audioData;

    // Start is called before the first frame update
    protected void Start()
    {
        button = GetComponent<Button>();
        audioData = GetComponent<AudioSource>();
        audioData.playOnAwake = false;

        button.onClick.AddListener(() =>
        {
            StartCoroutine(PlaySound());
        });
    }

    IEnumerator PlaySound()
    {
        audioData.Play();
        yield return new WaitWhile(() => audioData.isPlaying);
        Behaviour();
    }

    abstract protected void Behaviour();
}
