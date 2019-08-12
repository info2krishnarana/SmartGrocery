using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGrocery.UI.Win.Utilities
{
    public class Validation
    {
        public static bool IsAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    form.BringToFront();
                    form.WindowState = FormWindowState.Normal;
                    //form.ShowIcon = false;
                    //form.MinimizeBox = false;
                    //form.MaximizeBox = false;
                    isOpen = true;
                }
            }
            return isOpen;
        }

        public static void BindComboBox(ComboBox comboBox, object dataSource, string diplayMember, string valueMember, bool showOptional)
        {
            if (dataSource != null)
            {
                comboBox.DataSource = dataSource;
                comboBox.DisplayMember = diplayMember;
                comboBox.ValueMember = valueMember;
                //if (showOptional)
                //{
                //    comboBox.Items.Insert(0, "Select---");
                //}
            }
            //else
            //{
            //    comboBox.Items.Insert(0, "Select---");
            //}
        }
    }
}
