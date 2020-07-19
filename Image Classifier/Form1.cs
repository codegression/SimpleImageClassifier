using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Classifier
{
    public partial class Form1 : Form
    {
        Dictionary<string, double[]> Memory = new Dictionary<string, double[]>();
        
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.label1.Text = "Drag and drop an image below.";

            Memory.Add("Banana", new double[33] {1.7938506798694075E-05,
                                                0.0010942489147203387,
                                                0.0038388404549205323,
                                                0.0045384422200696016,
                                                0.0050407204104330359,
                                                0.010583719011229505,
                                                0.039213575861945252,
                                                0.070067807555699066,
                                                0.18112510314641409,
                                                0.29894521580023681,
                                                1,
                                                0.00084310981953862163,
                                                0.0040720410433035554,
                                                0.0052739209988160582,
                                                0.0053277365192121407,
                                                0.00814408208660711,
                                                0.028522225809923581,
                                                0.047411473468948445,
                                                0.10955046101962472,
                                                0.26258386251928389,
                                                0.28992214688049367,
                                                0.852814551716715,
                                                0.048846554012843969,
                                                0.048236644781688369,
                                                0.070910917375237692,
                                                0.11956014781329602,
                                                0.1026979514225236,
                                                0.0890467477487174,
                                                0.099433143185161263,
                                                0.11469881247084993,
                                                0.042855092742080152,
                                                0.083485810641122232,
                                                0.79469378968894633 });
            Memory.Add("Blueberry", new double[33] {0.16412736799677549,
                                                0.43466344216041919,
                                                0.49875050382910119,
                                                0.73422007255139055,
                                                1,
                                                0.85538089480048363,
                                                0.29592906086255544,
                                                0.070133010882708582,
                                                0.0036275695284159614,
                                                0,
                                                0,
                                                0.10294236195082628,
                                                0.35824264409512291,
                                                0.373559048770657,
                                                0.449093107617896,
                                                0.54469971785570337,
                                                0.71551793631600158,
                                                0.74292623941958891,
                                                0.54244256348246678,
                                                0.20072551390568319,
                                                0.026440951229343007,
                                                0.0002418379685610641,
                                                0.013462313583232568,
                                                0.2241031841999194,
                                                0.21644498186215236,
                                                0.25086658605401047,
                                                0.27190648931882305,
                                                0.32099959693671909,
                                                0.3800080612656187,
                                                0.48190245868601372,
                                                0.60927045546150749,
                                                0.788391777509069,
                                                0.49947601773478434
                                                 });
            Memory.Add("Durian", new double[33] {0.01594451894066376    ,
                                                0.066609912310108155    ,
                                                0.20344562168075234 ,
                                                0.37595056195634913 ,
                                                0.76081788026889219 ,
                                                0.83345536990313529 ,
                                                0.44734305803059443 ,
                                                0.093112064858761043    ,
                                                0.038842916879863083    ,
                                                0.20448550558427581 ,
                                                0.031432503484658682    ,
                                                0.016461704042204067    ,
                                                0.072551475907334545    ,
                                                0.22219330592656633 ,
                                                0.43603666390246487 ,
                                                0.66233767665896215 ,
                                                0.799787612258941   ,
                                                0.48299574783421845 ,
                                                0.11831739506325317 ,
                                                0.078928621839546909    ,
                                                0.17483944104310389 ,
                                                0.00699026942145844 ,
                                                0.034713155248160626    ,
                                                0.41594032852832719 ,
                                                1   ,
                                                0.77026836282795486 ,
                                                0.41551797907440408 ,
                                                0.24325564161829313 ,
                                                0.0981979021472555,
                                                0.04353617869682587,
                                                0.026346666196164228,
                                                0.021847486634790126,
                                                0.0018162129258782222
                                                });
            Memory.Add("Tomato", new double[33] {0.00010980564401010212,
                                                0,
                                                0.034533875041177116,
                                                0.0696716811244098,
                                                0.024596464258262875,
                                                0.0181728340836719,
                                                0.14557483254639289,
                                                0.52816514768859124,
                                                0.33287580981662457,
                                                0.39077083562095094,
                                                1,
                                                0.00016470846601515318,
                                                0.235478203579664,
                                                0.73646645437575486,
                                                0.38415504556934227,
                                                0.19237948830569893,
                                                0.09586032722081915,
                                                0.046859558581311078,
                                                0.02124739211595476,
                                                0.0073569781486768418,
                                                0.0056549906665202595,
                                                0.818848138794334,
                                                0.60469968156363241,
                                                0.65411222136817837,
                                                0.22636433512682552,
                                                0.11428022400351379,
                                                0.061875480399692546,
                                                0.033875041177116504,
                                                0.014933567585373888,
                                                0.0068354013396288568,
                                                0.0054902822005051055,
                                                0.0040902602393763036,
                                                0.81791479082024821
                                                 });
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            double[] vector = new double[33];

            Bitmap img = null;

            try
            {
                img = new Bitmap(files[0]);               
            }
            catch
            {
                return;
            }

            pictureBox1.Image = img;

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color clr = img.GetPixel(x, y);

                    double red = (double)clr.R / 25.5;
                    double green = (double)clr.G / 25.5;
                    double blue = (double)clr.B / 25.5;

                    vector[(int)Math.Round(red)]++;
                    vector[(int)Math.Round(green) + 11]++;
                    vector[(int)Math.Round(blue) + 22]++;
                }
            }
            double max = vector.Max();
            for (int i=0; i<vector.Length; i++)
            {
                vector[i] /= max;
            }

            label1.Text = Classify(vector);

        }

        private string Classify(double[] vector)
        {
            double closest = double.PositiveInfinity;

            string answer = "";

            foreach (KeyValuePair<string, double[]> entry in Memory)
            {
                double distance = EuclideanDistance(vector, entry.Value);

                if (distance < closest)
                {
                    closest = distance;
                    answer = entry.Key;
                }
            }

            return answer;
        }

        double EuclideanDistance(double[] a, double[] b)
        {
            double max = 0;
            for (int i=0; i<a.Length; i++)
            {
                max += (a[i] - b[i]) * (a[i] - b[i]);
            }

            return Math.Sqrt(max);

        }

    }
}
