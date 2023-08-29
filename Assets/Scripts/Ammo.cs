using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] float grabTime = 0.5f;
    [SerializeField] GameObject indicator;

    [HideInInspector]
    public PlayerAmmo pAmmo;
    Transform grabLocation;

    public bool selected;
    bool pickingUp = false;
    float pickUpTime = 0f;

    Color startColour;

    private void Start()
    {
        grabLocation = GameObject.FindGameObjectWithTag("GrabLocation").GetComponent<Transform>();
        startColour = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (selected)
        {
            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }
        
        if (pickingUp)
        {
            pickUpTime += Time.deltaTime;
            float percentageComplete = pickUpTime / grabTime;
            transform.position = Vector3.Lerp(transform.position, grabLocation.position, percentageComplete);

            if (transform.position == grabLocation.position)
            {
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
        pickingUp = false;
        pAmmo.AddAmmo(ammoAmount);
        Destroy(gameObject);
    }
}
