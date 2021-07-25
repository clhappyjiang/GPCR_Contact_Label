namespace ShowContact
{
    partial class Code_
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
            this.skinChatRichTextBox1 = new CCWin.SkinControl.SkinChatRichTextBox();
            this.SuspendLayout();
            // 
            // skinChatRichTextBox1
            // 
            this.skinChatRichTextBox1.Location = new System.Drawing.Point(12, 154);
            this.skinChatRichTextBox1.Name = "skinChatRichTextBox1";
            this.skinChatRichTextBox1.SelectControl = null;
            this.skinChatRichTextBox1.SelectControlIndex = 0;
            this.skinChatRichTextBox1.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.skinChatRichTextBox1.Size = new System.Drawing.Size(646, 284);
            this.skinChatRichTextBox1.TabIndex = 0;
            this.skinChatRichTextBox1.Text = "";
            // 
            // Code_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.skinChatRichTextBox1);
            this.Name = "Code_";
            this.Text = "使用教程";
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinChatRichTextBox skinChatRichTextBox1;
    }
}