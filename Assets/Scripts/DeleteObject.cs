using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteObject : MonoBehaviour
{
    public InputActionReference _inputReference;
    public AudioClip audioClip;
    public ParticleSystem particles;
   
    bool hasPlayedClip = false;

    void Awake()
    {
        _inputReference.action.started += DestroyObject;
    }

    void OnDestroy()
    {
        _inputReference.action.started -= DestroyObject;
    }

    void Update()
    {
        float distance = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
        if (distance >= 10f && !hasPlayedClip)
        {
            DestroyNow();
        }
    }

    public void DestroyObject(InputAction.CallbackContext context)
    {

        if (gameObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            DestroyNow();
        }
        else
        {
            return;
        }
    }

    void DestroyNow()
    {
        hasPlayedClip= true;
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        Destroy(Instantiate(particles.gameObject, gameObject.transform.position, gameObject.transform.rotation), 0.5f);
        Destroy(gameObject, 0.4f);
        _inputReference.action.started -= DestroyObject;
    }
}
