using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    float[] list1, list2, list3, list4, list5, list6;
    float[][] tempStatHolder;


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
        newUpgrade.SetDescription("Research into advanced materials has led to breakthoughs in metals used for armor plating.");
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
        newUpgrade.SetDescription("Due to the miniaturization of numerous part used in the production motors and improvements in overall efficiency the motors in your suit are substantially better.");
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
        newUpgrade.SetDescription("Through highly advanced R&D into star fighter systems a possibility was found to shrink the size of inertial dampeners. This has meant that the once instanteous changes in direction only possible by star fighter are now possibe for you.");
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
        newUpgrade.SetDescription("New power recycling and new hyper conductive alloys the power needed to use Impulse thrusters is now feasible.");
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
        newUpgrade.SetDescription("A combination between the new onboard super computer, inhertial dampeners and impulse thrusters mean the suit is now able to preform actions with percision down to micrometer. this combines with the threat detection system to allow the player to dodge attacks that would be impossible for anyone else.");
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
        newUpgrade.SetDescription("the itnergration of a super computer allows the suit to make hyper precise and near insant computations");
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
        newUpgrade.SetDescription("A mix of various sensor arrays and systems allows the suits onboard to calculate incoming attacks. This combined with a threat ranking allows the suit to prioritize incoming attacks and allow you to dodge more effectively ");
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
        newUpgrade.SetDescription("Improvements to sensors and the calculations of projectiles allows greater precision. its systems has also been expanded to factor in the terrain and surroundings to optimize movement patterns");
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
        newUpgrade.SetDescription("Thanks to new lightbending polymers it is possible to alter the shape and sillouhete of your armour. This increases the enemies difficult in hitting you ");
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
        newUpgrade.SetDescription("The major implementation of Ghost suit technology now allows the armor to render its wearer completely invisible to the eye");
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
        newUpgrade.SetDescription("A highly flexible and incredibly strong under layer, while it cannot compare to the stronger plate portions it instead acts to cover the weakspots and allows the user a full range of montion.");
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
        newUpgrade.SetDescription("With excessive budget increases allow the engineers to add a complete layer of controlling circuits under the armor layers. this gives the suit more precise controls as well as the ability to adapt the position of armor plates while also strengthing the user");
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
        newUpgrade.SetDescription("New mining and refinement procedures now allow the practical use or Corite in non Macro productions");
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
        newUpgrade.SetDescription("Advancements in chemistry have given the ability for more dynamic armor based off less rigid and more advanced nano weaves");
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
        newUpgrade.SetDescription("The invention of atomic printers has allowed engineers to both fabricate and work with materials once thought impossible due to their durability. This has meant that they can be now intergrated into new alloy for use in the suit");
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
        newUpgrade.SetDescription("thgrough planning of the suits subsystems combines with the creation of various subsystems vastly increase the suits durability as well as improving some of its base features");
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
        newUpgrade.SetDescription("Through  smart design and dynamic plate armor the suit gains the ability to enter a armored combat mode that allows it gain un paralleled armor");
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
        newUpgrade.SetDescription("implementation of nano repiar bots allows armor to repair without needing to travel to a repair station");
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
        newUpgrade.SetDescription("Medical gear is now fitted into the suit that allows healing in active combat situaations through the complex use of advanced medical equipment and chemicals.");
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
        newUpgrade.myType = Upgrade.type.stats;
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
        list3 = new float[] { 0, 0, 0, 0, -0.4f, 0, 1, -1, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
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
        newUpgrade.SetName("Energised Bullets");
        newUpgrade.SetDescription("Projectiles develop a front layer of plasma that increases stopping power and allows armour penertraion");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 5, 0, 0, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
        list3 = new float[] { 20, 0, 0, 0, 0, 0, 0, 0, 0 }; // sniper stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
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
        newUpgrade.SetName("Aim Assitors");
        newUpgrade.SetDescription("minature motors within the rifle massively decrease sway and recoil from the weapon as well as assiting the user to aim via sight");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 0, 0, 0, 0, 0, 0, 0, -20, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
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
        newUpgrade.SetName("Ap Rifle");
        newUpgrade.SetDescription("The introduction of cobium tipped bullet allow rifle rounds to practically ignore armour");
        newUpgrade.myType = Upgrade.type.stats;
        #region stat Changes
        list1 = new float[] { 0, 0, 0, 0, 0, 0 }; // sword stat changes : damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
        list2 = new float[] { 4, 0, 3, 0, 0, 0, 0, 0, 0 }; // rifle stat changes : damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
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

public class Ability
{
    public string Name { get; private set; }
    public string Descritption { get; private set; }
    
}
public class ActiveAbility : Ability
{
    public void InvokeToRun()
    {

    }
}
public class PassiveAbility : Ability
{
    public void AbilityFunction()
    {

    }

}