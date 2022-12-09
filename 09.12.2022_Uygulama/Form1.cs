using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09._12._2022_Uygulama
{
    public partial class Form1 : Form
    {
        public int _sayi;
        public int _Random;
        public int _Count = 0;
        public int _Count1 = 0;
        public bool _dene;
        public Form1()
        {
            InitializeComponent();
            
        }
        // 1.Görev oyunu başlata bastığımda timer çalışsın
        // 2. görec rast gele bir sayı üretsin
        // 3. görev dorm yüklendiğinde progressbar max60  btntahminet.enebiled=> faşse
        // 4. oynu başlata bastığımda timer çalışsın
        // 5. görev progressbar.value == progresbar.max labelları temizleyin
        // 6. görev Tahmin et butonuna bastığımda kullanıcı sayı girdimi kontrol girmedi yada yanlış girdiyse uyarı verin
        // 7. görev girilen sayıyı lbl bilgiye yazdır.
        // 8. görev kullanıcının girdiği sayi ile randomdan gelen sayı arasındaki ilişkiyi kontrol edin lblBilgiye surumları atın 
        // 9. görev kullanıcının tahmin ettiği sayı doğru ise kullanıcının ettiği süreye göre lblMesaj a bilegiler yazdıralım (%. tahminde bildin - 15. saniyede bildin diye)
        //10.görev Timer ı tetikleyin(tick) progressbar.value değerini kontrol edin.(value =>0 başaramadın.)
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 60;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random _RND = new Random();
            _Random = _RND.Next(1,101);

            _Count = 0;
            _Count1 = 0;

            timer1.Start(); // zamanlayıcı başladı
            lbbBilgi.Text = ""; // text temizlendi
            
            // bar maksimum değerine geri sayabilmesi için ayarlandı
            progressBar1.Value = progressBar1.Maximum; 



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _Count1++;
            if(progressBar1.Value > progressBar1.Minimum)
            {
                progressBar1.Value = progressBar1.Maximum - _Count1;
            }
            if (_Count > 59)
            {
                label3.Text = "süre bitti başaramadın";
                button2.Enabled = false;
                timer1.Stop();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _dene = int.TryParse(textBox1.Text, out _sayi);
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_dene != false && _sayi < 101 && _Count1 < 101)
            {
                _Count++;
                if (_sayi < _Random)
                {
                    lbbBilgi.Text = "daha büyük bir sayıya ihtiyacın var";
                }
                else if (_sayi > _Random)
                {
                    lbbBilgi.Text = "daha küçük bir sayıya ihtiyacın var";
                }
                else if (_sayi == _Random)
                {
                    lbbBilgi.Text = "Tebrikler";
                    label3.Text = _Count.ToString() + " . denemde buldunuz ve " + _Count1.ToString() + " snde tammamladınız";
                    timer1.Stop();
                    
                }
            }
            else
            {
                lbbBilgi.Text = "Hatalşı giriş yaptınız";
            }

            
        }
     
    }
}
