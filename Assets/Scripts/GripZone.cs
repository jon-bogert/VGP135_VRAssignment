using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class GripZone : MonoBehaviour
{
    [SerializeField] bool doLogging = true;
    Gun thisGun;
    Billboard _dot;
    bool _subscribed = false;

    private void Awake()
    {
        thisGun = GetComponentInParent<Gun>();
        _dot = GetComponentInChildren<Billboard>();

        if (!_dot)
            Debug.LogWarning("Dot Billboard was not found");
    }

    private void OnTriggerEnter(Collider other)
    {
        SecondaryGrip grip = other.GetComponent<SecondaryGrip>();
        if (grip != null)
        {
            if (doLogging) Debug.Log("SecondaryGrip Enter");
            if (_dot)
                _dot.IsEnabled = true;
            grip.onGripPress += OnGripPress;
            _subscribed = true;
            grip.currentGun = thisGun;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SecondaryGrip grip = other.GetComponent<SecondaryGrip>();
        if (grip != null)
        {
            if (doLogging) Debug.Log("SecondaryGrip Exit");

            if (_dot && _dot.IsEnabled)
                _dot.IsEnabled = false;

            if (_subscribed)
            {
                _subscribed = false;
                grip.onGripPress -= OnGripPress;
            }

            if (grip.isGrippingGun)
                grip.currentGun.EndSecondaryGrip();

            grip.currentGun = null;
        }
    }

    void OnGripPress(SecondaryGrip context)
    {
        if (_dot && _dot.IsEnabled)
            _dot.IsEnabled = false;

        if (_subscribed)
        {
            _subscribed = false;
            context.onGripPress -= OnGripPress;
        }
    }
}
