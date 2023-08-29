using UnityEngine;

public class GripZone : MonoBehaviour
{
    [SerializeField] bool doLogging = true;
    Gun thisGun;

    private void Awake()
    {
        thisGun = GetComponentInParent<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SecondaryGrip grip = other.GetComponent<SecondaryGrip>();
        if (grip != null)
        {
            if (doLogging) Debug.Log("SecondaryGrip Enter");
            grip.currentGun = thisGun;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SecondaryGrip grip = other.GetComponent<SecondaryGrip>();
        if (grip != null)
        {
            if (doLogging) Debug.Log("SecondaryGrip Exit");

            if (grip.isGrippingGun)
                grip.currentGun.EndSecondaryGrip();

            grip.currentGun = null;
        }
    }
}
