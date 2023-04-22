using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<Effect> effects = new List<Effect>(); //All types of effects
    public List<Person> people = new List<Person>(); //All types of people
    public List<Activity> activities = new List<Activity>(); //All types of activities
    public List<Message> messages = new List<Message>(); //All types of messages
    public List<Email> emails = new List<Email>(); //All types of emails

    public static Manager instance;

    void Awake()
    {
        PopulateEffects();
        PopulatePeople();
        PopulateMessages();
        PopulateEmails();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void PopulateEffects()
    {
        effects.Add(new Effect(0, "Happiness", 100.0f));
        effects.Add(new Effect(1, "Energy", 100.0f));
        effects.Add(new Effect(2, "Knowledge", 0.0f));
        effects.Add(new Effect(3, "Manners", 0.0f));
        effects.Add(new Effect(4, "Progression", 0.0f));
    }

    public void PopulatePeople()
    {
        people.Add(new Person(0, new Effect[] {effects[0], effects[1]})); //Parent
        people.Add(new Person(1, effects.ToArray())); //Child
    }

    public void PopulateMessages()
    {
        messages.Add(new Message(0, "Hello", 2));
        messages.Add(new Message(1, "My name is...", 2));
        messages.Add(new Message(2, "Goodbye", 0));
        messages.Add(new Message(3, "Greetings", 1));
        messages.Add(new Message(4, "Your child has the gay", 0));
        messages.Add(new Message(5, "Cancer has killed your family", 0));
    }

    public void PopulateActivities()
    {
        //Template: activities.Add(new Activity(0, "Watch tv", new Effect[]{effects[0]}));
    }

    public void PopulateEmails()
    {
        emails.Add(new Email(0, 0.0f)); //Bad email
        emails.Add(new Email(1, 0.0f)); //GoodEmail
        emails.Add(new Email(2, 0.0f)); //NeutralEmail
    }
}