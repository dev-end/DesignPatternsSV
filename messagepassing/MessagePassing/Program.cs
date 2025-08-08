using System;
using System.Collections.Generic;

// define a delegate MessageReveivedHandler
public delegate void MessageReceivedHandler(string message);

// define a class MessagePublisher
public class MessagePublisher
{
    // define an event using the delegate
    public event MessageReceivedHandler MessageReceived;

    // method to publish a message
    public void PublishMessage(string message)
    {
        // check if there are any subscribers
        if (MessageReceived != null)
        {
            // raise the event
            MessageReceived(message);
        }
    }
}

public class MessageSubscriber1
{
    public void HandleMessage(string message)
    {
        Console.WriteLine($"Subscriber 1 received: {message}");
    }
}

public class MessageSubscriber2
{
    public void HandleMessage(string message)
    {
        Console.WriteLine($"Subscriber 2 received and processed: {message.ToUpper()}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // create a publisher
        MessagePublisher publisher = new MessagePublisher();

        // create subscribers
        MessageSubscriber1 subscriber1 = new MessageSubscriber1();
        MessageSubscriber2 subscriber2 = new MessageSubscriber2();

        // subscribe to the event
        publisher.MessageReceived += subscriber1.HandleMessage;
        publisher.MessageReceived += subscriber2.HandleMessage;

        // publish a message
        publisher.PublishMessage("Hello, World!");

        // unsubscribe from the event
        publisher.MessageReceived -= subscriber1.HandleMessage;

        // publish another message
        publisher.PublishMessage("Goodbye, World!");
    }
}