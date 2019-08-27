using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringStuffConvo : MonoBehaviour
{
    [SerializeField] GameObject bringMeStuff;
    [HideInInspector] public bool collectableNow;
    [HideInInspector] public int collected;
    [SerializeField] int ColletXNumber;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collected < ColletXNumber)
            {
                collectableNow = true;
                bringMeStuff.SetActive(true);
            }
            else if (collected >= ColletXNumber)
                Destroy(gameObject);
        }
    }
}
