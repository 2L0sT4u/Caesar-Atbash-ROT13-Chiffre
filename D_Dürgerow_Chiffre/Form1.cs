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
        int schlüssel; //int zum Speichern der Anzahl der Stellen, um die in Cäsar verschoben werden soll
        string buchstaben = "GroßUndKlein";
        string leerzeichen = "behalten";
        string zeichen = "ASCII";
        int wiederholungen = 1;

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
            (textBox1.Text, textBox2.Text) = (textBox2.Text, textBox1.Text);
            (lblSp1.Text, lblSp2.Text) = (lblSp2.Text, lblSp1.Text);

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
            schlüssel = ((int)numericUpDown1.Value); //Anzahl um wie viel verschoben werden soll in Variable speichern
        }

        private void btnLZE_Click(object sender, EventArgs e)
        {
            if (btnLZE.Text == "Leerzeichen entfernen")
            {
                btnLZE.Text = "Leerzeichen behalten";
                leerzeichen = "behalten";
            }
            else
            {
                btnLZE.Text = "Leerzeichen entfernen";
                leerzeichen = "entfernen";
            }
        }
        private void btnGroß_Click(object sender, EventArgs e)
        {
            if (btnGroß.Text == "alles Groß")
            {
                btnGroß.Text = "alles Klein";
                buchstaben = "Klein";
            }
            else if (btnGroß.Text == "alles Klein")
            {
                btnGroß.Text = "Groß und Klein";
                buchstaben = "GroßUndKlein";
            }
            else
            {
                btnGroß.Text = "alles Groß";
                buchstaben = "Groß";
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e) //Übersetzen, wenn Text sich ändert
        {
            switch (chiffre)
            {
                case "Cäsar":
                    if (chiff == true)
                    {
                        textBox2.Text = Chiffre.Caesar(textBox1.Text, schlüssel, zeichen, leerzeichen, buchstaben, wiederholungen);
                    }
                    else
                    {
                        textBox2.Text = Chiffre.Caesar(textBox1.Text, schlüssel * -1, zeichen, leerzeichen, buchstaben, wiederholungen);
                    }
                    break;
                case "Atbash":    
                        textBox2.Text = Chiffre.Atbash(textBox1.Text, zeichen, leerzeichen, buchstaben, wiederholungen);
                    break;
                case "ROT13":
                    if (chiff == true)
                    {
                        textBox2.Text = Chiffre.Caesar(textBox1.Text, 13, zeichen, leerzeichen, buchstaben, wiederholungen);
                    }
                    else
                    {
                        textBox2.Text = Chiffre.Caesar(textBox1.Text, -13, zeichen, leerzeichen, buchstaben, wiederholungen);
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "ASCII")
            {
                button2.Text = "Alphabet";
                zeichen = "Alphabet";
            }
            else
            {
                button2.Text = "ASCII";
                zeichen = "ASCII";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}