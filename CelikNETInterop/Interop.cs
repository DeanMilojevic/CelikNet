using CelikNETInterop;
using CelikNETInterop.Data;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace CelikNET
{
	public class Interop : IDisposable
	{

		bool disposed = false;
		SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

		#region Wrapper methods

		public void Startup(int apiVersion = 2)
		{
			if (apiVersion != 2)
				throw new InvalidApiVersionException("Trenutno podrzana verzija CelikApi je 2. (Zvanicna dokumentacija)");

			Validate(CelikApiWrapper.EidStartup(apiVersion), StaticData.ACTION_FAILED, StaticData.STARTUP);
		}

		public CardData Read()
		{
			PEID_DOCUMENT_DATA d = new PEID_DOCUMENT_DATA();
			PEID_FIXED_PERSONAL_DATA f = new PEID_FIXED_PERSONAL_DATA();
			PEID_VARIABLE_PERSONAL_DATA v = new PEID_VARIABLE_PERSONAL_DATA();

			int c = 0;

			Validate(CelikApiWrapper.EidBeginRead(string.Empty, ref c), StaticData.ACTION_FAILED, StaticData.BEGIN_READ);

			Validate(CelikApiWrapper.EidReadDocumentData(ref d), StaticData.ACTION_FAILED, StaticData.READ_DOCUMENT_DATA);
			Validate(CelikApiWrapper.EidReadFixedPersonalData(ref f), StaticData.ACTION_FAILED, StaticData.READ_FIXED_DATA);
			Validate(CelikApiWrapper.EidReadVariablePersonalData(ref v), StaticData.ACTION_FAILED, StaticData.READ_VARIABLE_DATA);

			Validate(CelikApiWrapper.EidEndRead(), StaticData.ACTION_FAILED, StaticData.END_READ);

			return new CardData { DocumentData = d, FixedData = f, VariableData = v };
		}

		public void Cleanup()
		{
			Validate(CelikApiWrapper.EidCleanup(), StaticData.ACTION_FAILED, StaticData.CLEANUP);
		}

		private void Validate(int result, string msg, string action)
		{
			if (result != 0)
				throw new ReadingFailedException(msg) { FailedAction = action, Result = result };
		}

		#endregion

		#region IDisposable pattern

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				handle.Dispose();
			}

			disposed = true;
		}

		#endregion
	}
}