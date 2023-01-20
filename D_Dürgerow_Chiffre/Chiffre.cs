namespace D_Dürgerow_Chiffre
{
    static class Chiffre
    {
        public static string Caesar(string klartext, int schlüssel, string zeichen, string leerzeichen, string buchstaben, int wiederholungen)
        {
            // zeichen -> 'ASCII' oder 'Alphabet'
            // leerzeichen -> Leerzeichen 'behalten' oder 'entfernen'
            // buchstaben -> Buchstaben 'Groß und Klein', 'Groß' oder 'Klein'

            string geheimtext = string.Empty;
            char[] text = klartext.ToCharArray();

            if (zeichen == "ASCII")
            {
                for (int i = 0; i < wiederholungen; i++)
                {
                    string hilfsstring = string.Empty;
                    foreach (char ch in text)
                    {
                        hilfsstring += (char)((int)ch + schlüssel);
                    }

                    geheimtext = hilfsstring;
                    hilfsstring = string.Empty;
                    text = geheimtext.ToCharArray();
                }
                geheimtext = LeerzeichenPrüfen(geheimtext, leerzeichen);
                geheimtext = BuchstabenPrüfen(geheimtext, buchstaben);
            }
            else
            {
                char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrtsuvwxyz".ToCharArray();

                for (int i = 0; i < wiederholungen; i++)
                {

                    string hilfsstring = string.Empty;
                    foreach (char ch in text)
                    {
                        if (alphabet.Contains(ch))
                        {
                            int x = Array.IndexOf(alphabet, ch);
                            x += schlüssel;
                            try
                            {
                                hilfsstring += alphabet[x];
                            }
                            catch
                            {
                                try
                                {
                                    hilfsstring += alphabet[x - 52];
                                }
                                catch
                                {
                                    hilfsstring += alphabet[x + 52];
                                }
                            }
                        }
                        else
                        {
                            hilfsstring += ch;
                        }
                    }
                    geheimtext = hilfsstring;
                    hilfsstring = string.Empty;
                    text = geheimtext.ToCharArray();

                }
                geheimtext = LeerzeichenPrüfen(geheimtext, leerzeichen);
                geheimtext = BuchstabenPrüfen(geheimtext, buchstaben);
            }

            return geheimtext;
        }
        public static string Atbash(string klartext, string zeichen, string leerzeichen, string buchstaben, int wiederholungen)
        {
            string geheimtext = string.Empty;
            char[] text = klartext.ToCharArray();

            string Buchstaben = "abcdefghijklmnopqrstuvwxyzßäöü";
            string BuchstabenG = "ABCDEFGHIJKLMNOPQRSTUVWXYZßÄÖÜ";

            for (int i = 0; i < wiederholungen; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (Char.IsLetter(text[j]))
                    {
                        if (Buchstaben.Contains(text[j]))
                        {
                            geheimtext += (char)('z' - (text[j] - 'a'));
                        }
                        if (BuchstabenG.Contains(text[j]))
                        {
                            geheimtext += (char)('Z' - (text[j] - 'A'));
                        }
                    }
                    else
                    {
                        geheimtext += text[j];
                    }
                }
            }
            geheimtext = LeerzeichenPrüfen(geheimtext, leerzeichen);
            geheimtext = BuchstabenPrüfen(geheimtext, buchstaben);

            return geheimtext;
        }

        public static string LeerzeichenPrüfen(string text, string leerzeichen)
        {
            if (leerzeichen == "entfernen")
            {
                char[] chars = text.ToCharArray();
                text = string.Empty;
                foreach (char ch in chars)
                {
                    string hilfsstring = ch.ToString();
                    if (hilfsstring == " ") hilfsstring = string.Empty;
                    text += hilfsstring;
                }
            }

            return text;
        }
        public static string BuchstabenPrüfen(string text, string buchstaben)
        {
            string text1 = string.Empty;
            if (buchstaben == "Groß")
            {
                foreach (char ch in text.ToCharArray())
                {
                    text1 += (int)ch > 96 ? (char)((int)ch - 33) : ch;
                }
            }
            else if (buchstaben == "Klein")
            {
                foreach (char ch in text.ToCharArray())
                {
                    text1 += (int)ch < 91 ? (char)((int)ch + 33) : ch;
                }
            }else if(buchstaben == "GroßUndKlein")
            {
                text1 = text;
            }

            return text1;
        }
    }
}
