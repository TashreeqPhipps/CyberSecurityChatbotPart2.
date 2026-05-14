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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(461, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cybersecurity Awareness Chatbot";
            lblTitle.Click += label1_Click;
            // 
            // rtbChat
            // 
            rtbChat.Location = new Point(30, 67);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(563, 269);
            rtbChat.TabIndex = 1;
            rtbChat.Text = "";
            rtbChat.TextChanged += rtbChat_TextChanged;
            // 
            // txtUserInput
            // 
            txtUserInput.Location = new Point(30, 368);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(563, 27);
            txtUserInput.TabIndex = 2;
            txtUserInput.TextChanged += txtUserInput_TextChanged;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(599, 66);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += button1_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(599, 152);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear Chat";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnVoice
            // 
            btnVoice.Location = new Point(599, 235);
            btnVoice.Name = "btnVoice";
            btnVoice.Size = new Size(94, 29);
            btnVoice.TabIndex = 5;
            btnVoice.Text = "Play Voice Greeting";
            btnVoice.UseVisualStyleBackColor = true;
            btnVoice.Click += btnVoice_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 713);
            Controls.Add(btnVoice);
            Controls.Add(btnClear);
            Controls.Add(btnSend);
            Controls.Add(txtUserInput);
            Controls.Add(rtbChat);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private RichTextBox rtbChat;
        private TextBox txtUserInput;
        private Button btnSend;
        private Button btnClear;
        private Button btnVoice;
    }
}
