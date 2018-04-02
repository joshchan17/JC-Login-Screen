﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Projects_Project : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ProjectId, ProjectName from Project";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

    }
    protected void register(string b)
    {
        //encrypt user/pass and create new connection
        SqlConnection attach = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        attach.Open();
        SqlCommand cmd = attach.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO [Project] ([ProjectName])VALUES ('" + b + "')";

        cmd.ExecuteNonQuery();

        attach.Close();
    }

    
}