using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZXing;
using ZXing.Common;

using AForge.Video;
using AForge.Video.DirectShow;

using System.Runtime.InteropServices;

namespace QRCodeUnlock
{
    public partial class Prompt : Form
    {
        // Used to lock the computer if desired
        [DllImport("user32")]
        public static extern void LockWorkStation();
        
        // turns true when the user is really the user
        private bool approved = false;

        // countdown: 1 minute to provide valid credentials
        private int countdown = 60;

        public Prompt()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(Prompt_FormClosed);
            textBoxBackupPassword.KeyUp += new KeyEventHandler(textBoxBackupPassword_KeyUp);
            FormClosing += new FormClosingEventHandler(Prompt_FormClosing);
        }

        //
        // BEGINNING SOURCE CODE WEBCAM READER
        //

        //Create webcam object
        VideoCaptureDevice videoSource;

        private void Prompt_Load(object sender, EventArgs e)
        {
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (videosources != null)
            {
                //For example use first video device. You may check if this is your webcam.
                videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                try
                {
                    //Check if the video device provides a list of supported resolutions
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        string highestSolution = "0;0";
                        //Search for the highest resolution
                        for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                        {
                            if (videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Set the highest resolution as active
                        videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                    }
                }
                catch { }

                //Create NewFrame event handler
                //(This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                videoSource.Start();

                // Set focus on the form and specifically the text box
                this.Activate();
                textBoxBackupPassword.Focus();
            }

        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions
            //pictureBoxVideo.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();

            Bitmap barcodeBitmap = (Bitmap)eventArgs.Frame.Clone();

            if (ExtractQRCodeMessageFromImage(barcodeBitmap) == "yJz1X")
            {
                if (!System.IO.File.Exists("C:\\Users\\joach\\OVERRIDE"))
                {
                    approved = true;
                    Exit();
                }
            }
        }

        private void Prompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop and free the webcam object if application is closing
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        //
        // END SOURCE WEBCAM READER
        //

        //
        // BEGINNING STACKOVERFLOW SOURCE
        // http://stackoverflow.com/questions/32634027/how-to-decode-qrcode-from-webcamera-using-aforge-net-and-zxing-net-in-c-sharp
        //

        private string ExtractQRCodeMessageFromImage(Bitmap bitmap)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader
                    (null, newbitmap => new BitmapLuminanceSource(bitmap), luminance => new GlobalHistogramBinarizer(luminance));

                //reader.AutoRotate = true;
                //reader.TryInverted = true;
                List<BarcodeFormat> possibleFormats = new List<BarcodeFormat>();
                possibleFormats.Add(BarcodeFormat.CODE_128);
                reader.Options = new DecodingOptions { TryHarder = true , PossibleFormats = possibleFormats};

                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    return result.Text;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        //
        // END STACKOVERFLOW SOURCE
        //

        private void textBoxBackupPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (EqualsHash(textBoxBackupPassword.Text, "20F78D46DD45CD4B74C31056CEFFBFB4"))
            {
                // Correct password entered
                // Remove the override file if it exists
                if (System.IO.File.Exists("C:\\Users\\joach\\OVERRIDE"))
                {
                    System.IO.File.Delete("C:\\Users\\joach\\OVERRIDE");
                }

                // approve and exit
                approved = true;
                Exit();
            }
            
            if (textBoxBackupPassword.Text == "o")
            {
                // Override the QR Code Login functionality
                if (!System.IO.File.Exists("C:\\Users\\joach\\OVERRIDE"))
                {
                    System.IO.File.Create("C:\\Users\\joach\\OVERRIDE");
                }

                // exit, not approved
                Exit();
            }
        }
        
        private void Prompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if user hasn't provided the correct password/Code, lock work station again
            if (!approved) LockWorkStation();
        }

        private void Exit()
        {
            Application.Exit();
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            countdown -= 1;
            labelSecsToLogIn.Text = countdown.ToString() + " seconds to log in";
            if (countdown < 1)
            {
                Exit();
            }
        }

        private bool EqualsHash(string str, string hashstr)
        {
            byte[] byteCode = Encoding.Unicode.GetBytes(str);
            return hashstr == Hash.GetMD5(byteCode);
        }
    }
}
