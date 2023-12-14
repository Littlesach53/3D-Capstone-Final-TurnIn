using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class CraftingSystem : MonoBehaviour
{
public GameObject craftingScreenUI;
public GameObject toolsCatagoryScreenUI;
public GameObject materialsCatagoryScreenUI;
public GameObject materialsCatagoryScreen2UI;
public GameObject weaponsCatagoryScreenUI;
public GameObject furnitureCatagoryScreenUI;
public GameObject furnitureCatagoryScreen2UI;
public GameObject furnitureCatagoryScreen3UI;
public GameObject furnitureCatagoryScreen4UI;
public GameObject house1UI;
public GameObject house2UI;
public GameObject house3UI;
public GameObject house4UI;
public GameObject house5UI;
public GameObject watertower1UI;
public GameObject floor1UI;
public GameObject lights1UI;
public GameObject market1UI;
public GameObject userhouse1UI;
public GameObject church1UI;
public GameObject windmill1UI;



public List<string> inventoryitemList = new List<string>();

public bool isOpen;

// Catagory Buttons
Button toolsBTN, materialsBTN, materials2BTN, craftingScreenBTN, weaponsBTN, furnitureBTN, furniture2BTN, furniture3BTN, furniture4BTN;

// Craft Buttons
Button craftAxeLv1BTN, craftPickAxeLv1BTN, craftKnifeLv1BTN, craftTorchBTN, craftHammerLv1BTN, craftHoeLv1BTN, craftWoodPlankBTN,
craftRopeBTN, craftBandageBTN, craftFabricBTN, craftStringBTN, craftFuelBTN, craftNailsBTN, craftGlueBTN, craftStoneBlocksBTN,
craftBatteriesBTN, craftIronBeamsBTN, craftCampFireBTN, craftWoodAshBTN, craftSwordLv1BTN, craftSpearLv1BTN, 
craftWarAxeLv1BTN, craftWarHammerLv1BTN, craftClubLv1BTN, craftShieldLv1BTN, craftLockBTN, craftCouchBTN, craftCouchType2BTN, 
craftBedBTN, craftBedType2BTN, craftBookShelfBTN, craftBookShelfType2BTN, craftNightStandBTN, craftNightStandType2BTN, craftLampBTN, craftLampType2BTN, craftLampType3BTN, craftTableBTN, craftTableType2BTN, craftTableType3BTN, craftChairBTN,
craftChairType2BTN, craftStorageBoxSmallBTN, craftStorageBoxMediumBTN, craftStorageBoxLargeBTN, craftSinkBTN, craftWasherBTN, craftTVBTN, craftFridgeBTN;

Button upgradehouse1BTN, upgradehouse2BTN, upgradehouse3BTN, upgradehouse11BTN, upgradehouse111BTN, upgradehouse22BTN, upgradehouse222BTN, upgradehouse33BTN, upgradehouse333BTN, 
upgradehouse4BTN, upgradehouse44BTN, upgradehouse444BTN, upgradehouse5BTN, upgradehouse55BTN, upgradehouse555BTN, upgradechurch1BTN, upgradechurch11BTN, upgradechurch111BTN, upgradefloor1BTN,
upgradefloor11BTN, upgradefloor111BTN, upgradelights1BTN, upgradelights11BTN, upgradelights111BTN, upgradeuserhouse1BTN, upgradeuserhouse11BTN, upgradeuserhouse111BTN, upgrademarket1BTN, upgrademarket11BTN,
upgrademarket111BTN, upgradewatertower1BTN, upgradewatertower11BTN, upgradewatertower111BTN, upgradewindmill1BTN;

TextMeshProUGUI house1Req1, house1Req2, house1Req3, house11Req1, house11Req2, house11Req3, house111Req1, house111Req2, house111Req3, house2Req1, house2Req2, house2Req3, house22Req1, house22Req2, house22Req3,
house222Req1, house222Req2, house222Req3,house3Req1, house3Req2, house3Req3, house33Req1, house33Req2, house33Req3, house333Req1, house333Req2, house333Req3, house4Req1, house4Req2, house4Req3,
house44Req1, house44Req2, house44Req3, house444Req1, house444Req2, house444Req3, house5Req1, house5Req2, house5Req3, house55Req1, house55Req2, house55Req3, house555Req1, house555Req2, house555Req3,
lights1Req1, lights1Req2, lights1Req3, lights11Req1, lights11Req2, lights11Req3, lights111Req1, lights111Req2, lights111Req3, floor1Req1, floor1Req2, floor1Req3, floor11Req1, floor11Req2, floor11Req3, floor111Req1, floor111Req2, floor111Req3,
market1Req1, market1Req2, market1Req3, market11Req1, market11Req2, market11Req3, market111Req1, market111Req2, market111Req3, watertower1Req1, watertower1Req2, watertower1Req3,
watertower11Req1, watertower11Req2, watertower11Req3, watertower111Req1, watertower111Req2, watertower111Req3, userhouse1Req1, userhouse1Req2, userhouse1Req3, userhouse11Req1, userhouse11Req2, userhouse11Req3,
userhouse111Req1, userhouse111Req2, userhouse111Req3, church1Req1, church1Req2, church1Req3, church11Req1, church11Req2, church11Req3, church111Req1, church111Req2, church111Req3,
windmill1Req1, windmill1Req2, windmill1Req3;

// Reqirerment Text 
TextMeshProUGUI AxeLv1Req1, AxeLv1Req2, PickAxeLv1Req1, PickAxeLv1Req2, KnifeLv1Req1, KnifeLv1Req2, TorchReq1, TorchReq2, HammerLv1Req1, HammerLv1Req2, HoeLv1Req1, HoeLv1Req2,
WoodPlankReq1, FuelReq1, FuelReq2, FabricReq1, FabricReq2, StringReq1, BandageReq1, BandageReq2, RopeReq1, NailsReq1, GlueReq1, GlueReq2, StoneBlocksReq1, CampFireReq1, CampFireReq2,
IronBeamsReq1, BatteriesReq1, WoodAshReq1, SwordLv1Req1, SwordLv1Req2, SpearLv1Req1, SpearLv1Req2, WarAxeLv1Req1, WarAxeLv1Req2, WarHammerLv1Req1, WarHammerLv1Req2, 
ClubLv1Req1, ShieldLv1Req1, ShieldLv1Req2, LockReq1, StorageBoxSmallReq1, StorageBoxSmallReq2, StorageBoxMediumReq1, StorageBoxMediumReq2, StorageBoxLargeReq1,
StorageBoxLargeReq2, ChairReq1, ChairReq2, ChairType2Req1, ChairType2Req2, LampReq1, LampReq2, LampType2Req1, LampType2Req2, LampType3Req1, LampType3Req2,
TableReq1, TableReq2, TableType2Req1, TableType2Req2, TableType3Req1, TableType3Req2, NightStandReq1, NightStandReq2, NightStandType2Req1, NightStandType2Req2,
BedReq1, BedReq2, BedReq3, BedType2Req1, BedType2Req2, BedType2Req3, BookShelfReq1, BookShelfReq2, BookShelfType2Req1, BookShelfType2Req2, CouchReq1, CouchReq2, CouchType2Req1,
CouchType2Req2, FridgeReq1, FridgeReq2, SinkReq1, SinkReq2, WasherReq1, WasherReq2, TVReq1, TVReq2;

//All BluePrints
public Blueprint AxeLv1BLP = new Blueprint("AxeLv1", 2, "Rock", 2, "Stick", 2, "" ,0);
public Blueprint PickAxeLv1BLP = new Blueprint("PickAxeLv1", 2, "Rock", 3, "Stick", 2, "" ,0);
public Blueprint KnifeLv1BLP = new Blueprint("KnifeLv1", 2, "Rock", 1, "Stick", 1, "" ,0);
public Blueprint TorchBLP = new Blueprint("Torch", 2, "Cloth", 2, "Stick", 2, "" ,0);
public Blueprint HammerLv1BLP = new Blueprint("HammerLv1", 2, "Rock", 3, "Stick", 2, "" ,0);
public Blueprint HoeLv1BLP = new Blueprint("HoeLv1", 2, "Rock", 2, "Stick", 1, "" ,0);
public Blueprint WoodPlankBLP = new Blueprint("WoodPlank", 1, "Log", 1, "Log", 0, "" ,0);
public Blueprint FuelBLP = new Blueprint("Fuel", 2, "Coal", 3, "Sticks", 2, "" ,0);
public Blueprint FabricBLP = new Blueprint("Fabric", 2, "Cloth", 1, "String", 2, "" ,0);
public Blueprint StringBLP = new Blueprint("String", 1, "Cloth", 1, "Cloth", 0, "" ,0);
public Blueprint RopeBLP = new Blueprint("Rope", 2, "String", 3, "String", 0, "" ,0);
public Blueprint BandageBLP = new Blueprint("Bandage", 2, "Cloth", 2, "WoodAsh", 2, "" ,0);
public Blueprint NailsBLP = new Blueprint("Nails", 1, "Iron", 1, "Iron", 0, "" ,0);
public Blueprint GlueBLP = new Blueprint("Glue", 2, "Wood Ash", 2, "Polymer", 2, "" ,0);
public Blueprint StoneBlocksBLP = new Blueprint("Stone Blocks", 1, "Stone Ore", 1, "", 0, "" ,0);
public Blueprint IronBeamsBLP = new Blueprint("Iron Beams", 1, "Iron Ingot", 1, "", 0, "" ,0);
public Blueprint BatteriesBLP = new Blueprint("Batteries", 1, "Components", 3, "", 0, "" ,0);
public Blueprint WoodAshBLP = new Blueprint("WoodAsh", 1, "Log", 1, "", 0, "" ,0);
public Blueprint LockBLP = new Blueprint("Lock", 1,  "Iron Ingot", 3, "", 0, "", 0);
// Weapons Blueprints
public Blueprint SwordLv1BLP = new Blueprint("SwordLv1", 2, "Iron Ingot", 3, "WoodPlank", 1, "" ,0);
public Blueprint SpearLv1BLP = new Blueprint("SpearLv1", 2, "Iron Ingot", 1, "Log", 1, "" ,0);
public Blueprint WarAxeLv1BLP = new Blueprint("WarAxeLv1", 2, "Iron Ingot", 2, "Log", 1, "" ,0);
public Blueprint WarHammerLv1BLP = new Blueprint("WarHammerLv1", 2, "Iron Ingot", 3, "Log", 1, "" ,0);
public Blueprint ClubLv1BLP = new Blueprint("ClubLv1", 1, "Log", 1, "", 0, "" ,0);
public Blueprint ShieldLv1BLP = new Blueprint("ShieldLv1", 2, "WoodPlank", 2, "Iron Ingot", 1, "" ,0);

// Furniture BluePrints
public Blueprint StorageBoxSmallBLP = new Blueprint("StorageBoxSmall", 2, "Lock", 1, "WoodPlank", 3, "" ,0);
public Blueprint StorageBoxMediumBLP = new Blueprint("StorageBoxMedium", 2, "Lock", 3, "WoodPlank", 5, "" ,0);
public Blueprint StorageBoxLargeBLP = new Blueprint("StorageBoxLarge", 2, "Lock", 5, "WoodPlank", 7, "" ,0);

public Blueprint CampFireBLP = new Blueprint("CampFire", 2, "Rock", 3, "Stick", 3, "" ,0);
public Blueprint ChairBLP = new Blueprint("Chair", 2, "WoodPlank", 3, "Nails", 2, "" ,0);
public Blueprint ChairType2BLP = new Blueprint("ChairType2", 2, "WoodPlank", 3, "Fabric", 3, "" ,0);

public Blueprint LampBLP = new Blueprint("Lamp", 2, "IronBeams", 2, "Batteries", 2, "" ,0);
public Blueprint LampType2BLP = new Blueprint("LampType2", 2, "IronBeams", 2, "Batteries", 2, "" ,0);
public Blueprint LampType3BLP = new Blueprint("LampType3", 2, "IronBeams", 1, "Batteries", 1, "" ,0);
public Blueprint TableBLP = new Blueprint("Table", 2, "WoodPlank", 3, "Nails", 3, "" ,0);
public Blueprint TableType2BLP = new Blueprint("TableType2", 2, "WoodPlank", 4, "Nails", 3, "" ,0);
public Blueprint TableType3BLP = new Blueprint("TableType3", 2, "WoodPlank", 4, "Nails", 3, "" ,0);
public Blueprint NightStandBLP = new Blueprint("NightStand", 2, "WoodPlank", 2, "Glue", 2, "" ,0);
public Blueprint NightStandType2BLP = new Blueprint("NightStandType2", 2, "WoodPlank", 3, "Glue", 2, "" ,0);
public Blueprint BedBLP = new Blueprint("Bed", 3, "WoodPlank", 3, "Fabric", 3, "Nails" ,2);
public Blueprint BedType2BLP = new Blueprint("BedType2", 3, "WoodPlank", 3, "Fabric", 3, "Nails" ,3);
public Blueprint BookShelfBLP = new Blueprint("BookShelf", 2, "WoodPlank", 4, "Nails", 3, "" ,0);
public Blueprint BookShelfType2BLP = new Blueprint("BookShelfType2", 2, "WoodPlank", 4, "Nails", 3, "" ,0);
public Blueprint CouchBLP = new Blueprint("Couch", 2, "Fabric", 3, "Glue", 3, "" ,0);
public Blueprint CouchType2BLP = new Blueprint("CouchType2", 2, "Fabric", 4, "Glue", 4, "" ,0);
public Blueprint SinkBLP = new Blueprint("Sink", 2, "Iron Beams", 2, "Nails", 3, "" ,0);
public Blueprint WasherBLP = new Blueprint("Washer", 2, "Components", 3, "Iron Beams", 3, "" ,0);
public Blueprint FridgeBLP = new Blueprint("Fridge", 2, "Iron Beams", 2, "Batteries", 3, "" ,0);
public Blueprint TVBLP = new Blueprint("TV", 2, "Components", 3, "Polymer", 3, "" ,0);

//upgrades

public Blueprint House1UpgradeBLP = new Blueprint("House1", 3, "Log", 5, "Nails", 5, "Iron Beams", 5);
public Blueprint House11UpgradeBLP = new Blueprint("House11", 3, "Log", 5, "Nails", 5, "Iron Beams", 5);
public Blueprint House111UpgradeBLP = new Blueprint("House111", 3, "Log", 5, "Nails", 5, "Iron Beams", 5);
public Blueprint House2UpgradeBLP = new Blueprint("House2", 3, "WoodPlank", 8, "Nails", 5, "Iron Beams", 6);
public Blueprint House22UpgradeBLP = new Blueprint("House22", 3, "WoodPlank", 8, "Nails", 5, "Iron Beams", 6);
public Blueprint House222UpgradeBLP = new Blueprint("House222", 3, "WoodPlank", 8, "Nails", 5, "Iron Beams", 6);
public Blueprint House3UpgradeBLP = new Blueprint("House3", 3, "Log", 7, "Nails", 7, "Iron Beams", 7);
public Blueprint House33UpgradeBLP = new Blueprint("House33", 3, "Log", 7, "Nails", 7, "Iron Beams", 7);
public Blueprint House333UpgradeBLP = new Blueprint("House333", 3, "Log", 7, "Nails", 7, "Iron Beams", 7);
public Blueprint House4UpgradeBLP = new Blueprint("House4", 3, "Log", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint House44UpgradeBLP = new Blueprint("House44", 3, "Log", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint House444UpgradeBLP = new Blueprint("House444", 3, "Log", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint House5UpgradeBLP = new Blueprint("House5", 3, "WoodPlank", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint House55UpgradeBLP = new Blueprint("House55", 3, "WoodPlank", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint House555UpgradeBLP = new Blueprint("House555", 3, "WoodPlank", 7, "Glue", 5, "Iron Beams", 7);
public Blueprint Church1UpgradeBLP = new Blueprint("Church1", 3, "Nails", 7, "Fabric", 5, "Iron Beams", 7);
public Blueprint Church11UpgradeBLP = new Blueprint("Church11", 3, "Nails", 7, "Fabric", 5, "Iron Beams", 7);
public Blueprint Church111UpgradeBLP = new Blueprint("Church111", 3, "Nails", 7, "Fabric", 5, "Iron Beams", 7);
public Blueprint Lights1UpgradeBLP = new Blueprint("Lights1", 3, "Nails", 7, "Fuel", 7, "Log", 7);
public Blueprint Lights11UpgradeBLP = new Blueprint("Lights11", 3, "Nails", 7, "Fuel", 7, "Log", 7);
public Blueprint Lights111UpgradeBLP = new Blueprint("Lights111", 3, "Nails", 7, "Fuel", 7, "Log", 7);
public Blueprint Floor1UpgradeBLP = new Blueprint("Floor1", 2, "Nails", 10, "WoodPlank", 10, "", 0);
public Blueprint Floor11UpgradeBLP = new Blueprint("Floor11", 2, "Nails", 10, "WoodPlank", 10, "", 0);
public Blueprint Floor111UpgradeBLP = new Blueprint("Floor111", 2, "Nails", 10, "WoodPlank", 10, "", 0);
public Blueprint Market1UpgradeBLP = new Blueprint("Market1", 3, "Gold Ingot", 10, "Emerald Ingot", 6, "Iron Ingot", 6);
public Blueprint Market11UpgradeBLP = new Blueprint("Market11", 3, "Gold Ingot", 10, "Emerald Ingot", 6, "Iron Ingot", 6);
public Blueprint Market111UpgradeBLP = new Blueprint("Market111", 3, "Gold Ingot", 10, "Emerald Ingot", 6, "Iron Ingot", 6);
public Blueprint UserHouse1UpgradeBLP = new Blueprint("UserHouse1", 3, "Gold Ingot", 5, "Components", 3, "Iron Ingot", 5);
public Blueprint UserHouse11UpgradeBLP = new Blueprint("UserHouse11", 3, "Gold Ingot", 5, "Components", 3, "Iron Ingot", 5);
public Blueprint UserHouse111UpgradeBLP = new Blueprint("UserHouse111", 3, "Gold Ingot", 5, "Components", 3, "Iron Ingot", 5);
public Blueprint WaterTower1UpgradeBLP = new Blueprint("WaterTower1", 3, "Log", 5, "Nails", 5, "Water", 8);
public Blueprint WaterTower11UpgradeBLP = new Blueprint("WaterTower11", 3, "Log", 5, "Nails", 5, "Water", 8);
public Blueprint WaterTower111UpgradeBLP = new Blueprint("WaterTower111", 3, "Log", 5, "Nails", 5, "Water", 8);
public Blueprint Windmill1UpgradeBLP = new Blueprint("Windmill1", 3, "Log", 5, "Nails", 5, "Iron Beams", 6);


        public static CraftingSystem Instance {get; set;}
    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
  
     void Start()
    {
    isOpen = false;
// crafting screen butttons from other ui areas 
    craftingScreenBTN = materialsCatagoryScreenUI.transform.Find("ButtonHome").GetComponent<Button>();
    craftingScreenBTN.onClick.AddListener(delegate{OpenCraftingScreen();});
    craftingScreenBTN = toolsCatagoryScreenUI.transform.Find("ButtonHome").GetComponent<Button>();
    craftingScreenBTN.onClick.AddListener(delegate{OpenCraftingScreen();});
    craftingScreenBTN = weaponsCatagoryScreenUI.transform.Find("ButtonHome").GetComponent<Button>();
    craftingScreenBTN.onClick.AddListener(delegate{OpenCraftingScreen();});
    craftingScreenBTN = furnitureCatagoryScreenUI.transform.Find("ButtonHome").GetComponent<Button>();
    craftingScreenBTN.onClick.AddListener(delegate{OpenCraftingScreen();});

//Tool Screen 1 Buttons 
    toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
    toolsBTN.onClick.AddListener(delegate{OpenToolsCatagory();});

// Material Screen 1 Buttons 
    materialsBTN = craftingScreenUI.transform.Find("MaterialsButton").GetComponent<Button>();
    materialsBTN.onClick.AddListener(delegate{OpenMaterialsCatagory();});
    materialsBTN = materialsCatagoryScreen2UI.transform.Find("ButtonBack").GetComponent<Button>();
    materialsBTN.onClick.AddListener(delegate{OpenMaterialsCatagory();});

//Materials Screen 2 Buttons
    materials2BTN = materialsCatagoryScreenUI.transform.Find("ButtonNext").GetComponent<Button>();
    materials2BTN.onClick.AddListener(delegate{OpenMaterialsCatagory2();});

// Weapons Screen 1 Buttons 
    weaponsBTN = craftingScreenUI.transform.transform.Find("WeaponsButton").GetComponent<Button>();
    weaponsBTN.onClick.AddListener(delegate{OpenWeaponCatagory();});

    // Furniture Screen 1 Buttons 
    furnitureBTN = craftingScreenUI.transform.transform.Find("FurnitureButton").GetComponent<Button>();
    furnitureBTN.onClick.AddListener(delegate{OpenFurnitureCatagory();});
    furnitureBTN = furnitureCatagoryScreen2UI.transform.Find("ButtonBack").GetComponent<Button>();
    furnitureBTN.onClick.AddListener(delegate{OpenFurnitureCatagory();});

    //Furniture Screen 2 Button
    furniture2BTN = furnitureCatagoryScreenUI.transform.Find("ButtonNext").GetComponent<Button>();
    furniture2BTN.onClick.AddListener(delegate{OpenFurnitureCatagory2();});
    furniture2BTN = furnitureCatagoryScreen3UI.transform.Find("ButtonBack").GetComponent<Button>();
    furniture2BTN.onClick.AddListener(delegate{OpenFurnitureCatagory2();});

    // Furniture Screen 3 Button
    furniture3BTN = furnitureCatagoryScreen2UI.transform.Find("ButtonNext").GetComponent<Button>();
    furniture3BTN.onClick.AddListener(delegate{OpenFurnitureCatagory3();});
    furniture3BTN = furnitureCatagoryScreen4UI.transform.Find("ButtonBack").GetComponent<Button>();
    furniture3BTN.onClick.AddListener(delegate{OpenFurnitureCatagory3();});

    // Furniture Screen 4 Butons
    furniture4BTN = furnitureCatagoryScreen3UI.transform.Find("ButtonNext").GetComponent<Button>();
    furniture4BTN.onClick.AddListener(delegate{OpenFurnitureCatagory4();});
  
        //Axe
    AxeLv1Req1 = toolsCatagoryScreenUI.transform.Find("AxeLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    AxeLv1Req2 = toolsCatagoryScreenUI.transform.Find("AxeLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftAxeLv1BTN = toolsCatagoryScreenUI.transform.Find("AxeLv1").transform.Find("Button").GetComponent<Button>();
    craftAxeLv1BTN.onClick.AddListener(delegate{CraftAnyItem(AxeLv1BLP);});

    //PickAxe
    PickAxeLv1Req1 = toolsCatagoryScreenUI.transform.Find("PickAxeLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    PickAxeLv1Req2 = toolsCatagoryScreenUI.transform.Find("PickAxeLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftPickAxeLv1BTN = toolsCatagoryScreenUI.transform.Find("PickAxeLv1").transform.Find("Button").GetComponent<Button>();
    craftPickAxeLv1BTN.onClick.AddListener(delegate{CraftAnyItem(PickAxeLv1BLP);});

    //Knife
    KnifeLv1Req1 = toolsCatagoryScreenUI.transform.Find("KnifeLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    KnifeLv1Req2 = toolsCatagoryScreenUI.transform.Find("KnifeLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftKnifeLv1BTN = toolsCatagoryScreenUI.transform.Find("KnifeLv1").transform.Find("Button").GetComponent<Button>();
    craftKnifeLv1BTN.onClick.AddListener(delegate{CraftAnyItem(KnifeLv1BLP);});

    //Torch
    TorchReq1 = toolsCatagoryScreenUI.transform.Find("Torch").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    TorchReq2 = toolsCatagoryScreenUI.transform.Find("Torch").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftTorchBTN = toolsCatagoryScreenUI.transform.Find("Torch").transform.Find("Button").GetComponent<Button>();
    craftTorchBTN.onClick.AddListener(delegate{CraftAnyItem(TorchBLP);});

    //Hammer
    HammerLv1Req1 = toolsCatagoryScreenUI.transform.Find("HammerLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    HammerLv1Req2 = toolsCatagoryScreenUI.transform.Find("HammerLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftHammerLv1BTN = toolsCatagoryScreenUI.transform.Find("HammerLv1").transform.Find("Button").GetComponent<Button>();
    craftHammerLv1BTN.onClick.AddListener(delegate{CraftAnyItem(HammerLv1BLP);});

    //Hoe
    HoeLv1Req1 = toolsCatagoryScreenUI.transform.Find("HoeLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    HoeLv1Req2 = toolsCatagoryScreenUI.transform.Find("HoeLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftHoeLv1BTN = toolsCatagoryScreenUI.transform.Find("HoeLv1").transform.Find("Button").GetComponent<Button>();
    craftHoeLv1BTN.onClick.AddListener(delegate{CraftAnyItem(HoeLv1BLP);});

    //WoodPlank
    WoodPlankReq1 = materialsCatagoryScreenUI.transform.Find("WoodPlank").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftWoodPlankBTN = materialsCatagoryScreenUI.transform.Find("WoodPlank").transform.Find("Button").GetComponent<Button>();
    craftWoodPlankBTN.onClick.AddListener(delegate{CraftAnyItem(WoodPlankBLP);});
    craftWoodPlankBTN.onClick.AddListener(delegate{CraftAnyItem(WoodPlankBLP);});

    // Fuel
     FuelReq1 = materialsCatagoryScreenUI.transform.Find("Fuel").transform.Find("req1").GetComponent<TextMeshProUGUI>();
     FuelReq2 = materialsCatagoryScreenUI.transform.Find("Fuel").transform.Find("req2").GetComponent<TextMeshProUGUI>();
     
    craftFuelBTN = materialsCatagoryScreenUI.transform.Find("Fuel").transform.Find("Button").GetComponent<Button>();
    craftFuelBTN.onClick.AddListener(delegate{CraftAnyItem(FuelBLP);});

    // Fabric
     FabricReq1 = materialsCatagoryScreenUI.transform.Find("Fabric").transform.Find("req1").GetComponent<TextMeshProUGUI>();
     FabricReq2 = materialsCatagoryScreenUI.transform.Find("Fabric").transform.Find("req2").GetComponent<TextMeshProUGUI>();
     
    craftFabricBTN = materialsCatagoryScreenUI.transform.Find("Fabric").transform.Find("Button").GetComponent<Button>();
    craftFabricBTN.onClick.AddListener(delegate{CraftAnyItem(FabricBLP);});

    //string
     StringReq1 = materialsCatagoryScreenUI.transform.Find("String").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftStringBTN = materialsCatagoryScreenUI.transform.Find("String").transform.Find("Button").GetComponent<Button>();
    craftStringBTN.onClick.AddListener(delegate{CraftAnyItem(StringBLP);});

    //Leather
     BandageReq1 = materialsCatagoryScreenUI.transform.Find("Bandage").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    BandageReq2 = materialsCatagoryScreenUI.transform.Find("Bandage").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftBandageBTN = materialsCatagoryScreenUI.transform.Find("Bandage").transform.Find("Button").GetComponent<Button>();
    craftBandageBTN.onClick.AddListener(delegate{CraftAnyItem(BandageBLP);});

    //Rope 
     RopeReq1 = materialsCatagoryScreenUI.transform.Find("Rope").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftRopeBTN = materialsCatagoryScreenUI.transform.Find("Rope").transform.Find("Button").GetComponent<Button>();
    craftRopeBTN.onClick.AddListener(delegate{CraftAnyItem(RopeBLP);});

    //Nails
    NailsReq1 = materialsCatagoryScreen2UI.transform.Find("Nails").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftNailsBTN = materialsCatagoryScreen2UI.transform.Find("Nails").transform.Find("Button").GetComponent<Button>();
    craftNailsBTN.onClick.AddListener(delegate{CraftAnyItem(NailsBLP);});

    // Glue
     GlueReq1 = materialsCatagoryScreen2UI.transform.Find("Glue").transform.Find("req1").GetComponent<TextMeshProUGUI>();
     GlueReq2 = materialsCatagoryScreen2UI.transform.Find("Glue").transform.Find("req2").GetComponent<TextMeshProUGUI>();
     
    craftGlueBTN = materialsCatagoryScreen2UI.transform.Find("Glue").transform.Find("Button").GetComponent<Button>();
    craftGlueBTN.onClick.AddListener(delegate{CraftAnyItem(GlueBLP);});

    //WoodAsh
        WoodAshReq1 = materialsCatagoryScreen2UI.transform.Find("WoodAsh").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftWoodAshBTN = materialsCatagoryScreen2UI.transform.Find("WoodAsh").transform.Find("Button").GetComponent<Button>();
    craftWoodAshBTN.onClick.AddListener(delegate{CraftAnyItem(WoodAshBLP);});

    //Lock
    LockReq1 = materialsCatagoryScreen2UI.transform.Find("Lock").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftLockBTN = materialsCatagoryScreen2UI.transform.Find("Lock").transform.Find("Button").GetComponent<Button>();
    craftLockBTN.onClick.AddListener(delegate{CraftAnyItem(LockBLP);});

    //CampFire
    CampFireReq1 = furnitureCatagoryScreenUI.transform.Find("CampFire").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    CampFireReq2 = furnitureCatagoryScreenUI.transform.Find("CampFire").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftCampFireBTN = furnitureCatagoryScreenUI.transform.Find("CampFire").transform.Find("Button").GetComponent<Button>();
    craftCampFireBTN.onClick.AddListener(delegate{CraftAnyItem(CampFireBLP);});

    //Iron Beams
     IronBeamsReq1 = materialsCatagoryScreen2UI.transform.Find("Iron Beams").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftIronBeamsBTN = materialsCatagoryScreen2UI.transform.Find("Iron Beams").transform.Find("Button").GetComponent<Button>();
    craftIronBeamsBTN.onClick.AddListener(delegate{CraftAnyItem(IronBeamsBLP);});

    // Batteries
         BatteriesReq1 = materialsCatagoryScreen2UI.transform.Find("Batteries").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftBatteriesBTN = materialsCatagoryScreen2UI.transform.Find("Batteries").transform.Find("Button").GetComponent<Button>();
    craftBatteriesBTN.onClick.AddListener(delegate{CraftAnyItem(BatteriesBLP);});

    //SwordLv1
    SwordLv1Req1 = weaponsCatagoryScreenUI.transform.Find("SwordLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    SwordLv1Req2 = weaponsCatagoryScreenUI.transform.Find("SwordLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftSwordLv1BTN = weaponsCatagoryScreenUI.transform.Find("SwordLv1").transform.Find("Button").GetComponent<Button>();
    craftSwordLv1BTN.onClick.AddListener(delegate{CraftAnyItem(SwordLv1BLP);});

    //SpearLv1
    SpearLv1Req1 = weaponsCatagoryScreenUI.transform.Find("SpearLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    SpearLv1Req2 = weaponsCatagoryScreenUI.transform.Find("SpearLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftSpearLv1BTN = weaponsCatagoryScreenUI.transform.Find("SpearLv1").transform.Find("Button").GetComponent<Button>();
    craftSpearLv1BTN.onClick.AddListener(delegate{CraftAnyItem(SpearLv1BLP);});

    //WarAxeLv1
    WarAxeLv1Req1 = weaponsCatagoryScreenUI.transform.Find("WarAxeLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    WarAxeLv1Req2 = weaponsCatagoryScreenUI.transform.Find("WarAxeLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftWarAxeLv1BTN = weaponsCatagoryScreenUI.transform.Find("WarAxeLv1").transform.Find("Button").GetComponent<Button>();
    craftWarAxeLv1BTN.onClick.AddListener(delegate{CraftAnyItem(WarAxeLv1BLP);});

    //WarHammerLv1
    WarHammerLv1Req1 = weaponsCatagoryScreenUI.transform.Find("WarHammerLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    WarHammerLv1Req2 = weaponsCatagoryScreenUI.transform.Find("WarHammerLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftWarHammerLv1BTN= weaponsCatagoryScreenUI.transform.Find("WarHammerLv1").transform.Find("Button").GetComponent<Button>();
    craftWarHammerLv1BTN.onClick.AddListener(delegate{CraftAnyItem(WarHammerLv1BLP);});

    //ClubLv1
    ClubLv1Req1 = weaponsCatagoryScreenUI.transform.Find("ClubLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();

    craftClubLv1BTN= weaponsCatagoryScreenUI.transform.Find("ClubLv1").transform.Find("Button").GetComponent<Button>();
    craftClubLv1BTN.onClick.AddListener(delegate{CraftAnyItem(ClubLv1BLP);});

    //ShieldLv1
    ShieldLv1Req1 = weaponsCatagoryScreenUI.transform.Find("ShieldLv1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    ShieldLv1Req2 = weaponsCatagoryScreenUI.transform.Find("ShieldLv1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftShieldLv1BTN= weaponsCatagoryScreenUI.transform.Find("ShieldLv1").transform.Find("Button").GetComponent<Button>();
    craftShieldLv1BTN.onClick.AddListener(delegate{CraftAnyItem(ShieldLv1BLP);});

    //StorageBoxSmall
    StorageBoxSmallReq1 = furnitureCatagoryScreenUI.transform.Find("StorageBoxSmall").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    StorageBoxSmallReq2 = furnitureCatagoryScreenUI.transform.Find("StorageBoxSmall").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftStorageBoxSmallBTN = furnitureCatagoryScreenUI.transform.Find("StorageBoxSmall").transform.Find("Button").GetComponent<Button>();
    craftStorageBoxSmallBTN.onClick.AddListener(delegate{CraftAnyItem(StorageBoxSmallBLP);});

    //StorageBoxMedium
    StorageBoxMediumReq1 = furnitureCatagoryScreenUI.transform.Find("StorageBoxMedium").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    StorageBoxMediumReq2 = furnitureCatagoryScreenUI.transform.Find("StorageBoxMedium").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftStorageBoxMediumBTN = furnitureCatagoryScreenUI.transform.Find("StorageBoxMedium").transform.Find("Button").GetComponent<Button>();
    craftStorageBoxMediumBTN.onClick.AddListener(delegate{CraftAnyItem(StorageBoxMediumBLP);});

    //StorageBoxLarge
    StorageBoxLargeReq1 = furnitureCatagoryScreenUI.transform.Find("StorageBoxLarge").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    StorageBoxLargeReq2 = furnitureCatagoryScreenUI.transform.Find("StorageBoxLarge").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftStorageBoxLargeBTN = furnitureCatagoryScreenUI.transform.Find("StorageBoxLarge").transform.Find("Button").GetComponent<Button>();
    craftStorageBoxLargeBTN.onClick.AddListener(delegate{CraftAnyItem(StorageBoxLargeBLP);});

    //Chair
    ChairReq1 = furnitureCatagoryScreenUI.transform.Find("Chair").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    ChairReq2 = furnitureCatagoryScreenUI.transform.Find("Chair").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftChairBTN = furnitureCatagoryScreenUI.transform.Find("Chair").transform.Find("Button").GetComponent<Button>();
    craftChairBTN.onClick.AddListener(delegate{CraftAnyItem(ChairBLP);});

    //ChairType2
   ChairType2Req1 = furnitureCatagoryScreenUI.transform.Find("ChairType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
   ChairType2Req2 = furnitureCatagoryScreenUI.transform.Find("ChairType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftChairType2BTN = furnitureCatagoryScreenUI.transform.Find("ChairType2").transform.Find("Button").GetComponent<Button>();
    craftChairType2BTN.onClick.AddListener(delegate{CraftAnyItem(ChairType2BLP);});

    //Lamp
    LampReq1 = furnitureCatagoryScreen2UI.transform.Find("Lamp").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    LampReq2 = furnitureCatagoryScreen2UI.transform.Find("Lamp").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftLampBTN = furnitureCatagoryScreen2UI.transform.Find("Lamp").transform.Find("Button").GetComponent<Button>();
    craftLampBTN.onClick.AddListener(delegate{CraftAnyItem(LampBLP);});

    //LampType2
    LampType2Req1 = furnitureCatagoryScreen2UI.transform.Find("LampType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    LampType2Req2 = furnitureCatagoryScreen2UI.transform.Find("LampType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftLampType2BTN = furnitureCatagoryScreen2UI.transform.Find("LampType2").transform.Find("Button").GetComponent<Button>();
    craftLampType2BTN.onClick.AddListener(delegate{CraftAnyItem(LampType2BLP);});

    //LampType3
    LampType3Req1 = furnitureCatagoryScreen2UI.transform.Find("LampType3").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    LampType3Req2 = furnitureCatagoryScreen2UI.transform.Find("LampType3").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftLampType3BTN = furnitureCatagoryScreen2UI.transform.Find("LampType3").transform.Find("Button").GetComponent<Button>();
    craftLampType3BTN.onClick.AddListener(delegate{CraftAnyItem(LampType3BLP);});

    //Table
    TableReq1 = furnitureCatagoryScreen2UI.transform.Find("Table").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    TableReq2 = furnitureCatagoryScreen2UI.transform.Find("Table").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftTableBTN = furnitureCatagoryScreen2UI.transform.Find("Table").transform.Find("Button").GetComponent<Button>();
    craftTableBTN.onClick.AddListener(delegate{CraftAnyItem(TableBLP);});

    //TableType2
    TableType2Req1 = furnitureCatagoryScreen2UI.transform.Find("TableType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    TableType2Req2 = furnitureCatagoryScreen2UI.transform.Find("TableType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftTableType2BTN = furnitureCatagoryScreen2UI.transform.Find("TableType2").transform.Find("Button").GetComponent<Button>();
    craftTableType2BTN.onClick.AddListener(delegate{CraftAnyItem(TableType2BLP);});
    
    //TableType3
    TableType3Req1 = furnitureCatagoryScreen2UI.transform.Find("TableType3").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    TableType3Req2 = furnitureCatagoryScreen2UI.transform.Find("TableType3").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftTableType3BTN = furnitureCatagoryScreen2UI.transform.Find("TableType3").transform.Find("Button").GetComponent<Button>();
    craftTableType3BTN.onClick.AddListener(delegate{CraftAnyItem(TableType3BLP);});

    //NightStand
    NightStandReq1 = furnitureCatagoryScreen3UI.transform.Find("NightStand").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    NightStandReq2 = furnitureCatagoryScreen3UI.transform.Find("NightStand").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftNightStandBTN = furnitureCatagoryScreen3UI.transform.Find("NightStand").transform.Find("Button").GetComponent<Button>();
    craftNightStandBTN.onClick.AddListener(delegate{CraftAnyItem(NightStandBLP);});

    //NightStandType2
    NightStandType2Req1 = furnitureCatagoryScreen3UI.transform.Find("NightStandType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    NightStandType2Req2 = furnitureCatagoryScreen3UI.transform.Find("NightStandType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    
    craftNightStandType2BTN = furnitureCatagoryScreen3UI.transform.Find("NightStandType2").transform.Find("Button").GetComponent<Button>();
    craftNightStandType2BTN.onClick.AddListener(delegate{CraftAnyItem(NightStandType2BLP);});

    //Bed
    BedReq1 = furnitureCatagoryScreen3UI.transform.Find("Bed").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    BedReq2 = furnitureCatagoryScreen3UI.transform.Find("Bed").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    BedReq3 = furnitureCatagoryScreen3UI.transform.Find("Bed").transform.Find("req3").GetComponent<TextMeshProUGUI>();
    
    craftBedBTN = furnitureCatagoryScreen3UI.transform.Find("Bed").transform.Find("Button").GetComponent<Button>();
    craftBedBTN.onClick.AddListener(delegate{CraftAnyItem(BedBLP);});

    //BedType2
    BedType2Req1 = furnitureCatagoryScreen3UI.transform.Find("BedType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    BedType2Req2 = furnitureCatagoryScreen3UI.transform.Find("BedType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    BedType2Req3 = furnitureCatagoryScreen3UI.transform.Find("BedType2").transform.Find("req3").GetComponent<TextMeshProUGUI>();
    
    craftBedType2BTN = furnitureCatagoryScreen3UI.transform.Find("BedType2").transform.Find("Button").GetComponent<Button>();
    craftBedType2BTN.onClick.AddListener(delegate{CraftAnyItem(BedType2BLP);});

    //BookShelf
    BookShelfReq1 = furnitureCatagoryScreen3UI.transform.Find("BookShelf").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    BookShelfReq2 = furnitureCatagoryScreen3UI.transform.Find("BookShelf").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftBookShelfBTN = furnitureCatagoryScreen3UI.transform.Find("BookShelf").transform.Find("Button").GetComponent<Button>();
    craftBookShelfBTN.onClick.AddListener(delegate{CraftAnyItem(BookShelfBLP);});

    //BookShelfType2
    BookShelfType2Req1 = furnitureCatagoryScreen3UI.transform.Find("BookShelfType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    BookShelfType2Req2 = furnitureCatagoryScreen3UI.transform.Find("BookShelfType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftBookShelfType2BTN = furnitureCatagoryScreen3UI.transform.Find("BookShelfType2").transform.Find("Button").GetComponent<Button>();
    craftBookShelfType2BTN.onClick.AddListener(delegate{CraftAnyItem(BookShelfType2BLP);});

    //Couch
    CouchReq1 = furnitureCatagoryScreen4UI.transform.Find("Couch").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    CouchReq2 = furnitureCatagoryScreen4UI.transform.Find("Couch").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftCouchBTN = furnitureCatagoryScreen4UI.transform.Find("Couch").transform.Find("Button").GetComponent<Button>();
    craftCouchBTN.onClick.AddListener(delegate{CraftAnyItem(CouchBLP);});

    //CouchType2
    CouchType2Req1 = furnitureCatagoryScreen4UI.transform.Find("CouchType2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    CouchType2Req2 = furnitureCatagoryScreen4UI.transform.Find("CouchType2").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftCouchType2BTN = furnitureCatagoryScreen4UI.transform.Find("CouchType2").transform.Find("Button").GetComponent<Button>();
    craftCouchType2BTN.onClick.AddListener(delegate{CraftAnyItem(CouchType2BLP);});

    //Sink
    SinkReq1 = furnitureCatagoryScreen4UI.transform.Find("Sink").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    SinkReq2 = furnitureCatagoryScreen4UI.transform.Find("Sink").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftSinkBTN = furnitureCatagoryScreen4UI.transform.Find("Sink").transform.Find("Button").GetComponent<Button>();
    craftSinkBTN.onClick.AddListener(delegate{CraftAnyItem(SinkBLP);});

    //Wahser
    WasherReq1 = furnitureCatagoryScreen4UI.transform.Find("Washer").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    WasherReq2 = furnitureCatagoryScreen4UI.transform.Find("Washer").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftWasherBTN = furnitureCatagoryScreen4UI.transform.Find("Washer").transform.Find("Button").GetComponent<Button>();
    craftWasherBTN.onClick.AddListener(delegate{CraftAnyItem(WasherBLP);});

    //Fridge
    FridgeReq1 = furnitureCatagoryScreen4UI.transform.Find("Fridge").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    FridgeReq2 = furnitureCatagoryScreen4UI.transform.Find("Fridge").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftFridgeBTN = furnitureCatagoryScreen4UI.transform.Find("Fridge").transform.Find("Button").GetComponent<Button>();
    craftFridgeBTN.onClick.AddListener(delegate{CraftAnyItem(FridgeBLP);});
    
    //TV
    TVReq1 = furnitureCatagoryScreen4UI.transform.Find("TV").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    TVReq2 = furnitureCatagoryScreen4UI.transform.Find("TV").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    craftTVBTN = furnitureCatagoryScreen4UI.transform.Find("TV").transform.Find("Button").GetComponent<Button>();
    craftTVBTN.onClick.AddListener(delegate{CraftAnyItem(TVBLP);});

    //upgrades

    //house1
    house1Req1 = house1UI.transform.Find("House1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house1Req2 = house1UI.transform.Find("House1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house1Req3 = house1UI.transform.Find("House1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse1BTN = house1UI.transform.Find("House1").transform.Find("Button").GetComponent<Button>();
    upgradehouse1BTN.onClick.AddListener(delegate{UpgradeAnyItem(House1UpgradeBLP);});

        //house2
    house2Req1 = house2UI.transform.Find("House2").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house2Req2 = house2UI.transform.Find("House2").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house2Req3 = house2UI.transform.Find("House2").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse2BTN = house2UI.transform.Find("House2").transform.Find("Button").GetComponent<Button>();
    upgradehouse2BTN.onClick.AddListener(delegate{UpgradeAnyItem(House2UpgradeBLP);});

        //house3
    house3Req1 = house3UI.transform.Find("House3").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house3Req2 = house3UI.transform.Find("House3").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house3Req3 = house3UI.transform.Find("House3").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse3BTN = house3UI.transform.Find("House3").transform.Find("Button").GetComponent<Button>();
    upgradehouse3BTN.onClick.AddListener(delegate{UpgradeAnyItem(House3UpgradeBLP);});

        //house11
    house11Req1 = house1UI.transform.Find("House11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house11Req2 = house1UI.transform.Find("House11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house11Req3 = house1UI.transform.Find("House11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse11BTN = house1UI.transform.Find("House11").transform.Find("Button").GetComponent<Button>();
    upgradehouse11BTN.onClick.AddListener(delegate{UpgradeAnyItem(House11UpgradeBLP);});

        //house22
    house22Req1 = house2UI.transform.Find("House22").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house22Req2 = house2UI.transform.Find("House22").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house22Req3 = house2UI.transform.Find("House22").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse22BTN = house2UI.transform.Find("House22").transform.Find("Button").GetComponent<Button>();
    upgradehouse22BTN.onClick.AddListener(delegate{UpgradeAnyItem(House22UpgradeBLP);});

        //house3
    house33Req1 = house3UI.transform.Find("House33").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house33Req2 = house3UI.transform.Find("House33").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house33Req3 = house3UI.transform.Find("House33").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse33BTN = house3UI.transform.Find("House33").transform.Find("Button").GetComponent<Button>();
    upgradehouse33BTN.onClick.AddListener(delegate{UpgradeAnyItem(House33UpgradeBLP);});

            //house111
    house111Req1 = house1UI.transform.Find("House111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house111Req2 = house1UI.transform.Find("House111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house111Req3 = house1UI.transform.Find("House111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse111BTN = house1UI.transform.Find("House111").transform.Find("Button").GetComponent<Button>();
    upgradehouse111BTN.onClick.AddListener(delegate{UpgradeAnyItem(House111UpgradeBLP);});

        //house222
    house222Req1 = house2UI.transform.Find("House222").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house222Req2 = house2UI.transform.Find("House222").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house222Req3 = house2UI.transform.Find("House222").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse222BTN = house2UI.transform.Find("House222").transform.Find("Button").GetComponent<Button>();
    upgradehouse222BTN.onClick.AddListener(delegate{UpgradeAnyItem(House222UpgradeBLP);});

        //house3
    house333Req1 = house3UI.transform.Find("House333").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house333Req2 = house3UI.transform.Find("House333").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house333Req3 = house3UI.transform.Find("House333").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse333BTN = house3UI.transform.Find("House333").transform.Find("Button").GetComponent<Button>();
    upgradehouse333BTN.onClick.AddListener(delegate{UpgradeAnyItem(House333UpgradeBLP);});

            //house4
    house4Req1 = house4UI.transform.Find("House4").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house4Req2 = house4UI.transform.Find("House4").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house4Req3 = house4UI.transform.Find("House4").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse4BTN = house4UI.transform.Find("House4").transform.Find("Button").GetComponent<Button>();
    upgradehouse4BTN.onClick.AddListener(delegate{UpgradeAnyItem(House4UpgradeBLP);});

                //house44
    house44Req1 = house4UI.transform.Find("House44").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house44Req2 = house4UI.transform.Find("House44").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house44Req3 = house4UI.transform.Find("House44").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse44BTN = house4UI.transform.Find("House44").transform.Find("Button").GetComponent<Button>();
    upgradehouse44BTN.onClick.AddListener(delegate{UpgradeAnyItem(House44UpgradeBLP);});

                //house444
    house444Req1 = house4UI.transform.Find("House444").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house444Req2 = house4UI.transform.Find("House444").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house444Req3 = house4UI.transform.Find("House444").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse444BTN = house4UI.transform.Find("House444").transform.Find("Button").GetComponent<Button>();
    upgradehouse444BTN.onClick.AddListener(delegate{UpgradeAnyItem(House444UpgradeBLP);});

                //house5
    house5Req1 = house5UI.transform.Find("House5").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house5Req2 = house5UI.transform.Find("House5").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house5Req3 = house5UI.transform.Find("House5").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse5BTN = house5UI.transform.Find("House5").transform.Find("Button").GetComponent<Button>();
    upgradehouse5BTN.onClick.AddListener(delegate{UpgradeAnyItem(House5UpgradeBLP);});

                    //55
    house55Req1 = house5UI.transform.Find("House55").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house55Req2 = house5UI.transform.Find("House55").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house55Req3 = house5UI.transform.Find("House55").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse55BTN = house5UI.transform.Find("House55").transform.Find("Button").GetComponent<Button>();
    upgradehouse55BTN.onClick.AddListener(delegate{UpgradeAnyItem(House55UpgradeBLP);});

                    //house5
    house555Req1 = house5UI.transform.Find("House555").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    house555Req2 = house5UI.transform.Find("House555").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    house555Req3 = house5UI.transform.Find("House555").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradehouse555BTN = house5UI.transform.Find("House555").transform.Find("Button").GetComponent<Button>();
    upgradehouse555BTN.onClick.AddListener(delegate{UpgradeAnyItem(House555UpgradeBLP);});

    //church1
    church1Req1 = church1UI.transform.Find("Church1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    church1Req2 = church1UI.transform.Find("Church1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    church1Req3 = church1UI.transform.Find("Church1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradechurch1BTN = church1UI.transform.Find("Church1").transform.Find("Button").GetComponent<Button>();
    upgradechurch1BTN.onClick.AddListener(delegate{UpgradeAnyItem(Church1UpgradeBLP);});

       //church11
    church11Req1 = church1UI.transform.Find("Church11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    church11Req2 = church1UI.transform.Find("Church11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    church11Req3 = church1UI.transform.Find("Church11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradechurch11BTN = church1UI.transform.Find("Church11").transform.Find("Button").GetComponent<Button>();
    upgradechurch11BTN.onClick.AddListener(delegate{UpgradeAnyItem(Church11UpgradeBLP);});

       //church111
    church111Req1 = church1UI.transform.Find("Church111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    church111Req2 = church1UI.transform.Find("Church111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    church111Req3 = church1UI.transform.Find("Church111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradechurch111BTN = church1UI.transform.Find("Church111").transform.Find("Button").GetComponent<Button>();
    upgradechurch111BTN.onClick.AddListener(delegate{UpgradeAnyItem(Church111UpgradeBLP);});

    //Lights1
    lights1Req1 = lights1UI.transform.Find("Light1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    lights1Req2 = lights1UI.transform.Find("Light1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    lights1Req3 = lights1UI.transform.Find("Light1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradelights1BTN = lights1UI.transform.Find("Light1").transform.Find("Button").GetComponent<Button>();
    upgradelights1BTN.onClick.AddListener(delegate{UpgradeAnyItem(Lights1UpgradeBLP);});

        //Lights11
    lights11Req1 = lights1UI.transform.Find("Light11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    lights11Req2 = lights1UI.transform.Find("Light11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    lights11Req3 = lights1UI.transform.Find("Light11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradelights11BTN = lights1UI.transform.Find("Light11").transform.Find("Button").GetComponent<Button>();
    upgradelights11BTN.onClick.AddListener(delegate{UpgradeAnyItem(Lights11UpgradeBLP);});

        //Lights111
    lights111Req1 = lights1UI.transform.Find("Light111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    lights111Req2 = lights1UI.transform.Find("Light111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    lights111Req3 = lights1UI.transform.Find("Light111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradelights111BTN = lights1UI.transform.Find("Light111").transform.Find("Button").GetComponent<Button>();
    upgradelights111BTN.onClick.AddListener(delegate{UpgradeAnyItem(Lights111UpgradeBLP);});

    //Floor1
    floor1Req1 = floor1UI.transform.Find("Floor1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    floor1Req2 = floor1UI.transform.Find("Floor1").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    upgradefloor1BTN = floor1UI.transform.Find("Floor1").transform.Find("Button").GetComponent<Button>();
    upgradefloor1BTN.onClick.AddListener(delegate{UpgradeAnyItem(Floor1UpgradeBLP);});

        //Floor11
    floor11Req1 = floor1UI.transform.Find("Floor11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    floor11Req2 = floor1UI.transform.Find("Floor11").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    upgradefloor11BTN = floor1UI.transform.Find("Floor11").transform.Find("Button").GetComponent<Button>();
    upgradefloor11BTN.onClick.AddListener(delegate{UpgradeAnyItem(Floor11UpgradeBLP);});

        //Floor111
    floor111Req1 = floor1UI.transform.Find("Floor111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    floor111Req2 = floor1UI.transform.Find("Floor111").transform.Find("req2").GetComponent<TextMeshProUGUI>();

    upgradefloor111BTN = floor1UI.transform.Find("Floor111").transform.Find("Button").GetComponent<Button>();
    upgradefloor111BTN.onClick.AddListener(delegate{UpgradeAnyItem(Floor111UpgradeBLP);});

    //Market1
    market1Req1 = market1UI.transform.Find("Market1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    market1Req2 = market1UI.transform.Find("Market1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    market1Req3 = market1UI.transform.Find("Market1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgrademarket1BTN = market1UI.transform.Find("Market1").transform.Find("Button").GetComponent<Button>();
    upgrademarket1BTN.onClick.AddListener(delegate{UpgradeAnyItem(Market1UpgradeBLP);});

        //Market11
    market11Req1 = market1UI.transform.Find("Market11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    market11Req2 = market1UI.transform.Find("Market11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    market11Req3 = market1UI.transform.Find("Market11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgrademarket11BTN = market1UI.transform.Find("Market11").transform.Find("Button").GetComponent<Button>();
    upgrademarket11BTN.onClick.AddListener(delegate{UpgradeAnyItem(Market11UpgradeBLP);});

        //Market111
    market111Req1 = market1UI.transform.Find("Market111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    market111Req2 = market1UI.transform.Find("Market111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    market111Req3 = market1UI.transform.Find("Market111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgrademarket111BTN = market1UI.transform.Find("Market111").transform.Find("Button").GetComponent<Button>();
    upgrademarket111BTN.onClick.AddListener(delegate{UpgradeAnyItem(Market111UpgradeBLP);});

        //UserHouse1
    userhouse1Req1 = userhouse1UI.transform.Find("UserHouse1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    userhouse1Req2 = userhouse1UI.transform.Find("UserHouse1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    userhouse1Req3 = userhouse1UI.transform.Find("UserHouse1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradeuserhouse1BTN = userhouse1UI.transform.Find("UserHouse1").transform.Find("Button").GetComponent<Button>();
    upgradeuserhouse1BTN.onClick.AddListener(delegate{UpgradeAnyItem(UserHouse1UpgradeBLP);});

            //UserHouse11
    userhouse11Req1 = userhouse1UI.transform.Find("UserHouse11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    userhouse11Req2 = userhouse1UI.transform.Find("UserHouse11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    userhouse11Req3 = userhouse1UI.transform.Find("UserHouse11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradeuserhouse11BTN = userhouse1UI.transform.Find("UserHouse11").transform.Find("Button").GetComponent<Button>();
    upgradeuserhouse11BTN.onClick.AddListener(delegate{UpgradeAnyItem(UserHouse11UpgradeBLP);});

            //UserHouse111
    userhouse111Req1 = userhouse1UI.transform.Find("UserHouse111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    userhouse111Req2 = userhouse1UI.transform.Find("UserHouse111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    userhouse111Req3 = userhouse1UI.transform.Find("UserHouse111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradeuserhouse111BTN = userhouse1UI.transform.Find("UserHouse111").transform.Find("Button").GetComponent<Button>();
    upgradeuserhouse111BTN.onClick.AddListener(delegate{UpgradeAnyItem(UserHouse111UpgradeBLP);});

    //Watertower1
    watertower1Req1 = watertower1UI.transform.Find("WaterTower1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    watertower1Req2 = watertower1UI.transform.Find("WaterTower1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    watertower1Req3 = watertower1UI.transform.Find("WaterTower1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradewatertower1BTN = watertower1UI.transform.Find("WaterTower1").transform.Find("Button").GetComponent<Button>();
    upgradewatertower1BTN.onClick.AddListener(delegate{UpgradeAnyItem(WaterTower1UpgradeBLP);});

        //Watertower11
    watertower11Req1 = watertower1UI.transform.Find("WaterTower11").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    watertower11Req2 = watertower1UI.transform.Find("WaterTower11").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    watertower11Req3 = watertower1UI.transform.Find("WaterTower11").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradewatertower11BTN = watertower1UI.transform.Find("WaterTower11").transform.Find("Button").GetComponent<Button>();
    upgradewatertower11BTN.onClick.AddListener(delegate{UpgradeAnyItem(WaterTower11UpgradeBLP);});

        //Watertower111
    watertower111Req1 = watertower1UI.transform.Find("WaterTower111").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    watertower111Req2 = watertower1UI.transform.Find("WaterTower111").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    watertower111Req3 = watertower1UI.transform.Find("WaterTower111").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradewatertower111BTN = watertower1UI.transform.Find("WaterTower111").transform.Find("Button").GetComponent<Button>();
    upgradewatertower111BTN.onClick.AddListener(delegate{UpgradeAnyItem(WaterTower111UpgradeBLP);});

    //Windmill1
    windmill1Req1 = windmill1UI.transform.Find("Windmill1").transform.Find("req1").GetComponent<TextMeshProUGUI>();
    windmill1Req2 = windmill1UI.transform.Find("Windmill1").transform.Find("req2").GetComponent<TextMeshProUGUI>();
    windmill1Req3 = windmill1UI.transform.Find("Windmill1").transform.Find("req3").GetComponent<TextMeshProUGUI>();

    upgradewindmill1BTN = windmill1UI.transform.Find("Windmill1").transform.Find("Button").GetComponent<Button>();
    upgradewindmill1BTN.onClick.AddListener(delegate{UpgradeAnyItem(Windmill1UpgradeBLP);});
    }

  
  void OpenCraftingScreen()
    {
craftingScreenUI.SetActive(true);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);


    }
    void OpenToolsCatagory()
    {
craftingScreenUI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
toolsCatagoryScreenUI.SetActive(true);


    }
      void OpenMaterialsCatagory()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(true);


    }

        void OpenMaterialsCatagory2()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(true);
    }

    void OpenWeaponCatagory()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(true);
    }

    void OpenFurnitureCatagory()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(true);
    }

     void OpenFurnitureCatagory2()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(true);
    }

     void OpenFurnitureCatagory3()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(true);
    }

     void OpenFurnitureCatagory4()
    {
craftingScreenUI.SetActive(false);
toolsCatagoryScreenUI.SetActive(false);
materialsCatagoryScreen2UI.SetActive(false);
materialsCatagoryScreenUI.SetActive(false);
weaponsCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreenUI.SetActive(false);
furnitureCatagoryScreen2UI.SetActive(false);
furnitureCatagoryScreen3UI.SetActive(false);
furnitureCatagoryScreen4UI.SetActive(true);
    }
    

    

    void CraftAnyItem(Blueprint blueprintToCraft)
    {

InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);

if(blueprintToCraft.numOfRequirements == 1)
{
InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);

}else if(blueprintToCraft.numOfRequirements == 2)
{
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);
}
else if (blueprintToCraft.numOfRequirements == 3)
{
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req3, blueprintToCraft.Req3amount);
}



StartCoroutine(calculate());




        
    }


    public IEnumerator calculate()
    {
        yield return 0;

        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();
    }




        void UpgradeAnyItem(Blueprint blueprintToCraft)
    {

UpgradeManager.Instance.Upgrade(blueprintToCraft.itemName);

if(blueprintToCraft.numOfRequirements == 1)
{
InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);

}else if(blueprintToCraft.numOfRequirements == 2)
{
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);
}
else if (blueprintToCraft.numOfRequirements == 3)
{
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);
    InventorySystem.Instance.RemoveItem(blueprintToCraft.Req3, blueprintToCraft.Req3amount);
}



StartCoroutine(calculate1());




        
    }


    public IEnumerator calculate1()
    {
        yield return 0;

        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();
    }






        void Update()
    {



          if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            craftingScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SelectionManager.Instance.DisableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
            isOpen = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsCatagoryScreenUI.SetActive(false);
            materialsCatagoryScreenUI.SetActive(false);
            materialsCatagoryScreen2UI.SetActive(false);
           weaponsCatagoryScreenUI.SetActive(false);
           furnitureCatagoryScreenUI.SetActive(false);
           furnitureCatagoryScreen2UI.SetActive(false);
           furnitureCatagoryScreen3UI.SetActive(false);
           furnitureCatagoryScreen4UI.SetActive(false);
            if(!InventorySystem.Instance.isOpen)
            {
              Cursor.lockState = CursorLockMode.Locked;
              Cursor.visible = false;

              SelectionManager.Instance.EnableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
            }
          InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();
            isOpen = false;
        }
    }

    public void RefreshNeededItems()
{
    int stone_count = 0;
    int rock_count = 0;
    int stick_count = 0;
    int log_count = 0;
    int cloth_count = 0;
    int coal_count = 0;
    int hide_count = 0;
    int string_count = 0;
    int ironingot_count = 0;
    int polymer_count = 0;
    int woodash_count = 0;
    int components_count = 0;
    int woodplank_count = 0;
    int fabric_count = 0;
    int goldingot_count = 0;
    int nails_count = 0;
    int lock_count = 0;
    int batteries_count = 0;
    int ironbeams_count = 0;
    int glue_count = 0;
    int water_count = 0;
    int emeraldingot_count = 0;
    int fuel_count = 0;



    inventoryitemList = InventorySystem.Instance.itemList;

    foreach (string itemName in inventoryitemList)
    {

switch (itemName)
{
    case "Stone":
    stone_count += 1;
    break;
    case "Rock":
    rock_count += 1;
    break;
    case "Stick":
    stick_count += 1;
    break;
    case "Log":
    log_count += 1;
    break; 
    case "Cloth":
    cloth_count += 1;
    break;
     case "Coal":
    coal_count += 1;
    break;
     case "Hide":
    hide_count += 1;
    break;
     case "String":
    string_count += 1;
    break;
    case "Iron Ingot":
    ironingot_count += 1;
    break;
    case "Polymer":
    polymer_count += 1;
    break;
    case "WoodAsh":
    woodash_count += 1;
    break;
    case "Components":
    components_count += 1;
    break;
     case "WoodPlank":
    woodplank_count += 1;
    break;
         case "Fabric":
    fabric_count += 1;
    break;
    case "Gold Ingot":
    goldingot_count += 1;
    break;
    case "Nails":
    nails_count += 1;
    break;
        case "Lock":
    lock_count += 1;
    break;
    case "Batteries":
    batteries_count += 1;
    break;
    case "Iron Beams":
    ironbeams_count += 1;
    break;
    case "Glue":
    glue_count += 1;
    break;
     case "Water":
    water_count += 1;
    break;
    case "Emerald Ingot":
    emeraldingot_count += 1;
    break;
    case "Fuel":
    fuel_count += 1;
    break;
}

    }

    // AXE CRAFT BUTTON

AxeLv1Req1.text = "2 Rock[" + rock_count + "]";
AxeLv1Req2.text = "2 Stick[" + stick_count + "]";

if(rock_count >= 2 && stick_count >= 2)
{
craftAxeLv1BTN.gameObject.SetActive(true);
}
else
{
    craftAxeLv1BTN.gameObject.SetActive(false);
}

     // PICKAXE CRAFT BUTTON
     PickAxeLv1Req1.text = "3 Rock[" + rock_count + "]";
    PickAxeLv1Req2.text = "2 Stick[" + stick_count + "]";

if(rock_count >= 3 && stick_count >= 2)
{
craftPickAxeLv1BTN.gameObject.SetActive(true);
}
else
{
  craftPickAxeLv1BTN.gameObject.SetActive(false);
}

//Knife Craft Button
     KnifeLv1Req1.text = "1 Rock[" + rock_count + "]";
    KnifeLv1Req2.text = "1 Stick[" + stick_count + "]";

if(rock_count >= 1 && stick_count >= 1)
{
craftKnifeLv1BTN.gameObject.SetActive(true);
}
else
{
  craftKnifeLv1BTN.gameObject.SetActive(false);
}

//TORCH CRAFT BUTTON
     TorchReq1.text = "2 Cloth[" + cloth_count + "]";
    TorchReq2.text = "2 Stick[" + stick_count + "]";

if(cloth_count >= 2 && stick_count >= 2)
{
craftTorchBTN.gameObject.SetActive(true);
}
else
{
  craftTorchBTN.gameObject.SetActive(false);
}

//HAMMER CRAFT BUTTON
     HammerLv1Req1.text = "3 Rock[" + rock_count + "]";
    HammerLv1Req2.text = "2 Stick[" + stick_count + "]";

if(rock_count >= 3 && stick_count >= 2)
{
craftHammerLv1BTN.gameObject.SetActive(true);
}
else
{
  craftHammerLv1BTN.gameObject.SetActive(false);
}

//HOE CRAFT BUTTON
     HoeLv1Req1.text = "2 Rock[" + rock_count + "]";
    HoeLv1Req2.text = "1 Stick[" + stick_count + "]";

if(rock_count >= 2 && stick_count >= 1)
{
craftHoeLv1BTN.gameObject.SetActive(true);
}
else
{
  craftHoeLv1BTN.gameObject.SetActive(false);
}

//WoodPlank Craft Button
     WoodPlankReq1.text = "1 Log[" + log_count + "]";

if(log_count >= 1)
{
craftWoodPlankBTN.gameObject.SetActive(true);
}
else
{
  craftWoodPlankBTN.gameObject.SetActive(false);
}

//Fuel Craft Button
     FuelReq1.text = "3 Coal[" + coal_count + "]";
     FuelReq2.text = "2 Stick[" + stick_count + "]";

if(coal_count >= 3 && stick_count >= 2)
{
craftFuelBTN.gameObject.SetActive(true);
}
else
{
  craftFuelBTN.gameObject.SetActive(false);
}

//Craft Fabric Button
     FabricReq1.text = "1 Cloth[" + cloth_count + "]";
     FabricReq2.text = "2 String[" + string_count + "]";

if(cloth_count >= 1 && string_count >= 2)
{
craftFabricBTN.gameObject.SetActive(true);
}
else
{
  craftFabricBTN.gameObject.SetActive(false);
}

//Craft String Button
     StringReq1.text = "1 Cloth[" + cloth_count + "]";

if(cloth_count >= 1)
{
craftStringBTN.gameObject.SetActive(true);
}
else
{
  craftStringBTN.gameObject.SetActive(false);
}

// Craft Bandage Button
     BandageReq1.text = "2 Cloth[" + cloth_count + "]";
     BandageReq2.text = "2 WoodAsh[" + woodash_count + "]";

if(cloth_count >= 2 && woodash_count >= 2)
{
craftBandageBTN.gameObject.SetActive(true);
}
else
{
  craftBandageBTN.gameObject.SetActive(false);
}

// Craft Rope Button
     RopeReq1.text = "3 String[" + string_count + "]";

if(string_count >= 3)
{
craftRopeBTN.gameObject.SetActive(true);
}
else
{
  craftRopeBTN.gameObject.SetActive(false);
}

//Craft Nails Button
     NailsReq1.text = "1 Iron Ingot[" + ironingot_count + "]";

if(ironingot_count >= 1)
{
craftNailsBTN.gameObject.SetActive(true);
}
else
{
  craftNailsBTN.gameObject.SetActive(false);
}

//Craft Glue Button
     GlueReq1.text = "2 WoodAsh[" + woodash_count + "]";
     GlueReq2.text = "2 Polymer[" + polymer_count + "]";

if(polymer_count >= 1)
{
craftGlueBTN.gameObject.SetActive(true);
}
else
{
  craftGlueBTN.gameObject.SetActive(false);
}

//Craft WoodAsh Button
WoodAshReq1.text = "1 Log[" + log_count + "]";

if(log_count >= 1)
{
craftWoodAshBTN.gameObject.SetActive(true);
}
else
{
  craftWoodAshBTN.gameObject.SetActive(false);
}

//Craft CampFire Button
     CampFireReq1.text = "3 Rock[" + rock_count + "]";
     CampFireReq2.text = "3 Stick[" + stick_count + "]";

if(rock_count >= 3 && stick_count >= 3)
{
craftCampFireBTN.gameObject.SetActive(true);
}
else
{
  craftCampFireBTN.gameObject.SetActive(false);
}

//Craft Iron Beams Button
IronBeamsReq1.text = "1 Iron Ingot[" + ironingot_count + "]";

if(ironingot_count >= 1)
{
craftIronBeamsBTN.gameObject.SetActive(true);
}
else
{
  craftIronBeamsBTN.gameObject.SetActive(false);
}

//Craft Batterires Button
BatteriesReq1.text = "3 Components[" + components_count + "]";

if(components_count >= 3)
{
craftBatteriesBTN.gameObject.SetActive(true);
}
else
{
  craftBatteriesBTN.gameObject.SetActive(false);
}

//Craft SwordLv1 Button
SwordLv1Req1.text = "3 Iron Ingot[" + ironingot_count + "]";
SwordLv1Req2.text = "1 WoodPlank[" + woodplank_count + "]";

if(ironingot_count >= 3 && woodplank_count >= 1)
{
craftSwordLv1BTN.gameObject.SetActive(true);
}
else
{
  craftSwordLv1BTN.gameObject.SetActive(false);
}


//Craft SpearLv1Button
SpearLv1Req1.text = "1 Iron Ingot[" + ironingot_count + "]";
SpearLv1Req2.text = "1 Log[" + log_count + "]";

if(ironingot_count >= 1 && log_count >= 1)
{
craftSpearLv1BTN.gameObject.SetActive(true);
}
else
{
  craftSpearLv1BTN.gameObject.SetActive(false);
}


//craft WarAxeLv1 Button
WarAxeLv1Req1.text = "2 Iron Ingot[" + ironingot_count + "]";
WarAxeLv1Req2.text = "1 Log[" + log_count + "]";

if(ironingot_count >= 2 && log_count >= 1)
{
craftWarAxeLv1BTN.gameObject.SetActive(true);
}
else
{
  craftWarAxeLv1BTN.gameObject.SetActive(false);
}


//craft WarHammerLv1 Button
WarHammerLv1Req1.text = "3 Iron Ingot[" + ironingot_count + "]";
WarHammerLv1Req2.text = "1 Log[" + log_count + "]";

if(ironingot_count >= 3 && log_count >= 1)
{
craftWarHammerLv1BTN.gameObject.SetActive(true);
}
else
{
  craftWarHammerLv1BTN.gameObject.SetActive(false);
}


//craft ClubLv1 Button
ClubLv1Req1.text = "1 Log[" + log_count + "]";

if(log_count >= 1)
{
craftClubLv1BTN.gameObject.SetActive(true);
}
else
{
  craftClubLv1BTN.gameObject.SetActive(false);
}

//craft ShieldLv1 Button
ShieldLv1Req1.text = "2 WoodPlank[" + woodplank_count + "]";
ShieldLv1Req2.text = "1 Iron Ingot[" + ironingot_count + "]";

if(woodplank_count >= 2 && ironingot_count >= 1)
{
craftShieldLv1BTN.gameObject.SetActive(true);
}
else
{
  craftShieldLv1BTN.gameObject.SetActive(false);
}

//craft Lock Button
LockReq1.text = "3 Iron Ingot[" + ironingot_count + "]";

if(ironingot_count >= 3)
{
craftLockBTN.gameObject.SetActive(true);
}
else
{
  craftLockBTN.gameObject.SetActive(false);
}

//StorageBoxSmall 
StorageBoxSmallReq1.text = "1 Lock[" + lock_count + "]";
StorageBoxSmallReq2.text = "3 WoodPlank[" + woodplank_count + "]";

if(lock_count >= 1 && woodplank_count >= 3)
{
craftStorageBoxSmallBTN.gameObject.SetActive(true);
}
else
{
  craftStorageBoxSmallBTN.gameObject.SetActive(false);
}

//StorageBoxMedium Button
StorageBoxMediumReq1.text = "3 Lock[" + lock_count + "]";
StorageBoxMediumReq2.text = "5 WoodPlank[" + woodplank_count + "]";

if(lock_count >= 3 && woodplank_count >= 5)
{
craftStorageBoxMediumBTN.gameObject.SetActive(true);
}
else
{
  craftStorageBoxMediumBTN.gameObject.SetActive(false);
}

//StorageBoxLargeButton
StorageBoxLargeReq1.text = "5 Lock[" + lock_count + "]";
StorageBoxLargeReq2.text = "7 WoodPlank[" + woodplank_count + "]";

if(lock_count >= 5 && woodplank_count >= 7)
{
craftStorageBoxLargeBTN.gameObject.SetActive(true);
}
else
{
  craftStorageBoxLargeBTN.gameObject.SetActive(false);
}

//Chair Button
ChairReq1.text = "3 WoodPlank[" + woodplank_count + "]";
ChairReq2.text = "2 Nails[" + nails_count + "]";

if(woodplank_count >= 3 && nails_count >= 2)
{
craftChairBTN.gameObject.SetActive(true);
}
else
{
  craftChairBTN.gameObject.SetActive(false);
}

//ChairType2 Button
ChairType2Req1.text = "3 WoodPlank[" + woodplank_count + "]";
ChairType2Req2.text = "3 Fabric[" + fabric_count + "]";

if(woodplank_count >= 3 && fabric_count >= 3)
{
craftChairType2BTN.gameObject.SetActive(true);
}
else
{
  craftChairType2BTN.gameObject.SetActive(false);
}


//Lamp Button
LampReq1.text = "2 Iron Beams[" + ironbeams_count + "]";
LampReq2.text = "2 Batteries[" + batteries_count + "]";

if(ironbeams_count >= 2 && batteries_count >= 2)
{
craftLampBTN.gameObject.SetActive(true);
}
else
{
  craftLampBTN.gameObject.SetActive(false);
}

//LampType2 Button
LampType2Req1.text = "2 Iron Beams[" + ironbeams_count + "]";
LampType2Req2.text = "2 Batteries[" + batteries_count + "]";

if(ironbeams_count >= 2 && batteries_count >= 2)
{
craftLampType2BTN.gameObject.SetActive(true);
}
else
{
  craftLampType2BTN.gameObject.SetActive(false);
}

//LampType3 Button
LampType3Req1.text = "1 Iron Beams[" + ironbeams_count + "]";
LampType3Req2.text = "1 Batteries[" + batteries_count + "]";

if(ironbeams_count >= 1 && batteries_count >= 1)
{
craftLampType3BTN.gameObject.SetActive(true);
}
else
{
  craftLampType3BTN.gameObject.SetActive(false);
}

//Table Button
TableReq1.text = "3 WoodPlank[" + woodplank_count + "]";
TableReq2.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 3 && nails_count >= 3)
{
craftTableBTN.gameObject.SetActive(true);
}
else
{
  craftTableBTN.gameObject.SetActive(false);
}

//TableType2 Button
TableType2Req1.text = "4 WoodPlank[" + woodplank_count + "]";
TableType2Req2.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 4 && nails_count >= 3)
{
craftTableType2BTN.gameObject.SetActive(true);
}
else
{
  craftTableType2BTN.gameObject.SetActive(false);
}

//TableType3 Button
TableType3Req1.text = "4 WoodPlank[" + woodplank_count + "]";
TableType3Req2.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 4 && nails_count >= 3)
{
craftTableType3BTN.gameObject.SetActive(true);
}
else
{
  craftTableType3BTN.gameObject.SetActive(false);
}

//NightStand Button
NightStandReq1.text = "2 WoodPlank[" + woodplank_count + "]";
NightStandReq2.text = "2 Glue[" + glue_count + "]";

if(woodplank_count >= 2 && glue_count >= 2)
{
craftNightStandBTN.gameObject.SetActive(true);
}
else
{
  craftNightStandBTN.gameObject.SetActive(false);
}

//NightStandType2 Button
NightStandType2Req1.text = "3 WoodPlank[" + woodplank_count + "]";
NightStandType2Req2.text = "2 Glue[" + glue_count + "]";

if(woodplank_count >= 3 && glue_count >= 2)
{
craftNightStandType2BTN.gameObject.SetActive(true);
}
else
{
  craftNightStandType2BTN.gameObject.SetActive(false);
}

//Bed Button
BedReq1.text = "3 WoodPlank[" + woodplank_count + "]";
BedReq2.text = "3 Fabric[" + fabric_count + "]";
BedReq3.text = "2 Nails[" + nails_count + "]";

if(woodplank_count >= 3 && fabric_count >= 3 && nails_count >=2)
{
craftBedBTN.gameObject.SetActive(true);
}
else
{
  craftBedBTN.gameObject.SetActive(false);
}

//BedType2 Button
BedType2Req1.text = "4 WoodPlank[" + woodplank_count + "]";
BedType2Req2.text = "3 Fabric[" + fabric_count + "]";
BedType2Req3.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 4 && fabric_count >= 3 && nails_count >=3)
{
craftBedType2BTN.gameObject.SetActive(true);
}
else
{
  craftBedType2BTN.gameObject.SetActive(false);
}

//BookShelf Button
BookShelfReq1.text = "4 WoodPlank[" + woodplank_count + "]";
BookShelfReq2.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 4 && nails_count >= 3)
{
craftBookShelfBTN.gameObject.SetActive(true);
}
else
{
  craftBookShelfBTN.gameObject.SetActive(false);
}

//BookSHelfType2 Button
BookShelfType2Req1.text = "4 WoodPlank[" + woodplank_count + "]";
BookShelfType2Req2.text = "3 Nails[" + nails_count + "]";

if(woodplank_count >= 4 && nails_count >= 3)
{
craftBookShelfType2BTN.gameObject.SetActive(true);
}
else
{
  craftBookShelfType2BTN.gameObject.SetActive(false);
}

//Couch Button
CouchReq1.text = "3 Fabric[" + fabric_count + "]";
CouchReq2.text = "3 Glue[" + glue_count + "]";

if(fabric_count >= 3 && glue_count >= 3)
{
craftCouchBTN.gameObject.SetActive(true);
}
else
{
  craftCouchBTN.gameObject.SetActive(false);
}

//CouchType2 Button
CouchType2Req1.text = "4 Fabric[" + fabric_count + "]";
CouchType2Req2.text = "4 Glue[" + glue_count + "]";

if(fabric_count >= 4 && glue_count >= 4)
{
craftCouchType2BTN.gameObject.SetActive(true);
}
else
{
  craftCouchType2BTN.gameObject.SetActive(false);
}

//CraftSink Button
SinkReq1.text = "2 Iron Beams[" + ironbeams_count + "]";
SinkReq2.text = "3 Nails[" + nails_count + "]";

if(ironbeams_count >= 2 && nails_count >= 3)
{
craftSinkBTN.gameObject.SetActive(true);
}
else
{
  craftSinkBTN.gameObject.SetActive(false);
}

//craftWasher Button
WasherReq1.text = "3 Components[" + components_count + "]";
WasherReq2.text = "3 Iron Beams[" + ironbeams_count + "]";

if(components_count >= 3 && ironbeams_count >= 3)
{
craftWasherBTN.gameObject.SetActive(true);
}
else
{
  craftWasherBTN.gameObject.SetActive(false);
}

//craftFridge Button
FridgeReq1.text = "2 Iron Beams[" + ironbeams_count + "]";
FridgeReq2.text = "3 Batteries[" + batteries_count + "]";

if(ironbeams_count >= 2 && batteries_count >= 3)
{
craftFridgeBTN.gameObject.SetActive(true);
}
else
{
  craftFridgeBTN.gameObject.SetActive(false);
}

//craftTV Button
TVReq1.text = "3 Components[" + components_count + "]";
TVReq2.text = "3 Polymer[" + polymer_count + "]";

if(components_count >= 3 && polymer_count >= 3)
{
craftTVBTN.gameObject.SetActive(true);
}
else
{
  craftTVBTN.gameObject.SetActive(false);
}

//upgrades

//house1upgradebutton
house1Req1.text = "5 Log[" + log_count + "]";
house1Req2.text = "5 Nails[" + nails_count + "]";
house1Req3.text = "5 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 5 && nails_count >= 5 && ironbeams_count >= 5)
{
upgradehouse1BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse1BTN.gameObject.SetActive(false);
}

//house2upgradebutton
house2Req1.text = "8 WoodPlank[" + woodplank_count + "]";
house2Req2.text = "5 Nails[" + nails_count + "]";
house2Req3.text = "6 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 8 && nails_count >= 5 && ironbeams_count >= 6)
{
upgradehouse2BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse2BTN.gameObject.SetActive(false);
}

//house3upgradebutton
house3Req1.text = "7 Log[" + log_count + "]";
house3Req2.text = "5 Nails[" + nails_count + "]";
house3Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && nails_count >= 5 && ironbeams_count >= 7)
{
upgradehouse3BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse3BTN.gameObject.SetActive(false);
}

//house11upgradebutton
house11Req1.text = "5 Log[" + log_count + "]";
house11Req2.text = "5 Nails[" + nails_count + "]";
house11Req3.text = "5 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 5 && nails_count >= 5 && ironbeams_count >= 5)
{
upgradehouse11BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse11BTN.gameObject.SetActive(false);
}

//house22upgradebutton
house22Req1.text = "8 WoodPlank[" + woodplank_count + "]";
house22Req2.text = "5 Nails[" + nails_count + "]";
house22Req3.text = "6 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 8 && nails_count >= 5 && ironbeams_count >= 6)
{
upgradehouse22BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse22BTN.gameObject.SetActive(false);
}

//house33upgradebutton
house33Req1.text = "7 Log[" + log_count + "]";
house33Req2.text = "5 Nails[" + nails_count + "]";
house33Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && nails_count >= 5 && ironbeams_count >= 7)
{
upgradehouse33BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse33BTN.gameObject.SetActive(false);
}

//house111upgradebutton
house111Req1.text = "5 Log[" + log_count + "]";
house111Req2.text = "5 Nails[" + nails_count + "]";
house111Req3.text = "5 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 5 && nails_count >= 5 && ironbeams_count >= 5)
{
upgradehouse111BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse111BTN.gameObject.SetActive(false);
}

//house22upgradebutton
house222Req1.text = "8 WoodPlank[" + woodplank_count + "]";
house222Req2.text = "5 Nails[" + nails_count + "]";
house222Req3.text = "6 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 8 && nails_count >= 5 && ironbeams_count >= 6)
{
upgradehouse222BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse222BTN.gameObject.SetActive(false);
}

//house33upgradebutton
house333Req1.text = "7 Log[" + log_count + "]";
house333Req2.text = "5 Nails[" + nails_count + "]";
house333Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && nails_count >= 5 && ironbeams_count >= 7)
{
upgradehouse333BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse333BTN.gameObject.SetActive(false);
}

//house4upgradebutton
house4Req1.text = "7 Log[" + log_count + "]";
house4Req2.text = "5 Glue[" + glue_count + "]";
house4Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse4BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse4BTN.gameObject.SetActive(false);
}

//house4upgradebutton
house44Req1.text = "7 Log[" + log_count + "]";
house44Req2.text = "5 Glue[" + glue_count + "]";
house44Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse44BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse44BTN.gameObject.SetActive(false);
}

//house4upgradebutton
house444Req1.text = "7 Log[" + log_count + "]";
house444Req2.text = "5 Glue[" + glue_count + "]";
house444Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse444BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse444BTN.gameObject.SetActive(false);
}

//house5upgradebutton
house5Req1.text = "7 WoodPlank[" + woodplank_count + "]";
house5Req2.text = "5 Glue[" + glue_count + "]";
house5Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse5BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse5BTN.gameObject.SetActive(false);
}

//house5upgradebutton
house55Req1.text = "7 WoodPlank[" + woodplank_count + "]";
house55Req2.text = "5 Glue[" + glue_count + "]";
house55Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse55BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse55BTN.gameObject.SetActive(false);
}

//house5upgradebutton
house555Req1.text = "7 WoodPlank[" + woodplank_count + "]";
house555Req2.text = "5 Glue[" + glue_count + "]";
house555Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(woodplank_count >= 7 && glue_count >= 5 && ironbeams_count >= 7)
{
upgradehouse555BTN.gameObject.SetActive(true);
}
else
{
  upgradehouse555BTN.gameObject.SetActive(false);
}

//church1upgradebutton
church1Req1.text = "7 Nails[" + nails_count + "]";
church1Req2.text = "5 Fabric[" + fabric_count + "]";
church1Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(nails_count >= 7 && fabric_count >= 5 && ironbeams_count >= 7)
{
upgradechurch1BTN.gameObject.SetActive(true);
}
else
{
  upgradechurch1BTN.gameObject.SetActive(false);
}

//church11upgradebutton
church11Req1.text = "7 Nails[" + nails_count + "]";
church11Req2.text = "5 Fabric[" + fabric_count + "]";
church11Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(nails_count >= 7 && fabric_count >= 5 && ironbeams_count >= 7)
{
upgradechurch11BTN.gameObject.SetActive(true);
}
else
{
  upgradechurch11BTN.gameObject.SetActive(false);
}

//church111upgradebutton
church111Req1.text = "7 Nails[" + nails_count + "]";
church111Req2.text = "5 Fabric[" + fabric_count + "]";
church111Req3.text = "7 Iron Beams[" + ironbeams_count + "]";

if(nails_count >= 7 && fabric_count >= 5 && ironbeams_count >= 7)
{
upgradechurch111BTN.gameObject.SetActive(true);
}
else
{
  upgradechurch111BTN.gameObject.SetActive(false);
}

//Lights1upgradebutton
lights1Req1.text = "7 Nails[" + nails_count + "]";
lights1Req2.text = "7 Fuel[" + fuel_count + "]";
lights1Req3.text = "7 Log[" + log_count + "]";

if(nails_count >= 7 && fuel_count >= 7 && log_count >= 7)
{
upgradelights1BTN.gameObject.SetActive(true);
}
else
{
  upgradelights1BTN.gameObject.SetActive(false);
}

//Lights11upgradebutton
lights11Req1.text = "7 Nails[" + nails_count + "]";
lights11Req2.text = "7 Fuel[" + fuel_count + "]";
lights11Req3.text = "7 Log[" + log_count + "]";

if(nails_count >= 7 && fuel_count >= 7 && log_count >= 7)
{
upgradelights11BTN.gameObject.SetActive(true);
}
else
{
  upgradelights11BTN.gameObject.SetActive(false);
}

//Lights1upgradebutton
lights111Req1.text = "7 Nails[" + nails_count + "]";
lights111Req2.text = "7 Fuel[" + fuel_count + "]";
lights111Req3.text = "7 Log[" + log_count + "]";

if(nails_count >= 7 && fuel_count >= 7 && log_count >= 7)
{
upgradelights111BTN.gameObject.SetActive(true);
}
else
{
  upgradelights111BTN.gameObject.SetActive(false);
}

//Floor1upgradebutton
floor1Req1.text = "10 Nails[" + nails_count + "]";
floor1Req2.text = "10 WoodPlank[" + woodplank_count + "]";

if(nails_count >= 10 && woodplank_count >= 10)
{
upgradefloor1BTN.gameObject.SetActive(true);
}
else
{
  upgradefloor1BTN.gameObject.SetActive(false);
}

//Floor1upgradebutton
floor11Req1.text = "10 Nails[" + nails_count + "]";
floor11Req2.text = "10 WoodPlank[" + woodplank_count + "]";

if(nails_count >= 10 && woodplank_count >= 10)
{
upgradefloor11BTN.gameObject.SetActive(true);
}
else
{
  upgradefloor11BTN.gameObject.SetActive(false);
}

//Floor1upgradebutton
floor111Req1.text = "10 Nails[" + nails_count + "]";
floor111Req2.text = "10 WoodPlank[" + woodplank_count + "]";

if(nails_count >= 10 && woodplank_count >= 10)
{
upgradefloor111BTN.gameObject.SetActive(true);
}
else
{
  upgradefloor111BTN.gameObject.SetActive(false);
}

//Lights1upgradebutton
market1Req1.text = "10 Gold Ingot[" + goldingot_count + "]";
market1Req2.text = "6 Emerald Ingot[" + emeraldingot_count + "]";
market1Req3.text = "6 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 10 && emeraldingot_count >= 6 && ironingot_count >= 6)
{
upgrademarket1BTN.gameObject.SetActive(true);
}
else
{
  upgrademarket1BTN.gameObject.SetActive(false);
}

market11Req1.text = "10 Gold Ingot[" + goldingot_count + "]";
market11Req2.text = "6 Emerald Ingot[" + emeraldingot_count + "]";
market11Req3.text = "6 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 10 && emeraldingot_count >= 6 && ironingot_count >= 6)
{
upgrademarket11BTN.gameObject.SetActive(true);
}
else
{
  upgrademarket11BTN.gameObject.SetActive(false);
}

market111Req1.text = "10 Gold Ingot[" + goldingot_count + "]";
market111Req2.text = "6 Emerald Ingot[" + emeraldingot_count + "]";
market111Req3.text = "6 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 10 && emeraldingot_count >= 6 && ironingot_count >= 6)
{
upgrademarket111BTN.gameObject.SetActive(true);
}
else
{
  upgrademarket111BTN.gameObject.SetActive(false);
}

userhouse1Req1.text = "5 Gold Ingot[" + goldingot_count + "]";
userhouse1Req2.text = "3 Components[" + components_count + "]";
userhouse1Req3.text = "5 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 5 && components_count >= 3 && ironingot_count >= 5)
{
upgradeuserhouse1BTN.gameObject.SetActive(true);
}
else
{
  upgradeuserhouse1BTN.gameObject.SetActive(false);
}

userhouse11Req1.text = "5 Gold Ingot[" + goldingot_count + "]";
userhouse11Req2.text = "3 Components[" + components_count + "]";
userhouse11Req3.text = "5 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 5 && components_count >= 3 && ironingot_count >= 5)
{
upgradeuserhouse11BTN.gameObject.SetActive(true);
}
else
{
  upgradeuserhouse11BTN.gameObject.SetActive(false);
}

userhouse111Req1.text = "5 Gold Ingot[" + goldingot_count + "]";
userhouse111Req2.text = "3 Components[" + components_count + "]";
userhouse111Req3.text = "5 Iron Ingot[" + ironingot_count + "]";

if(goldingot_count >= 5 && components_count >= 3 && ironingot_count >= 5)
{
upgradeuserhouse111BTN.gameObject.SetActive(true);
}
else
{
  upgradeuserhouse111BTN.gameObject.SetActive(false);
}

watertower1Req1.text = "5 Log[" + log_count + "]";
watertower1Req2.text = "5 Nails[" + nails_count + "]";
watertower1Req3.text = "8 Water[" + water_count + "]";

if(log_count >= 5 && nails_count >= 5 && water_count >= 8)
{
upgradewatertower1BTN.gameObject.SetActive(true);
}
else
{
  upgradewatertower1BTN.gameObject.SetActive(false);
}

watertower11Req1.text = "5 Log[" + log_count + "]";
watertower11Req2.text = "5 Nails[" + nails_count + "]";
watertower11Req3.text = "8 Water[" + water_count + "]";

if(log_count >= 5 && nails_count >= 5 && water_count >= 8)
{
upgradewatertower11BTN.gameObject.SetActive(true);
}
else
{
  upgradewatertower11BTN.gameObject.SetActive(false);
}

watertower111Req1.text = "5 Log[" + log_count + "]";
watertower111Req2.text = "5 Nails[" + nails_count + "]";
watertower111Req3.text = "8 Water[" + water_count + "]";

if(log_count >= 5 && nails_count >= 5 && water_count >= 8)
{
upgradewatertower111BTN.gameObject.SetActive(true);
}
else
{
  upgradewatertower111BTN.gameObject.SetActive(false);
}

windmill1Req1.text = "5 Log[" + log_count + "]";
windmill1Req2.text = "5 Nails[" + nails_count + "]";
windmill1Req3.text = "6 Iron Beams[" + ironbeams_count + "]";

if(log_count >= 5 && nails_count >= 5 && ironbeams_count >= 6)
{
upgradewindmill1BTN.gameObject.SetActive(true);
}
else
{
  upgradewindmill1BTN.gameObject.SetActive(false);
}





}
}
