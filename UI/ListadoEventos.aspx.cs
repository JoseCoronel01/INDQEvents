using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Code;
using str = ModeloClases;
using Newtonsoft.Json;

namespace UI
{
    public partial class ListadoEventos : BaseCode
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(this.RutaApi);

            string json = await client.GetStringAsync(client.BaseAddress + "api/events");

            List<str.ListadoEventos> eventos = JsonConvert.DeserializeObject<List<str.ListadoEventos>>(json);

            List<str.Event> events = new List<str.Event>();

            foreach (var item in eventos)
            {
                events.Add(item.items[0]);
            }

            gvEventos.DataSource = events;

            gvEventos.DataBind();
        }
    }
}