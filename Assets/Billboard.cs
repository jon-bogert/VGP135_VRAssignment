using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Billboard : MonoBehaviour
{
    [SerializeField] bool _display = true;
    [SerializeField] Transform _cameraTransform;

    MeshRenderer _meshRenderer;

    public bool IsEnabled
    {
        get
        { 
            return _display;
        }
        set
        {
            _display = value;
            _meshRenderer.enabled = value;
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = _display;

        _rotationOffset = transform.localRotation;

        if (!_cameraTransform)
        {
            _cameraTransform = Camera.main.transform;
            if (!_cameraTransform) Debug.LogError("Billboard -> No Camera Transform Assigned of found");
        }
    }

    private void Update()
    {
        if (!_display)
            return;
        if (!_cameraTransform)
            return;

        transform.LookAt(_cameraTransform.position);
        transform.Rotate(Vector3.up * 180);
    }
}
