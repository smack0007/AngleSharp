using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AngleSharp
{
	public static class GLES
	{
		const string Library = "libglesv2.dll";

		public const uint ColorBufferBit = 0x00004000;
		public const uint DepthBufferBit = 0x00000100;

		public const uint VENDOR = 0x1F00;
		public const uint RENDERER = 0x1F01;
		public const uint VERSION = 0x1F02;
		public const uint EXTENSIONS = 0x1F03;

		[DllImport(Library, EntryPoint = "glClear")]
		public static extern void Clear(uint mask);

		[DllImport(Library, EntryPoint = "glClearColor")]
		public static extern void ClearColor(float red, float green, float blue, float alpha);

		[DllImport(Library, EntryPoint = "glGetString")]
		private static extern IntPtr _GetString(uint name);

		public static string GetString(uint name)
		{
			return Marshal.PtrToStringAnsi(_GetString(name));
		}
	}
}
