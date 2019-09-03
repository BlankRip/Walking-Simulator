using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    SkullScript skull;
    NPCScript npc;
    [SerializeField] GameObject vFx;
    [SerializeField] GameObject LitUpInstructions;
    [SerializeField] GameObject wrongLitText;
    [SerializeField] CapsuleCollider triggerCollider;
    [SerializeField] bool thisIsLeftStick;
    [SerializeField] bool thisIsRigthStick;
    bool inrange;

    // Start is called before the first frame update
    void Start()
    {
        skull = FindObjectOfType<SkullScript>();
        npc = FindObjectOfType<NPCScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisIsLeftStick)
        {
            if(Input.GetKeyDown(KeyCode.E) && inrange)
            {
                vFx.SetActive(true);
                skull.leftLit = true;
                triggerCollider.enabled = false;
            }
        }
        else if(thisIsRigthStick)
        {
            if (Input.GetKeyDown(KeyCode.E) && inrange)
            {
                if (skull.leftLit)
                {
                    vFx.SetActive(true);
                    skull.rightLit = true;
                    triggerCollider.enabled = false;
                }
                else
                    wrongLitText.SetActive(true);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && npc.finalPuzzleOn)
        {
            inrange = true;
            LitUpInstructions.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && npc.finalPuzzleOn)
        {
            inrange = false;
            LitUpInstructions.SetActive(false);
        }
    }
}
