using System;
using System.Media;
using System.Threading;

public class Chatbot
{
    public void Start()
    {
        PlayGreeting();
        ShowLogo();

        string name = GetUserName();
        WelcomeUser(name);

        ChatLoop(name);
    }

    private void PlayGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("welcome.wav");
            player.PlaySync();
        }
        catch
        {
            Console.WriteLine("Audio file not found.");
        }
    }

    private void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("======================================");
        Console.WriteLine("   CYBERSECURITY AWARENESS BOT");
        Console.WriteLine("======================================");
        Console.WriteLine("        [Stay Safe Online]");
        Console.WriteLine("======================================");
        Console.ResetColor();
    }

    private string GetUserName()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name cannot be empty. Try again: ");
            name = Console.ReadLine();
        }

        return name;
    }

    private void WelcomeUser(string name)
    {
        TypeEffect($"\nHello {name}! Welcome to the Cybersecurity Awareness Bot.");
        TypeEffect("You can ask me about passwords, phishing, and safe browsing.");
    }

    private void ChatLoop(string name)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n{name}, ask me something (type 'exit' to quit): ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter something.");
                continue;
            }

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Goodbye! Stay safe online.");
                break;
            }

            Respond(input);
        }
    }

    private void Respond(string input)
    {
        input = input.ToLower();

        if (input.Contains("how are you"))
            TypeEffect("I'm just a bot, but I'm always ready to help!");

        else if (input.Contains("purpose"))
            TypeEffect("My purpose is to educate you about cybersecurity.");

        else if (input.Contains("what can i ask"))
            TypeEffect("You can ask about passwords, phishing, or safe browsing.");

        else if (input.Contains("password"))
            TypeEffect("Use strong passwords with uppercase, numbers, and symbols.");

        else if (input.Contains("phishing"))
            TypeEffect("Phishing is when attackers trick you into giving personal info.");

        else if (input.Contains("browsing"))
            TypeEffect("Always use secure websites and avoid suspicious links.");

        else
            TypeEffect("I didn't quite understand that. Could you rephrase?");
    }

    private void TypeEffect(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }
}
