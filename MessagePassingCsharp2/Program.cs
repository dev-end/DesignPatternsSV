using System;

// Define an interface for a message
public interface IMessage
{
    string Content { get; }
}

// Concrete message types
public class TextMessage : IMessage
{
    public string Content { get; }
    public TextMessage(string content) { Content = content; }
}

public class AlertMessage : IMessage
{
    public string Content { get; }
    public string Severity { get; }
    public AlertMessage(string content, string severity) { Content = content; Severity = severity; }
}

// Define a message handler interface
public interface IMessageHandler
{
    void Handle(IMessage message);
}

// Concrete message handlers
public class TextMessageHandler : IMessageHandler
{
    public void Handle(IMessage message)
    {
        if (message is TextMessage textMessage)
        {
            Console.WriteLine($"Handling text message: {textMessage.Content}");
        }
        else
        {
            Console.WriteLine("Invalid message type for TextMessageHandler.");
        }
    }
}

public class AlertMessageHandler : IMessageHandler
{
    public void Handle(IMessage message)
    {
        if (message is AlertMessage alertMessage)
        {
            Console.WriteLine($"Handling alert message: {alertMessage.Content} with severity {alertMessage.Severity}");
        }
        else
        {
            Console.WriteLine("Invalid message type for AlertMessageHandler.");
        }
    }
}

public class MessageBus {
    private readonly Dictionary<Type, List<object>> _handlers = new();

    public void Subscribe<T>(IMessageHandler handler) where T : IMessage
    {
        var messageType = typeof(T);
        if (!_handlers.ContainsKey(messageType))
        {
            _handlers[messageType] = new List<object>();
        }
        _handlers[messageType].Add(handler);
    }

    public void Publish<T>(T message) where T : IMessage
    {
        Type messageType = typeof(T);
        if (_handlers.ContainsKey(messageType))
        {
            foreach (var handler in _handlers[messageType])
            {
                // Use reflection to call the Handle method on the handler
                var method = handler.GetType().GetMethod("Handle");
                if (method != null)
                {
                    method.Invoke(handler, new object[] { message });
                }
                else
                {
                    Console.WriteLine($"Handler {handler.GetType().Name} does not have a Handle method.");
                }
            }
        }
        else
        {
            Console.WriteLine($"No handler subscribed for message type: {messageType.Name}");
        }
    }

    public class Example
{
    public static void Main(string[] args)
    {
        MessageBus bus = new MessageBus();

        // Create handlers
        var textHandler = new TextMessageHandler();
        var alertHandler = new AlertMessageHandler();

        // Subscribe handlers to the bus
        bus.Subscribe<TextMessage>(textHandler);
        bus.Subscribe<AlertMessage>(alertHandler);

        // Publish messages
        bus.Publish(new TextMessage("Hello C# Message Bus!"));
        bus.Publish(new AlertMessage("System overload!", "Critical"));
        bus.Publish(new TextMessage("Another text message."));
    }
}    
}