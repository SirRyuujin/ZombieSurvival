using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeaponUIController : MonoBehaviour
{
    [Header("Ammo")]
    public TextMeshProUGUI AmmoCounterText;
    public IntVariable CurrentAmmo;
    public IntVariable MaxAmmo;
    public FloatVariable ReloadTime;

    [Header("Reloading")]
    public Image ReloadCircle;
    public Image ReloadCircleProgress;
    public RectTransform ReloadCircleRectTransform;
    public float RotationSpeed = 200f;

    public void UpdateAmmoCounter()
    {
        AmmoCounterText.text = string.Format("{0}/{1}", CurrentAmmo.Value.ToString(), MaxAmmo.Value.ToString());
    }

    public void StartReloadAnimation()
    {
        ReloadCircle.enabled = true;
        ReloadCircle.enabled = true;
        StartCoroutine(RotationAnimationCoroutine());
    }

    private IEnumerator RotationAnimationCoroutine()
    {
        float currentTimer = 0;
        while(currentTimer < ReloadTime.Value)
        {
            currentTimer += Time.deltaTime;
            ReloadCircleRectTransform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        FinishReloadAnimation();
    }

    private void FinishReloadAnimation()
    {
        ReloadCircle.enabled = false;
        ReloadCircle.enabled = false;
    }
}