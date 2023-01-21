using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Dürgerow_Chiffre
{
    public partial class CäsarBruteForceAttack : Form
    {
        public CäsarBruteForceAttack()
        {
            InitializeComponent();
        }
        public void BruteForceAttack(string geheimtext)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoopqrstuvwxyz".ToCharArray();

            for (int verschiebung = 0; verschiebung < alphabet.Length; verschiebung++)
            {
                daten.Rows.Add(verschiebung.ToString(), Chiffre.Caesar(geheimtext, verschiebung * -1, "Alphabet", true, "GroßUndKlein", 1));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            daten.Rows.Clear();
            BruteForceAttack(textBox1.Text);
        }
    }
}
