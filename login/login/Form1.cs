/*
 * Created by SharpDevelop.
 * User: chedli
 * Date: 20/05/2019
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class ouvragelist : Form
	{
		public ouvragelist()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
	
		
		void OuvragelistLoad(object sender, EventArgs e)
		{
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
string req="select * from Ouvrage ";
OleDbCommand cmd=new OleDbCommand(req,cnn);
//ouverture de la connexion

OleDbDataAdapter DA = new OleDbDataAdapter();
 cnn.Open();
DA.SelectCommand = cmd ;
DataSet DS = new DataSet();
DA.Fill(DS,"ouvrage");
comboBox1.DataSource=DS.Tables["ouvrage"];
comboBox1.DisplayMember="inventaire";
textBox1.Text=DS.Tables["ouvrage"].Rows[comboBox1.SelectedIndex]["titre"].ToString();
textBox2.Text=DS.Tables["ouvrage"].Rows[comboBox1.SelectedIndex]["Année_d’édition"].ToString();

		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
string req="select * from Ouvrage ";
OleDbCommand cmd=new OleDbCommand(req,cnn);
//ouverture de la connexion

OleDbDataAdapter DA = new OleDbDataAdapter();
 cnn.Open();
DA.SelectCommand = cmd ;
DataSet DS = new DataSet();
DA.Fill(DS,"ouvragelist");
int index = comboBox1.SelectedIndex ;
textBox1.Text=DS.Tables["ouvragelist"].Rows[index]["titre"].ToString();
textBox2.Text=DS.Tables["ouvragelist"].Rows[index]["Année_d’édition"].ToString();

		}
	}
}