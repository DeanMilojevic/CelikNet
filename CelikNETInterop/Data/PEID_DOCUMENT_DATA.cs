using System.Runtime.InteropServices;

namespace CelikNETInterop.Data
{
	public struct PEID_DOCUMENT_DATA
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string docRegNo;

		public int docRegNoSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
		public string documentType;

		public int documentTypeSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
		public string issuingDate;

		public int issuingDateSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
		public string expiryDate;

		public int expiryDateSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
		public string issuingAuthority;

		public int issuingAuthoritySize;
	}
}
