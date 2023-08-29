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

    Color highlightColour;

    private void Start()
    {
        grabLocation = GameObject.FindGameObjectWithTag("GrabLocation").GetComponent<Transform>();
        highlightColour = new Color(40, 40, 40);
    }

    void Update()
    {
        if (selected)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            GetComponent<Renderer>().material.SetColor("_EmissionColor", highlightColour);
        }
        else
        {
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
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
