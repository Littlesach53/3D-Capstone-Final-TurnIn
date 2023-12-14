using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; set; }

public Checkpoint House4Upgrade; // done
public Checkpoint House444Upgrade;//Done
public Checkpoint House2Upgrade; // done
public Checkpoint House33Upgrade;//Done
public Checkpoint House555Upgrade;
public Checkpoint WaterTower1Upgrade;//done
public Checkpoint Roads1Upgrade;//done
public Checkpoint Roads11Upgrade;//Done
public Checkpoint Roads111Upgrade;//Done
public Checkpoint Lights1Upgrade;//Done
public Checkpoint Lights11Upgrade;//Done
public Checkpoint Lights111Upgrade;//Done
public Checkpoint Church1Upgrade;// Done
public Checkpoint Church11Upgrade;//Done
public Checkpoint Church111Upgrade;//Done
public Checkpoint WindmillUpgrade;//Done
public Checkpoint market11upgrade;//Done

public Checkpoint market111upgrade;//Done
 
    [SerializeField] GameObject house1UI;
    [SerializeField] GameObject house2UI;
    [SerializeField] GameObject house3UI;
    [SerializeField] GameObject house4UI;
    [SerializeField] GameObject house5UI;
    [SerializeField] GameObject watertower1UI;
    [SerializeField] GameObject floor1UI;
    [SerializeField] GameObject lights1UI;
    [SerializeField] GameObject market1UI;
     [SerializeField] GameObject userhouse1UI;
    [SerializeField] GameObject church1UI;
    [SerializeField] GameObject windmill1UI;
     //public GameObject house4UI;
    [SerializeField] BuilingUpgrade selectedUpgradable;
    public bool upgradableUIOpen;
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
    public void OpenBox(BuilingUpgrade upgradable)
    {
        SetSelectedStorage(upgradable);
 
        GetRelevantUI(selectedUpgradable).SetActive(true);
        upgradableUIOpen = true;
 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
 
        SelectionManager.Instance.DisableSelection();
        SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
    }

 
    public void CloseBox()
    {

        GetRelevantUI(selectedUpgradable).SetActive(false);
        upgradableUIOpen = false;
 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
 
        SelectionManager.Instance.EnableSelection();
        SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
    }
 
    public void SetSelectedStorage(BuilingUpgrade upgradable)
    {
        selectedUpgradable = upgradable;
    }
 
    private GameObject GetRelevantUI(BuilingUpgrade upgradable)
    {
       switch (upgradable.thisUpgradableType)
    {
        case BuilingUpgrade.UpgradeType.house1:
            return house1UI; // replace with the UI for house1

        case BuilingUpgrade.UpgradeType.house11:
            return house1UI; // replace with the UI for house1

        case BuilingUpgrade.UpgradeType.house111:
            return house1UI; // replace with the UI for house1

        case BuilingUpgrade.UpgradeType.house2:
            return house2UI; // replace with the UI for medium boxes

            case BuilingUpgrade.UpgradeType.house22:
            return house2UI; // replace with the UI for medium boxes

            case BuilingUpgrade.UpgradeType.house222:
            return house2UI; // replace with the UI for medium boxes

        case BuilingUpgrade.UpgradeType.house3:
            return house3UI; // replace with the UI for large boxes

            case BuilingUpgrade.UpgradeType.house33:
            return house3UI; // replace with the UI for large boxes

            case BuilingUpgrade.UpgradeType.house333:
            return house3UI; // replace with the UI for large boxes

        case BuilingUpgrade.UpgradeType.house4:
        return house4UI;

        case BuilingUpgrade.UpgradeType.house44:
        return house4UI;

        case BuilingUpgrade.UpgradeType.house444:
        return house4UI;

        case BuilingUpgrade.UpgradeType.house5:
        return house5UI;

        case BuilingUpgrade.UpgradeType.house55:
        return house5UI;

        case BuilingUpgrade.UpgradeType.house555:
        return house5UI;

        case BuilingUpgrade.UpgradeType.watertower1:
        return watertower1UI;

        case BuilingUpgrade.UpgradeType.watertower11:
        return watertower1UI;

        case BuilingUpgrade.UpgradeType.watertower111:
        return watertower1UI;

        case BuilingUpgrade.UpgradeType.church1:
        return church1UI;

        case BuilingUpgrade.UpgradeType.church11:
        return church1UI;

        case BuilingUpgrade.UpgradeType.church111:
        return church1UI;

        case BuilingUpgrade.UpgradeType.market1:
        return market1UI;

         case BuilingUpgrade.UpgradeType.market11:
        return market1UI;

         case BuilingUpgrade.UpgradeType.market111:
        return market1UI;

         case BuilingUpgrade.UpgradeType.lights1:
        return lights1UI;

         case BuilingUpgrade.UpgradeType.lights11:
        return lights1UI;

         case BuilingUpgrade.UpgradeType.lights111:
        return lights1UI;

        case BuilingUpgrade.UpgradeType.floor1:
        return floor1UI;

        case BuilingUpgrade.UpgradeType.floor11:
        return floor1UI;

        case BuilingUpgrade.UpgradeType.floor111:
        return floor1UI;

        case BuilingUpgrade.UpgradeType.userhouse1:
        return userhouse1UI;

        case BuilingUpgrade.UpgradeType.userhouse11:
        return userhouse1UI;

        case BuilingUpgrade.UpgradeType.userhouse111:
        return userhouse1UI;

        case BuilingUpgrade.UpgradeType.windmill1:
        return windmill1UI;

        default:
            return null; // replace with a default UI or handle the default case accordingly
    }
    }

    public void Upgrade(string itemName)
    { 
    
       if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house1)
        {
GameObject parentObject = GameObject.Find("House1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}



      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house11)
        {
GameObject parentObject = GameObject.Find("House11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house111)
        {
GameObject parentObject = GameObject.Find("House111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house2)
        {
GameObject parentObject = GameObject.Find("House2");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
House2Upgrade.isCompleted = true;
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house22)
        {
GameObject parentObject = GameObject.Find("House22");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house222)
        {
GameObject parentObject = GameObject.Find("House222");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house3)
        {
GameObject parentObject = GameObject.Find("House3");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house33)
        {
GameObject parentObject = GameObject.Find("House33");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
House33Upgrade.isCompleted = true;
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house333)
        {
GameObject parentObject = GameObject.Find("House333");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house4)
        {
GameObject parentObject = GameObject.Find("House4");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
House4Upgrade.isCompleted = true;
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house44)
        {
GameObject parentObject = GameObject.Find("House44");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house444)
        {
GameObject parentObject = GameObject.Find("House444");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
House444Upgrade.isCompleted = true;
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house5)
        {
GameObject parentObject = GameObject.Find("House5");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}
      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house55)
        {
GameObject parentObject = GameObject.Find("House55");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

      if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.house555)
        {
GameObject parentObject = GameObject.Find("House555");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
House555Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.watertower1)
        {
GameObject parentObject = GameObject.Find("Watertower1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
WaterTower1Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.watertower11)
        {
GameObject parentObject = GameObject.Find("Watertower11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.watertower111)
        {
GameObject parentObject = GameObject.Find("Watertower111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.church1)
        {
GameObject parentObject = GameObject.Find("Church1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Church1Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.church11)
        {
GameObject parentObject = GameObject.Find("Church11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Church11Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.church111)
        {
GameObject parentObject = GameObject.Find("Church111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Church111Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.windmill1)
        {
GameObject parentObject = GameObject.Find("Windmill1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
WindmillUpgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.lights1)
        {
GameObject parentObject = GameObject.Find("Lights1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Lights1Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.lights11)
        {
GameObject parentObject = GameObject.Find("Lights11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Lights11Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.lights111)
        {
GameObject parentObject = GameObject.Find("Lights111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Lights111Upgrade.isCompleted =true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.floor1)
        {
GameObject parentObject = GameObject.Find("Floor1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Roads1Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.floor11)
        {
GameObject parentObject = GameObject.Find("Floor11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Roads11Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.floor111)
        {
GameObject parentObject = GameObject.Find("Floor111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
Roads111Upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.market1)
        {
GameObject parentObject = GameObject.Find("Market1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.market11)
        {
GameObject parentObject = GameObject.Find("Market11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
market11upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.market111)
        {
GameObject parentObject = GameObject.Find("Market111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
market111upgrade.isCompleted = true;
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.userhouse1)
        {
GameObject parentObject = GameObject.Find("UserHouse1");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.userhouse11)
        {
GameObject parentObject = GameObject.Find("UserHouse11");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}

     if (selectedUpgradable != null && selectedUpgradable.thisUpgradableType == BuilingUpgrade.UpgradeType.userhouse111)
        {
GameObject parentObject = GameObject.Find("UserHouse111");
  BoxCollider boxCollider = parentObject.transform.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
foreach (Transform childTransform in parentObject.transform)
{
    if (childTransform.GetSiblingIndex() == 0)
    {
        childTransform.gameObject.SetActive(false);
    }
    else
    {
        childTransform.gameObject.SetActive(true);
        CloseBox();
    }
}
}
}
}


