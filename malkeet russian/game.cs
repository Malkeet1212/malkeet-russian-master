using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malkeet_russian
{
    public partial class game : Form
    {
        
        public game()
        {
            InitializeComponent();
        }
        Russian RussianRoulleteobj = new Russian();
        Random numbrand = new Random();
        private void buttonload_Click(object sender, EventArgs e)
        {
            
            gamescreen.Image = malkeet_russian.Properties.Resources.load;
            System.IO.Stream str = malkeet_russian.Properties.Resources.load1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            buttonspin.Enabled = true;
            buttonload .Enabled = false;
        }

        private void buttonspin_Click(object sender, EventArgs e)
        {
            
            RussianRoulleteobj.Spinner = numbrand.Next(1, 6);

            gamescreen.Image = malkeet_russian.Properties.Resources.spin;
            System.IO.Stream str = malkeet_russian.Properties.Resources.spin1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play(); buttonshoot.Enabled = true;
            buttonspin.Enabled = false;
        }

        private void buttonshoot_Click(object sender, EventArgs e)
        {

            gamescreen.Image = malkeet_russian.Properties.Resources.shoot ;
            System.IO.Stream str = malkeet_russian.Properties.Resources.shoot1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();

            if (RussianRoulleteobj.Firedshots > 0 && RussianRoulleteobj.Spinner == 1)
            {

                MessageBox.Show("bullete fired you lost");
                //text mesaage
                buttonshoot .Enabled = false;
                buttonshootaway .Enabled = false;
                buttonspin .Enabled = false;
                buttonload.Enabled = false;



            }
            else if (RussianRoulleteobj.Firedshots > 0 && RussianRoulleteobj.Spinner != 1)
            {
                RussianRoulleteobj.Firedshots = RussianRoulleteobj.Firedshots - 1;
                RussianRoulleteobj.Spinner = RussianRoulleteobj.loadbulleteshift(RussianRoulleteobj.Spinner);
                MessageBox.Show("missed no bullete fired");                //text mesaage


            }


        }
        public int bulletemiss()
        {
            int winpoints = 0;
            if (RussianRoulleteobj.Firedshots > 0 && RussianRoulleteobj.Spinner == 1 && RussianRoulleteobj.Shootawaychance == 2)
            {

                winpoints = 10;//changes winpoint


            }
            if (RussianRoulleteobj.Firedshots > 0 && RussianRoulleteobj.Spinner == 1 && RussianRoulleteobj.Shootawaychance == 1)
            {

                winpoints = 5;//changes winpoint

            }

            else if (RussianRoulleteobj.Firedshots > 0 && RussianRoulleteobj.Spinner != 1)
            {
                winpoints = 0;//changes winpoint
                RussianRoulleteobj.Firedshots = RussianRoulleteobj.Firedshots - 1;
                RussianRoulleteobj.Spinner = RussianRoulleteobj.loadbulleteshift(RussianRoulleteobj.Spinner);



            }
            return winpoints;
        }

        private void buttonshootaway_Click(object sender, EventArgs e)
        {
            gamescreen.Image = malkeet_russian.Properties.Resources.shoot;
            System.IO.Stream str = malkeet_russian.Properties.Resources.shoot1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            int winnerscore = bulletemiss();
            if (winnerscore == 10)
            {
                MessageBox.Show("bullete fired you win score 100");//text mesaage
                buttonshoot.Enabled = false;
                buttonshootaway.Enabled = false;
                buttonspin.Enabled = false;
                buttonload.Enabled = false;

            }
            if (winnerscore == 5)
            {
                MessageBox.Show("bullete fired you win score 50");//text mesaage
                buttonshoot.Enabled = false;
                buttonshootaway.Enabled = false;
                buttonspin.Enabled = false;
                buttonload.Enabled = false;
            }
            if (winnerscore == 0)
            {

                MessageBox.Show("No bullete Fired");//text mesaage
            }
            if (RussianRoulleteobj.Firedshots == 0)
            {

                MessageBox.Show("you loose");//text mesaage
                buttonshootaway.Enabled = false;


            }
        }

        private void game_Load(object sender, EventArgs e)
        {
            buttonshoot.Enabled = false;
            buttonspin.Enabled = false;
            buttonload.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            (new game()).Show();
            this.Hide();
        }
    }
}
