using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bio3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Bitmap image, imageMonochrome, imageBlurimageDeduction, imageOtsuBinarization, imageFilter, imageBlur, imageDeduction;

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.tiff)|*.jpg; *.jpeg; *.gif; *.bmp; *.tiff";
            if (op.ShowDialog() == true)
            {
                image = new Bitmap(File.OpenRead(op.FileName));
            }
            BitmapImage myBitmapImage = new BitmapImage();
            using (var stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read))
            {
                myBitmapImage.BeginInit();
                myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                myBitmapImage.StreamSource = stream;
                myBitmapImage.EndInit();
            }
            ImagePhoto.Source = myBitmapImage;
            image = new Bitmap(image, image.Width/6, image.Height/6);
            imageMonochrome = new Bitmap(image);
            imageBlur = new Bitmap(image);
            imageDeduction = new Bitmap(image);
            imageOtsuBinarization = new Bitmap(image);
            imageFilter = new Bitmap(image);
        }

        private void Monochrome_Click(object sender, RoutedEventArgs e)
        {
            Monochrome monochrome = new Monochrome();
            imageMonochrome = monochrome.ReplacementForGray(imageMonochrome);
            setImage(imageMonochrome);
            image=imageMonochrome;
        }

        private void Blur_Click(object sender, RoutedEventArgs e)
        {
            Blur blur = new Blur();
            imageBlur=blur.BlurImage(imageBlur);
            setImage(imageBlur);
            image=imageBlur;
        }

        private void Deduction_Click(object sender, RoutedEventArgs e)
        {
            Deduction deduction = new Deduction();
            imageDeduction = deduction.DeductionImage(imageBlur ,imageMonochrome);
            setImage(imageDeduction);
            image=imageDeduction;
        }
        private void Otsu_Click(object sender, RoutedEventArgs e)
        {
            OtsuBinarization otsuBinarization = new OtsuBinarization();
            imageOtsuBinarization = otsuBinarization.Binarization(imageDeduction);
            setImage(imageOtsuBinarization);
            image=imageBlurimageDeduction;
        }
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Filter filter = new Filter();
            imageFilter = filter.FilterM(3,imageOtsuBinarization); //masak 3x3
            setImage(imageFilter);
            image=imageFilter;
        }

        private void setImage(Bitmap bmp)
        {
            using (var memory = new MemoryStream())
            {
                bmp.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                ImagePhoto.Source = bitmapImage;
            }
        }
        private void Safe_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePhoto.Source == null)
            {
                MessageBox.Show("Błąd z zapisem.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image files (*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpeg;*.png;*.bmp;*.gif;*.tiff|All Files (*.*)|*.*";

            string path = string.Empty;
            if (saveFileDialog.ShowDialog() == true)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    image.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;

                    switch (path.Substring(path.LastIndexOf('.') + 1))
                    {
                        case "jpeg":
                            JpegBitmapEncoder jpegEncoder = new JpegBitmapEncoder();
                            jpegEncoder.Frames.Add(BitmapFrame.Create(memory));
                            jpegEncoder.Save(stream);
                            break;

                        case "png":
                            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
                            pngEncoder.Frames.Add(BitmapFrame.Create(memory));
                            pngEncoder.Save(stream);
                            break;

                        case "bmp":
                            BmpBitmapEncoder bitmapEncoder = new BmpBitmapEncoder();
                            bitmapEncoder.Frames.Add(BitmapFrame.Create(memory));
                            bitmapEncoder.Save(stream);
                            break;

                        case "gif":
                            GifBitmapEncoder gifEncoder = new GifBitmapEncoder();
                            gifEncoder.Frames.Add(BitmapFrame.Create(memory));
                            gifEncoder.Save(stream);
                            break;

                        case "tiff":
                            TiffBitmapEncoder tiffEncoder = new TiffBitmapEncoder();
                            tiffEncoder.Frames.Add(BitmapFrame.Create(memory));
                            tiffEncoder.Save(stream);
                            break;
                    }
                }
            }
            MessageBox.Show("Zapisano pomyślnie");
        }
    }

}
