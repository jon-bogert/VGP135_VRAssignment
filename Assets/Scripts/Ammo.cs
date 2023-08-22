using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] float grabTime;

    public PlayerAmmo pAmmo;
    Transform grabLocation;

    bool pickingUp = false;
    float pickUpTime = 0f;

    private void Start()
    {
        grabLocation = GameObject.FindGameObjectWithTag("GrabLocation").GetComponent<Transform>();
    }

    void Update()
    {
        if (pickingUp)
        {
            pickUpTime += Time.deltaTime;
            float percentageComplete = pickUpTime / grabTime;
            transform.position = Vector3.Lerp(transform.position, grabLocation.position, percentageComplete);

            if (percentageComplete == 1.0f)
            {
                pickingUp = false;
                EndPickUp();
            }
        }
    }

    public void PickUpAmmo()
    {
        if (!pickingUp)
        {
            pickingUp = true;
            pickUpTime = 0f;
        }
    }

    void EndPickUp()
    {
        pAmmo.AddAmmo(ammoAmount);
        Destroy(gameObject);
    }
}
