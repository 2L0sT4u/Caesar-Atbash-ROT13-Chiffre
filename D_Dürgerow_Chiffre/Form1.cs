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

            while (abcd == true) Übersetzen(); // Übersetzen dauerhaft ausführen
        }

        bool abcd = true; //benötigt, um ÜBersetzten() dauerhaft laufen zu lassen
        bool chiff = true; // boolean, true->chiffrieren, false->dechiffrieren
        bool Leerzeichen = false; //boolean, ob Leerzeichen entfernt werden oder nicht
        string GKBuchstaben = "GroßUndKlein"; //string zum Speichern, ob Groß, Klein oder Groß und Kleinbuchstaben
        string chiffre = "Cäsar"; //string zum speichern des ausgewählten chiffre
        string Text1 = ""; //string zum speichern des ersten Textes (Eingabe)
        string Text2 = ""; //string zum speichern des zweiten Textes (Ausgabe)
        int verschiebung; //int zum Speichern der Anzahl der Stellen, um die in Cäsar verschoben werden soll

        //Array mit Groß und Kleinbuchstaben und Leerzeichen
        string[] Buchstaben = { " ", "a", "b", "c", "d", "e", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Ä", "Ö", "Ü", "ß" };
        //Array mit Groß und Kleinbuchstaben, ohne Leerzeichen
        string[] BuchstabenOL = { "a", "b", "c", "d", "e", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Ä", "Ö", "Ü", "ß" };
        //Array mit Großbuchstaben und Leerzeichen
        string[] Großbuchstaben = { " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Ä", "Ö", "Ü", "ß" };
        //Array mit Großbuchstaben, ohne Leerzeichen
        string[] GroßbuchstabenOL = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Ä", "Ö", "Ü", "ß" };
        //Arraymit Kleinbuchstaben und Leerzeichen
        string[] Kleinbuchstaben = { " ", "a", "b", "c", "d", "e", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß" };
        //Array mit Kleinbuchstaben, ohne Leerzeichen
        string[] KleinbuchstabenOL = { "a", "b", "c", "d", "e", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß" };


        private void Übersetzen() //Text1 wird (de-)chiffriert und in Text2 gespeichert
        {
            Text1 = textBox1.Text; //Eingabe in Text1 speichern

            switch (chiffre) //Überprüfung, welches Chiffre ausgewählt ist
            {
                case "Cäsar": //wenn Cäsar ausgewählt
                    verschiebung = (int)numericUpDown1.Value; //Anzahl der Verschiebungen speichern

                    switch (chiff)
                    {
                        case true: //Cäsar chiffrieren





                            break;

                        case false: //Cäsar dechiffrieren





                            break;
                    }
                    break;

                case "Atbash": //wenn Atbash ausgewählt
                    switch (chiff)
                    {
                        case true: //Atbash chiffrieren





                            break;

                        case false: // Atbash dechiffrieren





                            break;
                    }
                    break;

                case "ROT13": //wenn ROT13 ausgewählt
                    switch (chiff)
                    {
                        case true: //ROT13 chiffrieren





                            break;

                        case false: //ROT13 dechiffrieren





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
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //bei klick auf doppelpfeil ->
        {
            //Klartext und Geheimtext tauschen
            string i = lblSp1.Text;
            lblSp1.Text = lblSp2.Text;
            lblSp2.Text = i;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Leerzeichen = Leerzeichen == true ? Leerzeichen = false : Leerzeichen = true; //wenn Leerzeichen=true mach Leerzeichen=false ... wenn Leerzeichen =/= true (=false) mach Leerzeichen=true
        }
    }
}