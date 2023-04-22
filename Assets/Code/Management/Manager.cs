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
    public List<Room> rooms = new List<Room>(); //All types of Rooms

    public static Manager instance;

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
        effects.Add(new Effect(3, "Progression", 0.0f));
    }

    public void PopulatePeople()
    {
        people.Add(new Person(0, new Effect[] {effects[0], effects[1]})); //Parent
        people.Add(new Person(1, effects.ToArray())); //Child
    }

    public void PopulateMessages()
    {
        messages.Add(new Message(0, "Ronald McDonald", "Today we did a new exercise with the kids to evolve their concentration", 2, null));
        messages.Add(new Message(1, "Ronald McDonald", "Today we started teaching children to recycle", 2, null));
        messages.Add(new Message(2, "Ronald McDonald", "Your son slapped a girl because she was trying to steal his food", 0, null));
        messages.Add(new Message(3, "Ronald McDonald", "Your son has earned a Good Behaviour medal", 1, null));
        messages.Add(new Message(4, "Ronald McDonald", "Your son got a 'F' in History", 0, null));
    }

    public void PopulateActivities()
    {
        activities.Add(new Activity(0, "Watch tv", new Effect[]{effects[0], effects[1] }));
        activities.Add(new Activity(1, "Socializing", new Effect[] { effects[0] }));
        activities.Add(new Activity(2, "Rest with kids", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(3, "Resting", new Effect[] { effects[0], effects[1] }));
        activities.Add(new Activity(4, "Playing with kids", new Effect[]{effects[0], effects[1]}));
        activities.Add(new Activity(5, "Teaching", new Effect[] { effects[0] }));
        activities.Add(new Activity(6, "Recycling", new Effect[] { effects[0] }));
        activities.Add(new Activity(7, "Cooking", new Effect[]{ effects[0]}));
        activities.Add(new Activity(8, "Cleaning", new Effect[] { effects[0] }));
        activities.Add(new Activity(9, "Massage", new Effect[]{effects[0], effects [1]}));
        
        
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
        rooms.Add(new Room(4, "Massage Room", new Activity[] { activities[9]}));

    }
}