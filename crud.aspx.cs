using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();

        }
    }

    SqlConnection con = new SqlConnection("Data Source=LAPTOP-181KU5H3\\SQLEXPRESS;Initial Catalog=program;Integrated Security=True");
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comm=new SqlCommand( "Insert into product values('"+int.Parse(TextBox1.Text)+"' ,'"+TextBox2.Text+"','"+int.Parse(TextBox3.Text)+"','"+TextBox4.Text+"')",con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this,this.GetType(),"script","alert('Successfully Inserted');",true);
        load();
    }
    void load()
    {
        SqlCommand comm = new SqlCommand("select * from product", con);
        SqlDataAdapter a = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        a.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comm = new SqlCommand("update product set ProductName ='" + TextBox2.Text + "', CategoryID ='" + int.Parse(TextBox3.Text) + "', CategoryName ='" + TextBox4.Text + "' where ProductID = '"+int.Parse(TextBox1.Text) +"'", con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
        load();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comm = new SqlCommand("delete from product where ProductID = '" + int.Parse(TextBox1.Text) + "'", con);
        comm.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
        load();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand("select * from product where ProductID = '" + int.Parse(TextBox1.Text) + "'", con);
        SqlDataAdapter a = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        a.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}