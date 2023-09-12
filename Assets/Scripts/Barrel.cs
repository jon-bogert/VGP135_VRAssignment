
using UnityEngine;

public class Barrel : Destructable
{
    [SerializeField]AudioClip _clip;
    AudioSource _source;
    MeshRenderer _meshRenderer;
    private void Start()
    {
        hasDied += OnDeath;
        _source = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnDestroy()
    {
        hasDied -= OnDeath;
    }

    void OnDeath()
    {
        _source.PlayOneShot(_clip);
        _meshRenderer.enabled = false;
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        foreach (EnemyController e in  enemies)
        {
            if (e.isActiveAndEnabled)
            {
                e.Damage(30);
            }
        }
        Destroy(gameObject, 5f);
    }
}
