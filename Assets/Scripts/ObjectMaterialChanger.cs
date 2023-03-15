using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Debug = UnityEngine.Debug;

public class ObjectMaterialChanger : MonoBehaviour
{
    public InputActionReference inputReference;
    public GameObject controller;
    public AudioClip clip;

    MeshRenderer _renderer;

    void Awake()
    {
        inputReference.action.started += ChangeColorToPointer;
    }

    void OnDestroy()
    {
        inputReference.action.started -= ChangeColorToPointer;
    }


    void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void ChangeColorToPointer(InputAction.CallbackContext context)
    {
       if (gameObject.GetComponent<XRGrabInteractable>().isHovered)
        {
            GameObject pointer = controller.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
            Color color = pointer.GetComponent<MeshRenderer>().material.color;
            gameObject.GetComponent<HighlightClones>().SetOriginalColor(color);
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            _renderer.material.color = color;
        }
    }
}
