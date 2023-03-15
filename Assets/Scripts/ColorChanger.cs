using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public GameObject controller;
    public Material original;
    public Material target;
    GameObject pointer;
    Color newColor;
    MeshRenderer _renderer;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        pointer = controller.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        panel = gameObject.transform.GetChild(1).gameObject;
    }

    public void OnColorChange()
    {
        panel.GetComponent<Image>().material = target;
        AudioClip audioClip = pointer.GetComponent<AudioSource>().clip;
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        newColor = _renderer.material.color;
        pointer.GetComponent<MeshRenderer>().material.color = newColor;
    }

    public void ToggleBackground()
    {

        panel.GetComponent<Image>().material = original;
    }
}
