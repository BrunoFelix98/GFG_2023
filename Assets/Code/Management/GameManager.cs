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

            ResetSlides();

            Parent.instance.parentHappinessLevel = Manager.instance.people[1].Effects[0].EffectLevel;
            Parent.instance.parentEnergyLevel = Manager.instance.people[1].Effects[1].EffectLevel;

            Child.instance.childHappinessLevel = Manager.instance.people[1].Effects[0].EffectLevel / 2;
            Child.instance.childEnergyLevel = Manager.instance.people[1].Effects[1].EffectLevel / 2;

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
            ResetSlides();
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
            ResetChild();
            ResetSlides();
        }
        else if (scene.name.Equals("HouseScene"))
        {
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync("HouseScene");

            ResetParent();
            ResetChild();
            ResetSlides();
        }
    }

    public void EndDay()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("HouseScene"))
        {
            SceneManager.LoadScene("WorkScene");
            SceneManager.UnloadSceneAsync("HouseScene");

            Child.instance.childProgressionLevel = (Child.instance.childProgressionLevel + Child.instance.childKnowledgeLevel + 3);
            ResetSlides();
        }
    }

    public void ResetParent()
    {
        Parent.instance.parentHappinessLevel = 0;
        Parent.instance.parentEnergyLevel = 0;
        Parent.instance.currentEmailCompleteness = 0;
        Parent.instance.currentEmail = null;
        Parent.instance.timeOfDay = 0;
        Parent.instance.emailsCompleted = 0;
    }

    public void ResetChild()
    {
        Child.instance.childHappinessLevel = 0;
        Child.instance.childEnergyLevel = 0;
        Child.instance.childKnowledgeLevel = 0;
        Child.instance.childProgressionLevel = 0;
        Child.instance.eventTimer = 0;
    }

    public void ResetSlides()
    {
        Manager.instance.ParentEnergyBar = null;
        Manager.instance.ParentHappinessBar = null;
    }

    public void GameEnded()
    {
        //Handle the end of the game when the progression bar reaches 100
    }
}
