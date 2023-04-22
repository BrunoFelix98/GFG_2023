using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float messageTimer;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        instance = this;
    }

    public void Play()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("MainMenu"))
        {
            SceneManager.LoadScene("WorkScene");

            Parent.instance.currentHappinessLevel = Manager.instance.people[1].Effects[0].EffectLevel;
            Parent.instance.currentEnergyLevel = Manager.instance.people[1].Effects[1].EffectLevel;

            Parent.instance.GenerateNewEmail();
        }
    }

    public void EndWorkDay()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("WorkScene"))
        {
            SceneManager.LoadScene("HouseScene");
            SceneManager.UnloadSceneAsync("WorkScene");
        }
    }

    public void BackToMenu()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("WorkScene"))
        {
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync("WorkScene");

            ResetParent();
        }
        else if (scene.name.Equals("HouseScene"))
        {
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync("HouseScene");

            ResetParent();
        }
    }

    public void EndDay()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("HouseScene"))
        {
            SceneManager.LoadScene("WorkScene");
            SceneManager.UnloadSceneAsync("HouseScene");
        }
    }

    public void ResetParent()
    {
        Parent.instance.currentHappinessLevel = 0;
        Parent.instance.currentEnergyLevel = 0;
        Parent.instance.currentEmailCompleteness = 0;
        Parent.instance.currentEmail = null;
        Parent.instance.timeOfDay = 0;
        Parent.instance.emailsCompleted = 0;
    }

    public void SendMessageToParent()
    {
        if (messageTimer <= 60000)
        {
            messageTimer += Time.deltaTime;
        }
        else
        {
            GenerateMessage();
            messageTimer = 0;
        }
    }

    public void GenerateMessage()
    {
        //Generate a message based on the childs' progression, happiness and knowledge
    }

    public void GameEnded()
    {
        //Handle the end of the game when the progression bar reaches 100
    }
}
