using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryGrip : MonoBehaviour
{
    [SerializeField] InputActionReference gripInput;

    [HideInInspector]
    public Gun currentGun = null;

    public bool isGrippingGun { get { return (currentGun && currentGun.usingSecondaryGrip); } }

    private void Awake()
    {
        gripInput.action.performed += OnGrip;
    }

    private void OnDestroy()
    {
        gripInput.action.performed -= OnGrip;
    }

    void OnGrip(InputAction.CallbackContext ctx)
    {
        if (currentGun && ctx.ReadValue<float>() > 0.5f)
        {
            currentGun.StartSecondaryGrip(transform);
        }
        else if (currentGun)
        {
            currentGun.EndSecondaryGrip();
        }
    }
}
