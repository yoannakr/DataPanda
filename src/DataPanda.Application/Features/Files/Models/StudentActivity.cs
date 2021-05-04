namespace DataPanda.Application.Features.Files.Models
{
    public class StudentActivity
    {
        public StudentActivity(string eventContext, string component, string eventName, string description)
        {
            EventContext = eventContext;
            Component = component;
            EventName = eventName;
            Description = description;
        }

        public string EventContext { get; }

        public string Component { get; }

        public string EventName { get; }

        public string Description { get; }
    }
}
