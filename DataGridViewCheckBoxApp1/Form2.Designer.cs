namespace DataGridViewCheckBoxApp1;

partial class Form2
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
        dataGridView1 = new DataGridView();
        panel1 = new Panel();
        CheckAllButton = new Button();
        ExitButton = new Button();
        ToggleCurrentButton = new Button();
        GetAllCheckedButton = new Button();
        DirectionCheckBox = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(800, 377);
        dataGridView1.TabIndex = 2;
        // 
        // panel1
        // 
        panel1.Controls.Add(DirectionCheckBox);
        panel1.Controls.Add(CheckAllButton);
        panel1.Controls.Add(ExitButton);
        panel1.Controls.Add(ToggleCurrentButton);
        panel1.Controls.Add(GetAllCheckedButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 377);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 73);
        panel1.TabIndex = 3;
        // 
        // CheckAllButton
        // 
        CheckAllButton.Location = new Point(288, 21);
        CheckAllButton.Name = "CheckAllButton";
        CheckAllButton.Size = new Size(132, 29);
        CheckAllButton.TabIndex = 4;
        CheckAllButton.Text = "Check all";
        CheckAllButton.UseVisualStyleBackColor = true;
        CheckAllButton.Click += CheckAllButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Location = new Point(656, 21);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new Size(132, 29);
        ExitButton.TabIndex = 2;
        ExitButton.Text = "Exit";
        ExitButton.UseVisualStyleBackColor = true;
        // 
        // ToggleCurrentButton
        // 
        ToggleCurrentButton.Location = new Point(150, 21);
        ToggleCurrentButton.Name = "ToggleCurrentButton";
        ToggleCurrentButton.Size = new Size(132, 29);
        ToggleCurrentButton.TabIndex = 3;
        ToggleCurrentButton.Text = "Toggle current";
        ToggleCurrentButton.UseVisualStyleBackColor = true;
        ToggleCurrentButton.Click += ToggleCurrentButton_Click;
        // 
        // GetAllCheckedButton
        // 
        GetAllCheckedButton.Location = new Point(12, 21);
        GetAllCheckedButton.Name = "GetAllCheckedButton";
        GetAllCheckedButton.Size = new Size(132, 29);
        GetAllCheckedButton.TabIndex = 2;
        GetAllCheckedButton.Text = "Get all";
        GetAllCheckedButton.UseVisualStyleBackColor = true;
        GetAllCheckedButton.Click += GetAllCheckedButton_Click;
        // 
        // DirectionCheckBox
        // 
        DirectionCheckBox.AutoSize = true;
        DirectionCheckBox.Location = new Point(426, 24);
        DirectionCheckBox.Name = "DirectionCheckBox";
        DirectionCheckBox.Size = new Size(135, 24);
        DirectionCheckBox.TabIndex = 5;
        DirectionCheckBox.Text = "Check/un-check";
        DirectionCheckBox.UseVisualStyleBackColor = true;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dataGridView1);
        Controls.Add(panel1);
        Name = "Form2";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form2";
        Load += Form2_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Panel panel1;
    private Button ExitButton;
    private Button ToggleCurrentButton;
    private Button GetAllCheckedButton;
    private Button CheckAllButton;
    private CheckBox DirectionCheckBox;
}