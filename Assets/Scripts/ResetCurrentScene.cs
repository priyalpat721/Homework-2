using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetCurrentScene : MonoBehaviour
{
    public Material original;
    public Material target;

    Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Reset()
    {
        SceneManager.LoadScene(scene.name);
    }

    public void ChangeBackground()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        gameObject.transform.GetChild(0).GetComponent<Image>().material = target;
        Invoke("RestoreBackground", 0.1f);
    }

    void RestoreBackground()
    {

        gameObject.transform.GetChild(0).GetComponent<Image>().material = original;
        Invoke("Reset", 0.3f);
    }
}
