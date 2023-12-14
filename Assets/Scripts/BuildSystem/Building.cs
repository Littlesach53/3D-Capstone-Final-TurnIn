using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
 private Renderer _renderer;
 public Material defaultMat;
 private bool flaggedForDelete;
 public bool FlaggedForDelete => flaggedForDelete;

 private void Start()
 {
    _renderer = GetComponentInChildren<Renderer>();
    if(_renderer) defaultMat = _renderer.material;
 }

 public void UpdateMaterial(Material newMaterial)
 {
    if (_renderer.material != newMaterial) _renderer.material = newMaterial;

 }

 public void PlaceBuilding()
 {
     _renderer = GetComponentInChildren<Renderer>();
   // if(_renderer) defaultMat = _renderer.material;
    UpdateMaterial(defaultMat);
 }

 public void FlagForDelete(Material deleteMat)
 {
    UpdateMaterial(deleteMat);
    flaggedForDelete = true;
 }

 public void RemoveDeleteFlag()
 {
    UpdateMaterial(defaultMat);
    flaggedForDelete = false;
 }
}
