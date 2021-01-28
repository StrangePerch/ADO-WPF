using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;

namespace Barber
{
    public static class TextCheck
    {
        public static bool CheckPhoneBox(TextBox textbox)
        {
            return CheckBox(textbox, @"^[+](\d+[-])+\d+$");
        }

        public static bool CheckNameBox(TextBox textbox)
        {
            return CheckBox(textbox, @"^[A-Z a-z А-Я а-я]+$");
        }

        public static bool CheckEmailBox(TextBox textbox)
        {
            return CheckBox(textbox, @"^[A-Z a-z . _ 0-9]+[@]\w+[.]\w+$");
        }

        public static bool CheckPhone(string text)
        {
            return CheckText(text, @"^[+](\d+[-])+\d+$");
        }

        public static bool CheckName(string text)
        {
            return CheckText(text, @"^[A-Z a-z А-Я а-я]+$");
        }

        public static bool CheckEmail(string text)
        {
            return CheckText(text, @"^[A-Z a-z . _ 0-9]+[@]\w+[.]\w+$");
        }


        public static bool CheckBox(TextBox textbox, string pattern)
        {
            Match match = Regex.Match(textbox.Text, pattern);
            textbox.Foreground = match.Success ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
            return match.Success;
        }

        public static bool CheckText(string text, string pattern)
        {
            return Regex.Match(text, pattern).Success;
        }
    }
}