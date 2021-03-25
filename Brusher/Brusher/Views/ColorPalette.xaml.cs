using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brusher.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPalette : ContentPage
    {
        public String ColorDesplegado= "#000000";
        public bool SiHex;
        public ColorPalette()
        {
            
            InitializeComponent();
            ColorAleatorio();
        }
        public bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\#\b[0-9a-fA-F]+\b\Z");
        }
        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
           if(txtColor.Text== null)
            {
                DisplayAlert("Alerta", "Ingrese un color Hexadecimal Valido", "OK");
            }
            else
            {
                ColorDesplegado = txtColor.Text;
                SiHex = OnlyHexInString(ColorDesplegado);
            }
         
           if(SiHex==true)
            {

                NombreHex.Text = ColorDesplegado.ToUpper();
            CambioDeColor(ColorDesplegado);
            }
            else
            {
                DisplayAlert("Alerta", "Ingrese un color Hexadecimal Valido", "OK");
            }

        }

        public void CambioDeColor(string ColorDesplegado)
        {
            Line1.BackgroundColor = ColorConverters.FromHex(ColorDesplegado);
            Line2.BackgroundColor = ColorConverters.FromHex(ColorDesplegado).WithHue(30);
            Line3.BackgroundColor = ColorConverters.FromHex(ColorDesplegado).WithAlpha(30);
            Line4.BackgroundColor = ColorConverters.FromHex(ColorDesplegado).WithLuminosity(30);
            Line5.BackgroundColor = ColorConverters.FromHex(ColorDesplegado).WithSaturation(30);
            DesplegarInfo(ColorDesplegado);


        }

        public void DesplegarInfo(string ColorDesplegado)
        {
            String Hex;

            Color RGB = ColorConverters.FromHex(ColorDesplegado);
            Hex = String.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * RGB.R),(int)(255 * RGB.G),(int)(255 * RGB.B));
            Line1.Text = "Original color \n" + Convert.ToString(ColorConverters.FromHex(ColorDesplegado)) +Hex;
            
            RGB = ColorConverters.FromHex(ColorDesplegado).WithHue(30);
            Hex = String.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * RGB.R), (int)(255 * RGB.G), (int)(255 * RGB.B));
            Line2.Text = "WithHue \n" + Convert.ToString(ColorConverters.FromHex(ColorDesplegado).WithHue(30) + Hex);

            RGB = ColorConverters.FromHex(ColorDesplegado).WithAlpha(30);
            Hex = String.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * RGB.R), (int)(255 * RGB.G), (int)(255 * RGB.B));
            Line3.Text = "WithAlpha \n" + Convert.ToString(ColorConverters.FromHex(ColorDesplegado).WithAlpha(30) + Hex);

            RGB = ColorConverters.FromHex(ColorDesplegado).WithLuminosity(30);
            Hex = String.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * RGB.R), (int)(255 * RGB.G), (int)(255 * RGB.B));
            Line4.Text = "WithLuminosity \n" + Convert.ToString(ColorConverters.FromHex(ColorDesplegado).WithLuminosity(30) + Hex);

            RGB = ColorConverters.FromHex(ColorDesplegado).WithSaturation(30);
            Hex = String.Format(" #{0:X2}{1:X2}{2:X2}", (int)(255 * RGB.R), (int)(255 * RGB.G), (int)(255 * RGB.B));
            Line5.Text = "WithSaturation \n" + Convert.ToString(ColorConverters.FromHex(ColorDesplegado).WithSaturation(30) + Hex);
        }
        public void ColorAleatorio()
        {
            String color;
            Random aleatorio = new Random();
            Color ColorRandom = Color.FromRgb(aleatorio.Next(0, 255), aleatorio.Next(0, 255), aleatorio.Next(0, 255));
            color = String.Format("#{0:X2}{1:X2}{2:X2}", (int)(255 * ColorRandom.R), (int)(255 * ColorRandom.G), (int)(255 * ColorRandom.B));
            NombreHex.Text = color;

            CambioDeColor(color);
        }
        private void btnAleatorio_Clicked(object sender, EventArgs e)
        {
            ColorAleatorio();
        }
    }
}