using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class EquippableItem : MonoBehaviour
{
    public bool swingWait = false;
    public AudioSource aud;
    public AudioClip clip;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && InventorySystem.Instance.isOpen == false
        && CraftingSystem.Instance.isOpen == false && SelectionManager.Instance.handisVisible == false 
        && swingWait == false)// left Mouse Button
        {
            swingWait = true;
         animator.SetTrigger("Hit");
         aud.PlayOneShot(clip);

         StartCoroutine(NewSwingDelay());
        }
    }

    IEnumerator NewSwingDelay()
    {
        yield return new WaitForSeconds(1f); // delay is hard coded for axe
        swingWait = false;
    }
}
