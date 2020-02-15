
namespace LeetCode.P468
{
    using System.Linq;

    public class Solution
    {
        public string ValidIPAddress(string IP)
        {
            if(IP.Contains('.'))
            {
                return ValidIPAddressIPV4(IP) ? "IPv4" : "Neither";
            }
            else if(IP.Contains(':'))
            {
                return ValidIPAddressIPV6(IP) ? "IPv6" : "Neither";
            }
            else
            {
                return "Neither";
            }
        }

        private bool ValidIPAddressIPV4(string ip)
        {
            var split = ip.Split('.');
            if (split.Length != 4) return false;

            return split.All(p =>
            {
                if (p.Length > 3 || p.Length == 0) return false;
                if (!p.All(q => q >= '0' && q <= '9')) return false;

                var f = p[0];
                if (p.Length == 1) return true;
                else if (p.Length == 2) return f != '0';
                else
                {
                    if (f == '0') return false;
                    else if (f == '1') return true;
                    else if (f == '2') return p[1] < '5' || p[1] == '5' && p[2] < '6';
                    else return false;
                }
            });
        }

        private bool ValidIPAddressIPV6(string ip)
        {
            var split = ip.Split(':');
            if (split.Length != 8) return false;

            return split.All(p =>
            {
                if (p.Length > 4 || p.Length == 0) return false;
                if (!p.All(q => q >= '0' && q <= '9' || q >= 'a' && q <= 'f' || q >= 'A' && q <= 'F')) return false;

                return true;
            });
        }
    }
}
