using System;
using System.Runtime.InteropServices;

namespace SIMfnc
{
    /// <summary>
    /// Wrapper of SIM APIs.
    /// </summary>
    class SIM
    {
        public const int SIM_CAPSTYPE_ALL = 0x3F;       // All device cabability types
        public const int SIM_PBSTORAGE_SIM = 0x10;      // General SIM Storage
        public const int SIM_SMSSTORAGE_SIM = 0x2;      // SIM storage location
        public const uint SIM_PBINDEX_FIRSTAVAILABLE = 0xffffffff;
        public const int SIM_NUMPLAN_UNKNOWN = 0x0;
        public const int SIM_ADDRTYPE_UNKNOWN = 0x0;
        public const int SIMEntryCapacity = 1040; // SIMEntryCapacity = 1040 = sizeof(SIMPHONEBOOKENTRY)

        [StructLayout(LayoutKind.Sequential)]

        public struct SimLockingPwdLength
        {
            public uint dwFacility;           // The locking facility
            public uint dwPasswordLength;     // The minimum password length
        }
        
        internal struct SIMPHONEBOOKENTRY
        {
            public int cbSize;                                   // @field Size of the structure in bytes
            public int dwParams;                                 // @field Indicates valid parameter values
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string lpszAddress;                           // @field The actual phone number
            public int dwAddressType;                            // @field A SIM_ADDRTYPE_* constant
            public int dwNumPlan;                                // @field A SIM_NUMPLAN_* constant
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string lpszText;                              // @field Text assocaited with the entry
        }

        public struct SimCaps
        {
            public uint cbSize;
            public uint dwParams;
            public uint dwPBStorages;
            public uint dwMinPBIndex;
            public uint dwMaxPBIndex;
            public uint dwMaxPBEAddressLength;
            public uint dwMaxPBETextLength;
            public uint dwLockFacilities;
            public uint dwReadMsgStorages;
            public uint dwWriteMsgStorages;
            public uint dwNumLockingPwdLengths;
            public SimLockingPwdLength rgLockingPwdLengths0;
            public SimLockingPwdLength rgLockingPwdLengths1;
            public SimLockingPwdLength rgLockingPwdLengths2;
            public SimLockingPwdLength rgLockingPwdLengths3;
            public SimLockingPwdLength rgLockingPwdLengths4;
            public SimLockingPwdLength rgLockingPwdLengths5;
            public SimLockingPwdLength rgLockingPwdLengths6;
            public SimLockingPwdLength rgLockingPwdLengths7;
            public SimLockingPwdLength rgLockingPwdLengths8;
            public SimLockingPwdLength rgLockingPwdLengths9;
        }
        
        [DllImport("cellcore.dll")]
        public static extern int SimInitialize(uint dwFlags, int lpfnCallBack, uint dwParam, ref int lphSim);

        [DllImport("cellcore.dll")]
        public static extern int SimDeinitialize(int hSim);

        [DllImport("cellcore.dll")]
        public static extern int SimReadPhonebookEntry(int hSim, uint dwLocation, uint dwIndex, ref SIMPHONEBOOKENTRY lpPhonebookEntry);

        [DllImport("cellcore.dll")]
        public static extern int SimWritePhonebookEntry(int hSim, uint dwLocation, uint dwIndex, ref SIMPHONEBOOKENTRY lpPhonebookEntry);

        [DllImport("cellcore.dll")]
        public static extern int SimDeletePhonebookEntry(int hSim, uint dwLocation, uint dwIndex);

        [DllImport("cellcore.dll")]
        public static extern int SimGetPhonebookStatus(int hSim, uint dwLocation, ref uint lpdwUsed, ref uint lpdwTotal);

        [DllImport("cellcore.dll")]
        public static extern int SimGetDevCaps(int hSim, uint dwCapsType, ref SimCaps lpSimCaps);

        [DllImport("cellcore.dll")]
        public static extern int SimGetSmsStorageStatus(int hSim, uint dwStorage, ref uint lpdwUsed, ref uint lpdwTotal);
    }
}

