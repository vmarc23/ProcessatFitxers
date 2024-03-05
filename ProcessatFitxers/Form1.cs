using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessatFitxers
{
    public partial class Form1 : Form
    {
        List<string> vocals = new List<string> { "A", "E", "I", "O", "U" };
        List<Queue<int>> cues = new List<Queue<int>>();
        Dictionary<string, string> codis = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private Queue<int> GenerarNumerosAleatorios()
        {
            ArrayList Nums = new ArrayList() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Queue<int> cola = new Queue<int>();
            int bitConv;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] valor = new byte[4];
                rng.GetBytes(valor);
                bitConv = BitConverter.ToInt32(valor, 0);
            }
            Random rnd = new Random(bitConv);

            for (int i = 0; i < 10; i++)
            {
                int aleatori = rnd.Next(0, Nums.Count);
                cola.Enqueue((int)Nums[aleatori]);
                Nums.RemoveAt(aleatori);
            }
            return cola;
        }

        static string Codificar(Queue<int> queue)
        {
            List<string> stringList = new List<string>();
            foreach (int num in queue)
            {
                stringList.Add(num.ToString());
            }
            return string.Join("", stringList);
        }

        private void btn_codif_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var cua = GenerarNumerosAleatorios();
                cues.Add(cua);
                codis.Add(Codificar(cua), "");
            }

            using (FileStream f = new FileStream("codificacio.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var codi = codis.ElementAt(i); 
                        s.WriteLine(vocals[i] + ":" + codi.Key); 
                    }
                }
            }
            MessageBox.Show("Fitxer de codificacio creat correctament");
        }
        //FITXERS

        Thread t1;
        Thread t2;
        private void btf_genera_Click(object sender, EventArgs e)
        {
            if (txt_fitxers.Text != "" && txt_lletres.Text != "")
            {
                t1 = new Thread(genArx);
                t2 = new Thread(comprimirzip);

                int numfitx = int.Parse(txt_fitxers.Text);
                t1.Start();
                t2.Start(numfitx);

                MessageBox.Show("Arxius creats correctament");
            }
            else
            {
                MessageBox.Show("Primer, indica el número de lletres i fitxers.");
            }
        }

        private void genArx()
        {
            string directori = Path.Combine(Directory.GetCurrentDirectory() + "\\fitxers");
            DirectoryInfo di = new DirectoryInfo(directori);
            if (Directory.Exists(directori))
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            else
            {
                Directory.CreateDirectory(directori);
            }

            Random number = new Random();
            int randomnumfitx = int.Parse(txt_fitxers.Text) + 1;
            int randomnumlletres = int.Parse(txt_lletres.Text) + 1;

            Parallel.For(1, randomnumfitx, numero =>
            {
                string nomfitxer = "fitxer" + numero + ".txt";
                FileStream fs = File.Create(directori + "\\" + nomfitxer);
                fs.Close();
            });

            foreach (string fichero in Directory.GetFiles(directori))
            {
                FileStream fst = new FileStream(fichero, FileMode.Open, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fst);

                for (int i = 0; i < randomnumlletres; i++)
                {
                    int randomnumind = number.Next(0, 4);
                    sw.Write(vocals[randomnumind]);
                }
                sw.WriteLine();
                sw.Close();
                fst.Close();

                FileStream fst2 = new FileStream(fichero, FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fst2);
                StreamWriter sw2 = new StreamWriter(fst2);
                Dictionary<string, string> codis = getDecodificacio();

                string vocalesArchivo = sr.ReadToEnd();

                foreach (char vocal in vocalesArchivo)
                {
                    codis.TryGetValue(vocal.ToString(), out string value);
                    sw2.Write(value);
                }
                sw2.Close();
                sr.Close();
                fst2.Close();
            }
        }

        private Dictionary<string, string> getDecodificacio()
        {
            try
            {
                string directori = Path.Combine(Directory.GetCurrentDirectory(), "codificacio.txt");
                Dictionary<string, string> codis = new Dictionary<string, string>();

                using (FileStream fs = new FileStream(directori, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    char[] delims = new[] { '\r', '\n' };
                    string keypairs = sr.ReadToEnd();
                    string[] pairs = keypairs.Split(delims);

                    foreach (string line in pairs)
                    {
                        if (line != "")
                        {
                            string[] key = line.Split(':');
                            codis.Add(key[0], key[1]);
                        }
                    }
                }
                return codis;
            }
            catch
            {
                MessageBox.Show("No se encuentra el fichero de codificación");
                return codis;
            }
        }

        private void comprimirzip(object nombreArxius)
        {
            t1.Join();
            string path = Path.Combine(Directory.GetCurrentDirectory() + "\\fitxers.zip");
            string directori = Path.Combine(Directory.GetCurrentDirectory() + "\\fitxers");
            string[] files = Directory.GetFiles(directori);

            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name == "fitxers.zip")
                {
                    file.Delete();
                }
            }

            using (var archive = ZipFile.Open(path, ZipArchiveMode.Create))
            {
                foreach (var fPath in files)
                {
                    archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                }
            }
        }
    }
}
