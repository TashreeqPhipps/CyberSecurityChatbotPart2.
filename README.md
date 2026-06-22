# CyberSecurity Awareness Chatbot POE

## Description

CyberSecurity Awareness Chatbot POE is a Windows Forms GUI application built in C# using .NET 8. The project expands on the original console-based cybersecurity chatbot by adding a graphical user interface, voice greeting, keyword recognition, random responses, memory recall, sentiment detection, task management, a cybersecurity quiz, NLP-style command recognition, and an activity log.

The application is designed to help users learn basic cybersecurity awareness topics in an interactive and user-friendly way. It also helps users manage cybersecurity-related tasks such as reviewing privacy settings, updating passwords, and setting reminder dates.

---

## Features

* Windows Forms graphical user interface
* Tabbed interface for:

  * Chatbot
  * Tasks
  * Quiz
  * Activity Log
* Voice greeting using a WAV audio file
* Chat area for displaying user and chatbot messages
* Textbox input for user questions
* Send button for submitting messages
* Clear Chat button to reset the chat window
* Play Voice button to replay the greeting
* Keyword recognition for cybersecurity topics
* Random responses for selected topics
* Memory feature to remember the user's name and favourite cybersecurity topic
* Sentiment detection for words such as worried, curious, confused, and frustrated
* Follow-up conversation support using phrases such as:

  * tell me more
  * another tip
  * explain more
* Error handling for empty or unknown inputs
* Organised code using methods, dictionaries, lists, and delegates

---

## Part 3 Features

### Task Assistant

The chatbot includes a task assistant that allows the user to create and manage cybersecurity-related tasks.

Task assistant features include:

* Add a task
* Add a task title
* Add a task description
* Set an optional reminder date
* Store tasks in a MySQL database
* Display tasks in a DataGridView
* Mark tasks as completed
* Delete tasks from the database

Example task:

```text
Task Title: Review privacy settings
Description: Check Facebook and Instagram privacy settings
Reminder: 22 June 2026
```

---

### MySQL Database Integration

The application uses MySQL to store cybersecurity tasks. A database schema called `cybersecurity_chatbot` is used, with a table called `tasks`.

The `tasks` table stores:

* Task ID
* Task title
* Task description
* Reminder date
* Completion status
* Created date

The database table structure is:

```sql
CREATE DATABASE IF NOT EXISTS cybersecurity_chatbot;

USE cybersecurity_chatbot;

CREATE TABLE IF NOT EXISTS tasks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    reminder_date DATETIME NULL,
    is_completed BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

---

### Cybersecurity Quiz

The application includes a cybersecurity quiz to test the user's cybersecurity knowledge.

Quiz features include:

* More than 10 questions
* Multiple-choice questions
* True or false questions
* One question displayed at a time
* Immediate feedback after each answer
* Score tracking
* Final score display
* Final feedback based on performance

The quiz covers topics such as:

* Phishing
* Password safety
* OTP safety
* Malware
* Public WiFi
* Social media privacy
* Safe browsing
* Software updates

---

### NLP Simulation

The chatbot uses simple NLP-style keyword and phrase recognition to understand different user commands.

The chatbot can recognise commands such as:

```text
start quiz
take quiz
quiz me
add task to review privacy settings
create task to update my password
remind me to check my privacy settings tomorrow
show activity log
what have you done for me
```

This allows the chatbot to respond to different ways of asking for the same action.

---

### Activity Log

The application includes an activity log that records important actions completed by the chatbot.

The activity log records actions such as:

* Application started
* User name saved
* Favourite topic saved
* Task added
* Task completed
* Task deleted
* Reminder set
* Quiz started
* Quiz question answered
* Quiz completed
* Activity log requested
* Voice greeting played

The activity log can be viewed in the Activity Log tab or requested through the chatbot by typing:

```text
show activity log
```

or

```text
what have you done for me
```

---

## Cybersecurity Topics Covered

The chatbot can respond to questions about:

* Password safety
* Phishing
* Online scams
* Privacy
* Malware
* Public WiFi
* Online banking safety
* Social media safety
* Safe browsing
* Identity theft
* Software updates
* OTP and PIN safety
* Suspicious links

---

## How the Chatbot Works

When the application starts, the chatbot welcomes the user and asks for their name. After the user enters their name, the chatbot personalises the conversation.

The user can then ask questions about cybersecurity topics. The chatbot checks the user's input for keywords and provides a relevant response.

The chatbot can also remember the user's favourite cybersecurity topic and recall it later in the conversation.

For Part 3, the chatbot can also help the user manage cybersecurity-related tasks, start a quiz, and show recent activity.

---

## Example Conversation

```text
Chatbot: Welcome to the Cybersecurity Awareness Chatbot.

Chatbot: Please type your name first so I can personalise the chat.

You: Tashreeq

Chatbot: Nice to meet you, Tashreeq! You can ask about cybersecurity topics or ask me to add cybersecurity tasks.

You: password

Chatbot: A strong password should be at least 12 characters long and should not include personal details.

You: tell me more

Chatbot: Sure, Tashreeq. Here is more about password: Use strong passwords with uppercase letters, lowercase letters, numbers, and symbols.

You: I am worried about scams

Chatbot: It’s understandable to feel worried. Cybersecurity can seem stressful, but simple habits can protect you.

You: I am interested in privacy

Chatbot: Great, Tashreeq. I’ll remember that you are interested in privacy.

You: add task to review privacy settings tomorrow

Chatbot: Task added: Review privacy settings. Reminder set.

You: start quiz

Chatbot: Cybersecurity quiz started. Go to the Quiz tab and choose an answer.

You: show activity log

Chatbot: Here’s a summary of recent actions:
1. User name saved.
2. Favourite topic saved.
3. Task added.
4. Quiz started.
```

---

## Technologies Used

* C#
* .NET 8
* Windows Forms
* Visual Studio 2022
* MySQL
* MySQL Workbench
* MySql.Data NuGet package
* System.Media for audio playback
* GitHub for version control

---

## Project Structure

```text
CyberSecurityChatbotPart2

- Form1.cs
- Form1.Designer.cs
- Form1.resx
- Program.cs
- Greeting.wav
- CyberSecurityChatbotPart2.csproj
- README.md
```

---

## How to Run the Project

1. Open the project in Visual Studio 2022.
2. Make sure the project is set as the startup project.
3. Ensure that `Greeting.wav` is included in the project.
4. Select `Greeting.wav` and check that:

   * Build Action is set correctly
   * Copy to Output Directory is set to `Copy if newer`
5. Make sure MySQL is installed and running.
6. Open MySQL Workbench and create the database and table, or allow the application code to create them automatically.
7. Install the MySQL NuGet package if it is not already installed:

```powershell
Install-Package MySql.Data
```

8. Update the MySQL connection string in `Form1.cs` with the correct local MySQL password.
9. Click the green Start button to run the application.
10. Type your name first.
11. Start asking cybersecurity-related questions or use the Tasks, Quiz, and Activity Log tabs.

---

## Important Security Note

The MySQL password should not be uploaded to a public GitHub repository. Before pushing the final project to GitHub, either remove the real password, replace it with a placeholder, or make the repository private.

Example placeholder:

```csharp
private readonly string serverConnectionString = "server=localhost;port=3306;user=root;password=YOUR_PASSWORD;";
```

---

## Requirements Covered

| Requirement                                     | Status    |
| ----------------------------------------------- | --------- |
| Create a GUI application using WinForms         | Completed |
| Translate Task 1 chatbot into GUI               | Completed |
| Include voice implementation                    | Completed |
| Use keyword recognition                         | Completed |
| Recognise at least three cybersecurity keywords | Completed |
| Use random responses                            | Completed |
| Use arrays, lists, or dictionaries              | Completed |
| Maintain conversation flow                      | Completed |
| Implement memory and recall                     | Completed |
| Implement sentiment detection                   | Completed |
| Handle errors and unknown inputs                | Completed |
| Use methods and good code organisation          | Completed |
| Use delegates                                   | Completed |
| Add task assistant                              | Completed |
| Store tasks in MySQL database                   | Completed |
| Add optional reminders                          | Completed |
| Mark tasks as completed                         | Completed |
| Delete tasks                                    | Completed |
| Add cybersecurity quiz                          | Completed |
| Include more than 10 quiz questions             | Completed |
| Use multiple-choice and true/false questions    | Completed |
| Show immediate quiz feedback                    | Completed |
| Track and display final quiz score              | Completed |
| Add NLP-style command recognition               | Completed |
| Add activity log                                | Completed |
| Display recent activity                         | Completed |

---

## References

CloudConvert, 2026. *M4A to WAV converter*. Available at: https://cloudconvert.com/m4a-to-wav (Accessed: 22 June 2026).

Cybersecurity and Infrastructure Security Agency, 2024. *Secure Our World*. Available at: https://www.cisa.gov/secure-our-world (Accessed: 22 June 2026).

Cybersecurity and Infrastructure Security Agency, 2024. *Avoiding Social Engineering and Phishing Attacks*. Available at: https://www.cisa.gov/news-events/news/avoiding-social-engineering-and-phishing-attacks (Accessed: 22 June 2026).

GitHub, 2026. *GitHub Docs: About repositories*. Available at: https://docs.github.com/en/repositories/creating-and-managing-repositories/about-repositories (Accessed: 22 June 2026).

Microsoft, 2024. *C# documentation*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/ (Accessed: 22 June 2026).

Microsoft, 2024. *Windows Forms documentation for .NET*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/ (Accessed: 22 June 2026).

Microsoft, 2024. *System.Media.SoundPlayer class*. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer (Accessed: 22 June 2026).

Microsoft, 2024. *Collections and data structures in C#*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections (Accessed: 22 June 2026).

Microsoft, 2024. *Delegates in C#*. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/ (Accessed: 22 June 2026).

Microsoft, 2024. *DataGridView control overview*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/datagridview-control-overview-windows-forms (Accessed: 22 June 2026).

Microsoft, 2024. *ListBox control overview*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/listbox-control-overview-windows-forms (Accessed: 22 June 2026).

Microsoft, 2024. *RadioButton control overview*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/radiobutton-control-overview-windows-forms (Accessed: 22 June 2026).

Microsoft, 2024. *DateTimePicker control overview*. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/datetimepicker-control-overview-windows-forms (Accessed: 22 June 2026).

Microsoft, 2024. *Visual Studio documentation*. Available at: https://learn.microsoft.com/en-us/visualstudio/windows/ (Accessed: 22 June 2026).

MySQL, 2026. *MySQL Documentation*. Available at: https://dev.mysql.com/doc/ (Accessed: 22 June 2026).

MySQL, 2026. *MySQL Workbench Manual*. Available at: https://dev.mysql.com/doc/workbench/en/ (Accessed: 22 June 2026).

NuGet, 2026. *MySql.Data package*. Available at: https://www.nuget.org/packages/MySql.Data/ (Accessed: 22 June 2026).

National Cyber Security Centre, 2024. *Phishing attacks: Defending your organisation*. Available at: https://www.ncsc.gov.uk/guidance/phishing (Accessed: 22 June 2026).

National Cyber Security Centre, 2024. *Top tips for staying secure online*. Available at: https://www.ncsc.gov.uk/collection/top-tips-for-staying-secure-online (Accessed: 22 June 2026).

Oracle, 2026. *MySQL Connector/NET Developer Guide*. Available at: https://dev.mysql.com/doc/connector-net/en/ (Accessed: 22 June 2026).

---

## Author

Tashreeq Phipps

---

## Notes

This project was created for the Cybersecurity Awareness Chatbot POE. It demonstrates GUI design, user interaction, cybersecurity keyword recognition, memory recall, sentiment detection, random responses, use of generic collections, delegates, voice playback, MySQL database integration, task management, quiz functionality, NLP-style command recognition, and activity logging in a C# Windows Forms application.
