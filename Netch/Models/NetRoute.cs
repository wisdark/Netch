﻿using System;
using System.Net;
using Vanara.PInvoke;

namespace Netch.Models
{
    public struct NetRoute
    {
        public static NetRoute TemplateBuilder(string gateway, int interfaceIndex, int metric = 0)
        {
            return new()
            {
                Gateway = gateway,
                InterfaceIndex = interfaceIndex,
                Metric = metric
            };
        }

        public static (NetRoute, IPAddress address) GetBestRouteTemplate()
        {
            if (IpHlpApi.GetBestRoute(BitConverter.ToUInt32(IPAddress.Parse("114.114.114.114").GetAddressBytes(), 0), 0, out var route) != 0)
                throw new MessageException("GetBestRoute 搜索失败");

            var address = new IPAddress(route.dwForwardNextHop.S_addr);
            var gateway = new IPAddress(route.dwForwardNextHop.S_un_b);
            return (TemplateBuilder(gateway.ToString(), (int)route.dwForwardIfIndex), address);
        }

        public int InterfaceIndex;

        public string Gateway;

        public string Network;

        public byte Cidr;

        public int Metric;

        public NetRoute FillTemplate(string network, byte cidr, int? metric = null)
        {
            var o = (NetRoute)MemberwiseClone();
            o.Network = network;
            o.Cidr = cidr;
            if (metric != null)
                o.Metric = (int)metric;

            return o;
        }
    }
}