using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CyberSecurityChatbotPart2_
{
    public partial class Form1 : Form
    {
        private string userName = "";
        private string favouriteTopic = "";
        private string currentTopic = "";

        private readonly Random random = new Random();

        private readonly string serverConnectionString = "server=localhost;port=3306;user=root;password=Tashreeqq1;AllowPublicKeyRetrieval=True;SslMode=Disabled;";
        private readonly string databaseConnectionString = "server=localhost;port=3306;database=cybersecurity_chatbot;user=root;password=Tashreeqq1;AllowPublicKeyRetrieval=True;SslMode=Disabled;";

        private readonly List<string> activityLog = new List<string>();

        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuizIndex = 0;
        private int quizScore = 0;
        private bool quizActive = false;

        // Delegate requirement
        private delegate string ResponseDelegate(string input);

        // Generic collection requirement: Dictionary + Lists
        private readonly Dictionary<string, List<string>> cyberResponses;

        public Form1()
        {
            InitializeComponent();

            // Manually connect task buttons
            btnAddTask.Click -= btnAddTask_Click;
            btnAddTask.Click += btnAddTask_Click;

            btnCompleteTask.Click -= btnCompleteTask_Click;
            btnCompleteTask.Click += btnCompleteTask_Click;

            btnDeleteTask.Click -= btnDeleteTask_Click;
            btnDeleteTask.Click += btnDeleteTask_Click;

            // Manually connect Activity Log buttons
            btnRefreshLog.Click -= btnRefreshLog_Click;
            btnRefreshLog.Click += btnRefreshLog_Click;

            btnClearLog.Click -= btnClearLog_Click;
            btnClearLog.Click += btnClearLog_Click;

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
            AddBotMessage("For Part 3, you can also ask me to add tasks, set reminders, start the quiz, or show the activity log.");

            SetupTaskGrid();
            SetupQuiz();
            SetupActivityLog();

            try
            {
                EnsureDatabaseAndTable();
                LoadTasks();
                AddActivityLog("Application started and task database loaded.");
            }
            catch (Exception ex)
            {
                AddBotMessage("Database setup failed: " + ex.Message);
                AddBotMessage("Check your MySQL password in the connection string.");
            }

            PlayVoiceGreeting(false);
        }

        // =========================
        // CHATBOT BUTTONS
        // =========================

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
            AddBotMessage("Chat cleared. How can I help you stay safe online?");
            AddActivityLog("Chat cleared.");
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

            if (string.IsNullOrEmpty(userName))
            {
                userName = input.Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = "User";
                }

                AddActivityLog("User name saved as " + userName + ".");
                return $"Nice to meet you, {userName}! You can ask about cybersecurity topics or ask me to add cybersecurity tasks.";
            }

            if (input.Contains("start quiz") || input.Contains("take quiz") || input.Contains("quiz me") || input.Contains("cybersecurity quiz"))
            {
                StartQuiz();
                AddActivityLog("Quiz started from chatbot command.");
                return "Cybersecurity quiz started. Go to the Quiz tab and choose an answer.";
            }

            if (input.Contains("show activity log") || input.Contains("what have you done for me") || input.Contains("recent actions"))
            {
                AddActivityLog("Activity log requested from chatbot.");
                return GetActivityLogSummary();
            }

            if (IsTaskCommand(input))
            {
                return HandleTaskCommand(input);
            }

            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = "User";
                }

                AddActivityLog("User updated name to " + userName + ".");
                return $"Thanks, I’ll remember your name is {userName}.";
            }

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

                AddActivityLog("Favourite topic saved as " + favouriteTopic + ".");
                return $"Great, {userName}. I’ll remember that you are interested in {favouriteTopic}.";
            }

            if (input.Contains("what do you remember") || input.Contains("remember me") || input.Contains("what did i tell you"))
            {
                AddActivityLog("Memory recall requested.");

                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    return $"I remember that your name is {userName} and you are interested in {favouriteTopic}.";
                }

                return $"I remember that your name is {userName}, but you have not told me your favourite cybersecurity topic yet.";
            }

            if (input.Contains("tell me more") || input.Contains("explain more") || input.Contains("another tip") || input.Contains("more detail") || input.Contains("give me more"))
            {
                if (!string.IsNullOrEmpty(currentTopic) && cyberResponses.ContainsKey(currentTopic))
                {
                    string followUp = GetRandomResponse(currentTopic);
                    AddActivityLog("Follow-up response given for topic: " + currentTopic);
                    return $"Sure, {userName}. Here is more about {currentTopic}: {followUp}";
                }

                return "Sure, I can explain more. Please first ask about a topic like phishing, passwords, scams, privacy, malware, WiFi, banking, social media, or safe browsing.";
            }

            if (input.Contains("how are you"))
            {
                return $"I'm doing well, {userName}. I'm ready to help you learn how to stay safe online.";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to teach users about cybersecurity threats, help manage cybersecurity tasks, and test knowledge using a quiz.";
            }

            if (input.Contains("what can i ask") || input.Contains("help"))
            {
                return "You can ask me about passwords, phishing, scams, privacy, malware, WiFi, banking safety, OTPs, social media safety, safe browsing, tasks, reminders, quizzes, or activity logs.";
            }

            string detectedTopic = FindTopicFromInput(input);

            if (!string.IsNullOrEmpty(detectedTopic))
            {
                currentTopic = detectedTopic;
                string response = GetRandomResponse(detectedTopic);
                AddActivityLog("Cybersecurity topic answered: " + detectedTopic);

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            if (input.Contains("otp") || input.Contains("pin"))
            {
                currentTopic = "banking";
                AddActivityLog("Banking safety response given.");

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
                AddActivityLog("Software update safety response given.");

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
                AddActivityLog("Suspicious link safety response given.");

                string response = "Do not click suspicious links. Check the website address carefully and use the official website instead.";

                if (!string.IsNullOrEmpty(sentimentMessage))
                {
                    return sentimentMessage + " " + response;
                }

                return response;
            }

            if (!string.IsNullOrEmpty(sentimentMessage))
            {
                AddActivityLog("Sentiment detected in user message.");
                return sentimentMessage + " Try asking me about passwords, phishing, scams, privacy, malware, WiFi, banking safety, task reminders, or the quiz so I can help you further.";
            }

            return "I’m not sure I understand. Try asking about cybersecurity topics, or say something like 'add task to review privacy settings', 'start quiz', or 'show activity log'.";
        }

        // =========================
        // TASK ASSISTANT + MYSQL
        // =========================

        private void SetupTaskGrid()
        {
            dgvTasks.ReadOnly = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.AllowUserToAddRows = false;
        }

        private void EnsureDatabaseAndTable()
        {
            using (MySqlConnection connection = new MySqlConnection(serverConnectionString))
            {
                connection.Open();

                string createDatabase = "CREATE DATABASE IF NOT EXISTS cybersecurity_chatbot;";
                using (MySqlCommand command = new MySqlCommand(createDatabase, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
            {
                connection.Open();

                string createTable = @"
                    CREATE TABLE IF NOT EXISTS tasks (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        title VARCHAR(255) NOT NULL,
                        description TEXT,
                        reminder_date DATETIME NULL,
                        is_completed BOOLEAN DEFAULT FALSE,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";

                using (MySqlCommand command = new MySqlCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadTasks()
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        id AS ID,
                        title AS Title,
                        description AS Description,
                        reminder_date AS Reminder,
                        is_completed AS Completed,
                        created_at AS Created
                    FROM tasks
                    ORDER BY created_at DESC;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvTasks.DataSource = table;
                }
            }
        }

        private void AddTaskToDatabase(string title, string description, DateTime? reminderDate)
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO tasks (title, description, reminder_date)
                    VALUES (@title, @description, @reminderDate);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);

                    if (reminderDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@reminderDate", reminderDate.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@reminderDate", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetSelectedTaskId()
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                return -1;
            }

            object idValue = dgvTasks.SelectedRows[0].Cells["ID"].Value;

            if (idValue == null)
            {
                return -1;
            }

            return Convert.ToInt32(idValue);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string description = txtTaskDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                description = "No description provided.";
            }

            DateTime? reminderDate = null;

            if (chkReminder.Checked)
            {
                reminderDate = dtpReminder.Value;
            }

            try
            {
                AddTaskToDatabase(title, description, reminderDate);
                LoadTasks();

                txtTaskTitle.Clear();
                txtTaskDescription.Clear();
                chkReminder.Checked = false;

                AddActivityLog("Task added: " + title);

                if (reminderDate.HasValue)
                {
                    AddActivityLog("Reminder set for task '" + title + "' on " + reminderDate.Value.ToString("yyyy-MM-dd HH:mm"));
                }

                MessageBox.Show("Task added successfully.", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Task could not be added: " + ex.Message);
            }
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            int taskId = GetSelectedTaskId();

            if (taskId == -1)
            {
                MessageBox.Show("Please select a task to mark as complete.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
                {
                    connection.Open();

                    string query = "UPDATE tasks SET is_completed = TRUE WHERE id = @id;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", taskId);
                        command.ExecuteNonQuery();
                    }
                }

                LoadTasks();
                AddActivityLog("Task marked as completed. Task ID: " + taskId);
                MessageBox.Show("Task marked as complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Task could not be updated: " + ex.Message);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            int taskId = GetSelectedTaskId();

            if (taskId == -1)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM tasks WHERE id = @id;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", taskId);
                        command.ExecuteNonQuery();
                    }
                }

                LoadTasks();
                AddActivityLog("Task deleted. Task ID: " + taskId);
                MessageBox.Show("Task deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Task could not be deleted: " + ex.Message);
            }
        }

        // =========================
        // QUIZ FEATURE
        // =========================

        private void SetupQuiz()
        {
            lblQuestion.Text = "Click Start Quiz to begin";
            lblScore.Text = "Score: 0";
            rtbQuizFeedback.Clear();

            rbOptionA.Text = "Option A";
            rbOptionB.Text = "Option B";
            rbOptionC.Text = "Option C";
            rbOptionD.Text = "Option D";

            rbOptionA.Checked = false;
            rbOptionB.Checked = false;
            rbOptionC.Checked = false;
            rbOptionD.Checked = false;
        }

        private void LoadQuizQuestions()
        {
            quizQuestions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string> { "A fake message used to steal information", "A type of antivirus", "A safe website", "A computer update" },
                    CorrectAnswerIndex = 0,
                    Explanation = "Phishing tricks users into sharing passwords, banking details, or personal information."
                },
                new QuizQuestion
                {
                    Question = "True or False: You should share your OTP with someone if they say they work for the bank.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Banks will never ask for your OTP, PIN, or password."
                },
                new QuizQuestion
                {
                    Question = "Which password is strongest?",
                    Options = new List<string> { "password123", "tashreeq2003", "Blue!River92#Sun", "12345678" },
                    CorrectAnswerIndex = 2,
                    Explanation = "A strong password uses a mix of letters, numbers, and symbols."
                },
                new QuizQuestion
                {
                    Question = "What should you do before clicking a link in an email?",
                    Options = new List<string> { "Click immediately", "Check the sender and URL", "Forward it to everyone", "Reply with your password" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Always check the sender and website address before clicking links."
                },
                new QuizQuestion
                {
                    Question = "True or False: Public WiFi is always safe for online banking.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Public WiFi can be risky, especially for banking or private accounts."
                },
                new QuizQuestion
                {
                    Question = "What does malware mean?",
                    Options = new List<string> { "Helpful software", "Harmful software", "A secure password", "A website certificate" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Malware is harmful software that can damage devices or steal data."
                },
                new QuizQuestion
                {
                    Question = "Which action helps protect your social media privacy?",
                    Options = new List<string> { "Posting your address", "Accepting every request", "Using privacy settings", "Sharing your password" },
                    CorrectAnswerIndex = 2,
                    Explanation = "Privacy settings help control who can see your posts and personal details."
                },
                new QuizQuestion
                {
                    Question = "True or False: Software updates can fix security weaknesses.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 0,
                    Explanation = "Updates often fix security vulnerabilities that attackers could use."
                },
                new QuizQuestion
                {
                    Question = "What should you do if a message says your account will be blocked unless you click a link?",
                    Options = new List<string> { "Click quickly", "Ignore all security warnings forever", "Check directly with the official company", "Send your login details" },
                    CorrectAnswerIndex = 2,
                    Explanation = "Scammers often use panic and urgency. Verify using official contact details."
                },
                new QuizQuestion
                {
                    Question = "What does HTTPS usually show?",
                    Options = new List<string> { "The site is using a secure connection", "The site is definitely fake", "The site has no internet", "The site is a game" },
                    CorrectAnswerIndex = 0,
                    Explanation = "HTTPS means the connection is encrypted, but you should still check the website address."
                },
                new QuizQuestion
                {
                    Question = "True or False: It is safe to use the same password for all accounts.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Using the same password everywhere is risky because one breach can expose many accounts."
                },
                new QuizQuestion
                {
                    Question = "Which information should you avoid posting publicly online?",
                    Options = new List<string> { "A general hobby", "Your favourite sport", "Your home address and ID number", "A public quote" },
                    CorrectAnswerIndex = 2,
                    Explanation = "Sensitive personal details can be used for identity theft or scams."
                }
            };
        }

        private void StartQuiz()
        {
            LoadQuizQuestions();

            currentQuizIndex = 0;
            quizScore = 0;
            quizActive = true;

            lblScore.Text = "Score: 0";
            rtbQuizFeedback.Clear();

            AddActivityLog("Cybersecurity quiz started.");

            DisplayCurrentQuestion();
        }

        private void DisplayCurrentQuestion()
        {
            if (currentQuizIndex >= quizQuestions.Count)
            {
                EndQuiz();
                return;
            }

            QuizQuestion question = quizQuestions[currentQuizIndex];

            lblQuestion.Text = "Question " + (currentQuizIndex + 1) + " of " + quizQuestions.Count + ": " + question.Question;

            rbOptionA.Visible = true;
            rbOptionB.Visible = true;
            rbOptionC.Visible = true;
            rbOptionD.Visible = true;

            rbOptionA.Checked = false;
            rbOptionB.Checked = false;
            rbOptionC.Checked = false;
            rbOptionD.Checked = false;

            rbOptionA.Text = question.Options[0];
            rbOptionB.Text = question.Options[1];

            if (question.Options.Count > 2)
            {
                rbOptionC.Text = question.Options[2];
                rbOptionD.Text = question.Options[3];
                rbOptionC.Visible = true;
                rbOptionD.Visible = true;
            }
            else
            {
                rbOptionC.Text = "";
                rbOptionD.Text = "";
                rbOptionC.Visible = false;
                rbOptionD.Visible = false;
            }
        }

        private int GetSelectedQuizAnswer()
        {
            if (rbOptionA.Checked)
                return 0;

            if (rbOptionB.Checked)
                return 1;

            if (rbOptionC.Checked)
                return 2;

            if (rbOptionD.Checked)
                return 3;

            return -1;
        }

        private void SubmitQuizAnswer()
        {
            if (!quizActive)
            {
                MessageBox.Show("Please click Start Quiz first.", "Quiz Not Started", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedAnswer = GetSelectedQuizAnswer();

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Please select an answer.", "No Answer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuizQuestion question = quizQuestions[currentQuizIndex];

            if (selectedAnswer == question.CorrectAnswerIndex)
            {
                quizScore++;
                rtbQuizFeedback.AppendText("Question " + (currentQuizIndex + 1) + ": Correct!" + Environment.NewLine);
                AddActivityLog("Quiz question answered correctly.");
            }
            else
            {
                string correctAnswer = question.Options[question.CorrectAnswerIndex];
                rtbQuizFeedback.AppendText("Question " + (currentQuizIndex + 1) + ": Incorrect. Correct answer: " + correctAnswer + Environment.NewLine);
                AddActivityLog("Quiz question answered incorrectly.");
            }

            rtbQuizFeedback.AppendText("Explanation: " + question.Explanation + Environment.NewLine + Environment.NewLine);
            lblScore.Text = "Score: " + quizScore;

            currentQuizIndex++;

            if (currentQuizIndex >= quizQuestions.Count)
            {
                EndQuiz();
            }
            else
            {
                DisplayCurrentQuestion();
            }
        }

        private void EndQuiz()
        {
            quizActive = false;

            int percentage = (int)((double)quizScore / quizQuestions.Count * 100);

            lblQuestion.Text = "Quiz completed!";
            rbOptionA.Visible = false;
            rbOptionB.Visible = false;
            rbOptionC.Visible = false;
            rbOptionD.Visible = false;

            rtbQuizFeedback.AppendText("Final Score: " + quizScore + " out of " + quizQuestions.Count + " (" + percentage + "%)" + Environment.NewLine);

            if (percentage >= 80)
            {
                rtbQuizFeedback.AppendText("Excellent work! You have strong cybersecurity awareness." + Environment.NewLine);
            }
            else if (percentage >= 50)
            {
                rtbQuizFeedback.AppendText("Good effort. Revise phishing, passwords, privacy, and safe browsing." + Environment.NewLine);
            }
            else
            {
                rtbQuizFeedback.AppendText("Keep practising. Cybersecurity awareness improves with repetition." + Environment.NewLine);
            }

            AddActivityLog("Cybersecurity quiz completed. Final score: " + quizScore + "/" + quizQuestions.Count);
        }

        // =========================
        // NLP SIMULATION FOR TASKS
        // =========================

        private bool IsTaskCommand(string input)
        {
            return input.Contains("add task") ||
                   input.Contains("create task") ||
                   input.Contains("new task") ||
                   input.Contains("set reminder") ||
                   input.Contains("remind me") ||
                   input.Contains("reminder");
        }

        private string HandleTaskCommand(string input)
        {
            string title = ExtractTaskTitle(input);
            DateTime? reminderDate = ExtractReminderDate(input);

            string description = "Cybersecurity task created from chatbot command.";

            try
            {
                AddTaskToDatabase(title, description, reminderDate);
                LoadTasks();

                AddActivityLog("NLP task command detected.");
                AddActivityLog("Task added through chatbot: " + title);

                if (reminderDate.HasValue)
                {
                    AddActivityLog("Reminder set through chatbot for '" + title + "' on " + reminderDate.Value.ToString("yyyy-MM-dd HH:mm"));
                    return $"Task added: {title}. Reminder set for {reminderDate.Value:yyyy-MM-dd HH:mm}.";
                }

                return $"Task added: {title}. Would you like to set a reminder for this task?";
            }
            catch (Exception ex)
            {
                return "I understood that you wanted to add a task, but I could not save it to the database: " + ex.Message;
            }
        }

        private string ExtractTaskTitle(string input)
        {
            string title = input;

            title = title.Replace("add task", "")
                         .Replace("create task", "")
                         .Replace("new task", "")
                         .Replace("set reminder", "")
                         .Replace("remind me to", "")
                         .Replace("remind me", "")
                         .Replace("tomorrow", "")
                         .Replace("next week", "")
                         .Replace("in 3 days", "")
                         .Replace("in 5 days", "")
                         .Replace("in 7 days", "")
                         .Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                title = "Review cybersecurity settings";
            }

            return char.ToUpper(title[0]) + title.Substring(1);
        }

        private DateTime? ExtractReminderDate(string input)
        {
            if (input.Contains("tomorrow"))
                return DateTime.Now.AddDays(1);

            if (input.Contains("next week"))
                return DateTime.Now.AddDays(7);

            if (input.Contains("in 3 days"))
                return DateTime.Now.AddDays(3);

            if (input.Contains("in 5 days"))
                return DateTime.Now.AddDays(5);

            if (input.Contains("in 7 days"))
                return DateTime.Now.AddDays(7);

            return null;
        }

        // =========================
        // ACTIVITY LOG
        // =========================

        private void SetupActivityLog()
        {
            lstActivityLog.Items.Clear();
            lstActivityLog.Items.Add("Activity log ready.");
        }

        private void AddActivityLog(string action)
        {
            string entry = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + action;
            activityLog.Add(entry);
            RefreshActivityLogDisplay();
        }

        private void RefreshActivityLogDisplay()
        {
            if (lstActivityLog == null)
            {
                return;
            }

            lstActivityLog.Items.Clear();

            if (activityLog.Count == 0)
            {
                lstActivityLog.Items.Add("No activity has been recorded yet.");
                return;
            }

            int startIndex = Math.Max(0, activityLog.Count - 10);

            for (int i = startIndex; i < activityLog.Count; i++)
            {
                lstActivityLog.Items.Add(activityLog[i]);
            }
        }

        private string GetActivityLogSummary()
        {
            if (activityLog.Count == 0)
            {
                return "No activity has been recorded yet.";
            }

            int startIndex = Math.Max(0, activityLog.Count - 10);
            List<string> recentActions = activityLog.GetRange(startIndex, activityLog.Count - startIndex);

            string summary = "Here’s a summary of recent actions:" + Environment.NewLine;

            for (int i = 0; i < recentActions.Count; i++)
            {
                summary += (i + 1) + ". " + recentActions[i] + Environment.NewLine;
            }

            return summary;
        }

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            RefreshActivityLogDisplay();
            MessageBox.Show("Activity log refreshed.");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the activity log?", "Clear Activity Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                activityLog.Clear();
                RefreshActivityLogDisplay();
                MessageBox.Show("Activity log cleared.");
            }
        }

        // =========================
        // CYBERSECURITY CHATBOT HELPERS
        // =========================

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
                return "It’s understandable to feel worried. Cybersecurity can seem stressful, but simple habits can protect you.";

            if (input.Contains("confused") || input.Contains("unsure") || input.Contains("don't understand") || input.Contains("do not understand"))
                return "No problem, I’ll explain it in a simple way.";

            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("irritated"))
                return "I understand that it can be frustrating. Let’s take it step by step.";

            if (input.Contains("curious") || input.Contains("interested"))
                return "That’s great! Being curious is a good way to learn how to stay safe online.";

            if (input.Contains("happy") || input.Contains("good") || input.Contains("great"))
                return "That’s good to hear. Let’s keep building strong online safety habits.";

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

                    AddActivityLog("Voice greeting played.");
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

        // =========================
        // QUIZ QUESTION CLASS
        // =========================

        private class QuizQuestion
        {
            public string Question { get; set; } = "";
            public List<string> Options { get; set; } = new List<string>();
            public int CorrectAnswerIndex { get; set; }
            public string Explanation { get; set; } = "";
        }

        // =========================
        // EMPTY DESIGNER EVENTS
        // =========================

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip4_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnStartQui_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubmitQuizAnswer();
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            SubmitQuizAnswer();
        }
    }
}