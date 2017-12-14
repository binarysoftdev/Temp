	internal static class Utilities
	{
		private static readonly Version _osVersion = Environment.OSVersion.Version;

		internal static bool IsOSVistaOrNewer
		{
			get
			{
				return Utilities._osVersion >= new Version(6, 0);
			}
		}

		internal static bool IsOSWindows7OrNewer
		{
			get
			{
				return Utilities._osVersion >= new Version(6, 1);
			}
		}

		internal static bool IsOSWindows8OrNewer
		{
			get
			{
				return Utilities._osVersion >= new Version(6, 2);
			}
		}

		internal static bool IsCompositionEnabled
		{
			[SecurityCritical]
			[SecurityTreatAsSafe]
			get
			{
				if (!Utilities.IsOSVistaOrNewer)
				{
					return false;
				}
				int num = 0;
				UnsafeNativeMethods.HRESULT.Check(UnsafeNativeMethods.DwmIsCompositionEnabled(out num));
				return num != 0;
			}
		}

		internal static void SafeDispose<T>(ref T disposable) where T : IDisposable
		{
			IDisposable disposable2 = disposable;
			disposable = default(T);
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}

		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		internal static void SafeRelease<T>(ref T comObject) where T : class
		{
			T t = comObject;
			comObject = default(T);
			if (t != null)
			{
				Marshal.ReleaseComObject(t);
			}
		}
	}