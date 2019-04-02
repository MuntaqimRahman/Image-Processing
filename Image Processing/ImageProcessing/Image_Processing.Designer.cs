namespace ImageProcessing
{
    partial class formImageProcessing
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
            this.btnTransformGreen = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnNegative = new System.Windows.Forms.Button();
            this.btnLighten = new System.Windows.Forms.Button();
            this.btnDarken = new System.Windows.Forms.Button();
            this.btnSunset = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnTransformRed = new System.Windows.Forms.Button();
            this.btnTransformBlue = new System.Windows.Forms.Button();
            this.btnPolarize = new System.Windows.Forms.Button();
            this.btnVerticalFlip = new System.Windows.Forms.Button();
            this.btnHorizontalFlip = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnPixellate = new System.Windows.Forms.Button();
            this.btnScrolling = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnEdgeDetection = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.chBoxZoom = new System.Windows.Forms.CheckBox();
            this.btnZoomQuestion = new System.Windows.Forms.Button();
            this.lblZoomNotification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransformGreen
            // 
            this.btnTransformGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransformGreen.Location = new System.Drawing.Point(349, 137);
            this.btnTransformGreen.Name = "btnTransformGreen";
            this.btnTransformGreen.Size = new System.Drawing.Size(97, 23);
            this.btnTransformGreen.TabIndex = 7;
            this.btnTransformGreen.Text = "Transform Green";
            this.btnTransformGreen.UseVisualStyleBackColor = true;
            this.btnTransformGreen.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(257, 258);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(320, 240);
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // btnNegative
            // 
            this.btnNegative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNegative.Location = new System.Drawing.Point(349, 17);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(97, 24);
            this.btnNegative.TabIndex = 3;
            this.btnNegative.Text = "Negative";
            this.btnNegative.UseVisualStyleBackColor = true;
            this.btnNegative.Click += new System.EventHandler(this.Negative_Click);
            // 
            // btnLighten
            // 
            this.btnLighten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLighten.Location = new System.Drawing.Point(349, 47);
            this.btnLighten.Name = "btnLighten";
            this.btnLighten.Size = new System.Drawing.Size(97, 24);
            this.btnLighten.TabIndex = 4;
            this.btnLighten.Text = "Lighten";
            this.btnLighten.UseVisualStyleBackColor = true;
            this.btnLighten.Click += new System.EventHandler(this.Lighten_Click);
            // 
            // btnDarken
            // 
            this.btnDarken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarken.Location = new System.Drawing.Point(349, 77);
            this.btnDarken.Name = "btnDarken";
            this.btnDarken.Size = new System.Drawing.Size(97, 24);
            this.btnDarken.TabIndex = 5;
            this.btnDarken.Text = "Darken";
            this.btnDarken.UseVisualStyleBackColor = true;
            this.btnDarken.Click += new System.EventHandler(this.Darken_Click);
            // 
            // btnSunset
            // 
            this.btnSunset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSunset.Location = new System.Drawing.Point(452, 18);
            this.btnSunset.Name = "btnSunset";
            this.btnSunset.Size = new System.Drawing.Size(97, 23);
            this.btnSunset.TabIndex = 9;
            this.btnSunset.Text = "Sunset";
            this.btnSunset.UseVisualStyleBackColor = true;
            this.btnSunset.Click += new System.EventHandler(this.btnSunset_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate.Location = new System.Drawing.Point(453, 47);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(96, 24);
            this.btnRotate.TabIndex = 10;
            this.btnRotate.Text = "Rotate 180";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrayscale.Location = new System.Drawing.Point(349, 107);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(97, 24);
            this.btnGrayscale.TabIndex = 6;
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnTransformRed
            // 
            this.btnTransformRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransformRed.Location = new System.Drawing.Point(453, 137);
            this.btnTransformRed.Name = "btnTransformRed";
            this.btnTransformRed.Size = new System.Drawing.Size(97, 23);
            this.btnTransformRed.TabIndex = 13;
            this.btnTransformRed.Text = "Transform Red";
            this.btnTransformRed.UseVisualStyleBackColor = true;
            this.btnTransformRed.Click += new System.EventHandler(this.btnTransformRed_Click);
            // 
            // btnTransformBlue
            // 
            this.btnTransformBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransformBlue.Location = new System.Drawing.Point(349, 166);
            this.btnTransformBlue.Name = "btnTransformBlue";
            this.btnTransformBlue.Size = new System.Drawing.Size(97, 23);
            this.btnTransformBlue.TabIndex = 8;
            this.btnTransformBlue.Text = "Transform Blue";
            this.btnTransformBlue.UseVisualStyleBackColor = true;
            this.btnTransformBlue.Click += new System.EventHandler(this.btnTransformBlue_Click);
            // 
            // btnPolarize
            // 
            this.btnPolarize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolarize.Location = new System.Drawing.Point(451, 166);
            this.btnPolarize.Name = "btnPolarize";
            this.btnPolarize.Size = new System.Drawing.Size(97, 23);
            this.btnPolarize.TabIndex = 14;
            this.btnPolarize.Text = "Polarize";
            this.btnPolarize.UseVisualStyleBackColor = true;
            this.btnPolarize.Click += new System.EventHandler(this.btnPolarize_Click);
            // 
            // btnVerticalFlip
            // 
            this.btnVerticalFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerticalFlip.Location = new System.Drawing.Point(452, 77);
            this.btnVerticalFlip.Name = "btnVerticalFlip";
            this.btnVerticalFlip.Size = new System.Drawing.Size(96, 24);
            this.btnVerticalFlip.TabIndex = 11;
            this.btnVerticalFlip.Text = "Flip Vertically";
            this.btnVerticalFlip.UseVisualStyleBackColor = true;
            this.btnVerticalFlip.Click += new System.EventHandler(this.btnVerticalFlip_Click);
            // 
            // btnHorizontalFlip
            // 
            this.btnHorizontalFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorizontalFlip.Location = new System.Drawing.Point(453, 107);
            this.btnHorizontalFlip.Name = "btnHorizontalFlip";
            this.btnHorizontalFlip.Size = new System.Drawing.Size(96, 24);
            this.btnHorizontalFlip.TabIndex = 12;
            this.btnHorizontalFlip.Text = "Flip Horizontally";
            this.btnHorizontalFlip.UseVisualStyleBackColor = true;
            this.btnHorizontalFlip.Click += new System.EventHandler(this.btnHorizontalFlip_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlur.Location = new System.Drawing.Point(596, 138);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(97, 23);
            this.btnBlur.TabIndex = 19;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitch.Location = new System.Drawing.Point(596, 18);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(97, 23);
            this.btnSwitch.TabIndex = 15;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnPixellate
            // 
            this.btnPixellate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPixellate.Location = new System.Drawing.Point(596, 49);
            this.btnPixellate.Name = "btnPixellate";
            this.btnPixellate.Size = new System.Drawing.Size(97, 23);
            this.btnPixellate.TabIndex = 16;
            this.btnPixellate.Text = "Pixellate";
            this.btnPixellate.UseVisualStyleBackColor = true;
            this.btnPixellate.Click += new System.EventHandler(this.btnPixellate_Click);
            // 
            // btnScrolling
            // 
            this.btnScrolling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrolling.Location = new System.Drawing.Point(596, 78);
            this.btnScrolling.Name = "btnScrolling";
            this.btnScrolling.Size = new System.Drawing.Size(97, 23);
            this.btnScrolling.TabIndex = 17;
            this.btnScrolling.Text = "Scrolling";
            this.btnScrolling.UseVisualStyleBackColor = true;
            this.btnScrolling.Click += new System.EventHandler(this.btnScrolling_Click);
            // 
            // btnSort
            // 
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Location = new System.Drawing.Point(596, 108);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(97, 23);
            this.btnSort.TabIndex = 18;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnEdgeDetection
            // 
            this.btnEdgeDetection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdgeDetection.Location = new System.Drawing.Point(596, 167);
            this.btnEdgeDetection.Name = "btnEdgeDetection";
            this.btnEdgeDetection.Size = new System.Drawing.Size(97, 23);
            this.btnEdgeDetection.TabIndex = 20;
            this.btnEdgeDetection.Text = "Edge Detection";
            this.btnEdgeDetection.UseVisualStyleBackColor = true;
            this.btnEdgeDetection.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(95, 258);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 0;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Location = new System.Drawing.Point(176, 258);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 23);
            this.btnRedo.TabIndex = 1;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // chBoxZoom
            // 
            this.chBoxZoom.AutoSize = true;
            this.chBoxZoom.Location = new System.Drawing.Point(349, 195);
            this.chBoxZoom.Name = "chBoxZoom";
            this.chBoxZoom.Size = new System.Drawing.Size(53, 17);
            this.chBoxZoom.TabIndex = 25;
            this.chBoxZoom.Text = "Zoom";
            this.chBoxZoom.UseVisualStyleBackColor = true;
            this.chBoxZoom.CheckedChanged += new System.EventHandler(this.chBoxZoom_CheckedChanged);
            // 
            // btnZoomQuestion
            // 
            this.btnZoomQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomQuestion.Location = new System.Drawing.Point(399, 191);
            this.btnZoomQuestion.Name = "btnZoomQuestion";
            this.btnZoomQuestion.Size = new System.Drawing.Size(24, 23);
            this.btnZoomQuestion.TabIndex = 21;
            this.btnZoomQuestion.Text = "?";
            this.btnZoomQuestion.UseVisualStyleBackColor = true;
            this.btnZoomQuestion.Click += new System.EventHandler(this.btnZoomQuestion_Click);
            // 
            // lblZoomNotification
            // 
            this.lblZoomNotification.AutoSize = true;
            this.lblZoomNotification.Location = new System.Drawing.Point(351, 223);
            this.lblZoomNotification.Name = "lblZoomNotification";
            this.lblZoomNotification.Size = new System.Drawing.Size(0, 13);
            this.lblZoomNotification.TabIndex = 27;
            // 
            // formImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 290);
            this.Controls.Add(this.lblZoomNotification);
            this.Controls.Add(this.btnZoomQuestion);
            this.Controls.Add(this.chBoxZoom);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnEdgeDetection);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnScrolling);
            this.Controls.Add(this.btnPixellate);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.btnBlur);
            this.Controls.Add(this.btnHorizontalFlip);
            this.Controls.Add(this.btnVerticalFlip);
            this.Controls.Add(this.btnPolarize);
            this.Controls.Add(this.btnTransformBlue);
            this.Controls.Add(this.btnTransformRed);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnSunset);
            this.Controls.Add(this.btnDarken);
            this.Controls.Add(this.btnLighten);
            this.Controls.Add(this.btnNegative);
            this.Controls.Add(this.btnTransformGreen);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picImage);
            this.Name = "formImageProcessing";
            this.Text = "Image Processing";
            this.Load += new System.EventHandler(this.formImageProcessing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransformGreen;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnNegative;
        private System.Windows.Forms.Button btnLighten;
        private System.Windows.Forms.Button btnDarken;
        private System.Windows.Forms.Button btnSunset;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnTransformRed;
        private System.Windows.Forms.Button btnTransformBlue;
        private System.Windows.Forms.Button btnPolarize;
        private System.Windows.Forms.Button btnVerticalFlip;
        private System.Windows.Forms.Button btnHorizontalFlip;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnPixellate;
        private System.Windows.Forms.Button btnScrolling;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnEdgeDetection;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.CheckBox chBoxZoom;
        private System.Windows.Forms.Button btnZoomQuestion;
        private System.Windows.Forms.Label lblZoomNotification;
    }
}

