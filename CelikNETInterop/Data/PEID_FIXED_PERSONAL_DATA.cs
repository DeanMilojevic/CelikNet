using System.Runtime.InteropServices;

namespace CelikNETInterop.Data
{
	public struct PEID_FIXED_PERSONAL_DATA
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
		string personalNumber;

		int personalNumberSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string surname;

		int surnameSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string givenName;

		int givenNameSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string parentGivenName;

		int parentGivenNameSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
		string sex;

		int sexSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string placeOfBirth;

		int placeOfBirthSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string stateOfBirth;

		int stateOfBirthSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string dateOfBirth;

		int dateOfBirthSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		string communityOfBirth;

		int communityOfBirthSize;
	}
}
