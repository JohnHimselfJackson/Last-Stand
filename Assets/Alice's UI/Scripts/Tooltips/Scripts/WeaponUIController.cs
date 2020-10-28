using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using VulpineAlice.TooltipUI;

public class WeaponUIController : MonoBehaviour
{
    private Vector3 activePos, altPos, activeScale, altScale;

    private Quaternion activeRot, altRot;

    private string weaponName;

    private float reloadSpeed, currentAmmo;

    private bool isReloading = false;

    private int rPS, totalAmmo, uiAmmo;

    [SerializeField]
    private TMP_Text ammoText;

    [SerializeField]
    private GameObject activeWeapon, altWeapon, tempWeapon;

    private void Awake()
    {
        weaponName = activeWeapon.GetComponent<TooltipButton>().item.Name;
        activePos = activeWeapon.GetComponent<RectTransform>().anchoredPosition;
        activeRot = activeWeapon.GetComponent<RectTransform>().rotation;
        activeScale = activeWeapon.GetComponent<RectTransform>().sizeDelta;
        altPos = altWeapon.GetComponent<RectTransform>().anchoredPosition;
        altRot = altWeapon.GetComponent<RectTransform>().rotation;
        altScale = altWeapon.GetComponent<RectTransform>().sizeDelta;
        if (weaponName != "Sword")
        {
            totalAmmo = activeWeapon.GetComponent<TooltipButton>().item.TotalAmmo;
            currentAmmo = totalAmmo;
            reloadSpeed = activeWeapon.GetComponent<TooltipButton>().item.ReloadSpeed;
        }
        rPS = activeWeapon.GetComponent<TooltipButton>().item.RoundsPerSecond;

        AmmoUI();
    }

    public void SwapWeapon()
    {
        StartCoroutine(SmoothMove(activePos, altPos, activeScale, altScale, activeRot, altRot,  0.2f));
        
        tempWeapon = activeWeapon;
        activeWeapon = altWeapon;
        altWeapon = tempWeapon;
        weaponName = activeWeapon.GetComponent<TooltipButton>().item.Name;
        totalAmmo = activeWeapon.GetComponent<TooltipButton>().item.TotalAmmo;
        currentAmmo = totalAmmo;
        reloadSpeed = activeWeapon.GetComponent<TooltipButton>().item.ReloadSpeed;
        rPS = activeWeapon.GetComponent<TooltipButton>().item.RoundsPerSecond;
        AmmoUI();
    }

    public void ReloadWeapon()
    {
        if(currentAmmo < totalAmmo && isReloading == false)
        {
            isReloading = true;
            Invoke("ReloadFunction", reloadSpeed);
        }
    }

    private void ReloadFunction()
    {
        currentAmmo = totalAmmo;
        AmmoUI();
        isReloading = false;
    }

    public void FireWeapon()
    {
        if(!isReloading)
        {
            currentAmmo -= rPS * Time.deltaTime;
            AmmoUI();
        }
    }

    private void AmmoUI()
    {
        uiAmmo = (int)currentAmmo;

        StringBuilder builder = new StringBuilder();

        if (uiAmmo < 1)
        {
            ReloadWeapon();
        }

        if(weaponName == "Sword")
        {
            builder.Append("Ammo: ∞");
        }
        else
        {
            builder.Append("Ammo: ").Append(uiAmmo).Append(" / ").Append(totalAmmo);
        }

        ammoText.text = builder.ToString();
    }

    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, Vector3 startScale, Vector3 endScale, Quaternion startRot, Quaternion endRot, float seconds)
    {
        float t = 0f;
        while (t <= 1)
        {
            t += Time.deltaTime / seconds;
            activeWeapon.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
            activeWeapon.GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(startScale, endScale, Mathf.SmoothStep(0, 1, t));
            activeWeapon.GetComponent<RectTransform>().rotation = Quaternion.Lerp(startRot, endRot, Mathf.SmoothStep(0, 1, t));
            altWeapon.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(endPos, startPos, Mathf.SmoothStep(0, 1, t));
            altWeapon.GetComponent<RectTransform>().sizeDelta = Vector3.Lerp(endScale, startScale, Mathf.SmoothStep(0, 1, t));
            altWeapon.GetComponent<RectTransform>().rotation = Quaternion.Lerp(endRot, startRot, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
    }

}
