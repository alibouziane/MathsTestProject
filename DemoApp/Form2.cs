using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            var eleves = new List<Eleve>
            {
                new Eleve {Name="Albert",FirstName ="Dupont" },
                new Eleve {Name="Christine",FirstName ="Veille" },
                new Eleve {Name="Thomas",FirstName ="Lacoste" }
            };

            var classe = new Classe();
            classe.Eleves.AddRange(eleves);

            var listClasses = new List<Classe> { classe };
            //Récupérer les élèves dont le nom commence par A
            //1.- Depuis List<Eleve>


            var result = eleves.Where(el => el.Name.StartsWith("A"));


            //2. - Depuis List<Classe> (sans foreach)
            var result2 = listClasses.SelectMany(c => c.Eleves.Where(eleve => eleve.Name.StartsWith("A")));





        }
    }

    public class Eleve
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
    }

    public class Classe
    {
        public List<Eleve> Eleves { get; set; }
    }
}
