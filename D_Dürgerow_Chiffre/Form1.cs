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
        int verschiebung; //int zum Speichern der Anzahl der Stellen, um die in Cäsar verschoben werden soll

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

        private void pictureBox1_Click(object sender, EventArgs e) //bei klick auf doppelpfeil
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
            textBox1.Text = string.Empty; 
            textBox2.Text = string.Empty;
        }

        private void btn2_Click(object sender, EventArgs e) //button Atbash
        {
            lblChf.Text = "Chiffre: Atbash"; //Überschrift zeigt Atbash an
            chiffre = "Atbash"; //Atbash wird als ausgewähltes Chiffre gespeichert
            numericUpDown1.Visible = false; //numericUpDown-Komponente, um für Cäsar n festzulegen wird nicht sichtbar
            label1.Visible = false; //text vor numericUpDown ebenfalls nicht sichtbar
            label2.Visible = false; //text nach numericUpDown ebenfalls nicht sichtbar
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void btn3_Click(object sender, EventArgs e) //button ROT13
        {
            lblChf.Text = "Chiffre: ROT13"; //Überschrift zeigt ROT13 an
            chiffre = "ROT13"; //ROT13 wird als ausgewähltes Chiffre gespeichert
            numericUpDown1.Visible = false; // numericUpDown - Komponente, um für Cäsar n festzulegen wird nicht sichtbar
            label1.Visible = false; //text vor numericUpDown ebenfalls nicht sichtbar
            label2.Visible = false; //text nach numericUpDown ebenfalls nicht sichtbar
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //Anzahl um wie viel verschoben werden soll in Variable speichern
        {
            verschiebung = ((int)numericUpDown1.Value); //Anzahl um wie viel verschoben werden soll in Variable speichern
        }

        private void btnGroß_Click(object sender, EventArgs e)
        {
            string Text = textBox2.Text;
            Text = Text.ToUpper();
            textBox2.Text = Text;
        }

        private void btnKlein_Click(object sender, EventArgs e)
        {
            string Text = textBox2.Text;
            Text = Text.ToLower();
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



        private void textBox1_TextChanged(object sender, EventArgs e) //Übersetzen, wenn Text sich ändert
        {
            switch (chiffre)
            {
                case "Cäsar":
                    if (chiff == true) Caeser(textBox1.Text, verschiebung); else CaeserDe(textBox1.Text, verschiebung);
                    break;
                case "Atbash":
                    Atbash(textBox1.Text);
                    break;
                case "ROT13":
                    if (chiff == true) ROT13(textBox1.Text); else ROT13De(textBox1.Text);
                    break;
            }
        }

        //Algorithmen

        public void Caeser(string s, int v)
        {
            char[] Eingabe = s.ToCharArray();
            string Ausgabe = string.Empty;

            foreach(char ch in Eingabe)
            {
                int x = (int)ch;
                x += v;
                Ausgabe += (char)x;
            }
            textBox2.Text = Ausgabe;
        }

        public void CaeserDe(string s, int v)
        {
            char[] Eingabe = s.ToCharArray();
            string Ausgabe = string.Empty;

            foreach (char ch in Eingabe)
            {
                int x = (int)ch;
                x -= v; 
                if(x <= 0) x %= -255;
                Ausgabe += (char)x;
            }
            textBox2.Text = Ausgabe;
        }


        public void Atbash(string s)
        {
            string Buchstaben = "abcdefghijklmnopqrstuvwxyzßäöü";
            string BuchstabenG = "ABCDEFGHIJKLMNOPQRSTUVWXYZßÄÖÜ";

            char[] Eingabe = s.ToCharArray();
            string Ausgabe = string.Empty;

            for (int i = 0; i < Eingabe.Length; i++)
            {
                if (Char.IsLetter(Eingabe[i]))
                {
                    if (Buchstaben.Contains(Eingabe[i]))
                    {
                        Ausgabe += (char)('z' - (Eingabe[i] - 'a'));
                    }
                    if (BuchstabenG.Contains(Eingabe[i]))
                    {
                        Ausgabe += (char)('Z' - (Eingabe[i] - 'A'));
                    }

                }
                else
                {
                    Ausgabe += Eingabe[i];
                }
            }
            textBox2.Text = Ausgabe;
        }


        public void ROT13(string s)
        {
            char[] Eingabe = s.ToCharArray();
            string Ausgabe = string.Empty;

            foreach (char ch in Eingabe)
            {
                int x = (int)ch;
                x += 13;
                Ausgabe += (char)x;
            }
            textBox2.Text = Ausgabe;
        }

        public void ROT13De(string s)
        {
            char[] Eingabe = s.ToCharArray();
            string Ausgabe = string.Empty;

            foreach (char ch in Eingabe)
            {
                int x = (int)ch;
                x -= 13;
                Ausgabe += (char)x;
            }
            textBox2.Text = Ausgabe;
        }


    }
}