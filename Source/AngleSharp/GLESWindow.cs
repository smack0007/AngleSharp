using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleSharpDemo
{
	public class GLESWindow : Form
	{
		IntPtr display;
		IntPtr surface;

		public GLESWindow()
		{
			this.Text = "GLES with ANGLE";
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			display = EGL.GetDisplay(EGL.DEFAULT_DISPLAY);
								
			int majorVersion, minorVersion;
			if (!EGL.Initialize(display, out majorVersion, out minorVersion))
			{
				int error = EGL.GetError();
				throw new Exception();
			}

			EGL.BindAPI(EGL.OPENGL_ES_API);
			if (EGL.GetError() != EGL.SUCCESS)
			{
				throw new Exception();
			}
			
			int[] configAttributes = new int[]
			{
				EGL.RED_SIZE, 8,
				EGL.GREEN_SIZE, 8,
				EGL.BLUE_SIZE, 8,
				EGL.ALPHA_SIZE, 8,
				EGL.DEPTH_SIZE, 24,
				EGL.STENCIL_SIZE, 8,
				EGL.SAMPLE_BUFFERS, EGL.DONT_CARE,
				EGL.NONE
			};

			IntPtr config;
			int configCount;
			if (!EGL.ChooseConfig(display, configAttributes, out config, 1, out configCount) || (configCount != 1))
			{
				throw new Exception();
			}

			int[] surfaceAttributes = new int[]
			{
				EGL.NONE, EGL.NONE,
			};

			surface = EGL.CreateWindowSurface(display, config, this.Handle, surfaceAttributes);
			if (surface == IntPtr.Zero)
			{
				EGL.GetError(); // Clear error and try again
				surface = EGL.CreateWindowSurface(display, config, IntPtr.Zero, null);
			}

			if (EGL.GetError() != EGL.SUCCESS)
			{
				throw new Exception();
			}

			int[] contextAttibutes = new int[]
			{
				EGL.CONTEXT_CLIENT_VERSION, 2,
				EGL.NONE
			};

			IntPtr context = EGL.CreateContext(display, config, IntPtr.Zero, contextAttibutes);
			if (EGL.GetError() != EGL.SUCCESS)
			{
				throw new Exception();
			}

			EGL.MakeCurrent(display, surface, surface, context);
			if (EGL.GetError() != EGL.SUCCESS)
			{
				throw new Exception();
			}

			//// Turn off vsync
			EGL.SwapInterval(display, 0);

			GLES.ClearColor(1.0f, 0, 0, 1.0f);

			string text = "RENDERER: " + GLES.GetString(GLES.RENDERER) + Environment.NewLine;
			text += "VENDOR: " + GLES.GetString(GLES.VENDOR) + Environment.NewLine;
			text += "VERSION: " + GLES.GetString(GLES.VERSION) + Environment.NewLine;
			text += "EXTENSIONS: " + Environment.NewLine + GLES.GetString(GLES.EXTENSIONS);

			MessageBox.Show(text);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			GLES.Clear(GLES.ColorBufferBit | GLES.DepthBufferBit);

			EGL.SwapBuffers(display, surface);
		}
	}
}
