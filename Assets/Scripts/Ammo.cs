using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] float grabTime = 0.5f;

    [HideInInspector]
    public PlayerAmmo pAmmo;
    Transform grabLocation;

    public bool selected;
    bool pickingUp = false;
    float pickUpTime = 0f;

    private void Start()
    {
        grabLocation = GameObject.FindGameObjectWithTag("GrabLocation").GetComponent<Transform>();
    }

    void Update()
    {
        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        
        if (pickingUp)
        {
            pickUpTime += Time.deltaTime;
            float percentageComplete = pickUpTime / grabTime;
            transform.position = Vector3.Lerp(transform.position, grabLocation.position, percentageComplete);

            if (Mathf.Approximately(percentageComplete, 1.0f))
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
