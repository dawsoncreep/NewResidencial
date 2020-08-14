using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessInterfaces;

namespace caseta
{
    public partial class Frm_Login : Form
    {
        private readonly IUsuarioProcessor usuarioProcessor;
        public Frm_Login()
        {
            InitializeComponent();
            usuarioProcessor = Factoria.Instancia.CreateUsuarioProcessor();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioProcessor.UserExist(Tbx_User.Text.Trim(), Tbx_Pass.Text.Trim()))
            {
                Frm_Menu frm = new Frm_Menu();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectas","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Frm_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnIngresar_Click(btnIngresar, new EventArgs());
            }
        }
    }
}
