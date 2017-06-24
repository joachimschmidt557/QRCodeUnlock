using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeUnlock
{
    /// <summary>
    /// This class provides universal functions to create a hex string from data 
    /// </summary>
    public class Hex
    {
        /* Code converted from  ViruShield 2 */
        
        /// <summary>
        /// Gets a hex signature from a byte array
        /// </summary>
        /// <param name="byteArray">the byte array</param>
        /// <returns>the hex signature</returns>
        /// <remarks></remarks>
        public static string ByteArrayToHex(byte[] byteArray)
        {

            StringBuilder strTemp = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                strTemp.Append(string.Format("{0:X2}", b));
            }
            return strTemp.ToString();

        }
    }
}
