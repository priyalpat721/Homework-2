using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleObject : MonoBehaviour
{
    public InputActionReference input;
    public float speed = 0.05f;

    float originalSize;
    float min;
    float max;

    void Start()
    {
        originalSize = gameObject.transform.localScale.x;
        min = originalSize / 2f;
        max = originalSize * 4f - 0.01f;
    }

    void Update()
    {
        if (input.action.ReadValue<Vector2>().y != 0)
        {
            Scale();
        }
    }

    private void Scale()
    {
        if (gameObject.GetComponent<XRGrabInteractable>().isHovered)
        {
            float scale = speed * input.action.ReadValue<Vector2>().y;
            Vector3 localScale = gameObject.transform.localScale;
            Vector3 vector = new Vector3(localScale.x + scale, localScale.y + scale, localScale.z + scale);
            
            if ((localScale.x + scale) > min && (localScale.x + scale) < max)
            {
                gameObject.transform.localScale = Vector3.Lerp(localScale, vector, 0.01f);
            }
        }
    }
}
