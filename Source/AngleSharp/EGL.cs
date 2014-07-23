using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AngleSharp
{
	public static class EGL
	{
		const string Library = "libegl.dll";

		public const int ALPHA_SIZE = 0x3021;
		public const int BAD_ACCESS = 0x3002;
		public const int BAD_ALLOC = 0x3003;
		public const int BAD_ATTRIBUTE = 0x3004;
		public const int BAD_CONFIG = 0x3005;
		public const int BAD_CONTEXT = 0x3006;
		public const int BAD_CURRENT_SURFACE = 0x3007;
		public const int BAD_DISPLAY = 0x3008;
		public const int BAD_MATCH = 0x3009;
		public const int BAD_NATIVE_PIXMAP = 0x300A;
		public const int BAD_NATIVE_WINDOW = 0x300B;
		public const int BAD_PARAMETER = 0x300C;
		public const int BAD_SURFACE = 0x300D;
		public const int BLUE_SIZE = 0x3022;
		public const int BUFFER_SIZE = 0x3020;
		public const int CONFIG_CAVEAT = 0x3027;
		public const int CONFIG_ID = 0x3028;
		public const int CORE_NATIVE_ENGINE = 0x305B;
		public const int DEPTH_SIZE = 0x3025;
		public const int DONT_CARE = -1;
		public const int DRAW = 0x3059;
		public const int EXTENSIONS = 0x3055;
		public const int FALSE = 0;
		public const int GREEN_SIZE = 0x3023;
		public const int HEIGHT = 0x3056;
		public const int LARGEST_PBUFFER = 0x3058;
		public const int LEVEL = 0x3029;
		public const int MAX_PBUFFER_HEIGHT = 0x302A;
		public const int MAX_PBUFFER_PIXELS = 0x302B;
		public const int MAX_PBUFFER_WIDTH = 0x302C;
		public const int NATIVE_RENDERABLE = 0x302D;
		public const int NATIVE_VISUAL_ID = 0x302E;
		public const int NATIVE_VISUAL_TYPE = 0x302F;
		public const int NONE = 0x3038;
		public const int NON_CONFORMANT_CONFIG = 0x3051;
		public const int NOT_INITIALIZED = 0x3001;
		public const int PBUFFER_BIT = 0x0001;
		public const int PIXMAP_BIT = 0x0002;
		public const int READ = 0x305A;
		public const int RED_SIZE = 0x3024;
		public const int SAMPLES = 0x3031;
		public const int SAMPLE_BUFFERS = 0x3032;
		public const int SLOW_CONFIG = 0x3050;
		public const int STENCIL_SIZE = 0x3026;
		public const int SUCCESS = 0x3000;
		public const int SURFACE_TYPE = 0x3033;
		public const int TRANSPARENT_BLUE_VALUE = 0x3035;
		public const int TRANSPARENT_GREEN_VALUE = 0x3036;
		public const int TRANSPARENT_RED_VALUE = 0x3037;
		public const int TRANSPARENT_RGB = 0x3052;
		public const int TRANSPARENT_TYPE = 0x3034;
		public const int TRUE = 1;
		public const int VENDOR = 0x3053;
		public const int VERSION = 0x3054;
		public const int WIDTH = 0x3057;
		public const int WINDOW_BIT = 0x0004;

		public const int DEFAULT_DISPLAY = 0;

		public const int CONTEXT_CLIENT_VERSION = 0x3098;

		public const int OPENGL_ES_API = 0x30A0;

		public const int PLATFORM_ANGLE_TYPE_ANGLE = 0x3202;
		public const int PLATFORM_ANGLE_TYPE_D3D9_ANGLE = 0x3204;
		public const int PLATFORM_ANGLE_TYPE_D3D11_ANGLE = 0x3205;

		[DllImport(Library, EntryPoint = "eglBindAPI")]
		public static extern bool BindAPI(int api);

		[DllImport(Library, EntryPoint = "eglChooseConfig")]
		public static extern bool ChooseConfig(IntPtr dpy, int[] attrib_list, out IntPtr configs, int config_size, out int num_config);

		[DllImport(Library, EntryPoint = "eglCreateContext")]
		public static extern IntPtr CreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, int[] attrib_list);

		[DllImport(Library, EntryPoint = "eglCreateWindowSurface")]
		public static extern IntPtr CreateWindowSurface(IntPtr dpy, IntPtr config, IntPtr win, int[] attrib_list);

		[DllImport(Library, EntryPoint = "eglGetDisplay")]
		public static extern IntPtr GetDisplay(int displayId);

		[DllImport(Library, EntryPoint = "eglGetError")]
		public static extern int GetError();	 

		[DllImport(Library, EntryPoint = "eglGetProcAddress")]
		public static extern IntPtr GetProcAddress(string procName);

		[DllImport(Library, EntryPoint = "eglInitialize")]
		public static extern bool Initialize(IntPtr dpy, out int major, out int minor);

		[DllImport(Library, EntryPoint = "eglMakeCurrent")]
		public static extern bool MakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

		[DllImport(Library, EntryPoint = "eglSwapBuffers")]
		public static extern bool SwapBuffers(IntPtr dpy, IntPtr surface);

		[DllImport(Library, EntryPoint = "eglSwapInterval")]
		public static extern bool SwapInterval(IntPtr dpy, int interval);
	}
}
