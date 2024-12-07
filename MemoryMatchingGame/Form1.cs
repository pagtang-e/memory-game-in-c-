                           
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MemoryMatchingGame
{

   

    public partial class GameWindow : Form
    {
        
        Random location = new Random(); 
        List<Point> points = new List<Point>();
        List<PictureBox> calosc= new List<PictureBox>();
        PictureBox PendingImage1; 
        PictureBox PendingImage2;
        bool turn = false;
        int summ = 0;
        
        object iloscOkien;

        public static GameWindow instance;
        public Label name1;
        public Label name2;
        public GameWindow(object okna)
        {
            InitializeComponent();
            instance = this;
            name1 = ScoreLabel;
            name2 = label3;
            iloscOkien = okna;
            
        }

       

        private void GameWindow_Load(object sender, EventArgs e)
        {
             summ = 0;
            if (calosc.Count == 0)
            {
                foreach (PictureBox picture in CardsHolder.Controls)
            {


                
                calosc.Add(picture);
                


            }

               
                for (int i = 0; i < 24 - 2 * Convert.ToInt32(iloscOkien); i++)
                {

                    CardsHolder.Controls.Remove(calosc[0]);
                    calosc.Remove(calosc[0]);

                }
                
            }
               

            ScoreCounter.Text = "0";
            ScoreNumber2.Text = "0";
            label1.Text = "5";
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                

                    picture.Enabled = false;
                    points.Add(picture.Location);

                
               
            }
            foreach (PictureBox picture in CardsHolder.Controls)
            {
               

                int next = location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);

                
                   
            }

            timer2.Start();
            timer1.Start();
            Card1.Image = Properties.Resources.Card1;
            DupCard1.Image = Properties.Resources.Card1;
            Card2.Image = Properties.Resources.Card2;
            DupCard2.Image = Properties.Resources.Card2;
            Card3.Image = Properties.Resources.Card3;
            DupCard3.Image = Properties.Resources.Card3;
            Card4.Image = Properties.Resources.Card4;
            DupCard4.Image = Properties.Resources.Card4;
            Card5.Image = Properties.Resources.Card5;
            DupCard5.Image = Properties.Resources.Card5;
            Card6.Image = Properties.Resources.Card6;
            DupCard6.Image = Properties.Resources.Card6;
            Card7.Image = Properties.Resources.Card7;
            DupCard7.Image = Properties.Resources.Card7;
            Card8.Image = Properties.Resources.Card8;
            DupCard8.Image = Properties.Resources.Card8;
            Card9.Image = Properties.Resources.Card9;
            DupCard9.Image = Properties.Resources.Card9;
            Card10.Image = Properties.Resources.Card10;
            DupCard10.Image = Properties.Resources.Card10;
            Card11.Image = Properties.Resources.Card11;
            DupCard11.Image = Properties.Resources.Card11;
            Card12.Image = Properties.Resources.Card12;
            DupCard12.Image = Properties.Resources.Card12;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.Cover;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label1.Text);
            timer = timer-1;
            label1.Text = Convert.ToString(timer);
            if (timer == 0)
            {
                timer2.Stop();
            }
        }

        
        private void Check(PictureBox pic, Bitmap image)
        {

            pic.Image = image;
            if (PendingImage1 == null)
            {
                PendingImage1 = pic;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = pic;

                foreach (PictureBox picture in CardsHolder.Controls)
                {
                    picture.Enabled = false;
                 }
            }


            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)

                {
                    PendingImage1.Visible =  false;
                    PendingImage2.Visible = false;
                    PendingImage1 = null;
                    PendingImage2 = null;

                    foreach (PictureBox picture in CardsHolder.Controls)
                    {
                        picture.Enabled = true;
                    }

                    if (turn == false)
                    {
                        
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 1);
                        summ++;
                    }
                    else
                    {

                        
                        ScoreNumber2.Text = Convert.ToString(Convert.ToInt32(ScoreNumber2.Text) + 1);
                        summ++;

                    }
                    if( summ  >= Convert.ToInt32(iloscOkien))
                    {

                        

                        if (Convert.ToInt32(ScoreCounter.Text) > Convert.ToInt32(ScoreNumber2.Text))
                        {

                            MessageBox.Show("wygrywa gracz " + name1.Text + " z ilością punktów " + ScoreCounter.Text);

                        }
                        else {

                            MessageBox.Show("wygrywa gracz " + name2.Text + " z ilością punktów " + ScoreNumber2.Text);

                        }
                        Form2 f1 = new Form2();

                        f1.Show();
                        this.Hide();

                    }
                    
                }
                else
                {
                    if (turn == false)
                    {
                        tura.Text = "tura gracza 2";
                        turn = true;
                    }
                    else {

                        tura.Text = "tura gracza 1";
                        turn = false;

                    }
                    timer3.Start();
                    
                }
            }

        }


       



#region Cards
private void Card1_Click(object sender, EventArgs e)
        {
            
           Check(Card1 , Properties.Resources.Card1);
        }
        private void DupCard1_Click(object sender, EventArgs e)
        {
            Check(DupCard1, Properties.Resources.Card1);
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            
            Check(Card2, Properties.Resources.Card2);
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            
            Check(DupCard2, Properties.Resources.Card2);
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Check(Card3, Properties.Resources.Card3);
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            Check(DupCard3, Properties.Resources.Card3);
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Check(Card4, Properties.Resources.Card4);
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            Check(DupCard4, Properties.Resources.Card4);
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Check(Card5, Properties.Resources.Card5);
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            Check(DupCard5, Properties.Resources.Card5);
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Check(Card6, Properties.Resources.Card6);
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            Check(DupCard6, Properties.Resources.Card6);
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Check(Card7, Properties.Resources.Card7);
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            Check(DupCard7, Properties.Resources.Card7);
        }
        

        private void Card8_Click(object sender, EventArgs e)
        {
            Check(Card8, Properties.Resources.Card8);
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            Check(DupCard8, Properties.Resources.Card8);
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Check(Card9, Properties.Resources.Card9);
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            Check(DupCard9, Properties.Resources.Card9);
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Check(Card10, Properties.Resources.Card10);
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            Check(DupCard10, Properties.Resources.Card10);
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Check(Card11, Properties.Resources.Card11);
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            Check(DupCard11, Properties.Resources.Card11);
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Check(Card12, Properties.Resources.Card12);
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            Check(DupCard12, Properties.Resources.Card12);
        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = true;
            }
            timer3.Stop();
            PendingImage1.Image = Properties.Resources.Cover;
            PendingImage2.Image = Properties.Resources.Cover;
            PendingImage1 = null;
            PendingImage2 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Visible = true;
            }
            GameWindow_Load(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();

            f1.Show();
            this.Hide();
        }
    }
}
