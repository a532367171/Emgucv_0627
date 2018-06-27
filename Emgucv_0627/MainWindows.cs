using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Emgucv_0627
{
    public partial class MainWindows : Form
    {
        private string haarXmlPath = "haarcascade_frontalface_alt_tree.xml";
        double scale = 1.5;
        //double scale = 10;

        // web camera  
        private Capture capture;
        private bool capture_flag = true;
        private Image<Bgr, Byte> frame = null;
        Image<Gray, Byte> gray = null;
        Image<Bgr, Byte> smallframe = null;

        private System.Timers.Timer capture_tick;
        public MainWindows()
        {
            InitializeComponent();

            capture_tick = new System.Timers.Timer();
            capture_tick.Interval = 100;
            capture_tick.Enabled = Enabled;
            capture_tick.Stop();
            capture_tick.Elapsed += new ElapsedEventHandler(CaptureProcess);
        }
        public void CaptureProcess(object sender, EventArgs arg)
        {
            //frame = capture.QueryFrame();

            frame = capture.QueryFrame().ToImage<Bgr, byte>();
            if (frame != null)
            {

                //face detection   

                //frame = frame.Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL);  
                //smallframe = frame.Resize(1 / scale, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);//缩放摄像头拍到的大尺寸照片  
                smallframe = frame.Resize(1 / scale, Inter.Linear);//缩放摄像头拍到的大尺寸照片  

                gray = smallframe.Convert<Gray, Byte>(); //Convert it to Grayscale  
                gray._EqualizeHist();//均衡化  

                CascadeClassifier ccr = new CascadeClassifier(haarXmlPath);
                Rectangle[] rects = ccr.DetectMultiScale(gray, 1.3, 3, new Size(20, 20), Size.Empty);
                foreach (Rectangle r in rects)
                {
                    //This will focus in on the face from the haar results its not perfect but it will remove a majoriy  
                    //of the background noise  
                    Rectangle facesDetected = r;
                    facesDetected.X += (int)(facesDetected.Height * 0.6);
                    facesDetected.Y += (int)(facesDetected.Width * 0.8);
                    facesDetected.Height += (int)(facesDetected.Height * 0.1);
                    facesDetected.Width += (int)(facesDetected.Width * 0.2);

                    frame.Draw(facesDetected, new Bgr(Color.Red), 3);//绘制检测框  
                }


                imageBox_capture.Image = frame;
            }
        }


        private void button_capture_start_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException except)
                {
                    MessageBox.Show(except.Message);
                }
            }

            if (capture != null)
            {
                if (capture_flag)
                {
                    //Application.Idle += new EventHandler(CaptureProcess);  
                    capture_tick.Start();
                    button_capture_start.Text = "停止";
                }
                else
                {
                    //Application.Idle -= new EventHandler(CaptureProcess);  
                    capture_tick.Stop();
                    button_capture_start.Text = "开始";
                }
                capture_flag = !capture_flag;
            }
        }

        private void button_capture_frame_Click(object sender, EventArgs e)
        {

            face_box.Image = this.frame;

        }

        //private void btnTranstion_Click(object sender, EventArgs e)
        //{
        //    Bitmap bitmap = new Bitmap("001.jpg");
        //    //Bitmap转Image<Bgr, byte>
        //    Image<Bgr, byte> image = new Image<Bgr, byte>(bitmap);
        //    //Image<Bgr, byte>转Bitmap
        //    Bitmap _bitmap = image.ToBitmap();
        //    Bitmap _bitmap1 = image.Bitmap;
        //    //Image<Bgr, byte>转Mat
        //    Mat _mat = image.Mat;
        //    Mat _mat1 = image.ToUMat().GetMat(Emgu.CV.CvEnum.AccessType.Fast);
        //    //Mat转Image<Bgr, byte>
        //    Image<Bgr, byte> _image = _mat.ToImage<Bgr, byte>();
        //    //Mat转UMat
        //    UMat umat = _mat.GetUMat(Emgu.CV.CvEnum.AccessType.Fast);
        //    //UMat转Mat
        //    Mat mat = umat.GetMat(Emgu.CV.CvEnum.AccessType.Fast);
        //    //UMat转Image<Bgr, byte>
        //    Image<Bgr, byte> _image1 = umat.ToImage<Bgr, byte>();
        //    //Image<Bgr, byte>转UMat
        //    UMat umat2 = image.ToUMat();

        //    imgLoad.Image = image;
        //}
    }
}
