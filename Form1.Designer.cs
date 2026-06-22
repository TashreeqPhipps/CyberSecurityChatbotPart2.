namespace CyberSecurityChatbotPart2_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            rtbChat = new RichTextBox();
            txtUserInput = new TextBox();
            btnSend = new Button();
            btnClear = new Button();
            btnVoice = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dgvTasks = new DataGridView();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            btnAddTask = new Button();
            dtpReminder = new DateTimePicker();
            chkReminder = new CheckBox();
            txtTaskTitle = new TextBox();
            txtTaskDescription = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage3 = new TabPage();
            rtbQuizFeedback = new RichTextBox();
            lblScore = new Label();
            button2 = new Button();
            btnStartQui = new Button();
            rbOptionD = new RadioButton();
            rbOptionC = new RadioButton();
            rbOptionB = new RadioButton();
            rbOptionA = new RadioButton();
            lblQuestion = new Label();
            tabPage4 = new TabPage();
            lstActivityLog = new ListBox();
            btnRefreshLog = new Button();
            btnClearLog = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(6, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(461, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cybersecurity Awareness Chatbot";
            lblTitle.Click += label1_Click;
            // 
            // rtbChat
            // 
            rtbChat.Location = new Point(11, 77);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(563, 404);
            rtbChat.TabIndex = 1;
            rtbChat.Text = "";
            rtbChat.TextChanged += rtbChat_TextChanged;
            // 
            // txtUserInput
            // 
            txtUserInput.Location = new Point(11, 487);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(563, 27);
            txtUserInput.TabIndex = 2;
            txtUserInput.TextChanged += txtUserInput_TextChanged;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(650, 77);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += button1_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(650, 237);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear Chat";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnVoice
            // 
            btnVoice.Location = new Point(650, 159);
            btnVoice.Name = "btnVoice";
            btnVoice.Size = new Size(94, 29);
            btnVoice.TabIndex = 5;
            btnVoice.Text = "Play Voice Greeting";
            btnVoice.UseVisualStyleBackColor = true;
            btnVoice.Click += btnVoice_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(-3, -4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(924, 660);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSend);
            tabPage1.Controls.Add(btnClear);
            tabPage1.Controls.Add(txtUserInput);
            tabPage1.Controls.Add(rtbChat);
            tabPage1.Controls.Add(btnVoice);
            tabPage1.Controls.Add(lblTitle);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(916, 627);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Chatbot";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvTasks);
            tabPage2.Controls.Add(btnDeleteTask);
            tabPage2.Controls.Add(btnCompleteTask);
            tabPage2.Controls.Add(btnAddTask);
            tabPage2.Controls.Add(dtpReminder);
            tabPage2.Controls.Add(chkReminder);
            tabPage2.Controls.Add(txtTaskTitle);
            tabPage2.Controls.Add(txtTaskDescription);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(916, 627);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tasks";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTasks
            // 
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(23, 246);
            dgvTasks.MultiSelect = false;
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.Size = new Size(586, 274);
            dgvTasks.TabIndex = 10;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(551, 128);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(94, 29);
            btnDeleteTask.TabIndex = 9;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.Location = new Point(551, 69);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(141, 29);
            btnCompleteTask.TabIndex = 8;
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(551, 25);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(94, 29);
            btnAddTask.TabIndex = 7;
            btnAddTask.Text = " Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // dtpReminder
            // 
            dtpReminder.Location = new Point(23, 170);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.Size = new Size(586, 27);
            dtpReminder.TabIndex = 6;
            // 
            // chkReminder
            // 
            chkReminder.AutoSize = true;
            chkReminder.Location = new Point(171, 108);
            chkReminder.Name = "chkReminder";
            chkReminder.Size = new Size(120, 24);
            chkReminder.TabIndex = 5;
            chkReminder.Text = "Set Reminder";
            chkReminder.UseVisualStyleBackColor = true;
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(171, 25);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(348, 27);
            txtTaskTitle.TabIndex = 4;
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(171, 64);
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(348, 34);
            txtTaskDescription.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 108);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Reminder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 67);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Task Title:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(rtbQuizFeedback);
            tabPage3.Controls.Add(lblScore);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(btnStartQui);
            tabPage3.Controls.Add(rbOptionD);
            tabPage3.Controls.Add(rbOptionC);
            tabPage3.Controls.Add(rbOptionB);
            tabPage3.Controls.Add(rbOptionA);
            tabPage3.Controls.Add(lblQuestion);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(916, 627);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Quiz";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbQuizFeedback
            // 
            rtbQuizFeedback.Location = new Point(11, 402);
            rtbQuizFeedback.Name = "rtbQuizFeedback";
            rtbQuizFeedback.Size = new Size(446, 186);
            rtbQuizFeedback.TabIndex = 8;
            rtbQuizFeedback.Text = "";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(22, 361);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(61, 20);
            lblScore.TabIndex = 7;
            lblScore.Text = "Score: 0";
            // 
            // button2
            // 
            button2.Location = new Point(11, 308);
            button2.Name = "button2";
            button2.Size = new Size(149, 29);
            button2.TabIndex = 6;
            button2.Text = "Submit Answer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnStartQui
            // 
            btnStartQui.Location = new Point(11, 257);
            btnStartQui.Name = "btnStartQui";
            btnStartQui.Size = new Size(94, 29);
            btnStartQui.TabIndex = 5;
            btnStartQui.Text = "Start Quiz";
            btnStartQui.UseVisualStyleBackColor = true;
            btnStartQui.Click += btnStartQui_Click;
            // 
            // rbOptionD
            // 
            rbOptionD.AutoSize = true;
            rbOptionD.Location = new Point(11, 208);
            rbOptionD.Name = "rbOptionD";
            rbOptionD.Size = new Size(91, 24);
            rbOptionD.TabIndex = 4;
            rbOptionD.Text = "Option D";
            rbOptionD.UseVisualStyleBackColor = true;
            // 
            // rbOptionC
            // 
            rbOptionC.AutoSize = true;
            rbOptionC.Location = new Point(11, 157);
            rbOptionC.Name = "rbOptionC";
            rbOptionC.Size = new Size(89, 24);
            rbOptionC.TabIndex = 3;
            rbOptionC.Text = "Option C";
            rbOptionC.UseVisualStyleBackColor = true;
            // 
            // rbOptionB
            // 
            rbOptionB.AutoSize = true;
            rbOptionB.Location = new Point(11, 108);
            rbOptionB.Name = "rbOptionB";
            rbOptionB.Size = new Size(89, 24);
            rbOptionB.TabIndex = 2;
            rbOptionB.Text = "Option B";
            rbOptionB.UseVisualStyleBackColor = true;
            // 
            // rbOptionA
            // 
            rbOptionA.AutoSize = true;
            rbOptionA.Checked = true;
            rbOptionA.Location = new Point(11, 55);
            rbOptionA.Name = "rbOptionA";
            rbOptionA.Size = new Size(90, 24);
            rbOptionA.TabIndex = 1;
            rbOptionA.TabStop = true;
            rbOptionA.Text = "Option A";
            rbOptionA.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(11, 16);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(169, 20);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Click Start Quiz to begin";
            lblQuestion.Click += label4_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnClearLog);
            tabPage4.Controls.Add(btnRefreshLog);
            tabPage4.Controls.Add(lstActivityLog);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(916, 627);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Activity Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lstActivityLog
            // 
            lstActivityLog.FormattingEnabled = true;
            lstActivityLog.Location = new Point(21, 77);
            lstActivityLog.Name = "lstActivityLog";
            lstActivityLog.Size = new Size(571, 424);
            lstActivityLog.TabIndex = 0;
            // 
            // btnRefreshLog
            // 
            btnRefreshLog.Location = new Point(21, 26);
            btnRefreshLog.Name = "btnRefreshLog";
            btnRefreshLog.Size = new Size(194, 29);
            btnRefreshLog.TabIndex = 1;
            btnRefreshLog.Text = "Refresh Log";
            btnRefreshLog.UseVisualStyleBackColor = true;
            btnRefreshLog.Click += btnRefreshLog_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(240, 26);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(240, 29);
            btnClearLog.TabIndex = 2;
            btnClearLog.Text = "Clear Log";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 713);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private RichTextBox rtbChat;
        private TextBox txtUserInput;
        private Button btnSend;
        private Button btnClear;
        private Button btnVoice;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox txtTaskTitle;
        private TextBox txtTaskDescription;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvTasks;
        private Button btnDeleteTask;
        private Button btnCompleteTask;
        private Button btnAddTask;
        private DateTimePicker dtpReminder;
        private CheckBox chkReminder;
        private Button button2;
        private Button btnStartQui;
        private RadioButton rbOptionD;
        private RadioButton rbOptionC;
        private RadioButton rbOptionB;
        private RadioButton rbOptionA;
        private Label lblQuestion;
        private RichTextBox rtbQuizFeedback;
        private Label lblScore;
        private Button btnClearLog;
        private Button btnRefreshLog;
        private ListBox lstActivityLog;
    }
}
