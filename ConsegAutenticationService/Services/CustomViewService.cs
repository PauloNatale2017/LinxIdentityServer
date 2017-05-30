using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Validation;
using IdentityServer3.Core.ViewModels;
using Microsoft.Security.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LinxServerAuthentication.Services
{
    public class CustomViewService : IViewService
    {
        IClientStore clientStore;
 
        private readonly DefaultViewServiceOptions config;

        public CustomViewService(IClientStore clientStore)
        {
            this.clientStore = clientStore;
        }

        public virtual async Task<System.IO.Stream> Login(LoginViewModel model, SignInMessage message)
        {
            var client = await clientStore.FindClientByIdAsync(message.ClientId);
            var name = client != null ? client.ClientName : null;
          
            return await Render(model, "login", name);
        }
     

        public Task<Stream> Logout(LogoutViewModel model, SignOutMessage message)
        {
            return Render(model, "logout");
        }

        public Task<Stream> WelCome(Models.WelCome model, SignOutMessage message)
        {
            return Render(model, "WelCome");
        }

        public Task<Stream> LoggedOut(LoggedOutViewModel model, SignOutMessage message)
        {
            return Render(model, "loggedOut");
        }

        public Task<Stream> Consent(ConsentViewModel model, ValidatedAuthorizeRequest authorizeRequest)
        {
            return Render(model, "consent");
        }

        public Task<Stream> ClientPermissions(ClientPermissionsViewModel model)
        {
            return Render(model, "permissions");
        }

        public virtual Task<System.IO.Stream> Error(ErrorViewModel model)
        {
            return Render(model, "error");
        }

        protected virtual Task<System.IO.Stream> Render(CommonViewModel model, string page, string clientName = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            string html = LoadHtml(page);

            //"../../../plugins/bootstrapTable/css/bootstrap-table.css"

            switch (page)
            {

                case "login":
                    html = Replace(html, new
                    {
                        siteName = Microsoft.Security.Application.Encoder.HtmlEncode(model.SiteName),
                        model = Microsoft.Security.Application.Encoder.HtmlEncode(json),
                        clientName = clientName,
                        style1 = "<link href='../../../packagsConseg/css/bootstrap.min.css' rel='stylesheet'/>",
                        style2 = "<link href='../../../packagsConseg/css/estilo.css' rel='stylesheet'/>",
                        style3 = "<link href='../../../plugins/bootstrapswitch/dist/css/bootstrap3/bootstrap-switch.css' rel='stylesheet'/>",
                        style4 = "<link href='/Services/Content/app/ui-grid.css' rel='stylesheet'/>",

                        script1 = "<script src='../../../plugins/bootstrapswitch/docs/js/highlight.js'></script>",
                        script2 = "<script src='../../../plugins/bootstrapswitch/dist/js/bootstrap-switch.js'></script>",
                        script3 = "<script src='../../../plugins/bootstrapswitch/docs/js/main.js'></script>",
                        script4 = "<script src='http://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js'></script>",
                        script5 = "<script src='/Services/Content/app/ui-grid.js'></script>",



                    });
                    break;

                default:
                    html = Replace(html, new
                    {
                        // FaltaPacote
                        siteName = Microsoft.Security.Application.Encoder.HtmlEncode(model.SiteName),
                        model = Microsoft.Security.Application.Encoder.HtmlEncode(json),
                        clientName = clientName,

                    });
                    break;
            }


            //
            //
            //

           

            return Task.FromResult(StringToStream(html));
        }
        private string BuildTags(
            string tagFormat,
            string basePath,
            IEnumerable<string> values)
        {
            if (values == null)
            {
                return String.Empty;
            }

            var enumerable = values as string[] ?? values.ToArray();
            if (!enumerable.Any())
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            foreach (var value in enumerable)
            {
                var path = value;
                if (path.StartsWith("~/"))
                {
                    path = basePath + path.Substring(1);
                }

                sb.AppendFormat(tagFormat, path);
                sb.AppendLine();
            }

            return sb.ToString();
        }



        private string LoadHtml(string name)
        {

            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Services\Content\app");
            file = Path.Combine(file, name + ".html");         
            return File.ReadAllText(file);
        }

        string Replace(string value, IDictionary<string, object> values)
        {
            foreach (var key in values.Keys)
            {
                var val = values[key];
                val = val ?? String.Empty;
                if (val != null)
                {
                    value = value.Replace("{" + key + "}", val.ToString());
                }
            }
            return value;
        }

        string Replace(string value, object values)
        {
            return Replace(value, Map(values));
        }

        IDictionary<string, object> Map(object values)
        {
            var dictionary = values as IDictionary<string, object>;

            if (dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    dictionary.Add(descriptor.Name, descriptor.GetValue(values));
                }
            }

            return dictionary;
        }

        Stream StringToStream(string s)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(s);
            sw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}