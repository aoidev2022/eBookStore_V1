namespace eBookStore.RabbitMQ.Events.Queue
{
    public class EmailEvent : Event
    {
        public string Receiper { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public EmailEvent()
        {

        }

        public EmailEvent(string receiper, string title, string body)
        {
            Receiper = receiper;
            Title = title;
            Body = body;
        }
    }
}
