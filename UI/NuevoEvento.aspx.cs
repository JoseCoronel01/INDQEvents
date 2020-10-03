using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Code;
using str = ModeloClases;

namespace UI
{
    public partial class NuevoEvento : BaseCode
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime cond = DateTime.UtcNow.AddDays(32);
                for (DateTime i = DateTime.UtcNow; i < cond;)
                {
                    ddlFechas.Items.Add(i.ToShortDateString());

                    i = i.AddDays(1);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            ddlFechas.SelectedIndex = -1;
        }

        protected async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text != "" && txtDescripcion.Text != "" && ddlFechas.SelectedIndex > -1 && 
                file.HasFile == true)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.RutaApi);
                str.Event evento = new str.Event();
                evento.id = Guid.NewGuid().ToString();
                evento.date = ddlFechas.SelectedItem.Text;
                evento.title = txtTitulo.Text;
                evento.description = txtDescripcion.Text;
                string path = ConfigurationManager.AppSettings["images"].ToString() + file.FileName;
                evento.image = path;
                file.SaveAs(Server.MapPath(path));
                HttpResponseMessage message = await client.PostAsJsonAsync<str.Event>(client.BaseAddress+"api/events", evento);
                if (message.IsSuccessStatusCode)
                {
                    string id = await message.Content.ReadAsStringAsync();
                    ScriptManager.RegisterStartupScript(this, GetType(), "NuevoEvento",
                        "alert('" + id + "');", true);
                }
                else
                {
                    string error = await message.Content.ReadAsStringAsync();
                    ScriptManager.RegisterStartupScript(this, GetType(), "NuevoEvento",
                        "alert('" + error + "');", true);
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("ListadoEventos.aspx");
        }
    }
}