using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashTime = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    private Coroutine _damageFlashCoroutine;
    
    //[SerializeField] private SpriteRenderer spriteRenderer;

    void Awake()
    {
        _spriteRenderers = new SpriteRenderer[1]; // arbitrarily an object could have 5 sprite renderers that need to flash
        _spriteRenderers[0] = GetComponent<SpriteRenderer>(); // in the future the player/enemies will have weapons whose sprites are children of the GO, so this will need to be modified
        //spriteRenderer = GetComponent<SpriteRenderer>();
        Init();
    }

    private void Init()
    {
        // assign the materials from the sprite renderers
        _materials = new Material[_spriteRenderers.Length];

        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }


    }

    

    private IEnumerator DamageFlasher()
    {
        // set color
        SetFlashColor();
        // lerp the flash amount
        float currentFlashAmount = 0f;
        float elapsedtime = 0f;
        while (elapsedtime < _flashTime)
        {
            // iterate elapsed time
            elapsedtime += Time.deltaTime;
            // lerp flash amount
            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedtime / _flashTime);
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
    }  

    public void CallDamageFlashCorroutine()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    } 

    private void SetFlashColor()
    {
        // set color
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_FlashColor", _flashColor);

        }
    }


    public void SetFlashAmount(float amount)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat("_flashAmount", amount);
        }
    }

}

