using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryGrip : MonoBehaviour
{
    [SerializeField] InputActionReference gripInput;

    [HideInInspector]
    public Gun currentGun = null;

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
        if (ctx.ReadValue<float>() > 0.5f)
        {
            
        }
        else
        {
            //Let Go
        }
    }
}
