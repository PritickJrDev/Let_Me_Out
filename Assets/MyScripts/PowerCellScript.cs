using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerCellScript : MonoBehaviour
{
    GameObject powerCell;
    bool isCellActive;
    bool isGeneratorActive;
    int cellCollected, remainingCells;
    public TextMeshPro noCellMsg;
    public TextMeshProUGUI surviveMsg;
    public GameObject[] cells, redLight;
    public GameObject normalLight, mainLight, torchLight;
    public AudioSource audioSource1;
    public AudioClip audioClip1;
    public GameObject enenmy;

    private void Update()
    {
        if (isCellActive && Input.GetKeyDown(KeyCode.E)) {
            Destroy(powerCell);
            isCellActive = false;
            cellCollected++;
            remainingCells = cellCollected;
            cells[cellCollected - 1].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PickUp");
        }

        if (isGeneratorActive && Input.GetKeyDown(KeyCode.E) && cellCollected > 0)
        {
            FindObjectOfType<AudioManager>().Play("Start");
            for(int i = 0; i<cellCollected; i++)
            {
                redLight[i].SetActive(true);
                if (i == 0)
                {
                    normalLight.SetActive(true);
                }
                if( i == 2)
                {
                    FindObjectOfType<AudioManager>().Play("horrorBg2");
                }
                if(i == 3)
                {
                    FindObjectOfType<AIController>().speedWalk = 30;
                    FindObjectOfType<AudioManager>().Play("monsterScream");
                }
                if (i == 4)
                {
                    FindObjectOfType<AudioManager>().Play("StartingA");
                    StartCoroutine(StartingGenerator());
                    mainLight.SetActive(true);
                    noCellMsg.text = "Generator is Active";
                    surviveMsg.text = "You Survived!";
                    Destroy(surviveMsg, 10f);
                }
                StartCoroutine(RequireCellMsg());

            }
        }

        if (isGeneratorActive && Input.GetKeyDown(KeyCode.E) && remainingCells == 0)
        {
            noCellMsg.text = "Require Cell";
        }

        //torch light script;
        if (Input.GetKeyDown(KeyCode.T))
        {
            torchLight.gameObject.SetActive(!torchLight.gameObject.activeSelf);
            FindObjectOfType<AudioManager>().Play("torch");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerCell"))
        {
            powerCell = other.gameObject;
            other.gameObject.GetComponentInChildren<TextMeshPro>().text = "Press E";
            isCellActive = true;
        }

        if (other.gameObject.CompareTag("Generator"))
        {
            other.gameObject.GetComponentInChildren<TextMeshPro>().text = "Press E";
            isGeneratorActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PowerCell"))
        {
            other.gameObject.GetComponentInChildren<TextMeshPro>().text = string.Empty;
            isCellActive = false;
        }

        if (other.gameObject.CompareTag("Generator"))
        {
            other.gameObject.GetComponentInChildren<TextMeshPro>().text = string.Empty;
            isGeneratorActive = false;
        }
    }

    IEnumerator RequireCellMsg()
    {
        yield return new WaitForSeconds(1.5f);
        remainingCells = 0;
    }

    IEnumerator StartingGenerator()
    {
        yield return new WaitForSeconds(3f);
        enenmy.SetActive(false);
        //  FindObjectOfType<AudioManager>().Play("StartingB");
        audioSource1.Play();
        //audioSource2.loop = true;
    }
}
