using System;
using System.Windows.Forms;

namespace XCommerce.Base.Helpers
{
    public static class Validar
    {
        public static void NoLetras(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsWhiteSpace(e.KeyChar) || Char.IsUpper(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 22))
            {
                e.Handled = true;
            }
        }
        public static void NoNumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 2)
            {
                e.Handled = true;
            }
        }

        public static void NoSimbolos(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 2)
            {
                e.Handled = true;
            }
        }

        public static void NoInyeccion(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '{' || e.KeyChar == '}' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == ';' || e.KeyChar == '+' || e.KeyChar == '"' || (int)e.KeyChar == 39)
            {
                e.Handled = true;
            }
        }
    }
}
