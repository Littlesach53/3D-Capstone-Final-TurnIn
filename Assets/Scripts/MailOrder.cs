using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailOrder : MonoBehaviour
{
    public Checkpoint Mail;
    // Start is called before the first frame update    public Checkpoint GoToForge;
public void OnTriggerEnter(Collider other)
{
if (other.gameObject.CompareTag("Player"))
{
Mail.isCompleted = true;
}
}
}
