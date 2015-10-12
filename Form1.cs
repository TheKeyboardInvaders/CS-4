using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_4
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<char, string> encodeTable = new Dictionary<char, string>();
        private readonly Dictionary<string, char> decodeTable;

        char[] alpharus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
                            'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
                            'Ы', 'Ь', 'Э', 'Ю', 'Я', 'А', 'Б', 'В' };

        string[] peterKey = { "ме", "ли", "ко", "ин", "зе", "жу", "ню", "оы", "пы", "ра", "су", "ти",
                              "уф", "хм", "от", "ца", "чу", "ше", "ам", "эм", "яъ", "от", "нь", "щъ",
                              "юз", "яз", "фу", "бе", "ва", "гу", "дм", "го", "вй" };

        char[] alphaeng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z', 'A', 'B', 'C' };

        public Form1()
        {
            InitializeComponent();
            cbAlphabet.Items.Add("Русский");
            cbAlphabet.Items.Add("Английский");
            //cbAlphabet.SelectedItem = "Русский";

            // todo: consider space issue
        }

        #region Шифровка текста кодом Цезаря
        private void btnEncodeCaesar_Click(object sender, EventArgs e)
        {
            if (cbAlphabet.SelectedIndex == 0)
            {
                CaesarEncode(alpharus);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                CaesarEncode(alphaeng);
            }
        }

        private void CaesarEncode(char[] alphabet)
        {
            string input = tbInput.Text.ToUpper();
            string output = "";

            for (int i = 0; i < input.Length; ++i)
            {
                for (int j = 0; j < alphabet.Count(); ++j)
                {
                    if (input[i] == alphabet[j])
                    {
                        output += alphabet[j + 3];
                        break;
                    }
                }
            }

            tbResult.Text = output;
        }
        #endregion

        #region Расшифровка кода Цезаря
        private void btnDecodeCaesar_Click(object sender, EventArgs e)
        {
            if (cbAlphabet.SelectedIndex == 0)
            {
                CaesarDecode(alpharus);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                CaesarDecode(alphaeng);
            }
        }
        
        private void CaesarDecode(char[] alphabet)
        {

        }
        #endregion

        #region Шифровка текста кодом Петра Первого
        private void btnEncodePetrI_Click(object sender, EventArgs e)
        {
            if (cbAlphabet.SelectedIndex == 0)
            {
                PetrIEncode(alpharus);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                PetrIEncode(alphaeng);
            }
        }

        private void PetrIEncode(char[] alphabet)
        {
            string input = tbInput.Text.ToUpper();
            string output = "";

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == ' ')
                {
                    output += " ";
                }
                else
                for (int j = 0; j < alphabet.Length; ++j)
                {
                    if (input[i] == alphabet[j])
                    {
                        output += peterKey[j];
                        break;
                    }
                }
            }

            tbResult.Text = output;
        }
        #endregion

        #region Дешифровка кода Петра Первого
        private void btnDecodePetrI_Click(object sender, EventArgs e)
        {
            if (cbAlphabet.SelectedIndex == 0)
            {
                PetrIDecode(alpharus);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                PetrIDecode(alphaeng);
            }
        }

        private void PetrIDecode(char[] alphabet)
        {
            string input = tbInput.Text;
            string output = "";

            string tmp = "";
            for (int i = 0; i < input.Length - 1; i += 2)
            {
                tmp = input[i].ToString() + input[i + 1].ToString();
                if (input[i] == ' ')
                {
                    output += " ";
                }
                else
                for (int j = 0; j < peterKey.Length; ++j)
                {
                    if (tmp == peterKey[j])
                    {
                        output += alphabet[j];
                    }
                }
            }

            tbResult.Text = output.ToLower();
        }
        #endregion

        private void tbInput_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }
    }
}
