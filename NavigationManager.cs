using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlowMate
{
    internal class NavigationManager
    {
        /// <summary>
        /// Stores the last opened form to support back navigation.
        /// </summary>
        public static Form PreviousForm { get; set; }

        /// <summary>
        /// Navigates from the current form to the target form and remembers the current one.
        /// </summary>
        public static void GoTo(Form current, Form target)
        {
            PreviousForm = current;
            target.Show();
            current.Hide();
        }

        /// <summary>
        /// Navigates back to the previously opened form.
        /// </summary>
        public static void GoBack(Form current)
        {
            if (PreviousForm != null)
            {
                PreviousForm.Show();
                current.Hide();
            }
        }
    }
}
