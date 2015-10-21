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
                            'Ы', 'Ь', 'Э', 'Ю', 'Я', ' ' };

        char[] alpharusMoved = { 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
                                 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч',
                                 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', ' ', 'А', 'Б', 'В' };

        double[] arrayStat = new double[34];

        double[] occurance = new double[34];

        double[] occuranceBase =
        {
            0.064, 0.015, 0.039, 0.014, 0.026, 0.074, 0.074, 0.008, 0.015, 0.064, 0.01, 0.029, 0.036, 0.026,
            0.056, 0.095, 0.024, 0.041, 0.047, 0.056, 0.021, 0.002, 0.009, 0.004, 0.013, 0.006, 0.003, 0.015,
            0.016, 0.015, 0.003, 0.007, 0.019, 0.124
        };

        readonly string[] peterKey = { "ме", "ли", "ко", "ин", "зе", "жу", "ню", "оы", "пы", "ра", "су", "ти",
                                       "уф", "хм", "от", "ца", "чу", "ше", "ам", "эм", "яъ", "от", "нь", "щъ",
                                       "юз", "яз", "фу", "бе", "ва", "гу", "дм", "го", "вй" };

        readonly char[] alphaeng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                                     'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                                     'Y', 'Z', 'A', 'B', 'C' };

        private char[] inputMain;
        private char[] outputMain;

        public Form1()
        {
            InitializeComponent();
            cbAlphabet.Items.Add("Русский");
            cbAlphabet.Items.Add("Английский");
        }

        #region Шифровка текста кодом Цезаря
        private void btnEncodeCaesar_Click(object sender, EventArgs e)
        {
            inputMain = tbInput.Text.ToCharArray();
            if (cbAlphabet.SelectedIndex == 0)
            {
                CaesarEncode(alpharus, alpharusMoved);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                CaesarEncode(alphaeng, alpharusMoved);
            }
        }

        private void CaesarEncode(IReadOnlyList<char> alphabet, char[] alphabetMoved)
        {
            var input = tbInput.Text.ToUpper();
            var output = "";

            foreach (var t in input)
            {
                for (var j = 0; j < alphabet.Count(); ++j)
                {
                    if (t != alphabet[j]) continue;
                    output += alphabetMoved[j];
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
                CaesarDecode(alpharus, alpharusMoved);
            }
            if (cbAlphabet.SelectedIndex == 1)
            {
                CaesarDecode(alphaeng, alpharusMoved);
            }
        }
        
        private void CaesarDecode(IReadOnlyList<char> alphabet, char[] alphabetMoved)
        {
            var input = tbInput.Text;
            var output = "";

            foreach (var t in input)
            {
                for (var j = 0; j < alphabetMoved.Count(); ++j)
                {
                    if (t != alphabetMoved[j]) continue;
                    output += alphabet[j];
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
            //tbInput.Text = "";
        }

        private void Statistics()
        {
            tbResult.Text = "";
            var input = tbInput.Text.ToUpper();
            for (var i = 0; i < alpharus.Length; ++i)
            {
                foreach (var t in input)
                {
                    if (alpharus[i] == t)
                    {
                        ++arrayStat[i];
                    }
                }
            }

            for (var i = 0; i < arrayStat.Length; ++i)
            {
                occurance[i] = Math.Round(arrayStat[i]/input.Length, 3);
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

            for (var t = 0; t <= occurance.Length; ++t)
            {
                var curMax = occurance.Max();
                var curMaxInd = Array.IndexOf(occurance, curMax);

                var curMaxBase = occuranceBase.Max();
                var curMaxBaseInd = Array.IndexOf(occuranceBase, curMaxBase);

                for (var i = 0; i < input.Length; ++i)
                    if (input[i] == alpharus[curMaxInd])
                        output[i] = alpharus[curMaxBaseInd];

                //todo: Костыль, по возможности исправить

                //ShrinkOccurance(occurance, curMaxInd);

                //ShrinkOccurance(occuranceBase, curMaxBaseInd);

                var j = 0;
                double[] tmpdb = new double[occurance.Length - 1];

                for (var i = 0; i < occurance.Length; ++i)
                {
                    if (i == curMaxInd)
                    {
                        continue;
                    }
                    else tmpdb[j] = occurance[i];
                    ++j;
                }

                occurance = tmpdb;

                j = 0;
                double[] tmpdbBase = new double[occuranceBase.Length - 1];

                for (var i = 0; i < occuranceBase.Length; ++i)
                {
                    if (i == curMaxBaseInd)
                    {
                        continue;
                    }
                    else tmpdbBase[j] = occuranceBase[i];
                    ++j;
                }

                occuranceBase = tmpdbBase;

                j = 0;
                char[] tmpalpha = new char[alpharus.Length - 1];

                for (var i = 0; i < alpharus.Length; ++i)
                {
                    if (i == curMaxInd)
                    {
                        continue;
                    }
                    else tmpalpha[j] = alpharus[i];
                    ++j;
                }

                alpharus = tmpalpha;

                //Работает неправильно
                //occurance = occurance?.Except(new double[] { occurance[curMaxInd] }).ToArray();
                //occuranceBase = occuranceBase?.Except(new double[] {occuranceBase[curMaxBaseInd]}).ToArray();
            }
            foreach (var t in output)
            {
                tbResult.Text += t;
            }
            outputMain = tbResult.Text.ToCharArray();
        }

        private void ShrinkOccurance(double[] db, int index)
        {
            var j = 0;
            double[] tmpdb = new double[db.Length - 1];

            for (var i = 0; i < db.Length; ++i)
            {
                if (i == index)
                {
                    continue;
                }
                else tmpdb[j] = db[i];
                ++j;
            }
            
            db = tmpdb;
        }

        private double CalculateProcent(char[] input, char[] output)
        {
            double count = 0;
            double percent;
            for (var i = 0; i < output.Length; ++i)
            {
                if (input[i] == output[i]) ++count;
            }
            return percent = Math.Round(count / input.Length, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistics();
            CompareOccurance();
            lbProcent.Text = CalculateProcent(inputMain, outputMain).ToString();
        }
    }
}