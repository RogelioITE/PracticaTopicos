using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica2;

namespace Practica2
{
    public partial class FrmImagen : Form
    {
        public FrmImagen(string rutaImagen)
        {
            InitializeComponent();
            this.Text = Path.GetFileName(rutaImagen); // Muestra el nombre del archivo como título

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(rutaImagen),
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(pictureBox);
            this.Width = 600;
            this.Height = 400;
        }
    }
}