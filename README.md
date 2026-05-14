# CyberSecurity Chatbot Part 2

## Description

CyberSecurity Chatbot Part 2 is a Windows Forms GUI application built in C# using .NET 8. The application expands on the original console-based Cybersecurity Awareness Chatbot by adding a graphical user interface, voice greeting, keyword recognition, random responses, memory recall, sentiment detection, and better error handling.

The chatbot is designed to help users learn basic cybersecurity awareness topics in an interactive and user-friendly way.

---

## Features

- Windows Forms graphical user interface
- Voice greeting using a WAV audio file
- Chat area for displaying user and chatbot messages
- Textbox input for user questions
- Send button for submitting messages
- Clear Chat button to reset the chat window
- Play Voice button to replay the greeting
- Keyword recognition for cybersecurity topics
- Random responses for selected topics
- Memory feature to remember the user's name and favourite cybersecurity topic
- Sentiment detection for words such as worried, curious, and frustrated
- Follow-up conversation support using phrases like:
  - tell me more
  - another tip
  - explain more
- Error handling for empty or unknown inputs
- Organised code using methods, dictionaries, lists, and delegates

---

## Cybersecurity Topics Covered

The chatbot can respond to questions about:

- Password safety
- Phishing
- Online scams
- Privacy
- Malware
- Public WiFi
- Online banking safety
- Social media safety
- Safe browsing
- Identity theft
- Software updates

---

## How the Chatbot Works

When the application starts, the chatbot welcomes the user and asks for their name. After the user enters their name, the chatbot personalises the conversation.

The user can then ask questions about cybersecurity topics. The chatbot checks the user's input for keywords and provides a relevant response.

The chatbot can also remember the user's favourite cybersecurity topic and recall it later in the conversation.

---

## Example Conversation

Chatbot: Welcome to the Cybersecurity Awareness Chatbot.

Chatbot: Please type your name first so I can personalise the chat.

You: Tashreeq

Chatbot: Nice to meet you, Tashreeq! You can now ask me about cybersecurity topics.

You: password

Chatbot: A strong password should be at least 12 characters long and should not include personal details.

You: tell me more

Chatbot: Sure, Tashreeq. Here is more about password: Use strong passwords with uppercase letters, lowercase letters, numbers, and symbols.

You: I am worried about scams

Chatbot: It’s understandable to feel worried. Cybersecurity can seem stressful, but simple habits can protect you.

You: I am interested in privacy

Chatbot: Great, Tashreeq. I’ll remember that you are interested in privacy.

You: what do you remember?

Chatbot: I remember that your name is Tashreeq and you are interested in privacy.

---

## Technologies Used

- C#
- .NET 8
- Windows Forms
- Visual Studio 2022
- System.Media for audio playback
- GitHub for version control

---

## Project Structure

CyberSecurityChatbotPart2

- Form1.cs
- Form1.Designer.cs
- Form1.resx
- Program.cs
- Greeting.wav
- CyberSecurityChatbotPart2.csproj
- README.md

---

## How to Run the Project

1. Open the project in Visual Studio 2022.
2. Make sure the project is set as the startup project.
3. Ensure that `Greeting.wav` is included in the project.
4. Select `Greeting.wav` and check that:
   - Build Action is set correctly
   - Copy to Output Directory is set to `Copy if newer`
5. Click the green Start button to run the application.
6. Type your name first.
7. Start asking cybersecurity-related questions.

---

## Part 2 Requirements Covered

| Requirement | Status |
|---|---|
| Create a GUI application using WinForms | Completed |
| Translate Task 1 chatbot into GUI | Completed |
| Include voice implementation | Completed |
| Use keyword recognition | Completed |
| Recognise at least three cybersecurity keywords | Completed |
| Use random responses | Completed |
| Use arrays, lists, or dictionaries | Completed |
| Maintain conversation flow | Completed |
| Implement memory and recall | Completed |
| Implement sentiment detection | Completed |
| Handle errors and unknown inputs | Completed |
| Use methods and good code organisation | Completed |
| Use delegates | Completed |

---

## References

CloudConvert, 2026. *M4A to WAV converter*. Available at: https://cloudconvert.com/m4a-to-wav (Accessed: 14 May 2026).

GitHub, 2026. *GitHub Docs: About repositories*. Available at: https://docs.github.com/en/repositories/creating-and-managing-repositories/about-repositories (Accessed: 14 May 2026).

Microsoft, 2024. *C# documentation*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/ (Accessed: 14 May 2026).

Microsoft, 2024. *Windows Forms documentation for .NET*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/ (Accessed: 14 May 2026).

Microsoft, 2024. *System.Media.SoundPlayer class*. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer (Accessed: 14 May 2026).

Microsoft, 2024. *Collections and data structures in C#*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections (Accessed: 14 May 2026).

Microsoft, 2024. *Delegates in C#*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/ (Accessed: 14 May 2026).

Microsoft, 2024. *Visual Studio documentation*. Available at: https://learn.microsoft.com/en-us/visualstudio/windows/ (Accessed: 14 May 2026).

National Cyber Security Centre, 2024. *Phishing attacks: Defending your organisation*. Available at: https://www.ncsc.gov.uk/guidance/phishing (Accessed: 14 May 2026).

National Cyber Security Centre, 2024. *Top tips for staying secure online*. Available at: https://www.ncsc.gov.uk/collection/top-tips-for-staying-secure-online (Accessed: 14 May 2026).

Cybersecurity and Infrastructure Security Agency, 2024. *Secure our world*. Available at: https://www.cisa.gov/secure-our-world (Accessed: 14 May 2026).

Cybersecurity and Infrastructure Security Agency, 2024. *Phishing guidance*. Available at: https://www.cisa.gov/news-events/news/avoiding-social-engineering-and-phishing-attacks (Accessed: 14 May 2026).

---

## Author

Tashreeq Phipps

---

## Notes

This project was created for Part 2 of the Cybersecurity Awareness Chatbot assignment. It demonstrates GUI design, user interaction, cybersecurity keyword recognition, memory recall, sentiment detection, random responses, use of generic collections, delegates, and basic audio playback in a C# Windows Forms application.
