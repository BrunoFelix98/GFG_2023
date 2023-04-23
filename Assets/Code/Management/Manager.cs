using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<Effect> effects = new List<Effect>(); //All types of effects
    public List<Person> people = new List<Person>(); //All types of people
    public List<Activity> activities = new List<Activity>(); //All types of activities
    public List<Message> messages = new List<Message>(); //All types of messages
    public List<Email> emails = new List<Email>(); //All types of emails
    public List<Room> rooms = new List<Room>(); //All types of Rooms

    public static Manager instance;

    [SerializeField]
    public Slider ChildrenEnergyBar;
    [SerializeField]
    public Slider ChildrenHappinessBar;
    [SerializeField]
    public Slider ChildrenKnowledgeBar;
    [SerializeField]
    public Slider ChildrenProgressBar;
    [SerializeField]
    public Slider ParentEnergyBar;
    [SerializeField]
    public Slider ParentHappinessBar;

    public Sprite badGrades;
    public Sprite exercise;
    public Sprite goodBehaviour;
    public Sprite recycling;
    public Sprite slap;

    public bool canTakePhone = false;

    void Awake()
    {
        PopulateEffects();
        PopulatePeople();
        PopulateActivities();
        PopulateMessages();
        PopulateEmails();
        PopulateRooms();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliders();
        UpdateValues();
    }

    public void PopulateEffects()
    {
        effects.Add(new Effect(0, "Happiness", 100.0f));
        effects.Add(new Effect(1, "Energy", 100.0f));
        effects.Add(new Effect(2, "Knowledge", 0.0f));
        effects.Add(new Effect(3, "Progression", 0.0f));
    }

    public void PopulatePeople()
    {
        people.Add(new Person(0, new Effect[] { effects[0], effects[1] })); //Parent
        people.Add(new Person(1, effects.ToArray())); //Child
    }

    public void PopulateMessages()
    {
        messages.Add(new Message(0, "Ronald McDonald", "Today we did a new exercise with the kids to evolve their concentration", 2, exercise));
        messages.Add(new Message(1, "Ronald McDonald", "Today we started teaching children to recycle", 2, recycling));
        messages.Add(new Message(2, "Ronald McDonald", "Your son slapped a girl because she was trying to steal his food", 0, slap));
        messages.Add(new Message(3, "Ronald McDonald", "Your son has earned a Good Behaviour medal", 1, goodBehaviour));
        messages.Add(new Message(4, "Ronald McDonald", "Your son got a 'F' in History", 0, badGrades));
    }

    public void PopulateActivities()
    {
        activities.Add(new Activity(0, "Watch tv", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(1, "Socializing", new Effect[] { effects[0] }));
        activities.Add(new Activity(2, "Rest with kids", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(3, "Resting", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(4, "Playing with kids", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(5, "Teaching", new Effect[] { effects[0] }));
        activities.Add(new Activity(6, "Recycling", new Effect[] { effects[0] }));
        activities.Add(new Activity(7, "Cooking", new Effect[] { effects[0] }));
        activities.Add(new Activity(8, "Cleaning", new Effect[] { effects[0] }));
        activities.Add(new Activity(9, "Massage", new Effect[] { effects[0], effects[1] }));


    }

    public void PopulateEmails()
    {
        emails.Add(new Email(0)); //Bad email
        emails.Add(new Email(1)); //Good Email
        emails.Add(new Email(2)); //Neutral Email
    }

    public void PopulateRooms()
    {
        rooms.Add(new Room(0, "Bedroom", new Activity[] { activities[3] }));
        rooms.Add(new Room(1, "Living Room", new Activity[] { activities[0], activities[1], activities[2], activities[3] }));
        rooms.Add(new Room(2, "Playing Room", new Activity[] { activities[4], activities[5] }));
        rooms.Add(new Room(3, "Kitchen", new Activity[] { activities[6], activities[7], activities[8] }));
        rooms.Add(new Room(4, "Massage Room", new Activity[] { activities[9] }));

    }

    public void UpdateSliders()
    {
        if (SceneManager.GetActiveScene().name.Equals("WorkScene") || SceneManager.GetActiveScene().name.Equals("HouseScene"))
        {
            if (ParentEnergyBar == null)
            {
                ParentEnergyBar = GameObject.FindGameObjectWithTag("ParentEnergyBar").GetComponent<Slider>();
            }

            if (ParentHappinessBar == null)
            {
                ParentHappinessBar = GameObject.FindGameObjectWithTag("ParentHappinessBar").GetComponent<Slider>();
            }
        }

        if (SceneManager.GetActiveScene().name.Equals("HouseScene"))
        {
            if (ChildrenEnergyBar == null)
            {
                ChildrenEnergyBar = GameObject.FindGameObjectWithTag("ChildrenEnergyBar").GetComponent<Slider>();
            }

            if (ChildrenHappinessBar == null)
            {
                ChildrenHappinessBar = GameObject.FindGameObjectWithTag("ChildrenHappinessBar").GetComponent<Slider>();
            }

            if (ChildrenKnowledgeBar == null)
            {
                ChildrenKnowledgeBar = GameObject.FindGameObjectWithTag("ChildrenKnowledgeBar").GetComponent<Slider>();
            }

            if (ChildrenProgressBar == null)
            {
                ChildrenProgressBar = GameObject.FindGameObjectWithTag("ChildrenProgressBar").GetComponent<Slider>();
            }
        }
    }

    public void UpdateValues()
    {
        if (ChildrenEnergyBar)
        {
            ChildrenEnergyBar.value = Child.instance.childEnergyLevel / 100;
        }

        if (ChildrenHappinessBar)
        {
            ChildrenHappinessBar.value = Child.instance.childHappinessLevel / 100;
        }

        if (ChildrenKnowledgeBar)
        {
            ChildrenKnowledgeBar.value = Child.instance.childKnowledgeLevel / 100;
        }

        if (ChildrenProgressBar)
        {
            ChildrenProgressBar.value = Child.instance.childProgressionLevel / 100;
        }

        if (ParentEnergyBar)
        {
            ParentEnergyBar.value = Parent.instance.parentEnergyLevel / 100;
        }

        if (ParentHappinessBar)
        {
            ParentHappinessBar.value = Parent.instance.parentHappinessLevel / 100;
        }
    }
}