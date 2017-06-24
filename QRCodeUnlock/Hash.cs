using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QRCodeUnlock
{
    /// <summary>
    /// This class provides universal functions to create hashes from data
    /// </summary>
    public class Hash
    {

        /* Code converted from ViruShield 2 */

        /// <summary>
        /// Gets the MD5 Hash of a byte array
        /// </summary>
        /// <param name="bytearray">The byte array</param>
        /// <returns>The hash</returns>
        /// <remarks></remarks>
        public static string GetMD5(byte[] bytearray)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(bytearray);
                byte[] hash = md5.Hash;

                return Hex.ByteArrayToHex(hash);


            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        //=======================================================
        //Service provided by Telerik (www.telerik.com)
        //Conversion powered by NRefactory.
        //Twitter: @telerik
        //Facebook: facebook.com/telerik
        //=======================================================

    }
}
