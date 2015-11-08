using CelikNETInterop.Data;
using System.Runtime.InteropServices;

namespace CelikNETInterop
{
	public class CelikApiWrapper
	{
		private const string DLL = "CelikApi.dll";

		#region API methods

		[DllImport(DLL, EntryPoint = StaticData.STARTUP)]
		public static extern int EidStartup(int nApiVersion);

		[DllImport(DLL, EntryPoint = StaticData.CLEANUP)]
		public static extern int EidCleanup();

		[DllImport(DLL, EntryPoint = StaticData.BEGIN_READ)]
		public static extern int EidBeginRead(string szReader, ref int pnCardVersion);

		[DllImport(DLL, EntryPoint = StaticData.READ_DOCUMENT_DATA)]
		public static extern int EidReadDocumentData(ref PEID_DOCUMENT_DATA d);

		[DllImport(DLL, EntryPoint = StaticData.READ_FIXED_DATA)]
		public static extern int EidReadFixedPersonalData(ref PEID_FIXED_PERSONAL_DATA d);

		[DllImport(DLL, EntryPoint = StaticData.READ_VARIABLE_DATA)]
		public static extern int EidReadVariablePersonalData(ref PEID_VARIABLE_PERSONAL_DATA d);

		[DllImport(DLL, EntryPoint = StaticData.END_READ)]
		public static extern int EidEndRead();

		#endregion
	}
}
