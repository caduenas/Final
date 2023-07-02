﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMasterProyectoFinalF.pages
{
    public partial class registro_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void botonIngresar_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            conn.Open();
            string sql = @"Insert into asesorados(contrasena_asesorado, nombre_asesorado, apellido_asesorado, correo_asesorado, Meta_Lograr,  numero_asesorado, altura, peso, edad) values(@contras, @nom, @ape, @corre, @meta, @num,  @alt, @pes, @eda) ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@contras", password.Text);
            cmd.Parameters.AddWithValue("@nom", username.Text);
            cmd.Parameters.AddWithValue("@ape", apellido.Text);
            cmd.Parameters.AddWithValue("@corre", correo.Text);
            cmd.Parameters.AddWithValue("@meta", meta.Text);
            cmd.Parameters.AddWithValue("@num", numero.Text);
            cmd.Parameters.AddWithValue("@alt", altura.Text);
            cmd.Parameters.AddWithValue("@pes", peso.Text);
            cmd.Parameters.AddWithValue("@eda", edad.Text);
            bool proc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            conn.Close();
          
            Response.Redirect("asignacion_tablas.aspx");
        }
    }
}