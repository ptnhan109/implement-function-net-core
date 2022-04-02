
namespace SortVisualization
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
            this.pnlMonitor = new System.Windows.Forms.Panel();
            this.btnBubbleSort = new System.Windows.Forms.Button();
            this.pnlCount = new System.Windows.Forms.Panel();
            this.lblLoopCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMonitor
            // 
            this.pnlMonitor.BackColor = System.Drawing.Color.White;
            this.pnlMonitor.Location = new System.Drawing.Point(13, 13);
            this.pnlMonitor.Name = "pnlMonitor";
            this.pnlMonitor.Size = new System.Drawing.Size(1500, 600);
            this.pnlMonitor.TabIndex = 0;
            this.pnlMonitor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMonitor_Paint);
            // 
            // btnBubbleSort
            // 
            this.btnBubbleSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBubbleSort.Location = new System.Drawing.Point(1526, 113);
            this.btnBubbleSort.Name = "btnBubbleSort";
            this.btnBubbleSort.Size = new System.Drawing.Size(162, 37);
            this.btnBubbleSort.TabIndex = 1;
            this.btnBubbleSort.Text = "Bubble sort";
            this.btnBubbleSort.UseVisualStyleBackColor = true;
            this.btnBubbleSort.Click += new System.EventHandler(this.btnBubbleSort_Click);
            // 
            // pnlCount
            // 
            this.pnlCount.BackColor = System.Drawing.Color.White;
            this.pnlCount.Controls.Add(this.lblLoopCount);
            this.pnlCount.Controls.Add(this.label1);
            this.pnlCount.Location = new System.Drawing.Point(1520, 13);
            this.pnlCount.Name = "pnlCount";
            this.pnlCount.Size = new System.Drawing.Size(161, 42);
            this.pnlCount.TabIndex = 2;
            // 
            // lblLoopCount
            // 
            this.lblLoopCount.AutoSize = true;
            this.lblLoopCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoopCount.Location = new System.Drawing.Point(50, 7);
            this.lblLoopCount.Name = "lblLoopCount";
            this.lblLoopCount.Size = new System.Drawing.Size(25, 25);
            this.lblLoopCount.TabIndex = 1;
            this.lblLoopCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loops";
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSort.Location = new System.Drawing.Point(1526, 156);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(162, 37);
            this.btnQuickSort.TabIndex = 3;
            this.btnQuickSort.Text = "Quick sort";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(1526, 70);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(162, 37);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 631);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnQuickSort);
            this.Controls.Add(this.pnlCount);
            this.Controls.Add(this.btnBubbleSort);
            this.Controls.Add(this.pnlMonitor);
            this.Name = "Form1";
            this.Text = "Sort Visualization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCount.ResumeLayout(false);
            this.pnlCount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMonitor;
        private System.Windows.Forms.Button btnBubbleSort;
        private System.Windows.Forms.Panel pnlCount;
        private System.Windows.Forms.Label lblLoopCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Button btnGenerate;
    }
}

