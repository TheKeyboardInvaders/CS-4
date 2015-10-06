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
        char[] alpharus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
                            'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
                            'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };

        char[] alphaeng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z'
        };

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

        private void CaesarEncode(char[] alphabet)
        {

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

        }
        #endregion

        private void tbInput_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }
    }
}
