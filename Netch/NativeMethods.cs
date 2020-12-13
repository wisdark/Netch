﻿using System.Runtime.InteropServices;

namespace Netch
{
    public static class NativeMethods
    {
        /// <summary>
        ///		创建路由规则
        /// </summary>
        /// <param name="address">目标地址</param>
        /// <param name="cidr">CIDR</param>
        /// <param name="gateway">网关地址</param>
        /// <param name="index">适配器索引</param>
        /// <param name="metric">跃点数</param>
        /// <returns>是否成功</returns>
        [DllImport("NetchCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateRoute")]
        public static extern bool CreateRoute(string address, int cidr, string gateway, int index, int metric = 0);

        /// <summary>
        ///		删除路由规则
        /// </summary>
        /// <param name="address">目标地址</param>
        /// <param name="cidr">掩码地址</param>
        /// <param name="gateway">网关地址</param>
        /// <param name="index">适配器索引</param>
        /// <param name="metric">跃点数</param>
        /// <returns>是否成功</returns>
        [DllImport("NetchCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DeleteRoute")]
        public static extern bool DeleteRoute(string address, int cidr, string gateway, int index, int metric = 0);

        /// <summary>
        ///     设置直连
        /// </summary>
        /// <returns>是否成功</returns>
        [DllImport("sysproxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetDIRECT();

        /// <summary>
        ///     设置全局
        /// </summary>
        /// <param name="remote">地址</param>
        /// <param name="bypass">绕过</param>
        /// <returns>是否成功</returns>
        [DllImport("sysproxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetGlobal([MarshalAs(UnmanagedType.LPTStr)] string remote, [MarshalAs(UnmanagedType.LPTStr)] string bypass);

        /// <summary>
        ///     设置自动代理
        /// </summary>
        /// <param name="remote">URL</param>
        /// <returns>是否成功</returns>
        [DllImport("sysproxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetURL([MarshalAs(UnmanagedType.LPTStr)] string remote);

        [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint FlushDNSResolverCache();

        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern bool AttachConsole(int dwProcessId);
    }
}