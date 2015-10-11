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
                            'Ы', 'Ь', 'Э', 'Ю', 'Я', 'А', 'Б', 'В'
        };

        char[] alphaeng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z', 'A', 'B', 'C'
        };

        public Form1()
        {
            InitializeComponent();
            cbAlphabet.Items.Add("Русский");
            cbAlphabet.Items.Add("Английский");
            cbAlphabet.SelectedItem = "Русский";

            // todo: refactor with loop
            // todo: correct the alphabet
            // todo: consider space issue
            encodeTable.Add('а', "ме");
            encodeTable.Add('б', "ли");
            encodeTable.Add('в', "ко");
            encodeTable.Add('г', "ин");
            encodeTable.Add('д', "зе");
            encodeTable.Add('е', "жу");
            encodeTable.Add('ж', "ню");
            encodeTable.Add('и', "о");
            encodeTable.Add('й', "пы");
            encodeTable.Add('к', "ра");
            encodeTable.Add('л', "су");
            encodeTable.Add('м', "ти");
            encodeTable.Add('н', "у");
            encodeTable.Add('о', "хм");
            encodeTable.Add('п', "от");
            encodeTable.Add('р', "ца");
            encodeTable.Add('с', "чу");
            encodeTable.Add('т', "ше");
            encodeTable.Add('у', "ам");
            encodeTable.Add('ф', "э");
            encodeTable.Add('х', "ъ");
            //encodeTable.Add('ы', "от");
            encodeTable.Add('ц', "ь");
            //encodeTable.Add('ч', "ъ");
            encodeTable.Add('ш', "ю");
            encodeTable.Add('щ', "я");
            encodeTable.Add('ъ', "ф");
            encodeTable.Add('ь', "бе");
            encodeTable.Add('э', "ва");
            encodeTable.Add('ю', "гу");
            encodeTable.Add('я', "дм");

            // Меняем ключ-значение для таблицы расшифровки
            decodeTable = encodeTable.ToDictionary(kv => kv.Value, kv => kv.Key);
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
            string input = tbInput.Text.ToLower();
            string output = "";

            foreach (Char c in input)
            {
                output += encodeTable[c];
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
            for (int i = 0; i < input.Length - 1; ++i)
            {
                tmp = input[i].ToString() + input[i + 1].ToString();
                if (decodeTable.ContainsKey(tmp))
                {
                    output += decodeTable[tmp];
                    tmp = "";
                }
                else if (decodeTable.ContainsKey(input[i].ToString()))
                    output += decodeTable[input[i].ToString()];
            }

            tbResult.Text = output;
        }
        #endregion

        private void tbInput_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }
    }
}
