using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonManager))]
public class ButtonManagerEditor : Editor
{
    private void OnSceneGUI()
    {
        ButtonManager bm = target as ButtonManager;
        // gets all buttons
        UpgradeLogic[] buttons = bm.FindButtons();

        //either make buttons selectable or make buttons able to be set as dependents
        if(bm.buttonSelected == null)
        {
            Handles.color = bm.standradColor;
            foreach(UpgradeLogic ui in buttons)
            {
                if(Handles.Button(ui.transform.position + Vector3.up* 0.8f, ui.transform.rotation, 0.5f, 0.5f, Handles.CubeHandleCap))
                {
                    bm.buttonSelected = ui;
                }
            }
        }
        else
        {
            foreach (UpgradeLogic ui in buttons)
            {
                if(ui == bm.buttonSelected)
                {
                    Handles.color = Color.blue;
                    if (Handles.Button(ui.transform.position + Vector3.up * 0.8f, ui.transform.rotation, 0.5f, 0.5f, Handles.CubeHandleCap))
                    {
                        bm.buttonSelected = null;
                    }
                }
                else
                {
                    Handles.color = bm.standradColor;
                    if (Handles.Button(ui.transform.position + Vector3.up * 0.8f, ui.transform.rotation, 0.5f, 0.5f, Handles.CubeHandleCap))
                    {
                        UpgradeLogic[] temp = new UpgradeLogic[ui.prereq.Length + 1];
                        for(int tt = 0; tt < ui.prereq.Length; tt++)
                        {
                            temp[tt] = ui.prereq[tt];
                        }
                        temp[ui.prereq.Length] = bm.buttonSelected;
                        ui.prereq = temp;
                    }
                }
            }
        }

        // create clear prereq button
        foreach (UpgradeLogic ui in buttons)
        {
            Handles.color = Color.red;
            if (Handles.Button(ui.transform.position + Vector3.up * 0.8f + Vector3.right * 1, ui.transform.rotation, 0.5f, 0.5f, Handles.CubeHandleCap))
            {
                ui.prereq = new UpgradeLogic[0];
            }
        }
        //and or button
        foreach (UpgradeLogic ui in buttons)
        {
            Handles.color = Color.yellow;
            if (ui.and)
            {
                if (Handles.Button(ui.transform.position + Vector3.up * 0.8f + -Vector3.right * 1, ui.transform.rotation * Quaternion.Euler(-90,0,0), 0.5f, 0.5f, Handles.ConeHandleCap))
                {
                    ui.and = !ui.and;
                }    
            }
            else
            {
                if (Handles.Button(ui.transform.position + Vector3.up * 0.8f - Vector3.right * 1, ui.transform.rotation, 0.5f, 0.5f, Handles.SphereHandleCap))
                {
                    ui.and = !ui.and;
                }

            }

        }
        foreach (UpgradeLogic ui in buttons)
        {
            EditorUtility.SetDirty(ui);
        }
    }
}
