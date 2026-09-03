using System.Windows.Forms.Layout;

namespace deneAI;

partial class Advanced
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtPrompt = new TextBox();
        button1 = new Button();
        rtbChat = new RichTextBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        panel1 = new Panel();
        tableLayoutPanel2 = new TableLayoutPanel();
        btnClear = new Button();
        label1 = new Label();
        tableLayoutPanel1.SuspendLayout();
        panel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // txtPrompt
        // 
        txtPrompt.Dock = DockStyle.Fill;
        txtPrompt.Font = new Font("Segoe UI", 10F);
        txtPrompt.Location = new Point(3, 3);
        txtPrompt.Name = "txtPrompt";
        txtPrompt.Size = new Size(587, 25);
        txtPrompt.TabIndex = 0;
        // 
        // button1
        // 
        button1.BackColor = Color.WhiteSmoke;
        button1.BackgroundImage = Properties.Resources.icons8_send_letter_24;
        button1.BackgroundImageLayout = ImageLayout.Center;
        button1.Dock = DockStyle.Fill;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Location = new Point(593, 0);
        button1.Margin = new Padding(0);
        button1.Name = "button1";
        button1.Size = new Size(66, 30);
        button1.TabIndex = 1;
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // rtbChat
        // 
        rtbChat.Dock = DockStyle.Fill;
        rtbChat.Font = new Font("Segoe UI", 11F);
        rtbChat.Location = new Point(0, 0);
        rtbChat.Name = "rtbChat";
        rtbChat.Size = new Size(659, 395);
        rtbChat.TabIndex = 2;
        rtbChat.Text = "";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = Color.Gainsboro;
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.Controls.Add(button1, 1, 0);
        tableLayoutPanel1.Controls.Add(txtPrompt, 0, 0);
        tableLayoutPanel1.Dock = DockStyle.Bottom;
        tableLayoutPanel1.Location = new Point(0, 422);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(659, 30);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // panel1
        // 
        panel1.Controls.Add(rtbChat);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 27);
        panel1.Name = "panel1";
        panel1.Size = new Size(659, 395);
        panel1.TabIndex = 4;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.BackColor = SystemColors.ControlDarkDark;
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel2.Controls.Add(btnClear, 1, 0);
        tableLayoutPanel2.Controls.Add(label1, 0, 0);
        tableLayoutPanel2.Dock = DockStyle.Top;
        tableLayoutPanel2.Location = new Point(0, 0);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Size = new Size(659, 27);
        tableLayoutPanel2.TabIndex = 4;
        // 
        // btnClear
        // 
        btnClear.BackColor = SystemColors.ControlDark;
        btnClear.BackgroundImage = Properties.Resources.icons8_clear_24;
        btnClear.BackgroundImageLayout = ImageLayout.Center;
        btnClear.Dock = DockStyle.Fill;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.Location = new Point(593, 0);
        btnClear.Margin = new Padding(0);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(66, 27);
        btnClear.TabIndex = 1;
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        // 
        // label1
        // 
        label1.BackColor = SystemColors.ControlDarkDark;
        label1.Dock = DockStyle.Fill;
        label1.Font = new Font("Segoe UI", 12F);
        label1.ForeColor = SystemColors.ButtonFace;
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Padding = new Padding(10, 0, 0, 0);
        label1.Size = new Size(587, 27);
        label1.TabIndex = 2;
        label1.Text = "deneAI Advanced";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Advanced
        // 
        AcceptButton = button1;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(659, 452);
        Controls.Add(panel1);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(tableLayoutPanel2);
        MinimumSize = new Size(302, 187);
        Name = "Advanced";
        Text = "deneAI";
        FormClosing += Advanced_FormClosing;
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        panel1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TextBox txtPrompt;
    private Button button1;
    private RichTextBox rtbChat;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Button btnClear;
    private Label label1;
}