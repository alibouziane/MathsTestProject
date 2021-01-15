namespace DemoApp
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btGC = new System.Windows.Forms.Button();
            this.btnBadAsync = new System.Windows.Forms.Button();
            this.btnWaitingAsync = new System.Windows.Forms.Button();
            this.tbresult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.THreadManage = new System.Windows.Forms.Button();
            this.btnManualResetEvnt = new System.Windows.Forms.Button();
            this.btnAutoResetEvnt = new System.Windows.Forms.Button();
            this.btnMutex = new System.Windows.Forms.Button();
            this.btnSemaphore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(33, 36);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Object";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(33, 66);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(75, 23);
            this.btnDestroy.TabIndex = 1;
            this.btnDestroy.Text = "Destroy";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // btGC
            // 
            this.btGC.Location = new System.Drawing.Point(33, 108);
            this.btGC.Name = "btGC";
            this.btGC.Size = new System.Drawing.Size(75, 23);
            this.btGC.TabIndex = 2;
            this.btGC.Text = "GC";
            this.btGC.UseVisualStyleBackColor = true;
            this.btGC.Click += new System.EventHandler(this.btGC_Click);
            // 
            // btnBadAsync
            // 
            this.btnBadAsync.Location = new System.Drawing.Point(159, 36);
            this.btnBadAsync.Name = "btnBadAsync";
            this.btnBadAsync.Size = new System.Drawing.Size(75, 23);
            this.btnBadAsync.TabIndex = 3;
            this.btnBadAsync.Text = "BadAsync";
            this.btnBadAsync.UseVisualStyleBackColor = true;
            this.btnBadAsync.Click += new System.EventHandler(this.btnBadAsync_Click);
            // 
            // btnWaitingAsync
            // 
            this.btnWaitingAsync.Location = new System.Drawing.Point(122, 92);
            this.btnWaitingAsync.Name = "btnWaitingAsync";
            this.btnWaitingAsync.Size = new System.Drawing.Size(150, 23);
            this.btnWaitingAsync.TabIndex = 4;
            this.btnWaitingAsync.Text = "Waiting Asynchronously";
            this.btnWaitingAsync.UseVisualStyleBackColor = true;
            this.btnWaitingAsync.Click += new System.EventHandler(this.btnWaitingAsync_Click);
            // 
            // tbresult
            // 
            this.tbresult.Location = new System.Drawing.Point(336, 38);
            this.tbresult.Multiline = true;
            this.tbresult.Name = "tbresult";
            this.tbresult.Size = new System.Drawing.Size(235, 247);
            this.tbresult.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "NB processeur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // THreadManage
            // 
            this.THreadManage.Location = new System.Drawing.Point(5, 176);
            this.THreadManage.Name = "THreadManage";
            this.THreadManage.Size = new System.Drawing.Size(127, 23);
            this.THreadManage.TabIndex = 7;
            this.THreadManage.Text = "Thread Manage";
            this.THreadManage.UseVisualStyleBackColor = true;
            this.THreadManage.Click += new System.EventHandler(this.THreadManage_Click);
            // 
            // btnManualResetEvnt
            // 
            this.btnManualResetEvnt.Location = new System.Drawing.Point(5, 205);
            this.btnManualResetEvnt.Name = "btnManualResetEvnt";
            this.btnManualResetEvnt.Size = new System.Drawing.Size(127, 23);
            this.btnManualResetEvnt.TabIndex = 8;
            this.btnManualResetEvnt.Text = "Manual Reset Evnt";
            this.btnManualResetEvnt.UseVisualStyleBackColor = true;
            this.btnManualResetEvnt.Click += new System.EventHandler(this.btnManualResetEvnt_Click);
            // 
            // btnAutoResetEvnt
            // 
            this.btnAutoResetEvnt.Location = new System.Drawing.Point(5, 234);
            this.btnAutoResetEvnt.Name = "btnAutoResetEvnt";
            this.btnAutoResetEvnt.Size = new System.Drawing.Size(127, 23);
            this.btnAutoResetEvnt.TabIndex = 9;
            this.btnAutoResetEvnt.Text = "Auto Reset Evnt";
            this.btnAutoResetEvnt.UseVisualStyleBackColor = true;
            this.btnAutoResetEvnt.Click += new System.EventHandler(this.btnAutoResetEvnt_Click);
            // 
            // btnMutex
            // 
            this.btnMutex.Location = new System.Drawing.Point(5, 261);
            this.btnMutex.Name = "btnMutex";
            this.btnMutex.Size = new System.Drawing.Size(127, 23);
            this.btnMutex.TabIndex = 10;
            this.btnMutex.Text = "Mutex";
            this.btnMutex.UseVisualStyleBackColor = true;
            this.btnMutex.Click += new System.EventHandler(this.btnMutex_Click);
            // 
            // btnSemaphore
            // 
            this.btnSemaphore.Location = new System.Drawing.Point(5, 303);
            this.btnSemaphore.Name = "btnSemaphore";
            this.btnSemaphore.Size = new System.Drawing.Size(127, 23);
            this.btnSemaphore.TabIndex = 11;
            this.btnSemaphore.Text = "Semaphore";
            this.btnSemaphore.UseVisualStyleBackColor = true;
            this.btnSemaphore.Click += new System.EventHandler(this.btnSemaphore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 350);
            this.Controls.Add(this.btnSemaphore);
            this.Controls.Add(this.btnMutex);
            this.Controls.Add(this.btnAutoResetEvnt);
            this.Controls.Add(this.btnManualResetEvnt);
            this.Controls.Add(this.THreadManage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbresult);
            this.Controls.Add(this.btnWaitingAsync);
            this.Controls.Add(this.btnBadAsync);
            this.Controls.Add(this.btGC);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btGC;
        private System.Windows.Forms.Button btnBadAsync;
        private System.Windows.Forms.Button btnWaitingAsync;
        private System.Windows.Forms.TextBox tbresult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button THreadManage;
        private System.Windows.Forms.Button btnManualResetEvnt;
        private System.Windows.Forms.Button btnAutoResetEvnt;
        private System.Windows.Forms.Button btnMutex;
        private System.Windows.Forms.Button btnSemaphore;
    }
}

