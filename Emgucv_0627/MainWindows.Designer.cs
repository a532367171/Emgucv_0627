namespace Emgucv_0627
{
    partial class MainWindows
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
            this.components = new System.ComponentModel.Container();
            this.imageBox_capture = new Emgu.CV.UI.ImageBox();
            this.button_capture_start = new System.Windows.Forms.Button();
            this.face_box = new Emgu.CV.UI.ImageBox();
            this.button_capture_frame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_capture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.face_box)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox_capture
            // 
            this.imageBox_capture.Location = new System.Drawing.Point(13, 13);
            this.imageBox_capture.Name = "imageBox_capture";
            this.imageBox_capture.Size = new System.Drawing.Size(413, 333);
            this.imageBox_capture.TabIndex = 2;
            this.imageBox_capture.TabStop = false;
            // 
            // button_capture_start
            // 
            this.button_capture_start.Location = new System.Drawing.Point(58, 378);
            this.button_capture_start.Name = "button_capture_start";
            this.button_capture_start.Size = new System.Drawing.Size(101, 38);
            this.button_capture_start.TabIndex = 3;
            this.button_capture_start.UseVisualStyleBackColor = true;
            this.button_capture_start.Click += new System.EventHandler(this.button_capture_start_Click);
            // 
            // face_box
            // 
            this.face_box.Location = new System.Drawing.Point(433, 13);
            this.face_box.Name = "face_box";
            this.face_box.Size = new System.Drawing.Size(355, 333);
            this.face_box.TabIndex = 2;
            this.face_box.TabStop = false;
            // 
            // button_capture_frame
            // 
            this.button_capture_frame.Location = new System.Drawing.Point(490, 378);
            this.button_capture_frame.Name = "button_capture_frame";
            this.button_capture_frame.Size = new System.Drawing.Size(99, 41);
            this.button_capture_frame.TabIndex = 4;
            this.button_capture_frame.Text = "button1";
            this.button_capture_frame.UseVisualStyleBackColor = true;
            this.button_capture_frame.Click += new System.EventHandler(this.button_capture_frame_Click);
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_capture_frame);
            this.Controls.Add(this.face_box);
            this.Controls.Add(this.button_capture_start);
            this.Controls.Add(this.imageBox_capture);
            this.Name = "MainWindows";
            this.Text = "MainWindows";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_capture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.face_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox_capture;
        private System.Windows.Forms.Button button_capture_start;
        private Emgu.CV.UI.ImageBox face_box;
        private System.Windows.Forms.Button button_capture_frame;
    }
}