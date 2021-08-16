﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Direct.Shared;
using Direct.Interface;
using System.IO;
using log4net;

namespace Direct.Base64.Library
{
    /// <summary>
    /// Known Limitation, do not display base64 as value in the monitor.
    /// It is ok to use a local variable, but the monitor will crash with large texts.
    /// </summary>
    [DirectSealed]
    [DirectDom("Base64")]
    [ParameterType(false)]
    public class Base64
    {
        private static readonly ILog logArchitect = LogManager.GetLogger(Loggers.LibraryObjects);

        [DirectDom("Convert Base64 to File")]
        [DirectDomMethod("Write {Base64} to {File Path}")]
        [MethodDescription("Take a Base64 encoded string and create a file from it")]
        public static bool Base64ToFile(string base64string, string filepath)
        {
            try
            {
                if (logArchitect.IsDebugEnabled) {
                    logArchitect.Debug("Direct.Base64.Library - Start Converting to file from base64: " + base64string);
                        }
                byte[] tempBytes = Convert.FromBase64String(base64string);
                System.IO.File.WriteAllBytes(filepath, tempBytes);
                    if (logArchitect.IsDebugEnabled) {
                        logArchitect.Debug("Direct.Base64.Library - Completed converting base64 to filepath: " + filepath);
                    }
                return true;
            } 
            catch (Exception e)
            {
                logArchitect.Error("Direct.Base64.Library - Convert Base64 to File Exception", e);
                return false;
            }
        }

        [DirectDom("Convert File to Base64")]
        [DirectDomMethod("Read Base64 from {File Path}")]
        [MethodDescription("Read a file and return base64 string")]
        public static string FileToBase64(string filepath)
        {
            try
            {
                if (logArchitect.IsDebugEnabled) {
                    logArchitect.Debug("Direct.Base64.Library - Start Converting to base64 from file: " + filepath);
                }
                byte[] AsBytes = File.ReadAllBytes(filepath);
                String AsBase64String = Convert.ToBase64String(AsBytes);
                if (logArchitect.IsDebugEnabled) {
                    logArchitect.Debug("Direct.Base64.Library - Completed converting filepath to base64: " + AsBase64String);
                }
                return AsBase64String;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.Base64.Library - Convert File to Base64 Exception", e);
                return null;
            }
        }

        [DirectDom("Encode Text to Base64")]
        [DirectDomMethod("Encode {Text} to Base64")]
        [MethodDescription("Creates an encoded base64 text from supplied text")]
        public static string EncodeStringToBase64(string stringToEncode)
        {
            try
            {
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Base64.Library - Start encoding to base64 from string: " + stringToEncode);
                }
                var stringToEncodeBytes = Encoding.UTF8.GetBytes(stringToEncode);
                string AsBase64String = Convert.ToBase64String(stringToEncodeBytes);
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Base64.Library - Completed encoding string to base64: " + AsBase64String);
                }
                return AsBase64String;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.Base64.Library - Encode String to Base64 Exception", e);
                return null;
            }
        }

        [DirectDom("Decode Base64 to Plain Text")]
        [DirectDomMethod("Decode {Base64} to Plain Text")]
        [MethodDescription("Decodes supplied Base64 to Plain Text")]
        public static string DecodeBase64toPlainText(string base64EncodedData)
        {
            try
            {
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Base64.Library - Start decoding base64 to plain text. Passed base64 string: " + base64EncodedData);
                }
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                string decodedPlainText = Encoding.UTF8.GetString(base64EncodedBytes);
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Base64.Library - Completed decoding base64 to plain text: " + decodedPlainText);
                }
                return decodedPlainText;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.Base64.Library - Decode base64 string to plain text exception", e);
                return null;
            }
        }

    }
}
