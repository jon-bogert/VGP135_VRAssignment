using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 20;
    [SerializeField] float range = 0.5f;

    [SerializeField] Transform grabLocation;
    [SerializeField] InputActionReference pickupAction;

    Transform selectedObject;

    private bool ammoSelected;

    void Start()
    {
        //Subscribe to Input
        pickupAction.action.performed += PickUp;
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
            selectedObject = hitInfo.transform;
            Ammo ammo = selectedObject.GetComponent<Ammo>();

            if (ammo != null)
            {
                ammo.GetComponent<Renderer>().material.color = Color.green;
                ammo.selected = true;
                ammoSelected = true;
            }
            else if (ammoSelected)
            {
                selectedObject.GetComponent<Ammo>().selected = false;  
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
    }

    public void AddAmmo(int amount)
    {
        ammoAmount += amount;
    }
}
