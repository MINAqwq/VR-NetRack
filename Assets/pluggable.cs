using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private XRGeneralGrabTransformer interactableGrabTransformer;
    int timeout = 0;
    bool pluggedIntoSomething = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactableGrab = GetComponent<XRGrabInteractable>();
        interactableGrabTransformer = GetComponent<XRGeneralGrabTransformer>();
        plugStateTextSelf.text = "Unplugged";
        plugStateTextOther.text = "Unplugged";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pluggedIntoSomething)
        {
            if (timeout > 60)
            {
                interactableGrab.enabled = true;
                interactableGrabTransformer.enabled = true;
                disableAll();
            } else { 
                timeout++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plug")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            pluggedIntoThis = other.gameObject;
            interactableGrabTransformer.enabled = false;
            interactableGrab.enabled = false;
            disableAll();
        }
    }

    private void disableAll()
    {
        rb.detectCollisions = false;
        rb.useGravity = false;

        self.transform.rotation = Quaternion.Euler(0, 0, 0);
        self.transform.position = pluggedIntoThis.transform.position;
        plugStateTextSelf.text = pluggedIntoThis.name;
        plugStateTextOther.text = pluggedIntoThis.name;
        pluggedIntoThis.GetComponent<Collider>().enabled = false;

        timeout = 0;
        pluggedIntoSomething = true;
        rb.isKinematic = true;
    }
}
