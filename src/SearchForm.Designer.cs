namespace MovieDatabase
{
	partial class SearchForm
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
			checkBoxName = new CheckBox();
			checkBoxRD = new CheckBox();
			checkBoxRating = new CheckBox();
			checkBoxActor = new CheckBox();
			checkBoxGenre = new CheckBox();
			textBoxName = new TextBox();
			buttonSearch = new Button();
			trackBarRating = new TrackBar();
			textBoxGenre = new TextBox();
			textBoxActor = new TextBox();
			dateTimePickerRD = new DateTimePicker();
			labelRatingNumber = new Label();
			((System.ComponentModel.ISupportInitialize)trackBarRating).BeginInit();
			SuspendLayout();
			// 
			// checkBoxName
			// 
			checkBoxName.AutoSize = true;
			checkBoxName.Location = new Point(12, 12);
			checkBoxName.Name = "checkBoxName";
			checkBoxName.Size = new Size(71, 24);
			checkBoxName.TabIndex = 0;
			checkBoxName.Text = "Name";
			checkBoxName.UseVisualStyleBackColor = true;
			checkBoxName.CheckedChanged += checkBoxName_CheckedChanged;
			// 
			// checkBoxRD
			// 
			checkBoxRD.AutoSize = true;
			checkBoxRD.Location = new Point(12, 42);
			checkBoxRD.Name = "checkBoxRD";
			checkBoxRD.Size = new Size(116, 24);
			checkBoxRD.TabIndex = 1;
			checkBoxRD.Text = "Release date";
			checkBoxRD.UseVisualStyleBackColor = true;
			checkBoxRD.CheckedChanged += checkBoxRD_CheckedChanged;
			// 
			// checkBoxRating
			// 
			checkBoxRating.AutoSize = true;
			checkBoxRating.Location = new Point(12, 72);
			checkBoxRating.Name = "checkBoxRating";
			checkBoxRating.Size = new Size(74, 24);
			checkBoxRating.TabIndex = 2;
			checkBoxRating.Text = "Rating";
			checkBoxRating.UseVisualStyleBackColor = true;
			checkBoxRating.CheckedChanged += checkBoxRating_CheckedChanged;
			// 
			// checkBoxActor
			// 
			checkBoxActor.AutoSize = true;
			checkBoxActor.Location = new Point(12, 102);
			checkBoxActor.Name = "checkBoxActor";
			checkBoxActor.Size = new Size(67, 24);
			checkBoxActor.TabIndex = 3;
			checkBoxActor.Text = "Actor";
			checkBoxActor.UseVisualStyleBackColor = true;
			checkBoxActor.CheckedChanged += checkBoxActor_CheckedChanged;
			// 
			// checkBoxGenre
			// 
			checkBoxGenre.AutoSize = true;
			checkBoxGenre.Location = new Point(12, 132);
			checkBoxGenre.Name = "checkBoxGenre";
			checkBoxGenre.Size = new Size(70, 24);
			checkBoxGenre.TabIndex = 4;
			checkBoxGenre.Text = "Genre";
			checkBoxGenre.UseVisualStyleBackColor = true;
			checkBoxGenre.CheckedChanged += checkBoxGenre_CheckedChanged;
			// 
			// textBoxName
			// 
			textBoxName.Enabled = false;
			textBoxName.Location = new Point(92, 10);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(364, 27);
			textBoxName.TabIndex = 5;
			// 
			// buttonSearch
			// 
			buttonSearch.Location = new Point(12, 162);
			buttonSearch.Name = "buttonSearch";
			buttonSearch.Size = new Size(94, 29);
			buttonSearch.TabIndex = 6;
			buttonSearch.Text = "Search";
			buttonSearch.UseVisualStyleBackColor = true;
			buttonSearch.Click += buttonSearch_Click;
			// 
			// trackBarRating
			// 
			trackBarRating.Enabled = false;
			trackBarRating.LargeChange = 10;
			trackBarRating.Location = new Point(129, 72);
			trackBarRating.Maximum = 50;
			trackBarRating.Name = "trackBarRating";
			trackBarRating.Size = new Size(301, 56);
			trackBarRating.TabIndex = 8;
			trackBarRating.Scroll += trackBarRating_Scroll;
			// 
			// textBoxGenre
			// 
			textBoxGenre.Enabled = false;
			textBoxGenre.Location = new Point(92, 130);
			textBoxGenre.Name = "textBoxGenre";
			textBoxGenre.Size = new Size(364, 27);
			textBoxGenre.TabIndex = 9;
			// 
			// textBoxActor
			// 
			textBoxActor.Enabled = false;
			textBoxActor.Location = new Point(92, 100);
			textBoxActor.Name = "textBoxActor";
			textBoxActor.Size = new Size(364, 27);
			textBoxActor.TabIndex = 10;
			// 
			// dateTimePickerRD
			// 
			dateTimePickerRD.Enabled = false;
			dateTimePickerRD.Location = new Point(134, 42);
			dateTimePickerRD.Name = "dateTimePickerRD";
			dateTimePickerRD.Size = new Size(322, 27);
			dateTimePickerRD.TabIndex = 11;
			// 
			// labelRatingNumber
			// 
			labelRatingNumber.AutoSize = true;
			labelRatingNumber.Enabled = false;
			labelRatingNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
			labelRatingNumber.Location = new Point(92, 73);
			labelRatingNumber.Name = "labelRatingNumber";
			labelRatingNumber.Size = new Size(31, 20);
			labelRatingNumber.TabIndex = 12;
			labelRatingNumber.Text = "0.0";
			// 
			// SearchForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(465, 209);
			Controls.Add(labelRatingNumber);
			Controls.Add(dateTimePickerRD);
			Controls.Add(textBoxActor);
			Controls.Add(textBoxGenre);
			Controls.Add(trackBarRating);
			Controls.Add(buttonSearch);
			Controls.Add(textBoxName);
			Controls.Add(checkBoxGenre);
			Controls.Add(checkBoxActor);
			Controls.Add(checkBoxRating);
			Controls.Add(checkBoxRD);
			Controls.Add(checkBoxName);
			Name = "SearchForm";
			Text = "Search";
			((System.ComponentModel.ISupportInitialize)trackBarRating).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private CheckBox checkBoxName;
		private CheckBox checkBoxRD;
		private CheckBox checkBoxRating;
		private CheckBox checkBoxActor;
		private CheckBox checkBoxGenre;
		private TextBox textBoxName;
		private Button buttonSearch;
		private TrackBar trackBarRating;
		private TextBox textBoxGenre;
		private TextBox textBoxActor;
		private DateTimePicker dateTimePickerRD;
		private Label labelRatingNumber;
	}
}