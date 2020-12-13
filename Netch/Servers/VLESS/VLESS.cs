using System.Collections.Generic;
using Netch.Models;
using Netch.Servers.VMess;

namespace Netch.Servers.VLESS
{
    public class VLESS : VMess.VMess
    {
        public VLESS()
        {
            Type = "VLESS";
        }

        /// <summary>
        ///     加密方式
        /// </summary>
        public new string EncryptMethod { get; set; } = "none";

        /// <summary>
        ///		传输协议
        /// </summary>
        public new string TransferProtocol { get; set; } = VLESSGlobal.TransferProtocols[0];

        /// <summary>
        ///		伪装类型
        /// </summary>
        public new string FakeType { get; set; } = VLESSGlobal.FakeTypes[0];

        /// <summary>
        ///     
        /// </summary>
        public string Flow { get; set; }
    }

    public class VLESSGlobal
    {
        public static List<string> TransferProtocols => VMessGlobal.TransferProtocols;

        public static readonly List<string> FakeTypes = new List<string>
        {
            "none",
            "http"
        };

        public static readonly List<string> TLSSecure = new List<string>
        {
            "",
            "tls",
            "xtls"
        };
    }
}