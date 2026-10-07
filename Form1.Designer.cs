namespace Last_Submission
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
            this.pictureBoxBefore = new System.Windows.Forms.PictureBox();
            this.pictureBoxAfter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCLear = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btGrayscale = new System.Windows.Forms.Button();
            this.btBlackWhite = new System.Windows.Forms.Button();
            this.btInvert = new System.Windows.Forms.Button();
            this.btAddFrame = new System.Windows.Forms.Button();
            this.ADDframe2 = new System.Windows.Forms.Button();
            this.btFlipH = new System.Windows.Forms.Button();
            this.btFlipV = new System.Windows.Forms.Button();
            this.btResize = new System.Windows.Forms.Button();
            this.btMergeImages = new System.Windows.Forms.Button();
            this.btDetectEdges = new System.Windows.Forms.Button();
            this.btBrightness = new System.Windows.Forms.Button();
            this.btCrop = new System.Windows.Forms.Button();
            this.Blur = new System.Windows.Forms.Button();
            this.SunlightFilter = new System.Windows.Forms.Button();
            this.TVEffect = new System.Windows.Forms.Button();
            this.btPurpleFilter = new System.Windows.Forms.Button();
            this.InfraredFilter = new System.Windows.Forms.Button();
            this.btSkewFilter = new System.Windows.Forms.Button();
            this.btOilPainting = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btrotate = new System.Windows.Forms.Button();
            this.cmbRotate = new System.Windows.Forms.ComboBox();
            this.btDarken = new System.Windows.Forms.Button();
            this.guiName = new System.Windows.Forms.Label();
            this.Names = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfter)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBefore
            // 
            this.pictureBoxBefore.BackColor = System.Drawing.Color.White;
            this.pictureBoxBefore.Location = new System.Drawing.Point(41, 44);
            this.pictureBoxBefore.Name = "pictureBoxBefore";
            this.pictureBoxBefore.Size = new System.Drawing.Size(376, 530);
            this.pictureBoxBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBefore.TabIndex = 0;
            this.pictureBoxBefore.TabStop = false;
            // 
            // pictureBoxAfter
            // 
            this.pictureBoxAfter.BackColor = System.Drawing.Color.White;
            this.pictureBoxAfter.Location = new System.Drawing.Point(451, 44);
            this.pictureBoxAfter.Name = "pictureBoxAfter";
            this.pictureBoxAfter.Size = new System.Drawing.Size(359, 530);
            this.pictureBoxAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAfter.TabIndex = 1;
            this.pictureBoxAfter.TabStop = false;
            this.pictureBoxAfter.Click += new System.EventHandler(this.pictureBoxAfter_Click);
            this.pictureBoxAfter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAfter_MouseDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Before";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(568, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "After";
            // 
            // btLoad
            // 
            this.btLoad.BackColor = System.Drawing.Color.Blue;
            this.btLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoad.Location = new System.Drawing.Point(41, 580);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(376, 54);
            this.btLoad.TabIndex = 4;
            this.btLoad.Text = "load image";
            this.btLoad.UseVisualStyleBackColor = false;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.Lime;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.Black;
            this.btSave.Location = new System.Drawing.Point(451, 579);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(220, 55);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCLear
            // 
            this.btCLear.BackColor = System.Drawing.Color.Red;
            this.btCLear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCLear.Location = new System.Drawing.Point(677, 580);
            this.btCLear.Name = "btCLear";
            this.btCLear.Size = new System.Drawing.Size(133, 55);
            this.btCLear.TabIndex = 6;
            this.btCLear.Text = "Clear";
            this.btCLear.UseVisualStyleBackColor = false;
            this.btCLear.Click += new System.EventHandler(this.btCLear_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btGrayscale);
            this.flowLayoutPanel1.Controls.Add(this.btBlackWhite);
            this.flowLayoutPanel1.Controls.Add(this.btInvert);
            this.flowLayoutPanel1.Controls.Add(this.btAddFrame);
            this.flowLayoutPanel1.Controls.Add(this.ADDframe2);
            this.flowLayoutPanel1.Controls.Add(this.btFlipH);
            this.flowLayoutPanel1.Controls.Add(this.btFlipV);
            this.flowLayoutPanel1.Controls.Add(this.btResize);
            this.flowLayoutPanel1.Controls.Add(this.btMergeImages);
            this.flowLayoutPanel1.Controls.Add(this.btDetectEdges);
            this.flowLayoutPanel1.Controls.Add(this.btBrightness);
            this.flowLayoutPanel1.Controls.Add(this.btDarken);
            this.flowLayoutPanel1.Controls.Add(this.btCrop);
            this.flowLayoutPanel1.Controls.Add(this.Blur);
            this.flowLayoutPanel1.Controls.Add(this.SunlightFilter);
            this.flowLayoutPanel1.Controls.Add(this.TVEffect);
            this.flowLayoutPanel1.Controls.Add(this.btPurpleFilter);
            this.flowLayoutPanel1.Controls.Add(this.InfraredFilter);
            this.flowLayoutPanel1.Controls.Add(this.btSkewFilter);
            this.flowLayoutPanel1.Controls.Add(this.btOilPainting);
            this.flowLayoutPanel1.Controls.Add(this.btrotate);
            this.flowLayoutPanel1.Controls.Add(this.cmbRotate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(863, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 582);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btGrayscale
            // 
            this.btGrayscale.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btGrayscale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrayscale.Location = new System.Drawing.Point(3, 3);
            this.btGrayscale.Name = "btGrayscale";
            this.btGrayscale.Size = new System.Drawing.Size(111, 66);
            this.btGrayscale.TabIndex = 0;
            this.btGrayscale.Text = "Gray scale";
            this.btGrayscale.UseVisualStyleBackColor = false;
            this.btGrayscale.Click += new System.EventHandler(this.btGrayscale_Click);
            // 
            // btBlackWhite
            // 
            this.btBlackWhite.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btBlackWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBlackWhite.Location = new System.Drawing.Point(120, 3);
            this.btBlackWhite.Name = "btBlackWhite";
            this.btBlackWhite.Size = new System.Drawing.Size(142, 66);
            this.btBlackWhite.TabIndex = 1;
            this.btBlackWhite.Text = "Black And White";
            this.btBlackWhite.UseVisualStyleBackColor = false;
            this.btBlackWhite.Click += new System.EventHandler(this.btBlackWhite_Click);
            // 
            // btInvert
            // 
            this.btInvert.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInvert.Location = new System.Drawing.Point(268, 3);
            this.btInvert.Name = "btInvert";
            this.btInvert.Size = new System.Drawing.Size(111, 66);
            this.btInvert.TabIndex = 2;
            this.btInvert.Text = "Invert";
            this.btInvert.UseVisualStyleBackColor = false;
            this.btInvert.Click += new System.EventHandler(this.btInvert_Click);
            // 
            // btAddFrame
            // 
            this.btAddFrame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btAddFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFrame.Location = new System.Drawing.Point(3, 75);
            this.btAddFrame.Name = "btAddFrame";
            this.btAddFrame.Size = new System.Drawing.Size(111, 66);
            this.btAddFrame.TabIndex = 3;
            this.btAddFrame.Text = "Add Frame";
            this.btAddFrame.UseVisualStyleBackColor = false;
            this.btAddFrame.Click += new System.EventHandler(this.btAddFrame_Click);
            // 
            // ADDframe2
            // 
            this.ADDframe2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ADDframe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDframe2.Location = new System.Drawing.Point(120, 75);
            this.ADDframe2.Name = "ADDframe2";
            this.ADDframe2.Size = new System.Drawing.Size(111, 66);
            this.ADDframe2.TabIndex = 18;
            this.ADDframe2.Text = "Add Frame2";
            this.ADDframe2.UseVisualStyleBackColor = false;
            this.ADDframe2.Click += new System.EventHandler(this.ADDframe2_Click);
            // 
            // btFlipH
            // 
            this.btFlipH.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btFlipH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFlipH.Location = new System.Drawing.Point(237, 75);
            this.btFlipH.Name = "btFlipH";
            this.btFlipH.Size = new System.Drawing.Size(111, 66);
            this.btFlipH.TabIndex = 4;
            this.btFlipH.Text = "Flip H";
            this.btFlipH.UseVisualStyleBackColor = false;
            this.btFlipH.Click += new System.EventHandler(this.btFlipH_Click);
            // 
            // btFlipV
            // 
            this.btFlipV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btFlipV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFlipV.Location = new System.Drawing.Point(354, 75);
            this.btFlipV.Name = "btFlipV";
            this.btFlipV.Size = new System.Drawing.Size(111, 66);
            this.btFlipV.TabIndex = 5;
            this.btFlipV.Text = "FliP V";
            this.btFlipV.UseVisualStyleBackColor = false;
            this.btFlipV.Click += new System.EventHandler(this.btFlipV_Click);
            // 
            // btResize
            // 
            this.btResize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResize.Location = new System.Drawing.Point(3, 147);
            this.btResize.Name = "btResize";
            this.btResize.Size = new System.Drawing.Size(111, 66);
            this.btResize.TabIndex = 7;
            this.btResize.Text = "Resize";
            this.btResize.UseVisualStyleBackColor = false;
            this.btResize.Click += new System.EventHandler(this.btResize_Click);
            // 
            // btMergeImages
            // 
            this.btMergeImages.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btMergeImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMergeImages.Location = new System.Drawing.Point(120, 147);
            this.btMergeImages.Name = "btMergeImages";
            this.btMergeImages.Size = new System.Drawing.Size(202, 66);
            this.btMergeImages.TabIndex = 8;
            this.btMergeImages.Text = "Merge Images";
            this.btMergeImages.UseVisualStyleBackColor = false;
            this.btMergeImages.Click += new System.EventHandler(this.btMergeImages_Click);
            // 
            // btDetectEdges
            // 
            this.btDetectEdges.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btDetectEdges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetectEdges.Location = new System.Drawing.Point(328, 147);
            this.btDetectEdges.Name = "btDetectEdges";
            this.btDetectEdges.Size = new System.Drawing.Size(136, 66);
            this.btDetectEdges.TabIndex = 9;
            this.btDetectEdges.Text = "Detect Edges";
            this.btDetectEdges.UseVisualStyleBackColor = false;
            this.btDetectEdges.Click += new System.EventHandler(this.btDetectEdges_Click);
            // 
            // btBrightness
            // 
            this.btBrightness.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrightness.Location = new System.Drawing.Point(3, 219);
            this.btBrightness.Name = "btBrightness";
            this.btBrightness.Size = new System.Drawing.Size(146, 66);
            this.btBrightness.TabIndex = 6;
            this.btBrightness.Text = "Brightness";
            this.btBrightness.UseVisualStyleBackColor = false;
            this.btBrightness.Click += new System.EventHandler(this.btBrightness_Click);
            // 
            // btCrop
            // 
            this.btCrop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCrop.Location = new System.Drawing.Point(282, 219);
            this.btCrop.Name = "btCrop";
            this.btCrop.Size = new System.Drawing.Size(111, 66);
            this.btCrop.TabIndex = 10;
            this.btCrop.Text = "Crop";
            this.btCrop.UseVisualStyleBackColor = false;
            this.btCrop.Click += new System.EventHandler(this.btCrop_Click);
            this.btCrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btCrop_MouseDown);
            // 
            // Blur
            // 
            this.Blur.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Blur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blur.Location = new System.Drawing.Point(3, 291);
            this.Blur.Name = "Blur";
            this.Blur.Size = new System.Drawing.Size(111, 66);
            this.Blur.TabIndex = 11;
            this.Blur.Text = "Blur";
            this.Blur.UseVisualStyleBackColor = false;
            this.Blur.Click += new System.EventHandler(this.Blur_Click);
            // 
            // SunlightFilter
            // 
            this.SunlightFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SunlightFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SunlightFilter.Location = new System.Drawing.Point(120, 291);
            this.SunlightFilter.Name = "SunlightFilter";
            this.SunlightFilter.Size = new System.Drawing.Size(136, 66);
            this.SunlightFilter.TabIndex = 12;
            this.SunlightFilter.Text = "Sunlight Filter";
            this.SunlightFilter.UseVisualStyleBackColor = false;
            this.SunlightFilter.Click += new System.EventHandler(this.SunlightFilter_Click);
            // 
            // TVEffect
            // 
            this.TVEffect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TVEffect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVEffect.Location = new System.Drawing.Point(262, 291);
            this.TVEffect.Name = "TVEffect";
            this.TVEffect.Size = new System.Drawing.Size(111, 66);
            this.TVEffect.TabIndex = 13;
            this.TVEffect.Text = "TV Effect";
            this.TVEffect.UseVisualStyleBackColor = false;
            this.TVEffect.Click += new System.EventHandler(this.TVEffect_Click);
            // 
            // btPurpleFilter
            // 
            this.btPurpleFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btPurpleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPurpleFilter.Location = new System.Drawing.Point(3, 363);
            this.btPurpleFilter.Name = "btPurpleFilter";
            this.btPurpleFilter.Size = new System.Drawing.Size(117, 66);
            this.btPurpleFilter.TabIndex = 14;
            this.btPurpleFilter.Text = "Purple Filter";
            this.btPurpleFilter.UseVisualStyleBackColor = false;
            this.btPurpleFilter.Click += new System.EventHandler(this.btPurpleFilter_Click);
            // 
            // InfraredFilter
            // 
            this.InfraredFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.InfraredFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfraredFilter.Location = new System.Drawing.Point(126, 363);
            this.InfraredFilter.Name = "InfraredFilter";
            this.InfraredFilter.Size = new System.Drawing.Size(136, 66);
            this.InfraredFilter.TabIndex = 15;
            this.InfraredFilter.Text = "Infrared Filter";
            this.InfraredFilter.UseVisualStyleBackColor = false;
            this.InfraredFilter.Click += new System.EventHandler(this.InfraredFilter_Click);
            // 
            // btSkewFilter
            // 
            this.btSkewFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSkewFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSkewFilter.Location = new System.Drawing.Point(268, 363);
            this.btSkewFilter.Name = "btSkewFilter";
            this.btSkewFilter.Size = new System.Drawing.Size(117, 66);
            this.btSkewFilter.TabIndex = 16;
            this.btSkewFilter.Text = "Skew Filter";
            this.btSkewFilter.UseVisualStyleBackColor = false;
            this.btSkewFilter.Click += new System.EventHandler(this.btSkewFilter_Click);
            // 
            // btOilPainting
            // 
            this.btOilPainting.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btOilPainting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOilPainting.Location = new System.Drawing.Point(3, 435);
            this.btOilPainting.Name = "btOilPainting";
            this.btOilPainting.Size = new System.Drawing.Size(345, 66);
            this.btOilPainting.TabIndex = 17;
            this.btOilPainting.Text = "Oil Painting";
            this.btOilPainting.UseVisualStyleBackColor = false;
            this.btOilPainting.Click += new System.EventHandler(this.btOilPainting_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            // 
            // btrotate
            // 
            this.btrotate.BackColor = System.Drawing.Color.IndianRed;
            this.btrotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btrotate.Location = new System.Drawing.Point(3, 507);
            this.btrotate.Name = "btrotate";
            this.btrotate.Size = new System.Drawing.Size(158, 66);
            this.btrotate.TabIndex = 20;
            this.btrotate.Text = "Rotate";
            this.btrotate.UseVisualStyleBackColor = false;
            this.btrotate.Click += new System.EventHandler(this.btrotate_Click);
            // 
            // cmbRotate
            // 
            this.cmbRotate.BackColor = System.Drawing.Color.IndianRed;
            this.cmbRotate.FormattingEnabled = true;
            this.cmbRotate.Location = new System.Drawing.Point(167, 507);
            this.cmbRotate.Name = "cmbRotate";
            this.cmbRotate.Size = new System.Drawing.Size(155, 24);
            this.cmbRotate.TabIndex = 21;
            this.cmbRotate.SelectedIndexChanged += new System.EventHandler(this.cmbRotate_SelectedIndexChanged);
            // 
            // btDarken
            // 
            this.btDarken.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btDarken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDarken.Location = new System.Drawing.Point(155, 219);
            this.btDarken.Name = "btDarken";
            this.btDarken.Size = new System.Drawing.Size(121, 66);
            this.btDarken.TabIndex = 22;
            this.btDarken.Text = "Darken";
            this.btDarken.UseVisualStyleBackColor = false;
            this.btDarken.Click += new System.EventHandler(this.btDarken_Click);
            // 
            // guiName
            // 
            this.guiName.AutoSize = true;
            this.guiName.BackColor = System.Drawing.Color.Transparent;
            this.guiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiName.ForeColor = System.Drawing.Color.White;
            this.guiName.Location = new System.Drawing.Point(829, 654);
            this.guiName.Name = "guiName";
            this.guiName.Size = new System.Drawing.Size(333, 25);
            this.guiName.TabIndex = 8;
            this.guiName.Text = "GUI Developed by:Ahmed Mohamed";
            // 
            // Names
            // 
            this.Names.BackColor = System.Drawing.Color.Transparent;
            this.Names.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Names.ForeColor = System.Drawing.Color.White;
            this.Names.Location = new System.Drawing.Point(829, 598);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(510, 57);
            this.Names.TabIndex = 9;
            this.Names.Text = "Developed by: Ahmed Mohamed-Zeiad Mohamed\r\nHaneen Mostafa-Salma Mostafa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1616, 716);
            this.Controls.Add(this.Names);
            this.Controls.Add(this.guiName);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btCLear);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxAfter);
            this.Controls.Add(this.pictureBoxBefore);
            this.Name = "Form1";
            this.Text = "Magic";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfter)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBefore;
        private System.Windows.Forms.PictureBox pictureBoxAfter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCLear;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btGrayscale;
        private System.Windows.Forms.Button btBlackWhite;
        private System.Windows.Forms.Button btInvert;
        private System.Windows.Forms.Button btAddFrame;
        private System.Windows.Forms.Button btFlipH;
        private System.Windows.Forms.Button btFlipV;
        private System.Windows.Forms.Button btBrightness;
        private System.Windows.Forms.Button btResize;
        private System.Windows.Forms.Button btMergeImages;
        private System.Windows.Forms.Button btDetectEdges;
        private System.Windows.Forms.Button btCrop;
        private System.Windows.Forms.Button Blur;
        private System.Windows.Forms.Button SunlightFilter;
        private System.Windows.Forms.Button TVEffect;
        private System.Windows.Forms.Button btPurpleFilter;
        private System.Windows.Forms.Button InfraredFilter;
        private System.Windows.Forms.Button btSkewFilter;
        private System.Windows.Forms.Button btOilPainting;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ADDframe2;
        private System.Windows.Forms.Button btrotate;
        private System.Windows.Forms.ComboBox cmbRotate;
        private System.Windows.Forms.Button btDarken;
        private System.Windows.Forms.Label guiName;
        private System.Windows.Forms.Label Names;
    }
}

