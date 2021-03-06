﻿namespace CS_4
{
    partial class Form1
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnEncodeCaesar = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnEncodePetrI = new System.Windows.Forms.Button();
            this.btnDecodeCaesar = new System.Windows.Forms.Button();
            this.btnDecodePetrI = new System.Windows.Forms.Button();
            this.cbAlphabet = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInput.Location = new System.Drawing.Point(12, 12);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(622, 194);
            this.tbInput.TabIndex = 0;
            this.tbInput.Text = "Исходное сообщение";
            this.tbInput.Click += new System.EventHandler(this.tbInput_Click);
            // 
            // btnEncodeCaesar
            // 
            this.btnEncodeCaesar.BackColor = System.Drawing.Color.White;
            this.btnEncodeCaesar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEncodeCaesar.Location = new System.Drawing.Point(12, 212);
            this.btnEncodeCaesar.Name = "btnEncodeCaesar";
            this.btnEncodeCaesar.Size = new System.Drawing.Size(93, 37);
            this.btnEncodeCaesar.TabIndex = 1;
            this.btnEncodeCaesar.Text = "Зашифровать кодом Цезаря";
            this.btnEncodeCaesar.UseVisualStyleBackColor = false;
            this.btnEncodeCaesar.Click += new System.EventHandler(this.btnEncodeCaesar_Click);
            // 
            // tbResult
            // 
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbResult.Location = new System.Drawing.Point(12, 255);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(622, 194);
            this.tbResult.TabIndex = 2;
            this.tbResult.Text = "Зашифрованное сообщение";
            // 
            // btnEncodePetrI
            // 
            this.btnEncodePetrI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEncodePetrI.Location = new System.Drawing.Point(442, 212);
            this.btnEncodePetrI.Name = "btnEncodePetrI";
            this.btnEncodePetrI.Size = new System.Drawing.Size(93, 37);
            this.btnEncodePetrI.TabIndex = 3;
            this.btnEncodePetrI.Text = "Зашифровать кодом Петра I";
            this.btnEncodePetrI.UseVisualStyleBackColor = true;
            this.btnEncodePetrI.Click += new System.EventHandler(this.btnEncodePetrI_Click);
            // 
            // btnDecodeCaesar
            // 
            this.btnDecodeCaesar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDecodeCaesar.Location = new System.Drawing.Point(111, 212);
            this.btnDecodeCaesar.Name = "btnDecodeCaesar";
            this.btnDecodeCaesar.Size = new System.Drawing.Size(93, 37);
            this.btnDecodeCaesar.TabIndex = 4;
            this.btnDecodeCaesar.Text = "Расшифровать код Цезаря";
            this.btnDecodeCaesar.UseVisualStyleBackColor = true;
            this.btnDecodeCaesar.Click += new System.EventHandler(this.btnDecodeCaesar_Click);
            // 
            // btnDecodePetrI
            // 
            this.btnDecodePetrI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDecodePetrI.Location = new System.Drawing.Point(541, 212);
            this.btnDecodePetrI.Name = "btnDecodePetrI";
            this.btnDecodePetrI.Size = new System.Drawing.Size(93, 37);
            this.btnDecodePetrI.TabIndex = 5;
            this.btnDecodePetrI.Text = "Расшифровать код Петра I";
            this.btnDecodePetrI.UseVisualStyleBackColor = true;
            this.btnDecodePetrI.Click += new System.EventHandler(this.btnDecodePetrI_Click);
            // 
            // cbAlphabet
            // 
            this.cbAlphabet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbAlphabet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAlphabet.FormattingEnabled = true;
            this.cbAlphabet.Location = new System.Drawing.Point(256, 221);
            this.cbAlphabet.Name = "cbAlphabet";
            this.cbAlphabet.Size = new System.Drawing.Size(121, 21);
            this.cbAlphabet.TabIndex = 6;
            this.cbAlphabet.Text = "Выберите язык";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(646, 461);
            this.Controls.Add(this.cbAlphabet);
            this.Controls.Add(this.btnDecodePetrI);
            this.Controls.Add(this.btnDecodeCaesar);
            this.Controls.Add(this.btnEncodePetrI);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnEncodeCaesar);
            this.Controls.Add(this.tbInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnEncodeCaesar;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnEncodePetrI;
        private System.Windows.Forms.Button btnDecodeCaesar;
        private System.Windows.Forms.Button btnDecodePetrI;
        private System.Windows.Forms.ComboBox cbAlphabet;
    }
}

