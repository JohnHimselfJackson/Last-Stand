using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    float[] list1, list2, list3, list4, list5, list6;
    float[][] tempStatHolder = new float[6][];


    public static List<Upgrade> upgradeList = new List<Upgrade>();
    // Start is called before the first frame update
    void Awake()
    {
        Upgrade newUpgrade = new Upgrade();
        newUpgrade.SetName("Empty");
        newUpgrade.SetDescription("A blank upgrade for testing purposes");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/

        #region Armor Upgrades
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Hardend Plating");
        newUpgrade.SetDescription("Improves armour strength.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 5 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 1, 1, 15 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Enhanced Motors");
        newUpgrade.SetDescription("Increases agility and suit movement.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 1, 0, 0 }; // base stat changes
        list5 = new float[] { 3, 3, 2, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Inhertial Dampeners");
        newUpgrade.SetDescription("Increase movement persicion and stopping time, while overall increase agility.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0.5f, 0, 0 }; // base stat changes
        list5 = new float[] { 5, 5, 6, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Self Sufficient Impulse Thrusters");
        newUpgrade.SetDescription("Gain access to suit mounted impulse thrusters.");
        newUpgrade.myType = Upgrade.type.multi;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 1.5f, 0, 0 }; // base stat changes
        list5 = new float[] { 7, 7, 5, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Percision Movement");
        newUpgrade.SetDescription("Massively charge the suits dodign ability.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0.5f, 0, 0 }; // base stat changes
        list5 = new float[] { 10, 10, 15, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Onboard Super Computer");
        newUpgrade.SetDescription("Improved calculation allow better projectile evasion.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0.5f, 1, 0 }; // base stat changes
        list5 = new float[] { 5, 5, 6, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Suit Overcharge");
        newUpgrade.SetDescription("TBD");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Threat Detection System");
        newUpgrade.SetDescription("Increase evasion and attack range.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 1, 0 }; // base stat changes
        list5 = new float[] { 3, 3, 1, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Advanced Threat Detection");
        newUpgrade.SetDescription("Improvements to the prior threat detection.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0.5f, 2, 0 }; // base stat changes
        list5 = new float[] { 6, 6, 5, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Optics Manipulation");
        newUpgrade.SetDescription("Your suit appears smaller, making its harder to aim at you. ");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 4, 4, 6, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Advanced Optic Manipulation");
        newUpgrade.SetDescription("");
        newUpgrade.myType = Upgrade.type.multi;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 6, 6, 6, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][]; 
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Quantumn Slip");
        newUpgrade.SetDescription("TBD");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 2, 2, 6, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Reinforced Lining");
        newUpgrade.SetDescription("A nanoweave armour to cover your suits weakspots, increases armour.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 10 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 1, 1, 10 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Adaptive Lining");
        newUpgrade.SetDescription("All-round defence increases.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 5 }; // base stat changes
        list5 = new float[] { 2, 2, 4, 1, 1, 10 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Advanced Corite Refinement");
        newUpgrade.SetDescription("Super heavy metal increase armour strength drastically");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, -1, 0, 10 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 6, 4, 40 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Adaptive Plating");
        newUpgrade.SetDescription("Dynamic armour allows all round armour increases.");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 1, 1, 4, 2, 2, 15 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Cobium Intergration");
        newUpgrade.SetDescription("Intergration of experimental metals allow massive armour increases");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 15 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 6, 2, 40 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Compartementalized Design");
        newUpgrade.SetDescription("Compartmentalization of armour components massivelt increases armour durability");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 1, 1, 5 }; // base stat changes
        list5 = new float[] { 1, 1, 2, 0, 0, 100 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Juggernaught Mode");
        newUpgrade.SetDescription("Armour plates interlock to temporaily give the suit a massive defencive increase");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 1, 1, 0 }; // base stat changes
        list5 = new float[] { 1, 1, 2, 0, 0, 100 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Regenerative Materials");
        newUpgrade.SetDescription("Allows armour to naturally repair");
        newUpgrade.myType = Upgrade.type.passive;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Built in Med Suite");
        newUpgrade.SetDescription("Built in med gear allows the player to heal.");
        newUpgrade.myType = Upgrade.type.passive;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Shield Generation");
        newUpgrade.SetDescription("Grants the suit the ability to create a temporary energy barrier around the armor.");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Projectile Eradication");
        newUpgrade.SetDescription("the batteries on the suit breifly discharge stored power to destroy any projectiles in a range around the player.");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        #endregion

        #region Weapon Upgrades
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Percission Kinetics");
        newUpgrade.SetDescription("RND and improved both the power and range of kinetics weapons \n Unlocks Sniper");
        newUpgrade.myType = Upgrade.type.multi;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 2, 0, 0, 0, 0, 0, 1, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Steady Hands");
        newUpgrade.SetDescription("Consitent practice has honed your weapon skills");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, -0.2f, 0, 0.5f, -2, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, -0.4f, 0, 1, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Advanced Manufacturing");
        newUpgrade.SetDescription("The implementation of experiemental manufaturing processes allows the creation of improved gear");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 1, 0, 0, 5, 0, -0.02f, 0.5f, -3, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 4, 0, 0, 1, 0, -0.1f, 1, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("High Energy Rounds");
        newUpgrade.SetDescription("Improvements the kinetics base fireing method has allowed an increase to energy carried by all fired projectiles");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 4, 0, 0, 0, 0, 0, 1f, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 12, 0, 0, 0, 0, 0, 2, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Enhanced Firing Mechanism");
        newUpgrade.SetDescription("better ammo feed mechanisms as well as chamber cooling allow fater firerates");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, -0.06f, 0.5f, -2, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, -0.1f, 1, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Energised Projectiles");
        newUpgrade.SetDescription("Projectiles develop a front layer of plasma that increases stopping power and allows armour penertraion");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 5, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 20, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        tempStatHolder = new float[6][]; 
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Focus Laser");
        newUpgrade.SetDescription("Allows the Firing Battery of the Sniper to instead generate a laser capable of cutting through neo-steel like paper");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes :
        tempStatHolder = new float[6][]; 
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Long Range Target Recognition");
        newUpgrade.SetDescription("Introduces long range target recognition capabilites to all weapons");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 1, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 2, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 4, 0 }; // base stat changes : HP, move speed, minimap range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        tempStatHolder = new float[6][]; 
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Aim Assistors");
        newUpgrade.SetDescription("minature motors within the rifle massively decrease sway and recoil from the weapon as well as assiting the user to aim via sight");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, -20, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("High Explosives");
        newUpgrade.SetDescription("Rifle Battery is used to generate plasma in an underbarrel launcher that can be activated for use");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Extended Magazine");
        newUpgrade.SetDescription("Modified magazines now have more ammo in them");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 15, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 4, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("AP Rifle");
        newUpgrade.SetDescription("The introduction of cobium tipped bullet allow rifle rounds to practically ignore armour");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 4, 0, 3, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Devastator Rounds");
        newUpgrade.SetDescription("Devastator rounds are the new and deadliest when it comes to experimantal weaponary");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 10, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 20, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Rapid Reload");
        newUpgrade.SetDescription("Having build up years of muscle memory you can reload your weapons ");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, -0.5f, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, -1f, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Fast Swap");
        newUpgrade.SetDescription("Muscle memory allows you to swap near instantly");
        newUpgrade.myType = Upgrade.type.passive;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Close Combat");
        newUpgrade.SetDescription("Through training in CQC you have reached a level of skill to be granted use of an energy sword ");
        newUpgrade.myType = Upgrade.type.multi;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 1, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 3, 3, 3, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Molecular Blade");
        newUpgrade.SetDescription("Use of stronger and harder materials have allowed the sharpness of the sword's blade to increase to the molecular level");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 20, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Close Quarters Expert");
        newUpgrade.SetDescription("Continued refinement of your skills has greated you even better control of the blade");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 10, 0, 0, -0.1f, -0.3f, 2 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0.5f, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 3, 3, 3, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Slay");
        newUpgrade.SetDescription("Instantly kill all unit hit with a melee attack if they are under 20% health");
        newUpgrade.myType = Upgrade.type.passive;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Energy Projection");
        newUpgrade.SetDescription("Advanced plasma control allows you to temporary extend the length of the blase through the addition of a plasma tip");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("Super Nova");
        newUpgrade.SetDescription("Super nova is a show of having perfected the sword. it allows the user to attack dozens of times a second with no need to stop. while doing so they practioner is able to slice incoming projecitles in half, negating them ");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        newUpgrade = new Upgrade();
        newUpgrade.SetName("test");
        newUpgrade.SetDescription("Super nova is a show of having perfected the sword. it allows the user to attack dozens of times a second with no need to stop. while doing so they practioner is able to slice incoming projecitles in half, negating them ");
        newUpgrade.myType = Upgrade.type.active;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 800, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list4 = new float[] { 0, 0, 0, 0 }; // base stat changes : HP, move speed, veiw range, enviromental protection
        list5 = new float[] { 0, 0, 0, 0, 0, 0 }; // defence stat changes : evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
        list6 = new float[] { 0, 0, 0, 0 }; // tran stat changes : 
        tempStatHolder = new float[6][];
        tempStatHolder[0] = list1;
        tempStatHolder[1] = list2;
        tempStatHolder[2] = list3;
        tempStatHolder[3] = list4;
        tempStatHolder[4] = list5;
        tempStatHolder[5] = list6;
        #endregion
        newUpgrade.SetStatChanges(tempStatHolder);
        newUpgrade.upgraded = false;
        upgradeList.Add(newUpgrade);
        /*------------------------------------*/
        #endregion
    }

    void Start()
    {

    }
}




public class Upgrade
{
    public bool upgraded;
    public enum type { stats, passive, active, multi }
    public type myType;
    
    public string name {get; private set;}
    public void SetName(string newName)
    {
        name = newName;
    }
    
    public string description { get; private set; }
    public void SetDescription(string newDescription)
    {
        description = newDescription;
    }

    public float[][] statChanges { get; private set; }
    public void SetStatChanges(float[][] newStatChanges)
    {
        statChanges = newStatChanges;
    }

    public ActiveAbility aA;
    public PassiveAbility pA;
}


public class Ability : MonoBehaviour
{
    public string stringName;
    public string descritption;
}
public class ActiveAbility : Ability
{
    public float cooldown;
    public float cooldownCount;
    public virtual void InvokeToRun()
    {

    }
    /// <summary>
    /// Use for grenadeLauncher, 
    /// </summary>
    /// <param name="playerT"></param>
    /// <param name="playerCam"></param>
    public virtual void InvokeToRun(Camera playerCam)
    {

    }

    private void Update()
    {
        if (cooldownCount > 0)
        {
            cooldownCount -= Time.deltaTime;
        }
    }
}
public class PassiveAbility : Ability
{
    public void AbilityFunction()
    {

    }

}