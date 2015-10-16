using CelikNETInterop;
using CelikNETInterop.Data;
using System.Runtime.InteropServices;

namespace CelikNET
{
	public class Interop
	{
		public static readonly string ACTION_FAILED = "Akcija nije uspela.";

		public static readonly string STARTUP = "EidStartup";
		public static readonly string CLEANUP = "EidCleanup";
		public static readonly string BEGIN_READ = "EidBeginRead";
		public static readonly string END_READ = "EidEndRead";
		public static readonly string READ_DOCUMENT_DATA = "EidReadDocumentData";
		public static readonly string READ_VARIABLE_DATA = "EidReadDocumentData";
		public static readonly string READ_FIXED_DATA = "EidFixedDocumentData";

		#region CelikApi

		[DllImport("CelikApi.dll", EntryPoint = "EidStartup")]
		public static extern int EidStartup(int nApiVersion);

		[DllImport("CelikApi.dll", EntryPoint = "EidCleanup")]
		public static extern int EidCleanup();

		[DllImport("CelikApi.dll", EntryPoint = "EidBeginRead")]
		public static extern int EidBeginRead(string szReader, ref int pnCardVersion);

		[DllImport("CelikApi.dll", EntryPoint = "EidReadDocumentData")]
		public static extern int EidReadDocumentData(ref PEID_DOCUMENT_DATA d);

		[DllImport("CelikApi.dll", EntryPoint = "EidReadFixedPersonalData")]
		public static extern int EidReadFixedPersonalData(ref PEID_FIXED_PERSONAL_DATA d);

		[DllImport("CelikApi.dll", EntryPoint = "EidReadVariablePersonalData")]
		public static extern int EidReadVariablePersonalData(ref PEID_VARIABLE_PERSONAL_DATA d);

		[DllImport("CelikApi.dll", EntryPoint = "EidEndRead")]
		public static extern int EidEndRead();

		#endregion

		#region Wrapper metode

		public static void Startup(int apiVersion = 2)
		{
			if (apiVersion != 2)
				throw new InvalidApiVersionException("Trenutno podrzana verzija CelikApi je 2. (Zvanicna dokumentacija)");

			Validate(EidStartup(apiVersion), ACTION_FAILED, STARTUP);
		}

		public static CardData Read()
		{
			PEID_DOCUMENT_DATA d = new PEID_DOCUMENT_DATA();
			PEID_FIXED_PERSONAL_DATA f = new PEID_FIXED_PERSONAL_DATA();
			PEID_VARIABLE_PERSONAL_DATA v = new PEID_VARIABLE_PERSONAL_DATA();

			int c = 0;

			Validate(EidBeginRead(string.Empty, ref c), ACTION_FAILED, BEGIN_READ);

			Validate(EidReadDocumentData(ref d), ACTION_FAILED, READ_DOCUMENT_DATA);
			Validate(Interop.EidReadFixedPersonalData(ref f), ACTION_FAILED, READ_FIXED_DATA);
			Validate(Interop.EidReadVariablePersonalData(ref v), ACTION_FAILED, READ_VARIABLE_DATA);

			Validate(EidEndRead(), ACTION_FAILED, END_READ);

			return new CardData { DocumentData = d, FixedData = f, VariableData = v };
		}

		public static void Cleanup()
		{
			Validate(EidCleanup(), ACTION_FAILED, CLEANUP);
		}

		private static void Validate(int result, string msg, string action)
		{
			if (result != 0)
				throw new ReadingFailedException(msg) { FailedAction = action, Result = result };
		}

		#endregion
	}
}