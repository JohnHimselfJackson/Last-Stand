using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VulpineAlice.TooltipUI
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Image[] abilities;

        [SerializeField]
        private WeaponUIController weaponController;

        [SerializeField]
        private float[] cooldownTime, baseTime;

        private void Update()
        {
            InputCheck();
            uiUpdater();
        }

        private void InputCheck()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && cooldownTime[0] <= 0)
            {
                //cast ability
                cooldownTime[0] = baseTime[0];
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2) && cooldownTime[1] <= 0)
            {
                //cast ability
                cooldownTime[1] = baseTime[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && cooldownTime[2] <= 0)
            {
                //cast ability
                cooldownTime[2] = baseTime[2];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && cooldownTime[3] <= 0)
            {
                //cast ability
                cooldownTime[3] = baseTime[3];
            }
            else if(Input.GetKeyDown(KeyCode.Tab))
            {
                weaponController.SwapWeapon();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                weaponController.ReloadWeapon();
            }
            else if(Input.GetKey(KeyCode.Mouse0))
            {
                weaponController.FireWeapon();
            }
            else
            {
                for(int i = 0; i < cooldownTime.Length; i++)
                {
                    cooldownTime[i] -= Time.deltaTime;
                    if (cooldownTime[i] <= 0)
                    {
                        cooldownTime[i] = 0;
                    }
                }
            }
        }

        private void uiUpdater()
        {
            for(int i = 0; i < cooldownTime.Length; i++)
            {
                if(cooldownTime[i] > 0)
                {
                    abilities[i].fillAmount = cooldownTime[i] / baseTime[i];
                }
                else
                {
                    abilities[i].fillAmount = 0;
                }
            }
        }
    }
}
