using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] float _flashTime = 0.05f;
    [SerializeField] Transform _cameraTransform;
    float _timer = 0;
    Quaternion _rotationOffset = Quaternion.identity;

    private void Awake()
    {
        _rotationOffset = transform.localRotation;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isActiveAndEnabled)
            return;

        transform.LookAt(_cameraTransform.position);
        transform.Rotate(-_rotationOffset.eulerAngles);
        transform.Rotate(Vector3.up * Random.Range(0, 360));

        if (_timer >= _flashTime)
        {
            gameObject.SetActive(false);
        }

        _timer += Time.deltaTime;
    }

    public void Dewit()
    {
        _timer = 0f;
        gameObject.SetActive(true);
    }
}
