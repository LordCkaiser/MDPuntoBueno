﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;

namespace PuntoMD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparm, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text != "")
            {
                if (textPass.Text != "")
                {
                    ModeloUsuario user = new ModeloUsuario();
                    var validLogin = user.LoginUser(textUsuario.Text, textPass.Text);
                    if (validLogin == true)
                    {
                        Usuarios mainMenu = new Usuarios();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o contraseña incorrectos, intentelo nuevamente");
                        textPass.Clear();
                        textUsuario.Focus();
                    }

                }
                else msgError("¡Porfavor ingresa la contraseña");
            }

            else msgError ("¡Porfavor ingresa el usuario!");
           
            
            
        }
        private void msgError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
          
                Application.Exit();
        }
    }
}
