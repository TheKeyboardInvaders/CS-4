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

        readonly char[] alpharus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
                                     'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
                                     'Ы', 'Ь', 'Э', 'Ю', 'Я', 'А', 'Б', 'В' };

        double[] arrayStat = new double[33];

        double[] occurance = new double[33];

        private double[] occuranceBase =
        {
            0.064, 0.015, 0.039, 0.014, 0.026, 0.074, 0.074, 0.008, 0.015, 0.064, 0.01, 0.029, 0.036, 0.026,
            0.056, 0.095, 0.024, 0.041, 0.047, 0.056, 0.021, 0.002, 0.009, 0.004, 0.013, 0.006, 0.003, 0.015,
            0.016, 0.015, 0.003, 0.007, 0.019
        };

        readonly string[] peterKey = { "ме", "ли", "ко", "ин", "зе", "жу", "ню", "оы", "пы", "ра", "су", "ти",
                                       "уф", "хм", "от", "ца", "чу", "ше", "ам", "эм", "яъ", "от", "нь", "щъ",
                                       "юз", "яз", "фу", "бе", "ва", "гу", "дм", "го", "вй" };

        readonly char[] alphaeng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                                     'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                                     'Y', 'Z', 'A', 'B', 'C' };

        public Form1()
        {
            InitializeComponent();
            cbAlphabet.Items.Add("Русский");
            cbAlphabet.Items.Add("Английский");
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

        private void CaesarEncode(IReadOnlyList<char> alphabet)
        {
            var input = tbInput.Text.ToUpper();
            var output = "";

            foreach (var t in input)
            {
                for (var j = 0; j < alphabet.Count(); ++j)
                {
                    if (t != alphabet[j]) continue;
                    output += alphabet[j + 3];
                    break;
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
        
        private void CaesarDecode(IReadOnlyList<char> alphabet)
        {
            var input = tbInput.Text;
            var output = "";

            foreach (var t in input)
            {
                for (var j = 3; j < alphabet.Count(); ++j)
                {
                    if (t != alphabet[j]) continue;
                    output += alphabet[j - 3];
                    break;
                }
            }

            tbResult.Text = output;
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

        private void PetrIEncode(IReadOnlyList<char> alphabet)
        {
            var input = tbInput.Text.ToUpper();
            var output = "";

            foreach (var t in input)
            {
                if (t == ' ')
                {
                    output += " ";
                }
                else
                    for (var j = 0; j < alphabet.Count; ++j)
                    {
                        if (t != alphabet[j]) continue;
                        output += peterKey[j];
                        break;
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
            var input = tbInput.Text;
            var output = "";

            for (var i = 0; i < input.Length - 1; ++i)
            {
                if (input[i] == ' ')
                {
                    output += " ";
                }
                else
                {
                    var tmp = input[i].ToString() + input[i + 1].ToString();
                    for (var j = 0; j < peterKey.Length; ++j)
                    {
                        if (tmp == peterKey[j])
                        {
                            output += alphabet[j];
                        }
                    }
                    ++i;
                }
            }

            tbResult.Text = output.ToLower();
        }
        #endregion

        private void tbInput_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }

        private void Statistics()
        {
            tbResult.Text = "";
            var input = tbInput.Text.ToUpper();
            var num = input.Count(t => t != ' ');
            for (var i = 0; i < 33; ++i)
            {
                var v = i;
                foreach (var t in input.Where(t => alpharus[v] == t))
                {
                    ++arrayStat[i];
                }
            }

            for (var i = 0; i < arrayStat.Length; ++i)
            {
                occurance[i] = Math.Round(arrayStat[i]/num, 3);
            }

            foreach (var t in occurance)
            {
                tbResult.Text += t.ToString() + " ";
            }
        }

        private void CompareOccurance()
        {
            tbResult.Text = "";
            var input = tbInput.Text.ToCharArray();
            var output = tbInput.Text.ToCharArray();

            for (var t = 0; t <= 33; ++t)
            {
                var curMax = occurance.Max();
                var curMaxInd = Array.IndexOf(occurance, curMax);

                var curMaxBase = occuranceBase.Max();
                var curMaxBaseInd = Array.IndexOf(occuranceBase, curMaxBase);

                for (var i = 0; i < input.Length; ++i)
                    if (input[i] == alpharus[curMaxInd])
                        output[i] = alpharus[curMaxBaseInd];

                //todo: Костыль, по возможности исправить

                var j = 0;
                for (var i = 0; i < occurance.Length; ++i)
                {
                    if (i == curMaxInd)
                    {
                        continue;
                    }
                    else occurance[j] = occurance[i];
                    ++j;
                }

                j = 0;

                for (var i = 0; i < occuranceBase.Length; ++i)
                {
                    if (i == curMaxBaseInd)
                    {
                        continue;
                    }
                    else occuranceBase[j] = occuranceBase[i];
                    ++j;
                }

                //Работает неправильно
                //occurance = occurance?.Except(new double[] { occurance[curMaxInd] }).ToArray();
                //occuranceBase = occuranceBase?.Except(new double[] {occuranceBase[curMaxBaseInd]}).ToArray();
            }
            foreach (var t in output)
            {
                tbResult.Text += t;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistics();
            CompareOccurance();
        }
    }
}