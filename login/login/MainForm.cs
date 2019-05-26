/*
 * Created by SharpDevelop.
 * User: chedli
 * Date: 29/04/2019
 * Time: 11:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			            
//Création de la chaine de connexion
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
//ouverture de la connexion
try{
    cnn.Open();
    string req="select count(*) from utilisateur where login='"+textBox1.Text+"'";
OleDbCommand cmd=new OleDbCommand(req,cnn);
int nb = Convert.ToInt32(cmd.ExecuteScalar());
if (nb==0){
string req1="insert into utilisateur values('"+textBox1.Text+"','"+textBox2.Text+"')";
OleDbCommand cmd1=new OleDbCommand(req1,cnn);
cmd1.ExecuteNonQuery();
MessageBox.Show("ajout avec succès");
}else {
	MessageBox.Show("existe");
}


}
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            finally
            {
                cnn.Close();}

		}
		
		void Button2Click(object sender, EventArgs e)
		{
			string login , mdp ;
			login=textBox1.Text;
			mdp=textBox2.Text;
			string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
			try{
    cnn.Open();
string req="select count(*) from utilisateur where login='"+login+"' and mdp='"+mdp+"'";
OleDbCommand cmd=new OleDbCommand(req,cnn);
int nb = System.Convert.ToInt32(cmd.ExecuteScalar());

if (nb!=0){
	ouvrage F=new ouvrage();
	F.Show();
	this.Hide();
}else {
	MessageBox.Show("ne pas existe");
}
}
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            finally
            {
                cnn.Close();}
	}
	}
}
