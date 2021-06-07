using System;
using System.Windows.Forms;
using XCommerce.Base.Helpers;

namespace XCommerce.Base.Formularios
{
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
        }
        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            }
        }

        //=================   LIMPIAR CONTROLES   ================//

        public void LimpiarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls) 
                {
                    if (ctrol is TextBox)
                    {
                        ((TextBox)ctrol).Clear();
                    }
                    else if (ctrol is RichTextBox)
                    {
                        ((RichTextBox)ctrol).Clear();
                    }
                    else if (ctrol is NumericUpDown)
                    {
                        ((NumericUpDown)ctrol).Value = ((NumericUpDown)ctrol).Minimum ;
                    }
                    else if (ctrol is DateTimePicker)
                    {
                        ((DateTimePicker)ctrol).Value = DateTime.Now;
                    }
                    else if (ctrol is Panel)
                    {
                        LimpiarControles(ctrol);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    if (ctrol is TextBox)
                    {
                        ((TextBox)ctrol).Clear();
                    }
                    else if (ctrol is RichTextBox)
                    {
                        ((RichTextBox)ctrol).Clear();
                    }
                    else if (ctrol is NumericUpDown)
                    {
                        ((NumericUpDown) ctrol).Value = ((NumericUpDown) ctrol).Minimum;
                    }
                    else if (ctrol is DateTimePicker)
                    {
                        ((DateTimePicker)ctrol).Value = DateTime.Now;
                    }
                    else if (ctrol is Panel)
                    {
                        LimpiarControles(ctrol);
                    }
                }
            }
        }

        public void DesactivarControles(object obj, bool estado)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    if (ctrol is TextBox)
                    {
                        ((TextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is RichTextBox)
                    {
                        ((RichTextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is NumericUpDown)
                    {
                        ((NumericUpDown) ctrol).Enabled = estado;
                    }
                    else if (ctrol is DateTimePicker)
                    {
                        ((DateTimePicker) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Button)
                    {
                        ((Button) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Panel)
                    {
                        DesactivarControles(ctrol,estado);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    if (ctrol is TextBox)
                    {
                        ((TextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is RichTextBox)
                    {
                        ((RichTextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is NumericUpDown)
                    {
                        ((NumericUpDown) ctrol).Enabled = estado;
                    }
                    else if (ctrol is DateTimePicker)
                    {
                        ((DateTimePicker) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Button)
                    {
                        ((Button) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Panel)
                    {
                        DesactivarControles(obj, estado);
                    }
                }
            }
            else if (obj is UserControl)
            {
                foreach (var ctrol in ((UserControl) obj).Controls)
                {
                    if (ctrol is TextBox)
                    {
                        ((TextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is RichTextBox)
                    {
                        ((RichTextBox) ctrol).Enabled = estado;
                    }
                    else if (ctrol is NumericUpDown)
                    {
                        ((NumericUpDown) ctrol).Enabled = estado;
                    }
                    else if (ctrol is DateTimePicker)
                    {
                        ((DateTimePicker) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Button)
                    {
                        ((Button) ctrol).Enabled = estado;
                    }
                    else if (ctrol is Panel)
                    {
                        DesactivarControles(obj, estado);
                    }
                }
            }
        }

        public void ColorAlPerderFoco(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox) sender).BackColor = Color.ColorPerderFoco;
            }
            else if (sender is RichTextBox)
            {
                ((RichTextBox) sender).BackColor = Color.ColorPerderFoco;
            }
        }

        public void ColorAlRecibirFoco(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox) sender).BackColor = Color.ColorRecibirFoco;
            }
            else if (sender is RichTextBox)
            {
                ((RichTextBox) sender).BackColor = Color.ColorRecibirFoco;
            }
        }
    }
}
