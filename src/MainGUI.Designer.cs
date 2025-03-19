namespace MovieDatabase
{
	partial class MainGUI
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
			splitContainer1 = new SplitContainer();
			buttonSearch = new Button();
			checkBoxList = new CheckBox();
			listBoxMovies = new ListBox();
			buttonRemoveActor = new Button();
			checkBoxAddToList = new CheckBox();
			buttonRemoveGenre = new Button();
			buttonDelete = new Button();
			buttonActor = new Button();
			buttonSave = new Button();
			buttonGenre = new Button();
			labelRatingNumber = new Label();
			labelActors = new Label();
			trackBarRating = new TrackBar();
			listBoxActors = new ListBox();
			labelRating = new Label();
			labelGenres = new Label();
			listBoxGenres = new ListBox();
			dateTimePickerRD = new DateTimePicker();
			labelReleaseDate = new Label();
			textBoxDesc = new TextBox();
			labelDescription = new Label();
			textBoxName = new TextBox();
			labelName = new Label();
			menuStrip1 = new MenuStrip();
			accountToolStripMenuItem = new ToolStripMenuItem();
			logOutToolStripMenuItem = new ToolStripMenuItem();
			addToolStripMenuItem = new ToolStripMenuItem();
			newMovieToolStripMenuItem = new ToolStripMenuItem();
			importToolStripMenuItem = new ToolStripMenuItem();
			importJSONToolStripMenuItem = new ToolStripMenuItem();
			exportJSONToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBarRating).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 28);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(buttonSearch);
			splitContainer1.Panel1.Controls.Add(checkBoxList);
			splitContainer1.Panel1.Controls.Add(listBoxMovies);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(buttonRemoveActor);
			splitContainer1.Panel2.Controls.Add(checkBoxAddToList);
			splitContainer1.Panel2.Controls.Add(buttonRemoveGenre);
			splitContainer1.Panel2.Controls.Add(buttonDelete);
			splitContainer1.Panel2.Controls.Add(buttonActor);
			splitContainer1.Panel2.Controls.Add(buttonSave);
			splitContainer1.Panel2.Controls.Add(buttonGenre);
			splitContainer1.Panel2.Controls.Add(labelRatingNumber);
			splitContainer1.Panel2.Controls.Add(labelActors);
			splitContainer1.Panel2.Controls.Add(trackBarRating);
			splitContainer1.Panel2.Controls.Add(listBoxActors);
			splitContainer1.Panel2.Controls.Add(labelRating);
			splitContainer1.Panel2.Controls.Add(labelGenres);
			splitContainer1.Panel2.Controls.Add(listBoxGenres);
			splitContainer1.Panel2.Controls.Add(dateTimePickerRD);
			splitContainer1.Panel2.Controls.Add(labelReleaseDate);
			splitContainer1.Panel2.Controls.Add(textBoxDesc);
			splitContainer1.Panel2.Controls.Add(labelDescription);
			splitContainer1.Panel2.Controls.Add(textBoxName);
			splitContainer1.Panel2.Controls.Add(labelName);
			splitContainer1.Size = new Size(957, 886);
			splitContainer1.SplitterDistance = 474;
			splitContainer1.TabIndex = 0;
			// 
			// buttonSearch
			// 
			buttonSearch.Location = new Point(12, 3);
			buttonSearch.Name = "buttonSearch";
			buttonSearch.Size = new Size(94, 29);
			buttonSearch.TabIndex = 2;
			buttonSearch.Text = "Search";
			buttonSearch.UseVisualStyleBackColor = true;
			buttonSearch.Click += buttonSearch_Click;
			// 
			// checkBoxList
			// 
			checkBoxList.AutoSize = true;
			checkBoxList.Location = new Point(112, 6);
			checkBoxList.Name = "checkBoxList";
			checkBoxList.Size = new Size(74, 24);
			checkBoxList.TabIndex = 1;
			checkBoxList.Text = "My list";
			checkBoxList.UseVisualStyleBackColor = true;
			checkBoxList.CheckedChanged += checkBoxList_CheckedChanged;
			// 
			// listBoxMovies
			// 
			listBoxMovies.FormattingEnabled = true;
			listBoxMovies.Location = new Point(12, 42);
			listBoxMovies.Name = "listBoxMovies";
			listBoxMovies.Size = new Size(459, 824);
			listBoxMovies.TabIndex = 0;
			listBoxMovies.SelectedIndexChanged += listBoxMovies_SelectedIndexChanged;
			// 
			// buttonRemoveActor
			// 
			buttonRemoveActor.Enabled = false;
			buttonRemoveActor.Location = new Point(247, 591);
			buttonRemoveActor.Name = "buttonRemoveActor";
			buttonRemoveActor.Size = new Size(220, 29);
			buttonRemoveActor.TabIndex = 34;
			buttonRemoveActor.Text = "Remove";
			buttonRemoveActor.UseVisualStyleBackColor = true;
			buttonRemoveActor.Click += buttonRemoveActor_Click;
			// 
			// checkBoxAddToList
			// 
			checkBoxAddToList.AutoSize = true;
			checkBoxAddToList.Location = new Point(3, 8);
			checkBoxAddToList.Name = "checkBoxAddToList";
			checkBoxAddToList.Size = new Size(124, 24);
			checkBoxAddToList.TabIndex = 11;
			checkBoxAddToList.Text = "Add to my list";
			checkBoxAddToList.UseVisualStyleBackColor = true;
			checkBoxAddToList.CheckedChanged += checkBoxAddToList_CheckedChanged;
			// 
			// buttonRemoveGenre
			// 
			buttonRemoveGenre.Enabled = false;
			buttonRemoveGenre.Location = new Point(3, 591);
			buttonRemoveGenre.Name = "buttonRemoveGenre";
			buttonRemoveGenre.Size = new Size(220, 29);
			buttonRemoveGenre.TabIndex = 33;
			buttonRemoveGenre.Text = "Remove";
			buttonRemoveGenre.UseVisualStyleBackColor = true;
			buttonRemoveGenre.Click += buttonRemoveGenre_Click;
			// 
			// buttonDelete
			// 
			buttonDelete.Location = new Point(3, 683);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(464, 29);
			buttonDelete.TabIndex = 10;
			buttonDelete.Text = "Delete";
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += buttonDelete_Click_1;
			// 
			// buttonActor
			// 
			buttonActor.Location = new Point(247, 556);
			buttonActor.Name = "buttonActor";
			buttonActor.Size = new Size(220, 29);
			buttonActor.TabIndex = 32;
			buttonActor.Text = "Add";
			buttonActor.UseVisualStyleBackColor = true;
			buttonActor.Click += buttonActor_Click;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(3, 648);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(464, 29);
			buttonSave.TabIndex = 9;
			buttonSave.Text = "Save changes";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += buttonSave_Click;
			// 
			// buttonGenre
			// 
			buttonGenre.Location = new Point(3, 556);
			buttonGenre.Name = "buttonGenre";
			buttonGenre.Size = new Size(220, 29);
			buttonGenre.TabIndex = 31;
			buttonGenre.Text = "Add";
			buttonGenre.UseVisualStyleBackColor = true;
			buttonGenre.Click += buttonGenre_Click;
			// 
			// labelRatingNumber
			// 
			labelRatingNumber.AutoSize = true;
			labelRatingNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
			labelRatingNumber.Location = new Point(3, 221);
			labelRatingNumber.Name = "labelRatingNumber";
			labelRatingNumber.Size = new Size(31, 20);
			labelRatingNumber.TabIndex = 8;
			labelRatingNumber.Text = "0.0";
			// 
			// labelActors
			// 
			labelActors.AutoSize = true;
			labelActors.Location = new Point(247, 303);
			labelActors.Name = "labelActors";
			labelActors.Size = new Size(51, 20);
			labelActors.TabIndex = 30;
			labelActors.Text = "Actors";
			// 
			// trackBarRating
			// 
			trackBarRating.LargeChange = 10;
			trackBarRating.Location = new Point(3, 244);
			trackBarRating.Maximum = 50;
			trackBarRating.Name = "trackBarRating";
			trackBarRating.Size = new Size(464, 56);
			trackBarRating.TabIndex = 7;
			trackBarRating.Scroll += trackBarRating_Scroll;
			// 
			// listBoxActors
			// 
			listBoxActors.FormattingEnabled = true;
			listBoxActors.Location = new Point(247, 326);
			listBoxActors.Name = "listBoxActors";
			listBoxActors.Size = new Size(220, 224);
			listBoxActors.TabIndex = 29;
			listBoxActors.SelectedIndexChanged += listBoxActors_SelectedIndexChanged;
			// 
			// labelRating
			// 
			labelRating.AutoSize = true;
			labelRating.Location = new Point(3, 201);
			labelRating.Name = "labelRating";
			labelRating.Size = new Size(52, 20);
			labelRating.TabIndex = 6;
			labelRating.Text = "Rating";
			// 
			// labelGenres
			// 
			labelGenres.AutoSize = true;
			labelGenres.Location = new Point(3, 303);
			labelGenres.Name = "labelGenres";
			labelGenres.Size = new Size(54, 20);
			labelGenres.TabIndex = 28;
			labelGenres.Text = "Genres";
			// 
			// listBoxGenres
			// 
			listBoxGenres.FormattingEnabled = true;
			listBoxGenres.Location = new Point(3, 326);
			listBoxGenres.Name = "listBoxGenres";
			listBoxGenres.Size = new Size(220, 224);
			listBoxGenres.TabIndex = 27;
			listBoxGenres.SelectedIndexChanged += listBoxGenres_SelectedIndexChanged;
			// 
			// dateTimePickerRD
			// 
			dateTimePickerRD.Location = new Point(3, 171);
			dateTimePickerRD.Name = "dateTimePickerRD";
			dateTimePickerRD.Size = new Size(464, 27);
			dateTimePickerRD.TabIndex = 5;
			dateTimePickerRD.ValueChanged += dateTimePickerRD_ValueChanged;
			// 
			// labelReleaseDate
			// 
			labelReleaseDate.AutoSize = true;
			labelReleaseDate.Location = new Point(3, 148);
			labelReleaseDate.Name = "labelReleaseDate";
			labelReleaseDate.Size = new Size(94, 20);
			labelReleaseDate.TabIndex = 4;
			labelReleaseDate.Text = "Release date";
			// 
			// textBoxDesc
			// 
			textBoxDesc.Location = new Point(3, 118);
			textBoxDesc.Name = "textBoxDesc";
			textBoxDesc.Size = new Size(464, 27);
			textBoxDesc.TabIndex = 3;
			textBoxDesc.TextChanged += textBoxDesc_TextChanged;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Location = new Point(3, 95);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new Size(85, 20);
			labelDescription.TabIndex = 2;
			labelDescription.Text = "Description";
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(3, 65);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(464, 27);
			textBoxName.TabIndex = 1;
			textBoxName.TextChanged += textBoxName_TextChanged;
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new Point(3, 42);
			labelName.Name = "labelName";
			labelName.Size = new Size(91, 20);
			labelName.TabIndex = 0;
			labelName.Text = "Movie name";
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripMenuItem, addToolStripMenuItem, importToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(957, 28);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// accountToolStripMenuItem
			// 
			accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logOutToolStripMenuItem });
			accountToolStripMenuItem.Name = "accountToolStripMenuItem";
			accountToolStripMenuItem.Size = new Size(77, 24);
			accountToolStripMenuItem.Text = "Account";
			// 
			// logOutToolStripMenuItem
			// 
			logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
			logOutToolStripMenuItem.Size = new Size(224, 26);
			logOutToolStripMenuItem.Text = "Log out";
			logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
			// 
			// addToolStripMenuItem
			// 
			addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMovieToolStripMenuItem });
			addToolStripMenuItem.Name = "addToolStripMenuItem";
			addToolStripMenuItem.Size = new Size(51, 24);
			addToolStripMenuItem.Text = "Add";
			// 
			// newMovieToolStripMenuItem
			// 
			newMovieToolStripMenuItem.Name = "newMovieToolStripMenuItem";
			newMovieToolStripMenuItem.Size = new Size(167, 26);
			newMovieToolStripMenuItem.Text = "New movie";
			newMovieToolStripMenuItem.Click += newMovieToolStripMenuItem_Click;
			// 
			// importToolStripMenuItem
			// 
			importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importJSONToolStripMenuItem, exportJSONToolStripMenuItem });
			importToolStripMenuItem.Name = "importToolStripMenuItem";
			importToolStripMenuItem.Size = new Size(117, 24);
			importToolStripMenuItem.Text = "Import/Export";
			importToolStripMenuItem.Click += importToolStripMenuItem_Click;
			// 
			// importJSONToolStripMenuItem
			// 
			importJSONToolStripMenuItem.Name = "importJSONToolStripMenuItem";
			importJSONToolStripMenuItem.Size = new Size(224, 26);
			importJSONToolStripMenuItem.Text = "Import JSON";
			importJSONToolStripMenuItem.Click += importJSONToolStripMenuItem_Click;
			// 
			// exportJSONToolStripMenuItem
			// 
			exportJSONToolStripMenuItem.Name = "exportJSONToolStripMenuItem";
			exportJSONToolStripMenuItem.Size = new Size(224, 26);
			exportJSONToolStripMenuItem.Text = "Export JSON";
			exportJSONToolStripMenuItem.Click += exportJSONToolStripMenuItem_Click;
			// 
			// MainGUI
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(957, 914);
			Controls.Add(splitContainer1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "MainGUI";
			Text = "Movie Database";
			Load += MainGUI_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)trackBarRating).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private SplitContainer splitContainer1;
		private CheckBox checkBoxList;
		private ListBox listBoxMovies;
		private Button buttonSearch;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem accountToolStripMenuItem;
		private ToolStripMenuItem importToolStripMenuItem;
		private ToolStripMenuItem addToolStripMenuItem;
		private Label labelName;
		private TextBox textBoxDesc;
		private Label labelDescription;
		private TextBox textBoxName;
		private Label labelReleaseDate;
		private Label labelRating;
		private DateTimePicker dateTimePickerRD;
		private TrackBar trackBarRating;
		private Label labelRatingNumber;
		private Button buttonSave;
		private Button buttonDelete;
		private ToolStripMenuItem newMovieToolStripMenuItem;
		private CheckBox checkBoxAddToList;
		private Button buttonRemoveActor;
		private Button buttonRemoveGenre;
		private Button buttonActor;
		private Button buttonGenre;
		private Label labelActors;
		private ListBox listBoxActors;
		private Label labelGenres;
		private ListBox listBoxGenres;
		private ToolStripMenuItem logOutToolStripMenuItem;
		private ToolStripMenuItem importJSONToolStripMenuItem;
		private ToolStripMenuItem exportJSONToolStripMenuItem;
	}
}