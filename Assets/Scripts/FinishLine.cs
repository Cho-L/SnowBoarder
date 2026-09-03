using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] int currentStage;
    [SerializeField] int maxStage;
    [SerializeField] ParticleSystem finishEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("NextLevel", 0);
        }
    }

    void NextLevel()
    {
        currentStage = SceneManager.GetActiveScene().buildIndex;
        maxStage = SceneManager.sceneCountInBuildSettings;

        if (currentStage < maxStage - 1)
        {
            SceneManager.LoadScene(currentStage + 1);
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("게임 클리어!");
        }
    }
}
