using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LinxServerAuthentication.Confg
{
    static class CertificateLoad
    {
        public static X509Certificate2 Get()
        {
            //idsrv3test
            //server.crt
            return new X509Certificate2(
                string.Format(@"{0}\Certs\server.pfx", AppDomain.CurrentDomain.BaseDirectory), "82929262");

        }
    }
}