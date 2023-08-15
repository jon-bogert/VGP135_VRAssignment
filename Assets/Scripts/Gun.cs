using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] InputActionReference shootAction;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject impactEffect;
    [SerializeField] Animator muzzleFlashAnimator;

    [Header("Crosshair")]
    [SerializeField] Reticle crosshair;
    [SerializeField] float crosshairRange = 10f;

    void Start()
    {
        //Subscribe to Input
        shootAction.action.performed += Shoot;
    }

    void OnDestroy()
    {
        //Unsubscribe to Input
        shootAction.action.performed -= Shoot;
    }

    void OnEnable()
    {
        if (crosshair)
            crosshair.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        if (crosshair)
            crosshair.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!crosshair)
            return;

        //Updating Crosshair if not null
        Vector3 chPos;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, crosshairRange))
            chPos = hitInfo.point;
        else
        {
            chPos = new Vector3(muzzle.position.x, muzzle.position.y, muzzle.position.z);
            chPos += muzzle.forward * crosshairRange;
        }

        crosshair.transform.position = new Vector3(chPos.x, chPos.y, chPos.z);
        crosshair.transform.LookAt(muzzle);
    }

    void Shoot(InputAction.CallbackContext ctx)
    {
        if (isActiveAndEnabled)
        {
            if (crosshair)
                crosshair.Trigger();
            if (muzzleFlashAnimator)
                muzzleFlashAnimator.SetTrigger("isFiring");

            RaycastHit hitInfo;
            if (Physics.Raycast(muzzle.position, muzzle.forward, out hitInfo, range))
            {
                Destructable destructable = hitInfo.transform.GetComponent<Destructable>();
                if (destructable != null)
                {
                    destructable.Damage(damage);
                    Debug.Log("Hit: " + hitInfo.transform.name);
                }

                if (impactEffect)
                    Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}
