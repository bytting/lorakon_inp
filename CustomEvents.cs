/*	
	lorakon_inp - Sample input form for Genie2k
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag Robole,

using System;
using System.Windows.Forms;
using System.Globalization;
using System.Media;

namespace lorakon
{        
    public static class CustomEvents
    {
        private static string NumSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public static void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public static bool ValidateUnsignedInteger(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (!Char.IsNumber(num[i]))
                    return false;
            }
            return true;
        }

        public static void UnsignedNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow decimals
            char sep = Convert.ToChar(NumSep);

            TextBox tb = (TextBox)sender;
            if (e.KeyChar == sep)
            {
                // No separator at the beginning
                if (tb.SelectionStart == 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one separator
                foreach (char c in tb.Text)
                {
                    if (c == sep)
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != sep)
            {                
                e.Handled = true;
                SystemSounds.Beep.Play();
            }                
        }

        public static bool ValidateUnsignedNumeric(string num)
        {
            char sep = Convert.ToChar(NumSep);
            int separators = 0;

            for (int i=0; i<num.Length; i++)
            {
                if (!Char.IsNumber(num[i]) && num[i] != sep)
                    return false;                

                if (num[i] == sep)
                    separators++;
            }

            if (separators > 1)
                return false;

            return true;
        }

        public static void SignedNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow decimals and minus
            char sep = Convert.ToChar(NumSep);

            TextBox tb = (TextBox)sender;
            if (e.KeyChar == sep)
            {
                // No separator at the beginning
                if(tb.SelectionStart == 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one separator
                foreach (char c in tb.Text)
                {
                    if (c == sep)
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (e.KeyChar == '-')
            {                
                // Only minus at the beginning
                if (tb.SelectionStart != 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one minus
                foreach (char c in tb.Text)
                {
                    if (c == '-')
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != sep && e.KeyChar != '-')
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public static bool ValidateSignedNumeric(string num)
        {
            char sep = Convert.ToChar(NumSep);

            int hyphens = 0, separators = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (!Char.IsNumber(num[i]))
                {
                    if (num[i] != '-' && num[i] != sep)
                        return false;

                    if (num[i] == '-')
                        hyphens++;
                    else if (num[i] == sep)
                        separators++;
                }                    
            }

            if (hyphens > 1 || separators > 1)
                return false;

            return true;
        }

        public static void Latitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow decimals and minus
            char sep = Convert.ToChar(NumSep);

            TextBox tb = (TextBox)sender;
            if (e.KeyChar == sep)
            {
                // No separator at the beginning
                if (tb.SelectionStart == 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one separator
                foreach (char c in tb.Text)
                {
                    if (c == sep)
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }
            
            if (e.KeyChar == '-')
            {
                // Only minus at the beginning
                if (tb.SelectionStart != 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one minus
                foreach (char c in tb.Text)
                {
                    if (c == '-')
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (!Char.IsNumber(e.KeyChar)
                && !Char.IsControl(e.KeyChar)
                && e.KeyChar != sep
                && "-*°'\" NS".IndexOf(e.KeyChar) == -1)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public static void Longitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow decimals and minus
            char sep = Convert.ToChar(NumSep);

            TextBox tb = (TextBox)sender;
            if (e.KeyChar == sep)
            {
                // No separator at the beginning
                if (tb.SelectionStart == 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one separator
                foreach (char c in tb.Text)
                {
                    if (c == sep)
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (e.KeyChar == '-')
            {
                // Only minus at the beginning
                if (tb.SelectionStart != 0)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    return;
                }

                // Only allow one minus
                foreach (char c in tb.Text)
                {
                    if (c == '-')
                    {
                        e.Handled = true;
                        SystemSounds.Beep.Play();
                        return;
                    }
                }
            }

            if (!Char.IsNumber(e.KeyChar)
                && !Char.IsControl(e.KeyChar)
                && e.KeyChar != sep
                && "-*°'\" EW".IndexOf(e.KeyChar) == -1)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public static void Coordinate_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(NumSep == ".")
                tb.Text = tb.Text.Replace(',', '.');
            else if (NumSep == ",")
                tb.Text = tb.Text.Replace('.', ',');
        }

        public static void Decimal_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (NumSep == ".")
                tb.Text = tb.Text.Replace(',', '.');
            else if (NumSep == ",")
                tb.Text = tb.Text.Replace('.', ',');
        }        

        public static void Crop16_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Crop(tb.Text, 16);
        }

        public static void Crop24_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Crop(tb.Text, 24);
        }
        
        public static void Crop64_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Crop(tb.Text, 64);
        }

        public static void Crop255_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Crop(tb.Text, 255);
        }

        private static string Crop(string line, int size)
        {
            if (line.Length > size)
                return line.Substring(0, size);
            return line;
        }
    }    
}
