using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Grimoire.Tools
{
	public class KeyboardHook : IDisposable
	{
		public static KeyboardHook Instance { get; } = new KeyboardHook();

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern int SetWindowsHookEx(int idHook, KeyboardHook.CallbackDelegate lpfn, int hInstance, int threadId);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern bool UnhookWindowsHookEx(int idHook);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern int CallNextHookEx(int idHook, int nCode, int wParam, int lParam);

		public event Action<Keys> KeyDown;

		private KeyboardHook()
		{
			this.hookCallback = new KeyboardHook.CallbackDelegate(this.HookProc);
			this._hookId = KeyboardHook.SetWindowsHookEx(13, this.hookCallback, 0, 0);
			this.TargetedKeys = new List<Keys>();
		}

		private int HookProc(int code, int wParam, int lParam)
		{
			if (code < 0)
			{
				return KeyboardHook.CallNextHookEx(this._hookId, code, wParam, lParam);
			}
			if (wParam == 256 || wParam == 260)
			{
				Keys keys = (Keys)Marshal.ReadInt32((IntPtr)lParam);
				if (this.TargetedKeys.Contains(keys))
				{
					Action<Keys> keyDown = this.KeyDown;
					if (keyDown != null)
					{
						keyDown(keys);
					}
				}
			}
			return KeyboardHook.CallNextHookEx(this._hookId, code, wParam, lParam);
		}

		public void Dispose()
		{
			KeyboardHook.UnhookWindowsHookEx(this._hookId);
		}

		private const int WH_KEYBOARD_LL = 13;

		private const int WM_KEYDOWN = 256;

		private const int WM_SYSKEYDOWN = 260;

		private readonly KeyboardHook.CallbackDelegate hookCallback;

		public readonly List<Keys> TargetedKeys;

		private readonly int _hookId;

		public delegate int CallbackDelegate(int code, int wParam, int lParam);
	}
}
