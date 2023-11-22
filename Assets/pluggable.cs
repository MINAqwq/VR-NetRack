using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class pluggable : MonoBehaviour
{
    public GameObject self;
    private Rigidbody rb;
    private XRGrabInteractable interactableGrab;
    private XRGeneralGrabTransformer interactableGrabTransformer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactableGrab = GetComponent<XRGrabInteractable>();
        interactableGrabTransformer = GetComponent<XRGeneralGrabTransformer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plug")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            rb.isKinematic = true;
            rb.detectCollisions = true;
            rb.useGravity = false;
            interactableGrab.enabled = false;
            interactableGrabTransformer.enabled = false;
            self.transform.rotation = Quaternion.Euler(0, 0, 0);
            self.transform.position = other.transform.position;
            //self.transform = (collision.gameObject.transform);
            //Debug.Log("Do something here");
        }
    }
}
