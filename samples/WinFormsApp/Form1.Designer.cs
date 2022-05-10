namespace WinFormsApp
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
            this.CfdiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CfdiButton
            // 
            this.CfdiButton.Location = new System.Drawing.Point(219, 100);
            this.CfdiButton.Name = "CfdiButton";
            this.CfdiButton.Size = new System.Drawing.Size(171, 101);
            this.CfdiButton.TabIndex = 0;
            this.CfdiButton.Text = "Descargar CFDI | Metadata Emitidos / Recibidos";
            this.CfdiButton.UseVisualStyleBackColor = true;
            this.CfdiButton.Click += new System.EventHandler(this.CfdiButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 331);
            this.Controls.Add(this.CfdiButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button CfdiButton;
    }
}