namespace MovieDatabase
{
	partial class NewMovieForm
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
			labelRatingNumber = new Label();
			trackBarRating = new TrackBar();
			labelRating = new Label();
			dateTimePickerRD = new DateTimePicker();
			labelReleaseDate = new Label();
			textBoxDesc = new TextBox();
			labelDescription = new Label();
			textBoxName = new TextBox();
			labelName = new Label();
			listBoxGenres = new ListBox();
			buttonSave = new Button();
			labelGenres = new Label();
			listBoxActors = new ListBox();
			labelActors = new Label();
			buttonGenre = new Button();
			buttonActor = new Button();
			buttonRemoveGenre = new Button();
			buttonRemoveActor = new Button();
			((System.ComponentModel.ISupportInitialize)trackBarRating).BeginInit();
			SuspendLayout();
			// 
			// labelRatingNumber
			// 
			labelRatingNumber.AutoSize = true;
			labelRatingNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
			labelRatingNumber.Location = new Point(12, 188);
			labelRatingNumber.Name = "labelRatingNumber";
			labelRatingNumber.Size = new Size(31, 20);
			labelRatingNumber.TabIndex = 17;
			labelRatingNumber.Text = "0.0";
			// 
			// trackBarRating
			// 
			trackBarRating.LargeChange = 10;
			trackBarRating.Location = new Point(12, 211);
			trackBarRating.Maximum = 50;
			trackBarRating.Name = "trackBarRating";
			trackBarRating.Size = new Size(464, 56);
			trackBarRating.TabIndex = 16;
			trackBarRating.Scroll += trackBarRating_Scroll;
			// 
			// labelRating
			// 
			labelRating.AutoSize = true;
			labelRating.Location = new Point(12, 168);
			labelRating.Name = "labelRating";
			labelRating.Size = new Size(52, 20);
			labelRating.TabIndex = 15;
			labelRating.Text = "Rating";
			// 
			// dateTimePickerRD
			// 
			dateTimePickerRD.Location = new Point(12, 138);
			dateTimePickerRD.Name = "dateTimePickerRD";
			dateTimePickerRD.Size = new Size(464, 27);
			dateTimePickerRD.TabIndex = 14;
			// 
			// labelReleaseDate
			// 
			labelReleaseDate.AutoSize = true;
			labelReleaseDate.Location = new Point(12, 115);
			labelReleaseDate.Name = "labelReleaseDate";
			labelReleaseDate.Size = new Size(94, 20);
			labelReleaseDate.TabIndex = 13;
			labelReleaseDate.Text = "Release date";
			// 
			// textBoxDesc
			// 
			textBoxDesc.Location = new Point(12, 85);
			textBoxDesc.Name = "textBoxDesc";
			textBoxDesc.Size = new Size(464, 27);
			textBoxDesc.TabIndex = 12;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Location = new Point(12, 62);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new Size(85, 20);
			labelDescription.TabIndex = 11;
			labelDescription.Text = "Description";
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(12, 32);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(464, 27);
			textBoxName.TabIndex = 10;
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new Point(12, 9);
			labelName.Name = "labelName";
			labelName.Size = new Size(91, 20);
			labelName.TabIndex = 9;
			labelName.Text = "Movie name";
			// 
			// listBoxGenres
			// 
			listBoxGenres.FormattingEnabled = true;
			listBoxGenres.Location = new Point(482, 32);
			listBoxGenres.Name = "listBoxGenres";
			listBoxGenres.Size = new Size(163, 224);
			listBoxGenres.TabIndex = 18;
			listBoxGenres.SelectedIndexChanged += listBoxGenres_SelectedIndexChanged;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(12, 250);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(94, 29);
			buttonSave.TabIndex = 19;
			buttonSave.Text = "Create";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += buttonSave_Click;
			// 
			// labelGenres
			// 
			labelGenres.AutoSize = true;
			labelGenres.Location = new Point(482, 9);
			labelGenres.Name = "labelGenres";
			labelGenres.Size = new Size(54, 20);
			labelGenres.TabIndex = 20;
			labelGenres.Text = "Genres";
			// 
			// listBoxActors
			// 
			listBoxActors.FormattingEnabled = true;
			listBoxActors.Location = new Point(651, 32);
			listBoxActors.Name = "listBoxActors";
			listBoxActors.Size = new Size(163, 224);
			listBoxActors.TabIndex = 21;
			listBoxActors.SelectedIndexChanged += listBoxActors_SelectedIndexChanged;
			// 
			// labelActors
			// 
			labelActors.AutoSize = true;
			labelActors.Location = new Point(651, 9);
			labelActors.Name = "labelActors";
			labelActors.Size = new Size(51, 20);
			labelActors.TabIndex = 22;
			labelActors.Text = "Actors";
			// 
			// buttonGenre
			// 
			buttonGenre.Location = new Point(482, 262);
			buttonGenre.Name = "buttonGenre";
			buttonGenre.Size = new Size(163, 29);
			buttonGenre.TabIndex = 23;
			buttonGenre.Text = "Add";
			buttonGenre.UseVisualStyleBackColor = true;
			buttonGenre.Click += buttonGenre_Click;
			// 
			// buttonActor
			// 
			buttonActor.Location = new Point(651, 262);
			buttonActor.Name = "buttonActor";
			buttonActor.Size = new Size(163, 29);
			buttonActor.TabIndex = 24;
			buttonActor.Text = "Add";
			buttonActor.UseVisualStyleBackColor = true;
			buttonActor.Click += buttonActor_Click;
			// 
			// buttonRemoveGenre
			// 
			buttonRemoveGenre.Enabled = false;
			buttonRemoveGenre.Location = new Point(482, 297);
			buttonRemoveGenre.Name = "buttonRemoveGenre";
			buttonRemoveGenre.Size = new Size(163, 29);
			buttonRemoveGenre.TabIndex = 25;
			buttonRemoveGenre.Text = "Remove";
			buttonRemoveGenre.UseVisualStyleBackColor = true;
			buttonRemoveGenre.Click += buttonRemoveGenre_Click;
			// 
			// buttonRemoveActor
			// 
			buttonRemoveActor.Enabled = false;
			buttonRemoveActor.Location = new Point(651, 297);
			buttonRemoveActor.Name = "buttonRemoveActor";
			buttonRemoveActor.Size = new Size(163, 29);
			buttonRemoveActor.TabIndex = 26;
			buttonRemoveActor.Text = "Remove";
			buttonRemoveActor.UseVisualStyleBackColor = true;
			buttonRemoveActor.Click += buttonRemoveActor_Click;
			// 
			// NewMovieForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(825, 335);
			Controls.Add(buttonRemoveActor);
			Controls.Add(buttonRemoveGenre);
			Controls.Add(buttonActor);
			Controls.Add(buttonGenre);
			Controls.Add(labelActors);
			Controls.Add(listBoxActors);
			Controls.Add(labelGenres);
			Controls.Add(buttonSave);
			Controls.Add(listBoxGenres);
			Controls.Add(labelRatingNumber);
			Controls.Add(trackBarRating);
			Controls.Add(labelRating);
			Controls.Add(dateTimePickerRD);
			Controls.Add(labelReleaseDate);
			Controls.Add(textBoxDesc);
			Controls.Add(labelDescription);
			Controls.Add(textBoxName);
			Controls.Add(labelName);
			Name = "NewMovieForm";
			Text = "New movie";
			((System.ComponentModel.ISupportInitialize)trackBarRating).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelRatingNumber;
		private TrackBar trackBarRating;
		private Label labelRating;
		private DateTimePicker dateTimePickerRD;
		private Label labelReleaseDate;
		private TextBox textBoxDesc;
		private Label labelDescription;
		private TextBox textBoxName;
		private Label labelName;
		private ListBox listBoxGenres;
		private Button buttonSave;
		private Label labelGenres;
		private ListBox listBoxActors;
		private Label labelActors;
		private Button buttonGenre;
		private Button buttonActor;
		private Button buttonRemoveGenre;
		private Button buttonRemoveActor;
	}
}