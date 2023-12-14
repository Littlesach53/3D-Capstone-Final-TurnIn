using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoForge : MonoBehaviour
{

    public Checkpoint GoToForge;
public void OnTriggerEnter(Collider other)
{
if (other.gameObject.CompareTag("Player"))
{
GoToForge.isCompleted = true;
}
}
}
