using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Configuration;
using UI.Code;
using ModeloClases;

namespace UI
{
    public partial class Registro : BaseCode
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtContrasena.Text != "" && 
                txtConfirmar.Text != "" && txtCorreo.Text != "" && 
                txtNombre.Text != "")
            {
                if (txtContrasena.Text == txtConfirmar.Text)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(this.RutaApi);
                    User user = new User();
                    user.email = txtCorreo.Text;
                    user.firstName = txtNombre.Text.ToUpper();
                    user.lastName = txtApellido.Text.ToUpper();
                    user.password = txtConfirmar.Text;
                    if (rbMale.Checked)
                        user.gender = ModeloClases.User.eGender.male;
                    else if (rbFem.Checked)
                        user.gender = ModeloClases.User.eGender.female;
                    HttpResponseMessage message = await client.PostAsJsonAsync<User>(client.BaseAddress + 
                        "api/users", user);
                    if (message.IsSuccessStatusCode)
                    {
                        string msj = await message.Content.ReadAsStringAsync();

                        txtApellido.Text = "";
                        txtContrasena.Text = "";
                        txtConfirmar.Text = "";
                        txtCorreo.Text = "";
                        txtNombre.Text = "";

                        ScriptManager.RegisterStartupScript(this, GetType(), "Registro",
                            "alert('Usuario registrado con id: " + msj + "');", true);
                    }
                }
            }
        }
    }
}