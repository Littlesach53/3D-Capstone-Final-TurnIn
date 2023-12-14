using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilingUpgrade : MonoBehaviour
{
public bool playerInRange;

public enum UpgradeType
{
    house1,
    house11,
    house111,
    house2,
    house22,
    house222,
    house33,
    house3,
    house333,
    house4,
    house44,
    house444,
    house5,
    house55,
    house555,
    watertower1,
    watertower11,
    watertower111,
    church1,
    church11,
    church111,
    userhouse1,
    userhouse11,
    userhouse111,
    lights1,
    lights11,
    lights111,
    floor1,
    floor11,
    floor111,
    market1,
    market11,
    market111,

    windmill1

}

public UpgradeType thisUpgradableType;

private void Update()
{
    float distance = Vector3.Distance(PlayerState.Instance.playerBody.transform.position, transform.position);

    if (distance < 10f)
    {
        playerInRange = true;
    }
    else
    {
        playerInRange = false;
    }

}

public void OnTriggerEnter(Collider other)
{
    BuilingUpgrade builingUpgrade = this.GetComponent<BuilingUpgrade>();

    if (other.CompareTag("Player"))
        {
             playerInRange = true;
           UpgradeManager.Instance.OpenBox(builingUpgrade);

        }
}

public void OnTriggerExit(Collider other)
{
      BuilingUpgrade builingUpgrade = this.GetComponent<BuilingUpgrade>();

    if (other.CompareTag("Player"))
        {
             playerInRange = false;
           UpgradeManager.Instance.CloseBox();

        }
}
}