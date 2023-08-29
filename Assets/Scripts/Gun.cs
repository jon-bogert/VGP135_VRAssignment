using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] InputActionReference shootAction;
    [SerializeField] Transform muzzle;
    [SerializeField] Transform secondaryGrip;
    [SerializeField] Transform primaryHand;
    [SerializeField] GameObject impactEffect;
    [SerializeField] MuzzleFlash muzzleFlash;
    [SerializeField] AudioClip shotSound;
    [SerializeField] Animator gunAnimator;
    [SerializeField] bool _usesAmmo = true;

    [Header("Crosshair")]
    [SerializeField] Reticle crosshair;
    [SerializeField] float crosshairRange = 10f;

    AudioSource audioSource;

    bool _useSecondayGrip = false;
    Vector3 _localPosition = Vector3.zero;
    Quaternion _localRotation = Quaternion.identity;

    PlayerAmmo ammo;

    public bool usingSecondaryGrip { get { return _useSecondayGrip; } }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        _localPosition = transform.localPosition;
        _localRotation = transform.localRotation;
    }

    void Start()
    {
        ammo = FindObjectOfType<PlayerAmmo>();
        if (!ammo) Debug.LogWarning("PlayerAmmo Object was not found");

        //Subscribe to Input
        shootAction.action.performed += Shoot;
    }

    void OnDestroy()
    {
        //Unsubscribe to Input
        shootAction.action.performed -= Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (_useSecondayGrip)
        {
            transform.LookAt(secondaryGrip.position);
            //TODO - Rotate to match primary hand
        }

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
        if (!isActiveAndEnabled)
            return;
        if (_usesAmmo && ammo && !ammo.HasAmmo())
            return;

        if (audioSource)
            audioSource.PlayOneShot(shotSound);
        if (crosshair)
            crosshair.Trigger();
        if (muzzleFlash)
            muzzleFlash.Dewit();
        if (gunAnimator)
            gunAnimator.SetTrigger("Shoot");

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

        if (_usesAmmo)
            ammo.UseAmmo();
    }

    public void StartSecondaryGrip(Transform gripTransform)
    {
        secondaryGrip = gripTransform;
        _useSecondayGrip = true;
    }

    public void EndSecondaryGrip()
    {
        _useSecondayGrip = false;
        transform.localPosition = _localPosition;
        transform.localRotation = _localRotation;
    }
}
