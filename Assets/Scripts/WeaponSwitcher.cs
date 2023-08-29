using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject primary;
    [SerializeField] GameObject secondary;
    [SerializeField] InputActionReference _switchInput;

    bool _isPrimary;

    private void Awake()
    {
        primary.SetActive(true);
        secondary.SetActive(false);

        _switchInput.action.performed += OnSwictch;
    }

    private void OnDestroy()
    {
        _switchInput.action.performed -= OnSwictch;
    }

    void OnSwictch(InputAction.CallbackContext ctx)
    {
        _isPrimary = !_isPrimary;
        primary.SetActive(_isPrimary);
        secondary.SetActive(!_isPrimary);
    }

}
