using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkullScript : MonoBehaviour
{
    [SerializeField] GameObject touchSkullInstruct;
    [SerializeField] GameObject tbcPannal;

    [HideInInspector] public bool leftLit;
    [HideInInspector] public bool rightLit;
    bool inrange;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inrange)
        {
            tbcPannal.SetActive(true);
            StartCoroutine(backToMenu());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && leftLit && rightLit)
        {
            inrange = true;
            touchSkullInstruct.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && leftLit && rightLit)
        {
            inrange = false;
            touchSkullInstruct.SetActive(false);
        }
    }


    IEnumerator backToMenu()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0);
    }
}
