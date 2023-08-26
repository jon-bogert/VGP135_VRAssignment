using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 20;
    [SerializeField] float range = 0.5f;

    [SerializeField] Transform grabLocation;
    [SerializeField] InputActionReference pickupAction;
    [SerializeField] TextMeshProUGUI text;

    Transform selectedObject;

    private bool ammoSelected;

    void Start()
    {
        //Subscribe to Input
        pickupAction.action.performed += PickUp;
        text.text = ammoAmount.ToString();
    }

    void OnDestroy()
    {
        //Unsubscribe to Input
        pickupAction.action.performed -= PickUp;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(grabLocation.position, grabLocation.forward, out hitInfo, range))
        {
            Ammo ammo = hitInfo.transform.GetComponent<Ammo>();

            if (ammo != null)
            {
                selectedObject = hitInfo.transform;
                ammo.selected = true;
                ammoSelected = true;
            }
            else if (ammoSelected)
            {
                selectedObject.GetComponent<Ammo>().selected = false;
                ammoSelected = false;
            }
        }
    }

    void PickUp(InputAction.CallbackContext ctx)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(grabLocation.position, grabLocation.forward, out hitInfo, range))
        {
            Ammo ammo = hitInfo.transform.GetComponent<Ammo>();

            if (ammo != null) 
            {
                ammo.pAmmo = this;
                ammo.PickUpAmmo();
            }
        }
    }

    public bool HasAmmo()
    {
        return ammoAmount > 0;  
    }

    public void UseAmmo()
    {
        ammoAmount--;
        text.text = ammoAmount.ToString();
    }

    public void AddAmmo(int amount)
    {
        ammoAmount += amount;
        text.text = ammoAmount.ToString();
    }
}
