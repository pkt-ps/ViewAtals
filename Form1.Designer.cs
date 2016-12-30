namespace ViewAtlas
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(12, 31);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(129, 424);
			this.listBox1.TabIndex = 0;
			this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
			this.listBox1.MouseLeave += new System.EventHandler(this.listBox1_MouseLeave);
			this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Location = new System.Drawing.Point(56, 6);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(85, 19);
			this.textBoxSearch.TabIndex = 1;
			this.textBoxSearch.Click += new System.EventHandler(this.textBoxSearch_Click);
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Search";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(189, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "Path";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(223, 6);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(356, 19);
			this.textBox2.TabIndex = 11;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(161, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(418, 423);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.Form1_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(160, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 23);
			this.button1.TabIndex = 14;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 466);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxSearch);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Click += new System.EventHandler(this.Form1_Click);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
	}
}

