using UnityEngine;

public class GripZone : MonoBehaviour
{
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
            grip.currentGun = thisGun;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SecondaryGrip grip = other.GetComponent<SecondaryGrip>();
        if (grip != null)
        {
            grip.currentGun = null;
        }
    }
}
