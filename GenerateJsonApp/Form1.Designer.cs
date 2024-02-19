namespace GenerateJsonApp;

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
        CreatePeopleButton = new Button();
        CreateProductsButton = new Button();
        CreatePeopleWithBirthdate = new Button();
        SuspendLayout();
        // 
        // CreatePeopleButton
        // 
        CreatePeopleButton.Location = new Point(21, 37);
        CreatePeopleButton.Name = "CreatePeopleButton";
        CreatePeopleButton.Size = new Size(297, 29);
        CreatePeopleButton.TabIndex = 0;
        CreatePeopleButton.Text = "Create people";
        CreatePeopleButton.UseVisualStyleBackColor = true;
        CreatePeopleButton.Click += CreatePeopleButton_Click;
        // 
        // CreateProductsButton
        // 
        CreateProductsButton.Location = new Point(21, 138);
        CreateProductsButton.Name = "CreateProductsButton";
        CreateProductsButton.Size = new Size(297, 29);
        CreateProductsButton.TabIndex = 1;
        CreateProductsButton.Text = "Create products";
        CreateProductsButton.UseVisualStyleBackColor = true;
        CreateProductsButton.Click += CreateProductsButton_Click;
        // 
        // CreatePeopleWithBirthdate
        // 
        CreatePeopleWithBirthdate.Location = new Point(21, 86);
        CreatePeopleWithBirthdate.Name = "CreatePeopleWithBirthdate";
        CreatePeopleWithBirthdate.Size = new Size(297, 29);
        CreatePeopleWithBirthdate.TabIndex = 2;
        CreatePeopleWithBirthdate.Text = "Create people with birthDate";
        CreatePeopleWithBirthdate.UseVisualStyleBackColor = true;
        CreatePeopleWithBirthdate.Click += CreatePeopleWithBirthdate_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(344, 191);
        Controls.Add(CreatePeopleWithBirthdate);
        Controls.Add(CreateProductsButton);
        Controls.Add(CreatePeopleButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Generate json";
        ResumeLayout(false);
    }

    #endregion

    private Button CreatePeopleButton;
    private Button CreateProductsButton;
    private Button CreatePeopleWithBirthdate;
}
