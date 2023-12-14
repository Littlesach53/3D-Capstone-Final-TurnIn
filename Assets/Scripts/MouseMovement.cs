using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
 
    public float mouseSensitivity = 100f;
 
    float xRotation = 0f;
    float YRotation = 0f;
 
    void Start()
    {
      //Locking the cursor to the middle of the screen and making it invisible
      Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {

       if(!InventorySystem.Instance.isOpen && !CraftingSystem.Instance.isOpen && !SmeltingSystem.Instance.isUiOpen && !StorageManager.Instance.storageUIOpen && !DialogSystem.Instance.dialogUIActive && !QuestManager.Instance.isQuestMenuOpen && !MenuManager.Instance.isMenuOpen)// add back  && !MenuManager.Instance.isMenuOpen && !StorageManager.Instance.storageUIOpen
     {
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
       //control rotation around x axis (Look up and down)
       xRotation -= mouseY;
 
       //we clamp the rotation so we cant Over-rotate (like in real life)
       xRotation = Mathf.Clamp(xRotation, -80f, 80f);
 
       //control rotation around y axis (Look up and down)
       YRotation += mouseX;
 
       //applying both rotations
       transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
       }
 
    }
}
