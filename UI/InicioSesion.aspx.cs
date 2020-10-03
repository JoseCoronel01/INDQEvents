using str = ModeloClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Code;
using Newtonsoft.Json;

namespace UI
{
    public partial class InicioSesion : BaseCode
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "" && txtContra.Text != "")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.RutaApi);
                str.InicioSesion inicioSesion = new str.InicioSesion();
                inicioSesion.email = txtCorreo.Text;
                inicioSesion.password = txtContra.Text;
                HttpResponseMessage message = await client.PostAsJsonAsync(client.BaseAddress + 
                    "api/users/login", inicioSesion);
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    str.InicioSesionRespuesta respuesta = JsonConvert.
                        DeserializeObject<str.InicioSesionRespuesta>(json);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Registro",
                        "alert('Inicio de sesión correcto: " + respuesta.firstName + " " + respuesta.lastName + "');", true);
                    this.Page.Response.Redirect("ListadoEventos.aspx");
                }
                else
                {
                    string msj = await message.Content.ReadAsStringAsync();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Registro",
                        "alert('" + msj + "');", true);
                }
            }
        }
    }
}