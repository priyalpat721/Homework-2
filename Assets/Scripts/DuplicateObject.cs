using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateObject : MonoBehaviour
{
    public InputActionReference _inputReference;

    AudioSource audioSource;

    void Awake()
    {
        // add Cloned and Detached events to action's .started and .canceled states
        _inputReference.action.started += Cloned;
        _inputReference.action.canceled += Detached;
    }

    void OnDestroy()
    {
        // remove Cloned and Detached events to action's .started and .canceled states
        _inputReference.action.started -= Cloned;
        _inputReference.action.canceled -= Detached;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Cloned(InputAction.CallbackContext context)
    {
        // if the object is selected
        if (gameObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            Color originalColor = gameObject.GetComponent<HighlightObject>().GetOriginalColor();
            // instantiate a copy of the current gameObject in the current position/rotation
            GameObject clonedObject = Instantiate(gameObject, transform.position, transform.rotation);
            clonedObject.GetComponent<MeshRenderer>().material.color = gameObject.GetComponent<MeshRenderer>().material.color;
            clonedObject.GetComponent<Rigidbody>().useGravity = false;
            clonedObject.GetComponent<Rigidbody>().isKinematic = false;
            // can specify custom behaviors for the clone here
            // can do additional things like playing an sfx
            if (audioSource.clip)
            {
                audioSource.Play();
            }
        }

        else
        {
            return;
        }
    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }
}
