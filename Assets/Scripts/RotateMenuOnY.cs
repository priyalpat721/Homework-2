using UnityEngine;
using UnityEngine.InputSystem;

public class RotateMenuOnY : MonoBehaviour
{
    public InputActionReference input;
    public float speed = 5f;
    float currentYValue;

    private void Update()
    {
        currentYValue = gameObject.transform.localRotation.y;

        if (input.action.ReadValue<Vector2>().x != 0)
        {
            RotateObject();
        }
    }


    private void RotateObject()
    {
        float y = input.action.ReadValue<Vector2>().x * 10f;
        float yTransform = y + currentYValue;
        gameObject.transform.Rotate(new Vector3(0f, yTransform, 0f) * speed * Time.deltaTime);
    }
}
