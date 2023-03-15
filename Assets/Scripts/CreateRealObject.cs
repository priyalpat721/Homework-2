using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateRealObject : MonoBehaviour
{
    public InputActionReference inputReference;
    public ParticleSystem particles;
    public AudioClip audioClip;

    void Awake()
    {
        inputReference.action.started += CreateObject;
    }

    void OnDestroy()
    {
        inputReference.action.started -= CreateObject;
    }

    private void CreateObject(InputAction.CallbackContext context)
    {
        if (gameObject.GetComponent<XRSimpleInteractable>().isHovered)
        {
            Vector3 position = new Vector3(-0.8f, 1.193f, 0.7f);
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            Destroy(Instantiate(particles.gameObject, position, Quaternion.identity), 0.5f);
            Color originalColor = gameObject.GetComponent<HighlightObject>().GetOriginalColor();
            GameObject newObject = Instantiate(gameObject);
            newObject.transform.position= position;
            newObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            newObject.GetComponent<MeshRenderer>().material.color = originalColor;
            newObject.GetComponent<Rigidbody>().useGravity = true;
            newObject.GetComponent<Rigidbody>().isKinematic = false;
            newObject.GetComponent<XRSimpleInteractable>().enabled= false;
            newObject.GetComponent<XRGrabInteractable>().enabled = true;
            newObject.GetComponent<ObjectMaterialChanger>().enabled = true;
            newObject.GetComponent<DeleteObject>().enabled = true;
            newObject.GetComponent<HighlightClones>().enabled = true;
            newObject.GetComponent<ScaleObject>().enabled = true;
            newObject.GetComponent<DuplicateObject>().enabled = true;
        }
    }
}