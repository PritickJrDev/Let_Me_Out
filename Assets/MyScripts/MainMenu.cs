using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button hintButton, controlButtonm, playButton, quitButton;
    public GameObject hintPanel,controlPanel;
    public Animator anim;

    private void Start()
    {
        hintButton.onClick.AddListener(() =>
        {
            hintPanel.gameObject.SetActive(!hintPanel.gameObject.activeSelf);
        });

        playButton.onClick.AddListener(() =>
        {
            FindObjectOfType<AudioManager>().Play("playSound");
            StartCoroutine(LoadSceneOne());
        });

        controlButtonm.onClick.AddListener(() =>
        {
            controlPanel.gameObject.SetActive(!controlPanel.gameObject.activeSelf);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("I quit");
        });
    }

    IEnumerator LoadSceneOne()
    {
        anim.SetBool("End", true);
        yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Japan");
    }
}
