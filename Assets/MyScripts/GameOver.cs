using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI deadText, restartQuitText;
    bool isPlayerDied;
    public GameObject deadPanel, backPanel;
    bool isActive;

    private void Start()
    {
        isActive = false;
    }
    private void Update()
    {
        if (isPlayerDied && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else if(isPlayerDied && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
            Debug.Log("Quit");
        }

        
        if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
             backPanel.SetActive(true);
             Time.timeScale = 0f;
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
             isActive = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            backPanel.SetActive(false);
             Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
            FindObjectOfType<AIController>().speedRun = 0;
            FindObjectOfType<AIController>().speedWalk = 0;

            FindObjectOfType<PlayerMovement>().crouchSpeed = 0;
            FindObjectOfType<PlayerMovement>().walkSpeed = 0;
            FindObjectOfType<PlayerMovement>().sprintSpeed = 0;

            deadText.text = "Executed";
            deadPanel.SetActive(true);
            StartCoroutine(RestartMsg());
        }
    }

    IEnumerator RestartMsg()
    {
        yield return new WaitForSeconds(3f);
        restartQuitText.text = "Press R to Restart / Q to Exit";
        isPlayerDied = true;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
