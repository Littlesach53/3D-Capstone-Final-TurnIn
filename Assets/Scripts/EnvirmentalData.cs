using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnvirmentalData 
{

    public List<string> pickedupItems;

    public List<StorageData> storage;
 public EnvirmentalData(List<string> _pickedupItems, List<StorageData> _storage)
 {
pickedupItems = _pickedupItems;
storage = _storage;
 }

 [System.Serializable]
public class StorageData
{
     public List<string> items;
    public Vector3 position;
    public Vector3 rotation;
}
}