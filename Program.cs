using System;
using System.Xml.Linq;
using System.Media;

//Threading import to allow for delays between output
using System.Threading;

class Cipher
{
    public static void greetingAnimation()
    {
        string welcomeArt = @"██     ██ ███████ ██       ██████  ██████  ███    ███ ███████ ██ 
██     ██ ██      ██      ██      ██    ██ ████  ████ ██      ██ 
██  █  ██ █████   ██      ██      ██    ██ ██ ████ ██ █████   ██ 
██ ███ ██ ██      ██      ██      ██    ██ ██  ██  ██ ██         
 ███ ███  ███████ ███████  ██████  ██████  ██      ██ ███████ ██ 
                                                                 
                                                                 
                ██      █████  ███    ███                        
                ██     ██   ██ ████  ████                        
                ██     ███████ ██ ████ ██                        
                ██     ██   ██ ██  ██  ██                        
                ██     ██   ██ ██      ██                        
                                                                 
                                                                 
          ██████ ██ ██████  ██   ██ ███████ ██████               
         ██      ██ ██   ██ ██   ██ ██      ██   ██              
         ██      ██ ██████  ███████ █████   ██████               
         ██      ██ ██      ██   ██ ██      ██   ██              
██ ██ ██  ██████ ██ ██      ██   ██ ███████ ██   ██ ██ ██ ██     
                                                                 
                                                                 ";

        string[] lines = welcomeArt.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
            Thread.Sleep(150);
        }
    }

    public static void closingAnimation()
    {
        string GoodbyeArt = @"   _____                 _ _                
  / ____|               | | |               
 | |  __  ___   ___   __| | |__  _   _  ___ 
 | | |_ |/ _ \ / _ \ / _` | '_ \| | | |/ _ \
 | |__| | (_) | (_) | (_| | |_) | |_| |  __/
  \_____|\___/ \___/ \__,_|_.__/ \__, |\___|
                                  __/ |     
                                 |___/      ";
        string[] lines = GoodbyeArt.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
            Thread.Sleep(150);
        }


    }
   
    //formatting method that outputs boarders depending on the  argument received
    public static void formatting(string format)
    {
        format = format.ToLower();
        if (format.Contains("br") || format.Contains("break") || format.Contains("blank")) Console.WriteLine("");
        else if (format.Contains("dash")) printOut("----------------------------------------------------------------------");
        else if (format.Contains("boarder")) printOut("=============================================================================");
        else printOut("");
    }

    public static void printOut(string text)
    {
        //uses Console.Write in order to make output feel more interactive
        foreach (var character in text)
        {
            Console.Write(character);
            Thread.Sleep(15);
        }
        Thread.Sleep(1000);
        formatting("br");
    }

    public static void timeSleep()
    {
        //method for processing delay
        Thread.Sleep(1500);
    }

    //MAIN METHOD!
            static void Main(string[] args)
            {

            //main foreground color will be dark cyan
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            AudioManager audio = new AudioManager();

        audio.PlayWav("Boot up sound effect.wav");



        greetingAnimation();
        
                printOut("Hello there! What is your name?");


            //user input will be in white color
        Console.ForegroundColor = ConsoleColor.White;

        string name = Console.ReadLine();
                timeSleep();

                //single use error handling for blank username input
                if (name.Equals(""))
                {
                    printOut("Please enter a name:");
                    name = Console.ReadLine();
            timeSleep();
                }
                //converts name varible to titlecase e.g. thando -> Thando
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        printOut("Welcome " + name + "! It is good to meet you \nHow are you");
        Console.ForegroundColor = ConsoleColor.White;

        string feeling = Console.ReadLine().ToLower();
                timeSleep();

        Console.ForegroundColor = ConsoleColor.DarkCyan;

        //asks user how they are feeling and responds accordingly
        if (feeling.Contains("good") || feeling.Contains("great") || feeling.Contains("amazing") || feeling.Contains("cool")) printOut("That's great to hear\nSo...");

                else if (feeling.Contains("sad") || feeling.Contains("angry") || feeling.Contains("not")) printOut("That sounds sad. I'm sure all will be okay");

                else printOut("I may not now what that means but aside from that..\n");

                formatting("boarder");
                //main loop to keep the program running
                while (true)
                {
                    printOut("\nWhat would you like to know today " + name + "?");
            Console.ForegroundColor = ConsoleColor.White;

            string query = Console.ReadLine().ToLower();
                    
                    timeSleep();
                    formatting("dash");
            //breaks main loop when user exit the application
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (query.Equals("exit") || query.Contains("quit") || query.Contains("bye") || query.Contains("close"))
                    {
                        printOut("Exiting application\nEnjoy the rest of your day\n");
                        
                        //Display closing animation
                        closingAnimation();
                        
                        //terminate loop
                        break;
                    }
                    switch (query)
                    {

                        //default is for when question asked is not part of the queries
                        default:
                            printOut("Sorry, I do not understand the question.\nTry to rephrase the question or try questions related to cybersecurity or even about my purpose. ");
                            printOut("Here is a list of things you can ask here:" +
                                                "Questions related to me:\nMy purpose\nWho made me\nWhat I can do\n" +
                                                "\nCybersecurity-related questions:\n" +
                                                "what is cybersecurity?\nWhy is cybersecurity important?\nWhat is hacking?" +
                                                "Other security-related questions:\n" +
                                                "Safe Web Browsing\nWhat is phishing?\nPassword Safety\n\nYou can enter 'exit' to close the chatbot ");
                            formatting("dash");
                            break;


                        //questions regarding the chatbot application
                        case "what is your purpose" or "purpose" or "what are you" or "who are you" or "what is your duty" or "what is your job" or "what do you do":
                            printOut("I am Cipher\nI am a chatbot made to educate and provide some insight to cybersecurity and tech-related security measures.\n" +
                            "I was made in 2026 as an attempt to counter the increasing number of cyberattacks that were taking place. \n" +
                            "Since most people are not as aware about the potential dangers and risks that come with technology, there are people who take exploit that to their own benefit\n" +

                            "So if you are eager to learn, go ahead and ask any cyberesecurity-related questions you may be qurious about\n");
                        formatting("dash");
                            break;

                        //questions about cybersecurity
                        case "what is cybersecurity":
                            Console.WriteLine("Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks, commonly called cyberattacks or hacking.\n" +
                            "Think of cybersecurity as the digital versions of superheroes who stop the villains who try to rob banks.\n" +
                            "But in this case, the villains are doing it through the internet, and no one is held at gunpoint. \n" +
                            "These cyberattacks are usually aimed at accessing, modifying, or destroying restricted sensitive information; extorting money from users through ransomware, or interrupting normal business processes.\n" +
                            "Now we can try to prevent cyberattacks by implementing effective cybersecuritytechniques\n" +
                            "Effective techniques can work the best when they prevent damage to critical before they are even attacked, thus keeping all systems running at 100%\n" +

                            "So that's it :)");
                        formatting("dash");

                        break;


                        //questions about hacking
                        //case declaration is made to respond to any question with the term hacking
                        case string hacked when hacked.Contains("hacked") || hacked.Contains("hacking"):
                            printOut(name + ". If you believe you have been exposed or potentially given away sensitive information, you should hurry to protect your accounts.\n" +
                            "The reason for hurrying is because if an attacker got access to your account, it is possible that they can log YOU out of your own account.\n" +
                            "It is therefore crucial that you act fast if this happens:\n" +
                            "Change your passwords\n" +
                            "Sign out on all devices that may have access to your account\n" +
                            "If you may have given away banking information, block your cards and ask the bank for new ones.\n" +
                            "This should prevent a lot of damage which could be critical to your assets/personal information but it doesn't guarantee that you will be fully protected");
                        formatting("dash");

                        break;

                        case "what is hacking":
                            printOut("Hacking is a term used to explain an illegal digital attack on systems. It is the foundation that cybersecurity works towards fighting");
                            break;

                        //other security related question
                        case string phishing when phishing.Contains("phish"):

                            printOut("Phishing is a dangerous tactic used by attackers to trick users to granting unauthorized access to sensitive information\n" +
                            "They do this by posing as a legitimate and professional organization.\n" +
                            "The messages are personalized and get increasingly difficult to distinguish from the legit organization.\n" +
                            "Today, users have become more prone to phishing attacks as generative AI is able to make super realistic website/applications that look just as good as the original.\n" +
                            "Unfortunately, this issue is bound to get worse as AI continuously evolves.");
                        formatting("dash");

                        break;

                        case string safe when safe.Contains("safe") || safe.Contains("browsing"):
                        formatting("boarder");
                            printOut("When you use a computer or the internet, you may think you are just accessing the information you want, but in the background, a lot could be happening:\n" +
                            "Your activity could be monitored, you could be observed by malicious software made to steal your passwords\n" +
                            "You could even be tricked into clicking on unsafe links that give attackers access to all your sensitive information.\n" +
                            "And the worst part is that you wouldn’t even know until it’s too late.\n" +
                            "So here are a few things you can do to prevent this from happening:");

                        formatting("dash");

                        printOut("\nBe cautious with links and attachments\n" +
                            "A new and arising dangerous attack used today is link redirection.\n" +
                            "You click on a link that is intended to take you to your planned website, but it redirects you to a fake similar webpage\n" +
                            "More often, users cannot tell the difference, so they enter their personal information.\n" +
                            "Verify the link before you click on it and check if it says that it will take you to where you want it to\n" +
                            "You could also use an online link verifier to ensure that it is safe to click.\n" +
                            "Remember the phrase:\n think before you click\n");
                        formatting("dash");


                        printOut("\nUse strong unique passwords\n" +
                            "As the everyday systems we use develop, we are encouraged to come up with strong passwords that would be difficult to guess or predict\n" +
                             "Even so, you could still be at risk." +
                             "As unique as your password may be, you shouldn’t reuse the same one across sites." +
                             "If one were to get their hands on it, they would have access to all the other sites with all your personal information");
                        formatting("dash");


                        printOut("\nLimit the amount of personal information you share online\n" +
                             "As you explore various platforms, you will find yourself encouraged to share personal details to further improve your user experience\n" +
                             "Many don’t realize how much information is being collected over time" +
                             "Most already try their best to protect their data but regardless, companies still try to obtain some level of data from users");
                        formatting("dash");

                        printOut("\nRecognize emotional manipulation online \n" +
                             "A lot of online threats, commonly scams rely on the psychological sense of urgency, fear, or excitement to persuade users to perform quick reactions to satisfy those emotions." +
                             "Examples of this could be a bank telling you that your account was potentially hacked and requires immediate attention." +
                             "It is best advised to take a moment to think before you click or respond in order to break that psychological pattern." +
                             "Slowing down is the most effective defences against manipulation-driven attacks.");
                        formatting("dash");

                        printOut("\nTreat online safety as an ongoing habit\n" +
                             "You need to understand that cybersecurity is a process, a habit and not a single one-time setup that works forever.\n" +
                             " As technology evolves, so do security threats and precautions that worked perfectly a year ago may not be sufficient in today’s time.\n" +
                             "Try to stay informed about potential dangers, continue to perform basic practices, and apply pattern recognition as you use these daily systems.\n" +

                             "You would be surprised how many users have been a victim and how it’s not all just theory and risk.");
                            break;





                    }
                }
            }
}

