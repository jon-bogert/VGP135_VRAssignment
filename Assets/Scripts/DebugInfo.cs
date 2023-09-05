using UnityEngine;

public class DebugInfo : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text fps;

    // Update is called once per frame
    void Update()
    {
        fps.text = (1 / Time.unscaledDeltaTime).ToString();
    }
}
