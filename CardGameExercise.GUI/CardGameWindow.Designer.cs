namespace CardGameExercise.GUI;

partial class CardGameWindow
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        btnLoadFromFile = new System.Windows.Forms.Button();
        txtRawCards = new System.Windows.Forms.TextBox();
        btnSubmit = new System.Windows.Forms.Button();
        txtCardOverview = new System.Windows.Forms.TextBox();
        lblScore = new System.Windows.Forms.Label();
        lblErrorMessage = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42105F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
        tableLayoutPanel1.Controls.Add(btnLoadFromFile, 2, 2);
        tableLayoutPanel1.Controls.Add(txtRawCards, 0, 2);
        tableLayoutPanel1.Controls.Add(btnSubmit, 1, 2);
        tableLayoutPanel1.Controls.Add(txtCardOverview, 0, 1);
        tableLayoutPanel1.Controls.Add(lblScore, 0, 0);
        tableLayoutPanel1.Controls.Add(lblErrorMessage, 2, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.Size = new System.Drawing.Size(484, 261);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // btnLoadFromFile
        // 
        btnLoadFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
        btnLoadFromFile.Location = new System.Drawing.Point(355, 211);
        btnLoadFromFile.Name = "btnLoadFromFile";
        btnLoadFromFile.Size = new System.Drawing.Size(126, 47);
        btnLoadFromFile.TabIndex = 0;
        btnLoadFromFile.Text = "Load from file (.csv)";
        btnLoadFromFile.UseVisualStyleBackColor = true;
        btnLoadFromFile.Click += btnLoadFromFile_Click;
        // 
        // txtRawCards
        // 
        txtRawCards.Dock = System.Windows.Forms.DockStyle.Fill;
        txtRawCards.Location = new System.Drawing.Point(3, 211);
        txtRawCards.Multiline = true;
        txtRawCards.Name = "txtRawCards";
        txtRawCards.Size = new System.Drawing.Size(280, 47);
        txtRawCards.TabIndex = 1;
        // 
        // btnSubmit
        // 
        btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
        btnSubmit.Location = new System.Drawing.Point(289, 211);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new System.Drawing.Size(60, 47);
        btnSubmit.TabIndex = 2;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // txtCardOverview
        // 
        tableLayoutPanel1.SetColumnSpan(txtCardOverview, 2);
        txtCardOverview.Dock = System.Windows.Forms.DockStyle.Fill;
        txtCardOverview.Location = new System.Drawing.Point(3, 42);
        txtCardOverview.Multiline = true;
        txtCardOverview.Name = "txtCardOverview";
        txtCardOverview.ReadOnly = true;
        txtCardOverview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtCardOverview.Size = new System.Drawing.Size(346, 163);
        txtCardOverview.TabIndex = 3;
        // 
        // lblScore
        // 
        lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
        lblScore.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblScore.Location = new System.Drawing.Point(3, 0);
        lblScore.Name = "lblScore";
        lblScore.Size = new System.Drawing.Size(280, 39);
        lblScore.TabIndex = 4;
        lblScore.Text = "Current Score: ";
        lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblErrorMessage
        // 
        lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
        lblErrorMessage.Location = new System.Drawing.Point(355, 39);
        lblErrorMessage.Name = "lblErrorMessage";
        lblErrorMessage.Size = new System.Drawing.Size(126, 169);
        lblErrorMessage.TabIndex = 5;
        lblErrorMessage.Text = "No errors";
        lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // CardGameWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(484, 261);
        Controls.Add(tableLayoutPanel1);
        MaximumSize = new System.Drawing.Size(500, 300);
        MinimizeBox = false;
        MinimumSize = new System.Drawing.Size(500, 300);
        ShowIcon = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Card Game Score Parser";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblErrorMessage;

    private System.Windows.Forms.Label lblScore;

    private System.Windows.Forms.TextBox txtCardOverview;

    private System.Windows.Forms.Button btnSubmit;

    private System.Windows.Forms.Button btnLoadFromFile;
    private System.Windows.Forms.TextBox txtRawCards;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}