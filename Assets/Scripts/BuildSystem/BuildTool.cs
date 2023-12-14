using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildTool : MonoBehaviour
{
    public static BuildTool Instance { get; set; }
 [SerializeField] private float rotateSnapAngle = 90f;
 [SerializeField] private float rayDistance;
 [SerializeField] private LayerMask buildModeLayerMask;
 [SerializeField] private LayerMask deleteModelLayerMask;
 [SerializeField] private int defaultLayerInt = 8;
 [SerializeField] private Transform rayOrigin;
 [SerializeField] private Material _buildingMatPositive;
 [SerializeField] private Material _buildingMatNegative;

 public InventoryItem Invi;

 private bool _deleteModeEnabled;
 private bool _buildModeEnabled;

 private Camera cam;

 [SerializeField] private Building spawnedBuilding;
 private Building targetBuilding;

private Quaternion lastRotation;

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


 private void Start()
 {
    cam = Camera.main;
    Invi = gameObject.GetComponent<InventoryItem>();
 }

 private void Update()
 {

    if (Input.GetKeyDown(KeyCode.Q)) _deleteModeEnabled = !_deleteModeEnabled;
    if(_deleteModeEnabled) DeleteModeLogic();

    
   if (Input.GetKeyDown(KeyCode.B)) _buildModeEnabled = !_buildModeEnabled;
  if (_buildModeEnabled) BuildModeLogic();

 }

 private bool IsRayHittingSomething(LayerMask layerMask, out RaycastHit hitInfo)
 {
    var ray = new Ray(rayOrigin.position, cam.transform.forward * rayDistance);
    return Physics.Raycast(ray, out hitInfo, rayDistance, layerMask);
 }



 public void BuildModeLogic()
 {
    
    if (targetBuilding != null && targetBuilding.FlaggedForDelete)
    {
        targetBuilding.RemoveDeleteFlag();
        targetBuilding = null;
    }
if (spawnedBuilding == null) return;

if (Input.GetKeyDown(KeyCode.R))
{
    spawnedBuilding.transform.Rotate(0, rotateSnapAngle, 0);
lastRotation = spawnedBuilding.transform.rotation;
}

if ( !IsRayHittingSomething(buildModeLayerMask, out RaycastHit hitInfo))
{
  //  spawnedBuilding.UpdateMaterial(_buildingMatNegative);
}
else 
{
  //   spawnedBuilding.UpdateMaterial(_buildingMatPositive);
     var gridPosition = WorldGrid.GridPositionFromWorldPoint3D(hitInfo.point, 1f);
spawnedBuilding.transform.position = gridPosition;

if (Input.GetKeyDown(KeyCode.Mouse0))
{
Building placedBuilding = Instantiate (spawnedBuilding, gridPosition, lastRotation);
placedBuilding.PlaceBuilding();

 }
}

 }


private void DeleteModeLogic()
{
    if (IsRayHittingSomething(deleteModelLayerMask, out RaycastHit hitInfo))
    {
        var detectedBuilding = hitInfo.collider.gameObject.GetComponentInParent<Building>();

        if (detectedBuilding != null)
        {
            if (targetBuilding == null)
            {
                targetBuilding = detectedBuilding;
            }

            if (detectedBuilding != targetBuilding && targetBuilding.FlaggedForDelete)
            {
                targetBuilding.RemoveDeleteFlag();
                targetBuilding = detectedBuilding;
            }

            if (detectedBuilding == targetBuilding && !targetBuilding.FlaggedForDelete)
            {
                targetBuilding.FlagForDelete(_buildingMatNegative);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(targetBuilding.gameObject);
                targetBuilding = null;
            }
        }
    }
    else
    {
        if (targetBuilding != null && targetBuilding.FlaggedForDelete)
        {
            targetBuilding.RemoveDeleteFlag();
            targetBuilding = null;
        }
    }
}
}