using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityChatbotPart2_
{
    public partial class Form1 : Form
    {
        private string userName = "";
        private string favouriteTopic = "";
        private string currentTopic = "";

        private readonly Random random = new Random();

        // Delegate requirement
        private delegate string ResponseDelegate(string input);

        // Generic collection requirement: Dictionary + Lists
        private readonly Dictionary<string, List<string>> cyberResponses;

        public Form1()
        {
            InitializeComponent();

            cyberResponses = new Dictionary<string, List<string>>
            {
                {
                    "password", new List<string>
                    {
                        "Use strong passwords with uppercase letters, lowercase letters, numbers, and symbols.",
                        "Avoid using the same password for different accounts.",
                        "A strong password should be at least 12 characters long and should not include personal details.",
                        "Consider using a password manager to store strong passwords safely.",
                        "Never share your password with anyone, even people you trust."
                    }
                },
                {
                    "phishing", new List<string>
                    {
                        "Phishing is when scammers use fake emails, messages, or websites to steal your information.",
                        "Always check the sender’s email address before clicking on links.",
                        "Do not click links from suspicious emails. Visit the official website directly.",
                        "Be careful of messages that create panic or urgency, such as 'your account will be blocked'.",
                        "If an email asks for passwords, OTPs, or banking details, it is likely a scam."
                    }
                },
                {
                    "scam", new List<string>
                    {
                        "Scams often create urgency to make you act quickly. Always slow down and verify first.",
                        "Never share your OTP, PIN, password, or banking details with anyone.",
                        "If something sounds too good to be true, it is probably a scam.",
                        "Always confirm payment requests directly with the person or company using official contact details.",
                        "Be careful of fake competitions, fake delivery messages, and fake job offers."
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Protect your privacy by limiting what personal information you share online.",
                        "Check your privacy settings on social media accounts regularly.",
                        "Avoid posting sensitive information such as your address, ID number, or banking details.",
                        "Think carefully before sharing your location online.",
                        "Use strong privacy settings so only trusted people can see your personal posts."
                    }
                },
                {
                    "malware", new List<string>
                    {
                        "Malware is harmful software that can damage your device or steal your data.",
                        "Avoid downloading files from unknown websites.",
                        "Keep your antivirus software and operating system updated.",
                        "Do not open attachments from unknown senders.",
                        "Only install apps from trusted stores and official websites."
                    }
                },
                {
                    "wifi", new List<string>
                    {
                        "Public WiFi can be risky, especially for online banking.",
                        "Avoid logging into sensitive accounts when using public WiFi.",
                        "Use trusted networks whenever possible.",
                        "Do not enter banking details when connected to unknown WiFi networks.",
                        "If you must use public WiFi, avoid making payments or accessing private accounts."
                    }
                },
                {
                    "banking", new List<string>
                    {
                        "Banks will never ask for your PIN or OTP.",
                        "Always use official banking apps or websites.",
                        "Do not approve banking requests you did not make.",
                        "Never share your card number, CVV, PIN, password, or OTP with anyone.",
                        "If you receive a suspicious banking message, contact your bank directly using official contact details."
                    }
                },
                {
                    "social media", new List<string>
                    {
                        "Be careful about what you post on social media.",
                        "Do not accept friend requests from people you do not know.",
                        "Use privacy settings to control who can see your posts.",
                        "Avoid sharing your location, school, workplace, or private details publicly.",
                        "Be careful of fake profiles pretending to be someone you know."
                    }
                },
                {
                    "safe browsing", new List<string>
                    {
                        "Browse safely by checking URLs before entering personal information.",
                        "Only enter sensitive information on secure websites that use HTTPS.",
                        "Avoid clicking pop-up ads or suspicious download buttons.",
                        "Check that the website name is spelled correctly before logging in.",
                        "Do not save passwords on shared or public computers."
                    }
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbChat.Clear();

            AddBotMessage("Welcome to the Cybersecurity Awareness Chatbot.");
            AddBotMessage("Please type your name first so I can personalise the chat.");
            AddBotMessage("You can ask me about passwords, phishing, scams, privacy, malware, WiFi, banking, social media, and safe browsing.");
            AddBotMessage("You can also type things like 'I am worried about scams', 'I am interested in privacy', 'tell me more', or 'what do you remember?'.");

            // Optional: automatically play voice greeting when the GUI opens.
            // If you do not want it to play automatically, remove the line below.
            PlayVoiceGreeting(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
            AddBotMessage("Chat cleared. How can I help you stay safe online?");
        }

        private void btnVoice_Click(object sender, EventArgs e)
        {
            PlayVoiceGreeting(true);
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void SendMessage()
        {
            string input = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage("Please enter something before pressing Send.");
                return;
            }

            AddUserMessage(input);
            txtUserInput.Clear();

            ResponseDelegate responseMethod = GenerateResponse;
            string response = responseMethod(input.ToLower());

            AddBotMessage(response);
        }

        private string GenerateResponse(string input)
        {
            string sentimentMessage = DetectSentiment(input);

            // First message becomes the user's name
            if (string.IsNullOrEmpty(userName))
            {
                userName = input.Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = "User";
                }

                return $"Nice to meet you, {userName}! You can now ask me about cybersecurity topics like passwords, phishing, privacy, scams, malware, WiFi, banking, social media, or safe browsing.";
            }

            // Update name
            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = "User";
                }

                return $"Thanks, I’ll remember your name is {userName}.";
            }

            // Memory feature: remember favourite topic
            if (input.Contains("i am interested in") || input.Contains("i'm interested in") || input.Contains("interested in"))
            {
                favouriteTopic = input.Replace("i am interested in", "")
                                      .Replace("i'm interested in", "")
                                      .Replace("interested in", "")
                                      .Trim();

                if (string.IsNullOrWhiteSpace(favouriteTopic))
                {
                    return "Please tell me which cybersecurity topic you are interested in, such as privacy, phishing, or passwords.";
                }

                currentTopic = FindTopicFromInput(favouriteTopic);

                if (string.IsNullOrEmpty(currentTopic))
                {
                    currentTopic = favouriteTopic;
                }

                return $"Great, {userName}. I’ll remember that you are interested in {favouriteTopic}.";
            }

            // Recall memory
            if (input.Contains("what do you remember") || input.Contains("remember me") || input.Contains("what did i tell you"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    return $"I remember that your name is {userName} and you are interested in {favouriteTopic}.";
                }

                return $"I remember that your name is {userName}, but you have not told me your favourite cybersecurity topic yet.";
            }

            // Follow-up conversation flow
            if (input.Contains("tell me more") || input.Contains("explain more") || input.Contains("another tip") || input.Contains("more detail") || input.Contains("give me more"))
            {
                if (!string.IsNullOrEmpty(currentTopic) && cyberResponses.ContainsKey(currentTopic))
                {
                    string followUp = GetRandomResponse(currentTopic);
                    return $"Sure, {userName}. Here is more about {currentTopic}: {followUp}";
                }

                return "Sure, I can explain more. Please first ask about a topic like phishing, passwords, scams, privacy, malware, WiFi, banking, social media, or safe browsing.";
            }

            // General chatbot questions
            if (input.Contains("how are you"))
            {
                return $"I'm doing well, {userName}. I'm ready to help you learn how to stay safe online.";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to teach users about cybersecurity threats and how to avoid them.";
            }

            if (input.Contains("what can i ask") || input.Contains("help"))
            {
                return "You can ask me about passwords, phishing, scams, privacy, malware, WiFi, banking safety, OTPs, social media safety, and safe browsing.";
            }

            // Detect cybersecurity topic
            string detectedTopic = FindTopicFromInput(input);

            if (!string.IsNullOrEmpty(detectedTopic))
            {
                currentTopic = detectedTopic;
                string response = GetRandomResponse(detectedTopic);

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            // Extra keyword handling
            if (input.Contains("otp") || input.Contains("pin"))
            {
                currentTopic = "banking";

                string response = "Never share your OTP, PIN, or banking details. Banks will never ask for this information.";

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            if (input.Contains("update") || input.Contains("software update"))
            {
                currentTopic = "malware";

                string response = "Keeping your software updated helps fix security weaknesses that attackers could use.";

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            if (input.Contains("link") || input.Contains("suspicious link"))
            {
                currentTopic = "phishing";

                string response = "Do not click suspicious links. Check the website address carefully and use the official website instead.";

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            // Sentiment-only response
            if (!string.IsNullOrEmpty(sentimentMessage))
            {
                return sentimentMessage + " Try asking me about passwords, phishing, scams, privacy, malware, WiFi, or banking safety so I can help you further.";
            }

            // Default error handling
            return "I’m not sure I understand. Try asking about cybersecurity topics like passwords, phishing, scams, privacy, malware, WiFi, banking, social media, or safe browsing.";
        }

        private string FindTopicFromInput(string input)
        {
            if (input.Contains("password") || input.Contains("passwords"))
                return "password";

            if (input.Contains("phishing") || input.Contains("phish"))
                return "phishing";

            if (input.Contains("scam") || input.Contains("scams"))
                return "scam";

            if (input.Contains("privacy") || input.Contains("private"))
                return "privacy";

            if (input.Contains("malware") || input.Contains("virus"))
                return "malware";

            if (input.Contains("wifi") || input.Contains("wi-fi") || input.Contains("public wifi"))
                return "wifi";

            if (input.Contains("bank") || input.Contains("banking") || input.Contains("otp") || input.Contains("pin"))
                return "banking";

            if (input.Contains("social") || input.Contains("facebook") || input.Contains("instagram") || input.Contains("tiktok"))
                return "social media";

            if (input.Contains("safe browsing") || input.Contains("browsing") || input.Contains("online safety") || input.Contains("https") || input.Contains("website"))
                return "safe browsing";

            return "";
        }

        private string GetRandomResponse(string topic)
        {
            if (!cyberResponses.ContainsKey(topic))
            {
                return "I can help with that cybersecurity topic, but please ask me in a bit more detail.";
            }

            List<string> responses = cyberResponses[topic];
            int index = random.Next(responses.Count);
            return responses[index];
        }

        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid") || input.Contains("nervous"))
            {
                return "It’s understandable to feel worried. Cybersecurity can seem stressful, but simple habits can protect you.";
            }

            if (input.Contains("confused") || input.Contains("unsure") || input.Contains("don't understand") || input.Contains("do not understand"))
            {
                return "No problem, I’ll explain it in a simple way.";
            }

            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("irritated"))
            {
                return "I understand that it can be frustrating. Let’s take it step by step.";
            }

            if (input.Contains("curious") || input.Contains("interested"))
            {
                return "That’s great! Being curious is a good way to learn how to stay safe online.";
            }

            if (input.Contains("happy") || input.Contains("good") || input.Contains("great"))
            {
                return "That’s good to hear. Let’s keep building strong online safety habits.";
            }

            return "";
        }

        private void PlayVoiceGreeting(bool showMessage)
        {
            try
            {
                string audioPath = Path.Combine(Application.StartupPath, "Greeting.wav");

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play();

                    if (showMessage)
                    {
                        AddBotMessage("Voice greeting played.");
                    }
                }
                else
                {
                    if (showMessage)
                    {
                        AddBotMessage("Audio file not found. Make sure Greeting.wav is added to the project and set to Copy if newer.");
                    }
                }
            }
            catch (Exception ex)
            {
                AddBotMessage("Voice greeting could not play: " + ex.Message);
            }
        }

        private void AddUserMessage(string message)
        {
            rtbChat.SelectionColor = Color.Blue;
            rtbChat.AppendText("You: " + message + Environment.NewLine);
            rtbChat.SelectionColor = Color.Black;
            rtbChat.ScrollToCaret();
        }

        private void AddBotMessage(string message)
        {
            rtbChat.SelectionColor = Color.Green;
            rtbChat.AppendText("Chatbot: " + message + Environment.NewLine + Environment.NewLine);
            rtbChat.SelectionColor = Color.Black;
            rtbChat.ScrollToCaret();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}