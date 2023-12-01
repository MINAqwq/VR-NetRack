using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.XR.CoreUtils.Bindings.Variables;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class pluggable : MonoBehaviour
{
    public GameObject self;
    private GameObject pluggedIntoThis;
    public TextMeshPro plugStateTextSelf;
    public TextMeshPro plugStateTextOther;
    private Rigidbody rb;
    private XRGrabInteractable interactableGrab;
    private bool pluggedIntoSomething = false;
    int unplugTimeout = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactableGrab = GetComponent<XRGrabInteractable>();
        resetText();
    }

    private void resetText()
    {
        plugStateTextSelf.text = "Unplugged";
        plugStateTextOther.text = "Unplugged";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pluggedIntoSomething)
        {
            // Make it grabbable again
            interactableGrab.interactionLayers = 1;
        } else {
            // only run this if we've had something assigned in the past
            if (pluggedIntoThis) {
                // If it is no longer plugged into something, but the plug is still disabled
                if (pluggedIntoThis.GetComponent<Collider>().enabled == false)
                {
                    if (unplugTimeout < 60) { 
                        unplugTimeout++;
                    } else {
                        pluggedIntoThis.GetComponent<Collider>().enabled = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Plug") && (!pluggedIntoSomething))
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            pluggedIntoThis = other.gameObject;
            disableAll();
        }
    }

    private void disableAll()
    {
        // Disable Grab
        interactableGrab.interactionLayers = 0;

        // Set position to plug
        self.transform.rotation = Quaternion.Euler(0, 0, 0);
        self.transform.position = pluggedIntoThis.transform.position;

        // Set names
        plugStateTextSelf.text = pluggedIntoThis.name;
        plugStateTextOther.text = pluggedIntoThis.name;

        // Disable plug collision
        pluggedIntoThis.GetComponent<Collider>().enabled = false;

        // Freeze in place
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pluggedIntoSomething = true;
    }

    public void enableAll()
    {
        if (pluggedIntoSomething) {
            // Unfreeze etc.
            rb.isKinematic = false;
            rb.constraints = ~RigidbodyConstraints.FreezeAll;
            pluggedIntoSomething = false;

            // Restart unplug timer
            unplugTimeout = 0;

            // Reset Text
            resetText();
        }
    }
}
