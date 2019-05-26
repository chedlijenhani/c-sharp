/*
 * Created by SharpDevelop.
 * User: chedli
 * Date: 29/04/2019
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace login
{
	/// <summary>
	/// Description of ouvrage.
	/// </summary>
	public partial class ouvrage : Form
	{
		public ouvrage()
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
    if (!(textBox1.Text=="") && !(textBox2.Text=="") && !(textBox3.Text=="")){
string req="insert into Ouvrage values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
OleDbCommand cmd=new OleDbCommand(req,cnn);
cmd.ExecuteNonQuery();
MessageBox.Show("ajout avec succès");
}else {
	 MessageBox.Show("un champ vide");
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
			textBox1.Text="";
				textBox2.Text="";
				textBox3.Text="";
				
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			            
//Création de la chaine de connexion
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
//ouverture de la connexion
try{
    cnn.Open();
    if (!(textBox1.Text=="")){
string req="select * from Ouvrage where inventaire ='"+textBox1.Text+"'";
OleDbCommand cmd=new OleDbCommand(req,cnn);
OleDbDataReader RDR = cmd.ExecuteReader();
if (RDR.HasRows==true)
{
while ( RDR.Read()){

				textBox2.Text=RDR.GetString(1);
				textBox3.Text=RDR.GetString(2);
	}
	}else{
		MessageBox.Show("ne pas existe");
	}


RDR.Close();

}else {
	 MessageBox.Show("un champ vide");
}
    }
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            finally
            {
            	cnn.Close();}

		}
		
		void Button4Click(object sender, EventArgs e)
		{
			//Création de la chaine de connexion
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
//ouverture de la connexion
try{
    cnn.Open();
   
string req="UPDATE Ouvrage SET titre = '"+textBox2.Text+"', Année_d’édition ='"+textBox3.Text+"'WHERE inventaire = '"+textBox1.Text+"'";
OleDbCommand cmd=new OleDbCommand(req,cnn);
 cmd.ExecuteNonQuery();

 MessageBox.Show("update validee");}
	
   
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            finally
            {cnn.Close();}
		
	}
		
		void Button5Click(object sender, EventArgs e)
		{
						//Création de la chaine de connexion
string StrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Base.mdb"; //Création de l'objet de connexion
OleDbConnection  cnn = new OleDbConnection(StrCnn);
//ouverture de la connexion
try{
    cnn.Open();
   
string req="DELETE FROM `ouvrage` WHERE inventaire = '"+textBox1.Text+"'";
OleDbCommand cmd=new OleDbCommand(req,cnn);
 cmd.ExecuteNonQuery();

 MessageBox.Show("delete validee");}
	
   
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            finally
            {cnn.Close();}
		}
		
		
		
		
		
		
		
		
		
		void Button6Click(object sender, EventArgs e)
		{
			ouvragelist F=new ouvragelist();
	F.Show();
	this.Hide();
		}
		}
	}
