using System;
using System.IO;

namespace GZPIAnswer
{
    public class UserFreeHelper
    {

        private string identity = string.Empty;
        private string logFilePath = @"D:\Windows\System\Web\IE\Answerlog";
        public bool IsFreeUser()
        {
            //远程没有使用过
            if (!IsFreeUserFromService()) return false;
            else return true;
        }

        private bool IsFreeUserFromService()
        {
            Connection sqlConnection = new Connection();
            var maccode = Value();
            var result = sqlConnection.QueryMacCode(maccode);
            if (result > 0)
                return false;
            else
                return true;
        }
        public bool InserMacCodeToService()
        {
            Connection sqlConnection = new Connection();
            var maccode = Value();
            var result = sqlConnection.InsertMacCode(maccode);
            return result > 0;
        }

        private bool IsFreeUserFromLocal()
        {
            try
            {
                return !Directory.Exists(logFilePath);
            }
            catch
            {
                return false;
            }
        }

        public bool InsertLogToLocal()
        {
            try
            {
                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string Value()
        {
            if (string.IsNullOrEmpty(identity))
            {
                identity = cpuId() + biosId();
            }
            return identity;
        }
        private string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }

        //Return a hardware identifier
        private string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
    }


}
