using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace NVStereoTest
{
    public class WinForm : System.Windows.Forms.Form
    {
        private Device _device;
        private System.ComponentModel.Container components = null;
        private Surface _imageBuf;
        private Surface _attBuf;
        private Surface _backBuf;
        private Surface _imageLeft;
        private Surface _imageRight;
        private Surface _attLeft;
        private Surface _attRight;
        private Rectangle _size = new Rectangle(0, 0, 1024, 768); //640, 480); //1920, 1080);
        private uint count = 0;
        private uint mode = 1;
        private uint file = 'e';
        private uint ab = 'a';
        private uint dt = 2;
        //private Random rd;

        static void Main()
        {
            using (WinForm new_form = new WinForm())
            {
                new_form.InitializeComponent();
                new_form.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
                new_form.InitializeDevice();
                new_form.LoadSurfaces();
                new_form.Set3D();
                Application.Run(new_form);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(_size.Width, _size.Height);
            this.Text = "Nvidia 3D Vision test";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(KeyIn);

            //rd = new Random();
        }
        private void KeyIn(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
            {
                file = 'e';
            }
            else if (e.KeyChar == '1')
            {
                file = 'h';
            }
            else if (e.KeyChar == '2')
            {
                file = 'm';
            }
            else if (e.KeyChar == '3')
            {
                file = 'b';
            }
            else if (e.KeyChar == '4')
            {
                file = 'f';
            }
            else if (e.KeyChar == '5')
            {
                file = 'c';
            }
            else if (e.KeyChar == 'o')
            {
                mode = 2;
            }
            else if (e.KeyChar == 'k')
            {
                mode = 1;
            }
            else if (e.KeyChar == 'a')
            {
                ab = 'a';
            }
            else if (e.KeyChar == 'b')
            {
                ab = 'b';
            }
            else { }
            LoadSurfaces();
            Set3D();
        }

        public void InitializeDevice()
        {
            PresentParameters presentParams = new PresentParameters();
            
            presentParams.Windowed = false;
            presentParams.BackBufferFormat = Format.A8R8G8B8;
            presentParams.BackBufferWidth =  _size.Width;
            presentParams.BackBufferHeight =  _size.Height;
            presentParams.BackBufferCount = 1;
            presentParams.SwapEffect = SwapEffect.Flip; //.Discard;
            presentParams.PresentationInterval = PresentInterval.Immediate; //.One;
            
            _device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);

            _imageBuf = _device.CreateOffscreenPlainSurface(_size.Width * 2, _size.Height + 1, Format.A8R8G8B8, Pool.Default);
            _attBuf = _device.CreateOffscreenPlainSurface(_size.Width * 2, _size.Height + 1, Format.A8R8G8B8, Pool.Default);
        }

        public void LoadSurfaces()
        {
            //_imageBuf = _device.CreateOffscreenPlainSurface(_size.Width * 2, _size.Height + 1, Format.A8R8G8B8, Pool.Default);
            //_attBuf = _device.CreateOffscreenPlainSurface(_size.Width * 2, _size.Height + 1, Format.A8R8G8B8, Pool.Default);
            string ea0 = "new_ea0.bmp", ea1 = "new_ea1.bmp", ea2 = "new_ea2.bmp", ea3 = "new_ea3.bmp", ea4 = "ea4.bmp", ea5 = "ea5.bmp";
            //string ea0 = "ea0.bmp", ea1 = "ea1.bmp", ea2 = "ea2.bmp", ea3 = "ea3.bmp", ea4 = "ea4.bmp", ea5 = "ea5.bmp";
            string ha0 = "new_ha0.bmp", ha1 = "new_ha1.bmp", ha2 = "new_ha2.bmp", ha3 = "new_ha3.bmp", ha4 = "ha4.bmp", ha5 = "ha5.bmp";
            //string ha0 = "ha0.bmp", ha1 = "ha1.bmp", ha2 = "ha2.bmp", ha3 = "ha3.bmp", ha4 = "ha4.bmp", ha5 = "ha5.bmp";
            string ma0 = "new_ma0.bmp", ma1 = "new_ma1.bmp", ma2 = "new_ma2.bmp", ma3 = "new_ma3.bmp", ma4 = "ma4.bmp", ma5 = "ma5.bmp";
            string ba0 = "new_ba0.bmp", ba1 = "new_ba1.bmp", ba2 = "new_ba2.bmp", ba3 = "new_ba3.bmp", ba4 = "ba4.bmp", ba5 = "ba5.bmp";
            string fa0 = "new_fa0.bmp", fa1 = "new_fa1.bmp", fa2 = "new_fa2.bmp", fa3 = "new_fa3.bmp", fa4 = "fa4.bmp", fa5 = "fa5.bmp";
            string ca0 = "new_ca0.bmp", ca1 = "new_ca1.bmp", ca2 = "new_ca2.bmp", ca3 = "new_ca3.bmp", ca4 = "ca4.bmp", ca5 = "ca5.bmp";
            //string eb0 = "eb0.bmp", eb1 = "eb1.bmp", eb2 = "eb2.bmp", eb3 = "eb3.bmp", eb4 = "eb4.bmp", eb5 = "eb5.bmp";
            string eb0 = "new_eb0.bmp", eb1 = "new_eb1.bmp", eb2 = "new_eb2.bmp", eb3 = "new_eb3.bmp", eb4 = "eb4.bmp", eb5 = "eb5.bmp";
            string hb0 = "new_hb0.bmp", hb1 = "new_hb1.bmp", hb2 = "new_hb2.bmp", hb3 = "new_hb3.bmp", hb4 = "hb4.bmp", hb5 = "hb5.bmp";
            string mb0 = "new_mb0.bmp", mb1 = "new_mb1.bmp", mb2 = "new_mb2.bmp", mb3 = "new_mb3.bmp", mb4 = "mb4.bmp", mb5 = "mb5.bmp";
            string bb0 = "new_bb0.bmp", bb1 = "new_bb1.bmp", bb2 = "new_bb2.bmp", bb3 = "new_bb3.bmp", bb4 = "bb4.bmp", bb5 = "bb5.bmp";
            string fb0 = "new_fb0.bmp", fb1 = "new_fb1.bmp", fb2 = "new_fb2.bmp", fb3 = "new_fb3.bmp", fb4 = "fb4.bmp", fb5 = "fb5.bmp";
            string cb0 = "new_cb0.bmp", cb1 = "new_cb1.bmp", cb2 = "new_cb2.bmp", cb3 = "new_cb3.bmp", cb4 = "cb4.bmp", cb5 = "cb5.bmp";

            string k0 = "", k1 = "", k2 = "", k3 = "", k4 = "", k5 = "";
            if (ab == 'a')
            {
                if (file == 'e')
                {
                    k0 = ea0; k1 = ea1; k2 = ea2; k3 = ea3; k4 = ea4; k5 = ea5;
                }
                else if (file == 'h')
                {
                    k0 = ha0; k1 = ha1; k2 = ha2; k3 = ha3; k4 = ha4; k5 = ha5;
                }
                else if (file == 'm')
                {
                    k0 = ma0; k1 = ma1; k2 = ma2; k3 = ma3; k4 = ma4; k5 = ma5;
                }
                else if (file == 'b')
                {
                    k0 = ba0; k1 = ba1; k2 = ba2; k3 = ba3; k4 = ba4; k5 = ba5;
                }
                else if (file == 'f')
                {
                    k0 = fa0; k1 = fa1; k2 = fa2; k3 = fa3; k4 = fa4; k5 = fa5;
                }
                else if (file == 'c')
                {
                    k0 = ca0; k1 = ca1; k2 = ca2; k3 = ca3; k4 = ca4; k5 = ca5;
                }
                else { }
            }
            else if (ab == 'b')
            {
                if (file == 'e')
                {
                    k0 = eb0; k1 = eb1; k2 = eb2; k3 = eb3; k4 = eb4; k5 = eb5;
                }
                else if (file == 'h')
                {
                    k0 = hb0; k1 = hb1; k2 = hb2; k3 = hb3; k4 = hb4; k5 = hb5;
                }
                else if (file == 'm')
                {
                    k0 = mb0; k1 = mb1; k2 = mb2; k3 = mb3; k4 = mb4; k5 = mb5;
                }
                else if (file == 'b')
                {
                    k0 = bb0; k1 = bb1; k2 = bb2; k3 = bb3; k4 = bb4; k5 = bb5;
                }
                else if (file == 'f')
                {
                    k0 = fb0; k1 = fb1; k2 = fb2; k3 = fb3; k4 = fb4; k5 = fb5;
                }
                else if (file == 'c')
                {
                    k0 = cb0; k1 = cb1; k2 = cb2; k3 = cb3; k4 = cb4; k5 = cb5;
                }
                else { }
            }
            else { }

            if (mode == 1)
            {
                _imageLeft = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k0), Pool.Default);
                _imageRight = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k1), Pool.Default);

                _attLeft = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k2), Pool.Default);
                _attRight = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k3), Pool.Default);
            }
            else if (mode == 2)
            {
                _imageLeft = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k4), Pool.Default);
                _imageRight = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k5), Pool.Default);

                _attLeft = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k4), Pool.Default);
                _attRight = Surface.FromBitmap(_device, (Bitmap)Bitmap.FromFile(k5), Pool.Default);
            }
            else if (mode == 3)
            {
            }
            else if (mode == 4)
            {
            }
            else { }
        }

        private void Set3D()
        {
            Rectangle sourRect = new Rectangle(0, 0, 1024, 768);
            Rectangle destRect = new Rectangle(0, 0, _size.Width, _size.Height);
            //_device.StretchRectangle(_imageLeft, _size, _imageBuf, destRect, TextureFilter.None);
            _device.StretchRectangle(_imageLeft, sourRect, _imageBuf, destRect, TextureFilter.Linear);
            destRect.X = _size.Width;
            //_device.StretchRectangle(_imageRight, _size, _imageBuf, destRect, TextureFilter.None);
            _device.StretchRectangle(_imageRight, sourRect, _imageBuf, destRect, TextureFilter.Linear);
            GraphicsStream gStream = _imageBuf.LockRectangle(LockFlags.None);
            /*
            byte[] data = new byte[] {0x4e, 0x56, 0x33, 0x44,   //NVSTEREO_IMAGE_SIGNATURE         = 0x4433564e;
0x00, 0x0F, 0x00, 0x00,   //Screen width * 2 = 1920*2 = 3840 = 0x00000F00;
0x38, 0x04, 0x00, 0x00,   //Screen height = 1080             = 0x00000438;
0x20, 0x00, 0x00, 0x00,   //dwBPP = 32                       = 0x00000020;
0x02, 0x00, 0x00, 0x00};  //dwFlags = SIH_SCALE_TO_FIT       = 0x00000002;
            */
            
            byte[] data = new byte[] {0x4e, 0x56, 0x33, 0x44,   //NVSTEREO_IMAGE_SIGNATURE         = 0x4433564e;
0x00, 0x08, 0x00, 0x00,   //Screen width * 2 = 1024*2 = 2048 = 0x00000800;
0x00, 0x03, 0x00, 0x00,   //Screen height = 768             = 0x00000300;
0x20, 0x00, 0x00, 0x00,   //dwBPP = 32                       = 0x00000020;
0x00, 0x00, 0x00, 0x00};  //dwFlags = SIH_SCALE_TO_FIT       = 0x00000002;
             
            /*
            byte[] data = new byte[] {0x4e, 0x56, 0x33, 0x44,   //NVSTEREO_IMAGE_SIGNATURE         = 0x4433564e;
0x00, 0x0A, 0x00, 0x00,   //Screen width * 2 = 1280*2 = 2560 = 0x00000AAC;
0xD0, 0x02, 0x00, 0x00,   //Screen height = 720             = 0x00000300;
0x20, 0x00, 0x00, 0x00,   //dwBPP = 32                       = 0x00000020;
0x02, 0x00, 0x00, 0x00};  //dwFlags = SIH_SCALE_TO_FIT       = 0x00000002;
            */
            
            gStream.Seek(_size.Width * 2 * _size.Height * 4, System.IO.SeekOrigin.Begin);   //last row
            gStream.Write(data, 0, data.Length);

            gStream.Close();

            _imageBuf.UnlockRectangle();

            //*************************************************************************************

            destRect.X = 0;
            _device.StretchRectangle(_attLeft, sourRect, _attBuf, destRect, TextureFilter.None);
            destRect.X = _size.Width;
            _device.StretchRectangle(_attRight, sourRect, _attBuf, destRect, TextureFilter.None);
            gStream = _attBuf.LockRectangle(LockFlags.None);

            gStream.Seek(_size.Width * 2 * _size.Height * 4, System.IO.SeekOrigin.Begin);   //last row
            gStream.Write(data, 0, data.Length);

            gStream.Close();

            _attBuf.UnlockRectangle();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            _device.BeginScene();

            // Get the Backbuffer then Stretch the Surface on it.
            _backBuf = _device.GetBackBuffer(0, 0, BackBufferType.Mono);
            if (count <= dt/2-1)
            {
                _device.StretchRectangle(_imageBuf, new Rectangle(0, 0, _size.Width * 2, _size.Height + 1), _backBuf, new Rectangle(0, 0, _size.Width, _size.Height), TextureFilter.None);
            }
            else 
            {
                _device.StretchRectangle(_attBuf, new Rectangle(0, 0, _size.Width * 2, _size.Height + 1), _backBuf, new Rectangle(0, 0, _size.Width, _size.Height), TextureFilter.None); 
            }
            count++;
            count = count % dt;

            _backBuf.ReleaseGraphics();

            _device.EndScene();

            _device.Present();

            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
