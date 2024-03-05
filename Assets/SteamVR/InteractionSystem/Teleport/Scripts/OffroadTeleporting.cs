using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OffroadTeleporting : MonoBehaviour
{

    public GameObject Player;
    public GameObject Line;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Line.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SteamVR_Input.GetStateDown("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            //print("Fire out the teleport line");
            Ray raycast = new Ray(transform.position, transform.forward);

            bool bHit = Physics.Raycast(raycast, out hit);
            if (bHit)
            {
                print(hit.point);
            }
            Line.GetComponent<Renderer>().enabled = true;
        }

        if (SteamVR_Input.GetStateUp("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            //print("Teleport to the intersection point");
            if (hit.collider.gameObject.tag == "Terrain")
            {
                Player.transform.position = hit.point;
            }

            Line.GetComponent<Renderer>().enabled = false;
        }
    }
}
