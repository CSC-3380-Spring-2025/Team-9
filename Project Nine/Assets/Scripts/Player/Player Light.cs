using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light2D playerLight;

    private float defaultInner = 2.5f;
    private float defaultOuter = 7f;

    private float newInner = 5f;
    private float newOuter = 9f;

    private bool isLightExpanded = false;

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLight();
        }   
    }

    private void ToggleLight()
    {
        if (playerLight == null)
        {
            Debug.LogWarning("Player Light2D not assigned.");
            return;
        }

        if (!isLightExpanded)
        {
            playerLight.pointLightInnerRadius = newInner;
            playerLight.pointLightOuterRadius = newOuter;
        }
        else
        {
            playerLight.pointLightInnerRadius = defaultInner;
            playerLight.pointLightOuterRadius = defaultOuter;
        }

        isLightExpanded = !isLightExpanded;
    }
}
