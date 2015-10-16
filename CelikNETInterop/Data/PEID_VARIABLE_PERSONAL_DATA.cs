using System.Runtime.InteropServices;

namespace CelikNETInterop.Data
{
	public struct PEID_VARIABLE_PERSONAL_DATA
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
		string state;

		int stateSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string community;

		int communitySize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string place;

		int placeSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string street;

		int streetSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
		string houseNumber;

		int houseNumberSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
		string houseLetter;

		int houseLetterSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
		string entrance;

		int entranceSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
		string floor;

		int floorSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
		string apartmentNumber;

		int apartmentNumberSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
		string addressDate;

		int addressDateSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
		string addressLabel;

		int addressLabelSize;
	}
}
