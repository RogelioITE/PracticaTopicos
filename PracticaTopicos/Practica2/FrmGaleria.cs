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
    public partial class FrmGaleria : Form
    {
        private string directorioImagenes = "";
        private PictureBox imagenSeleccionada = null;

        public FrmGaleria()
        {
            InitializeComponent();
            AgregarBotones();
        }

        private void SeleccionarCarpeta()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta de imágenes";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    directorioImagenes = folderDialog.SelectedPath;
                    CargarImagenes();
                }
            }
        }

        private void CargarImagenes()
        {
            if (string.IsNullOrEmpty(directorioImagenes) || !Directory.Exists(directorioImagenes))
            {
                MessageBox.Show("Debe seleccionar una carpeta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flowLayoutPanel1.Controls.Clear();
            imagenSeleccionada = null;

            string[] archivos = Directory.GetFiles(directorioImagenes, "*.*")
                                         .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                     f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                     f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                                         .ToArray();

            if (archivos.Length == 0)
            {
                MessageBox.Show("No hay imágenes en la carpeta seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (string archivo in archivos)
            {
                AgregarImagenAlPanel(archivo);
            }
        }

        private void AgregarImagenAlPanel(string rutaImagen)
        {
            try
            {
                PictureBox picBox = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Tag = rutaImagen,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.None,
                    Image = CargarImagenSinBloqueo(rutaImagen)
                };

                // Crear menú contextual
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem eliminarItem = new ToolStripMenuItem("Eliminar");

                eliminarItem.Click += (s, e) => EliminarImagen(picBox);

                menu.Items.Add(eliminarItem);
                picBox.ContextMenuStrip = menu; // Asignar menú al PictureBox

                picBox.Click += pictureBox_Click;
                flowLayoutPanel1.Controls.Add(picBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Image CargarImagenSinBloqueo(string rutaImagen)
        {
            using (FileStream fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(fs);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                // Abre la imagen en grande
                if (pic.Tag is string rutaImagen)
                {
                    FrmImagen formImagen = new FrmImagen(rutaImagen);
                    formImagen.ShowDialog();
                }

                // Resalta la imagen seleccionada
                if (imagenSeleccionada != null)
                {
                    imagenSeleccionada.BorderStyle = BorderStyle.None;
                }
                imagenSeleccionada = pic;
                imagenSeleccionada.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void AgregarBotones()
        {
            FlowLayoutPanel panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            Button btnSeleccionarCarpeta = CrearBoton("Carpeta", BtnSeleccionarCarpeta_Click);
            Button btnAgregarImagen = CrearBoton("Agregar", BtnAgregarImagen_Click);
            Button btnLimpiar = CrearBoton("Limpiar", BtnLimpiar_Click);

            panelBotones.Controls.Add(btnSeleccionarCarpeta);
            panelBotones.Controls.Add(btnAgregarImagen);
            panelBotones.Controls.Add(btnLimpiar);

            this.Controls.Add(panelBotones);
        }

        private Button CrearBoton(string texto, EventHandler evento)
        {
            return new Button
            {
                Text = texto,
                Width = 90,
                Height = 30,
                Margin = new Padding(5),
                BackColor = Color.LightGray
            }.Apply(boton => boton.Click += evento);
        }

        private void BtnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta de imágenes";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    directorioImagenes = folderDialog.SelectedPath;
                    MessageBox.Show("Carpeta seleccionada correctamente.\nAhora puedes presionar 'Agregar' para ver las imágenes.", "Carpeta Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(directorioImagenes))
            {
                MessageBox.Show("Debe seleccionar una carpeta antes de agregar imágenes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp";
                openFileDialog.Multiselect = true; // Permite seleccionar varias imágenes

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string archivo in openFileDialog.FileNames) // Recorre las imágenes seleccionadas
                    {
                        string destino = Path.Combine(directorioImagenes, Path.GetFileName(archivo));

                        try
                        {
                            if (!File.Exists(destino))
                            {
                                File.Copy(archivo, destino);
                            }

                            AgregarImagenAlPanel(destino);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"No se pudo agregar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void EliminarImagen(PictureBox pic)
        {
            if (pic.Tag is string rutaImagen)
            {
                DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar esta imagen?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Liberar la imagen antes de eliminarla
                        pic.Image.Dispose();
                        pic.Image = null;

                        // Remover el PictureBox completamente del panel
                        flowLayoutPanel1.Controls.Remove(pic);
                        pic.Dispose();

                        // Forzar redistribución para eliminar espacios vacíos
                        flowLayoutPanel1.PerformLayout();
                        flowLayoutPanel1.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo eliminar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            imagenSeleccionada = null;
        }
    }

    public static class ControlExtensions
    {
        public static T Apply<T>(this T control, Action<T> action)
        {
            action(control);
            return control;
        }
    }
}