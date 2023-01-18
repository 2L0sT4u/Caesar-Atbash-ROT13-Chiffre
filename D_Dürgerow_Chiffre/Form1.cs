namespace D_Dürgerow_Chiffre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel01.Visible = false; //Panel auf dem Knöpfe für verschiedene Chiffre sind, ist zu beginn nicht sichtbar
            panel02.Visible = false; //Panel auf dem Knöpfe für verschiedene Optionen sind, ist zu beginn nicht sichtbar
            this.MaximizeBox = false; //verhindert, dass das Formular maximiert werden kann (Vollbild)
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //verhindert, dass die Größe des Formulares verändert werden kann
        }

        bool chiff = true; // boolean, true->chiffrieren, false->dechiffrieren
        string chiffre = "Cäsar"; //string zum speichern des ausgewählten chiffre
        string Text1 = ""; //string zum speichern des ersten Textes (Eingabe)
        int verschiebung; //int zum Speichern der Anzahl der Stellen, um die in Cäsar verschoben werden soll

        //Array mit Groß und Kleinbuchstaben und Leerzeichen
        char[] Buchstaben = "abcdefghijklmnopqrstuvwxyzßäöüABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ".ToCharArray();        

        private void Übersetzen() //Text1 wird (de-)chiffriert und in Text2 gespeichert
        {
            Text1 = textBox1.Text; //Eingabe in Text1 speichern
            string Text02 = string.Empty;
            char[] Text01 = Text1.ToCharArray();

            switch (chiffre) //Überprüfung, welches Chiffre ausgewählt ist
            {
                case "Cäsar": //wenn Cäsar ausgewählt
                    verschiebung = (int)numericUpDown1.Value; //Anzahl der Verschiebungen speichern

                    switch (chiff)
                    {
                        case true: //Cäsar chiffrieren

                            foreach (char ch in Text01)
                            {
                                if (Buchstaben.Contains(ch))
                                {
                                    int x = Array.IndexOf(Buchstaben, ch) + verschiebung;
                                    if (x > Buchstaben.Length) x %= Buchstaben.Length;
                                    Text02 += Buchstaben[x];
                                }
                                else
                                {
                                    Text02 += ch;
                                }
                            }
                            textBox2.Text = Text02;

                            break;

                        case false: //Cäsar dechiffrieren

                            break;
                    }
                    break;

                case "Atbash": //wenn Atbash ausgewählt
                    switch (chiff)
                    {
                        case true: //Atbash chiffrieren

                            foreach (char ch in Text01)
                            {
                                if (Buchstaben.Contains(ch))
                                {

                                    Text02 += Buchstaben[(Buchstaben.Length - Array.IndexOf(Buchstaben, ch)) % Buchstaben.Length] ;
                                }
                                else
                                {
                                    Text02 += ch;
                                }
                            }
                            textBox2.Text = Text02;

                            break;

                        case false: // Atbash dechiffrieren

                            foreach (char ch in Text01)
                            {
                                if (Buchstaben.Contains(ch))
                                {
                                    int x = Buchstaben.Length - (Array.IndexOf(Buchstaben, ch) % Buchstaben.Length);
                                    Text02 += Buchstaben[x];
                                }
                                else
                                {
                                    Text02 += ch;
                                }
                            }
                            textBox2.Text = Text02;

                            break;
                    }
                    break;

                case "ROT13": //wenn ROT13 ausgewählt
                    switch (chiff)
                    {
                        case true:

                            foreach (char ch in Text01)
                            {
                                if (Buchstaben.Contains(ch))
                                {
                                    int x = Array.IndexOf(Buchstaben, ch) + 13;
                                    if (x > Buchstaben.Length) x %= Buchstaben.Length;
                                    Text02 += Buchstaben[x];
                                }
                                else
                                {
                                    Text02 += ch;
                                }
                            }
                            textBox2.Text = Text02;

                            break;

                        case false:

                            foreach (char ch in Text01)
                            {
                                if (Buchstaben.Contains(ch))
                                {
                                    int x = Array.IndexOf(Buchstaben, ch) - 13;
                                    if (x > Buchstaben.Length) x %= Buchstaben.Length;
                                    Text02 += Buchstaben[x];
                                }
                                else
                                {
                                    Text02 += ch;
                                }
                            }
                            textBox2.Text = Text02;

                            break;
                    }
                    break;

                default: //Fehlermeldung, wenn keines der drei Chiffre ausgewählt ist
                    MessageBox.Show("Fehler: kein Chiffre ausgewählt", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e) //button Chiffre
        {
            // Chiffre aufklappen/zuklappen ... bei panel.visible=false rutscht Optionen durch Dock=Top nach oben  => zuklappen
            switch (panel01.Visible)
            {
                case true:
                    panel01.Visible = false; //aufklappen
                    break;

                case false:
                    panel01.Visible = true; //zuklappen
                    panel02.Visible = false; //anderes zuklappen
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e) //button Optionen
        {
            // Optionen aufklappen/zuklappen
            switch (panel02.Visible)
            {
                case true:
                    panel02.Visible = false; //aufklappen
                    break;

                case false:
                    panel02.Visible = true; //zuklappen
                    panel01.Visible = false; //anderes zuklappen
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //bei klick auf doppelpfeil ->
        {
            //Klartext und Geheimtext tauschen
            string i = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = i;

            string o = lblSp1.Text;
            lblSp1.Text = lblSp2.Text;
            lblSp2.Text = o;

            chiff = chiff == true ? chiff = false : chiff = true; //wenn chiff=true mach chiff=false ... wenn chiff =/= true (=false) mach chiff=true
        }

        private void btn1_Click(object sender, EventArgs e) //button Cäsar
        {
            lblChf.Text = "Chiffre: Cäsar"; //Überschrift zeigt Cäsar an
            chiffre = "Cäsar"; //Cäsar wird als ausgewähltes Chiffre gespeichert
            numericUpDown1.Visible = true; //numericUpDown-Komponente, um für Cäsar n festzulegen wird sichtbar
            label1.Visible = true; //text vor numericUpDown ebenfalls sichtbar
            label2.Visible = true; //text nach numericUpDown ebenfalls sichtbar
        }

        private void btn2_Click(object sender, EventArgs e) //button Atbash
        {
            lblChf.Text = "Chiffre: Atbash"; //Überschrift zeigt Atbash an
            chiffre = "Atbash"; //Atbash wird als ausgewähltes Chiffre gespeichert
            numericUpDown1.Visible = false; //numericUpDown-Komponente, um für Cäsar n festzulegen wird nicht sichtbar
            label1.Visible = false; //text vor numericUpDown ebenfalls nicht sichtbar
            label2.Visible = false; //text nach numericUpDown ebenfalls nicht sichtbar
        }

        private void btn3_Click(object sender, EventArgs e) //button ROT13
        {
            lblChf.Text = "Chiffre: ROT13"; //Überschrift zeigt ROT13 an
            chiffre = "ROT13"; //ROT13 wird als ausgewähltes Chiffre gespeichert
            numericUpDown1.Visible = false; // numericUpDown - Komponente, um für Cäsar n festzulegen wird nicht sichtbar
            label1.Visible = false; //text vor numericUpDown ebenfalls nicht sichtbar
            label2.Visible = false; //text nach numericUpDown ebenfalls nicht sichtbar
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //Anzahl um wie viel verschoben werden soll in Variable speichern
        {
            verschiebung = ((int)numericUpDown1.Value); //Anzahl um wie viel verschoben werden soll in Variable speichern
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Übersetzen();
        }

        private void btnGroß_Click(object sender, EventArgs e)
        {
            string Text = textBox2.Text;
            Text=Text.ToUpper();
            textBox2.Text = Text;
        }

        private void btnKlein_Click(object sender, EventArgs e)
        {
            string Text = textBox2.Text;
            Text= Text.ToLower();
            textBox2.Text = Text;
        }

        private void btnLZE_Click(object sender, EventArgs e)
        {
            char[] list = textBox2.Text.ToCharArray();
            textBox2.Text = string.Empty;
            foreach (char ch in list)
            {
                string x = ch.ToString();
                if (x == " ") x = string.Empty;
                textBox2.Text += x;
            }
        }
    }
}