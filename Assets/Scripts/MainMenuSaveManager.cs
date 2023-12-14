using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.SceneUtils;
using static EnvirmentalData;

public class MainMenuSaveManager : MonoBehaviour
{
    public static MainMenuSaveManager Instance { get; private set; }

    public bool isSavingToJson;
    

    //Json Project Save Path
    string jsonPathProject;

    //Json External/Real Save path
    string jsonPathPersistant;

    //Binary Save Path
    string binaryPath;

    public bool isLoading;

    public Canvas loadingScreen;


string fileName = "SaveGame";
    public void Start()
    {
        binaryPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
        jsonPathPersistant = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
        jsonPathProject = Application.dataPath + Path.AltDirectorySeparatorChar;
    }

#region || -------- General Section -------- ||

public void SaveGame(int slotNumber)
{
    AllGameData data = new AllGameData();

    data.playerData = GetPlayerData();

    data.envirmentalData = GetEnvirmentalData();

    SelectSavingType(data, slotNumber);
}

private EnvirmentalData GetEnvirmentalData()
{
    List<string> itemsPickedup = InventorySystem.Instance.itemsPickedup;

    List<StorageData> allstorage = new List<StorageData>();
    foreach(Transform placeable in EnviromentManager.Instance.Placables.transform)
    {
        if (placeable.gameObject.GetComponent<StorageBox>())
        {
            var sd = new StorageData();
            sd.items = placeable.gameObject.GetComponent<StorageBox>().items;
            sd.position = placeable.position;
            sd.rotation = new Vector3(placeable.rotation.x, placeable.rotation.y, placeable.rotation.z);

            allstorage.Add(sd);
        }
    }

    return new EnvirmentalData(itemsPickedup, allstorage);
}

private PlayerData GetPlayerData()
{
    float[] playerStats = new float[3];
    playerStats[0] = PlayerState.Instance.currentHealth;
    playerStats[1] = PlayerState.Instance.currentCalories;
    playerStats[2] = PlayerState.Instance.currentHydration;

    float[] playerPosAndRot = new float[6];
    playerPosAndRot[0] = PlayerState.Instance.playerBody.transform.position.x;
    playerPosAndRot[1] = PlayerState.Instance.playerBody.transform.position.y;
    playerPosAndRot[2] = PlayerState.Instance.playerBody.transform.position.z;

    playerPosAndRot[3] = PlayerState.Instance.playerBody.transform.rotation.x;
    playerPosAndRot[4] = PlayerState.Instance.playerBody.transform.rotation.y;
    playerPosAndRot[5] = PlayerState.Instance.playerBody.transform.rotation.z;

    string[] inventory = InventorySystem.Instance.itemList.ToArray();

    string[] quickSlots = GetQuickSlotsContent();

    return new PlayerData(playerStats, playerPosAndRot, inventory, quickSlots);
}

private string[] GetQuickSlotsContent()
{
    List<string> temp = new List<string>();

    foreach (GameObject slot in EquipSystem.Instance.quickSlotsList)
    {
        if (slot.transform.childCount != 0)
        {
            string name = slot.transform.GetChild(0).name;
            string str2 = "(Clone)";
            string cleanName = name.Replace(str2, "");
            temp.Add(cleanName);
        }
    }

    return temp.ToArray();
}
    public void SelectSavingType(AllGameData gameData, int slotNumber)
    {
      if (isSavingToJson)
      {
       SaveGameDataToJsonFile(gameData, slotNumber);
      }
      else
      {
        SaveGameDataToBinaryFile(gameData, slotNumber);
      }
    }

public AllGameData SelectLoadingType(int slotNumber)
{
    if (isSavingToJson)
    {
        AllGameData gameData = LoadGameDataFromJsonFile(slotNumber);
        return gameData;
    }
    else
    {
        AllGameData gameData = LoadGameDataFromBinaryFile(slotNumber);
        return gameData;
    }
}

public void LoadGame(int slotNumber)
{
    //PlayerData
    SetPlayerData(SelectLoadingType(slotNumber).playerData);

    //EnviromentData
    SetEnvirmentalData(SelectLoadingType(slotNumber).envirmentalData);

    DisableLoadingScreen();
}

private void SetEnvirmentalData(EnvirmentalData envirmentalData)
{
    foreach(Transform itemType in Collectables.Instance.allItems.transform)
    {
        foreach (Transform item in itemType.transform)
        {
            if (envirmentalData.pickedupItems.Contains(item.name))
            {
                Destroy(item.gameObject);
            }
        }
    }

    InventorySystem.Instance.itemsPickedup = envirmentalData.pickedupItems;


    //Set storage box data 
    foreach (StorageData storage in envirmentalData.storage)
    {
        var StorageBoxPrefab = Instantiate(Resources.Load<GameObject>("StorageBoxSmallModel"),
        new Vector3(storage.position.x, storage.position.y, storage.position.z),
        Quaternion.Euler(storage.rotation.x, storage.rotation.y, storage.rotation.z));

        var StorageBoxMPrefab = Instantiate(Resources.Load<GameObject>("StorageBoxMediumModel"),
        new Vector3(storage.position.x, storage.position.y, storage.position.z),
        Quaternion.Euler(storage.rotation.x, storage.rotation.y, storage.rotation.z));

        var StorageBoxLPrefab = Instantiate(Resources.Load<GameObject>("StorageBoxLargeModel"),
        new Vector3(storage.position.x, storage.position.y, storage.position.z),
        Quaternion.Euler(storage.rotation.x, storage.rotation.y, storage.rotation.z));

        StorageBoxMPrefab.GetComponent<StorageBox>().items = storage.items;
        StorageBoxLPrefab.GetComponent<StorageBox>().items = storage.items;
        StorageBoxPrefab.GetComponent<StorageBox>().items = storage.items;

        StorageBoxPrefab.transform.SetParent(EnviromentManager.Instance.Placables.transform);
         StorageBoxMPrefab.transform.SetParent(EnviromentManager.Instance.Placables.transform);
          StorageBoxLPrefab.transform.SetParent(EnviromentManager.Instance.Placables.transform);
    }
    }

private void SetPlayerData(PlayerData playerData)
{
//Setting Player Stats

PlayerState.Instance.currentHealth = playerData.playerStats[0];
PlayerState.Instance.currentCalories = playerData.playerStats[1];
PlayerState.Instance.currentHydration = playerData.playerStats[2];

//Setting Player Position

Vector3 loadedPosition;
loadedPosition.x = playerData.playerPositionAndRotation[0];
loadedPosition.y = playerData.playerPositionAndRotation[1];
loadedPosition.z = playerData.playerPositionAndRotation[2];

PlayerState.Instance.playerBody.transform.position = loadedPosition;

//Setting Player Rotation
Vector3 loadedRotation;
loadedRotation.x = playerData.playerPositionAndRotation[3];
loadedRotation.y = playerData.playerPositionAndRotation[4];
loadedRotation.z = playerData.playerPositionAndRotation[5];

PlayerState.Instance.playerBody.transform.rotation = Quaternion.Euler(loadedRotation);


//Setting the inventory content
foreach (string item in playerData.inventoryContent)
{
    InventorySystem.Instance.AddToInventory(item);
}


//Setting the quickslots Content
foreach(string item in playerData.quickSlotsContent)
{
    //Fine Next Free Quicksslot
    GameObject availableSlot = EquipSystem.Instance.FindNextEmptySlot();

    var itemToAdd = Instantiate(Resources.Load<GameObject>(item));

    itemToAdd.transform.SetParent(availableSlot.transform, false);
}
}

public void StartLoadedGame(int slotNumber)
{
    ActivateLoadingScreen();
    SceneManager.LoadScene("SampleScene");
    StartCoroutine(DelayedLoading(slotNumber));
    
}

IEnumerator DelayedLoading(int slotNumber)
{
    yield return new WaitForSeconds(1f);
    LoadGame(slotNumber);
}

    #endregion

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


#region || -------- Settings Section -------- ||
    public void SaveAllSettings(float volume, float brightness, int toggleState, int dropdownIndex)
    {
        SaveVolume(volume);
        SaveBrightness(brightness);
        SaveToggleState(toggleState);
        SaveDropdownIndex(dropdownIndex);
    }

    public void LoadAllSettings(out float volume, out float brightness, out int toggleState, out int dropdownIndex)
    {
        volume = LoadVolume();
        brightness = LoadBrightness();
        toggleState = LoadToggleState();
        dropdownIndex = LoadDropdownIndex();
    }

    public void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();
    }

    public float LoadVolume()
    {
        return PlayerPrefs.GetFloat("GameVolume");
    }

    public void SaveBrightness(float brightness)
    {
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }

    public float LoadBrightness()
    {
        return PlayerPrefs.GetFloat("Brightness");
    }

    public void SaveToggleState(int toggleState)
    {
        PlayerPrefs.SetInt("ToggleState", toggleState);
        PlayerPrefs.Save();
    }

    public int LoadToggleState()
    {
        return PlayerPrefs.GetInt("ToggleState");
    }

    public void SaveDropdownIndex(int dropdownIndex)
    {
        PlayerPrefs.SetInt("DropdownIndex", dropdownIndex);
        PlayerPrefs.Save();
    }

    public int LoadDropdownIndex()
    {
        return PlayerPrefs.GetInt("DropdownIndex");
    }

    #endregion



#region || -------- To Binary Section -------- ||


public void SaveGameDataToBinaryFile(AllGameData gameData, int slotNumber)
{
BinaryFormatter formatter = new BinaryFormatter();


FileStream stream = new FileStream(binaryPath + fileName + slotNumber + ".bin", FileMode.Create);

formatter.Serialize(stream, gameData);
stream.Close();

print("Data saved to" + binaryPath + fileName + slotNumber + ".bin");
}

public AllGameData LoadGameDataFromBinaryFile(int slotNumber)
{

    if(File.Exists(binaryPath + fileName + slotNumber + ".bin"))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(binaryPath + fileName + slotNumber + ".bin", FileMode.Open);

        AllGameData data = formatter.Deserialize(stream) as AllGameData;
        stream.Close();

        print("Game Loaded" + binaryPath + fileName + slotNumber + ".bin");

        return data;
    }
    else
    {
     return  null;
    }
}
#endregion


#region || -------- To Json Section -------- ||


public void SaveGameDataToJsonFile(AllGameData gameData, int slotNumber)
{
string json = JsonUtility.ToJson(gameData);

string encrypted = EncryptionDecryption(json);

using (StreamWriter writer = new StreamWriter(jsonPathProject + fileName + slotNumber + ".json"))//Replace right before build
{
    writer.Write(encrypted);
    print("Saved Game to Json file at :" + jsonPathProject + fileName + slotNumber + ".json");//replace before build
};
}

public AllGameData LoadGameDataFromJsonFile(int slotNumber)
{
 using (StreamReader reader = new StreamReader(jsonPathProject + fileName + slotNumber + ".json"))//Replace Right before Build
 {
    string json = reader.ReadToEnd();

    string decrypted = EncryptionDecryption(json);

    AllGameData data = JsonUtility.FromJson<AllGameData>(decrypted);
    return data;
 };
}

//Encryption

public string EncryptionDecryption(string jsonString)
{
    string keyword = "1234567";
    string result = "";

    for (int i = 0; i < jsonString.Length; i++)
    {
        result += (char)(jsonString[i] ^ keyword[i % keyword.Length]);
    }
    return result;

    //XOR = "is there a difference"

    // --- Encrypt ---
}
#endregion


#region  || -------- Utility -------- ||

public bool DoesFileExists(int slotNumber)
{
    if (isSavingToJson)
    {
        if (System.IO.File.Exists(jsonPathProject + fileName + slotNumber + ".json"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        if (System.IO.File.Exists(binaryPath + fileName + slotNumber + ".bin"))
        {
          return true;
        }
        else
        {
           return false;
        }
    }
}

 public bool IsSlotEmpty(int slotNumber)
    {
        if (DoesFileExists(slotNumber))
        {
         return false;
        }
        else
        {
            return true;
        }
    }

        public void DeselectButton()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }


#endregion

public void ActivateLoadingScreen()
{
loadingScreen.gameObject.SetActive(true);

Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
}

public void DisableLoadingScreen()
{
loadingScreen.gameObject.SetActive(false);
}
    // ... (existing code)

    public int GetMostRecentSaveSlot()
    {
        // Get all file paths in the save directory
        string[] saveFiles;
        if (isSavingToJson)
        {
            saveFiles = Directory.GetFiles(jsonPathProject, fileName + "*.json");
        }
        else
        {
            saveFiles = Directory.GetFiles(binaryPath, fileName + "*.bin");
        }

        // Extract timestamps from file names
        List<string> timestamps = new List<string>();
        foreach (string filePath in saveFiles)
        {
            string timestamp = GetTimestampFromFileName(filePath);
            if (!string.IsNullOrEmpty(timestamp))
            {
                timestamps.Add(timestamp);
            }
        }

        // Sort timestamps in descending order
        timestamps.Sort((a, b) => string.Compare(b, a));

        // If there are any valid timestamps, return the corresponding slot number
        if (timestamps.Count > 0)
        {
            string mostRecentTimestamp = timestamps[0];
            return GetSlotNumberFromTimestamp(mostRecentTimestamp);
        }

        // Return a default slot number (you can customize this behavior)
        return 1;
    }

    private string GetTimestampFromFileName(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string[] parts = fileName.Split('_');
        if (parts.Length == 2)
        {
            return parts[1];
        }
        return null;
    }

    private int GetSlotNumberFromTimestamp(string timestamp)
    {
        int slotNumber;
        if (int.TryParse(timestamp, out slotNumber))
        {
            return slotNumber;
        }
        return 1; // Default slot number if parsing fails
    }

}