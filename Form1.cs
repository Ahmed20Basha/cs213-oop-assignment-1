using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Last_Submission
{
    public partial class Form1 : Form
    {
        //الجسر بين اللغتين 
        [DllImport("c++.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void applyFilter(string imagePath, int filterChoice, int extraParam, string imagePath2);
        string currentImagePath = "";

        //للماوس
        private bool isSelecting = false;
        private Rectangle cropRectangle;
        private Point startPoint;
        private bool isCropModeActive = false;
        public Form1()
        {
            InitializeComponent();
            cmbRotate.Items.Add("90");
            cmbRotate.Items.Add("180");
            cmbRotate.Items.Add("270");

            cmbRotate.SelectedIndex = 0;


            pictureBoxAfter.MouseDown += PictureBoxAfter_MouseDown;
            pictureBoxAfter.MouseMove += PictureBoxAfter_MouseMove;
            pictureBoxAfter.MouseUp += PictureBoxAfter_MouseUp;
            pictureBoxAfter.Paint += PictureBoxAfter_Paint;
        }
        private void CropImageAction(Rectangle rect)
        {
            if (pictureBoxAfter.Image == null) return;

            // 1. حساب النسبة والتناسب بين عرض الصورة في الـ PictureBox وحجمها الحقيقي بالبيكسل
            using (Bitmap sourceBmp = new Bitmap(pictureBoxAfter.Image))
            {
                double ratioX = (double)sourceBmp.Width / pictureBoxAfter.ClientSize.Width;
                double ratioY = (double)sourceBmp.Height / pictureBoxAfter.ClientSize.Height;

                int realX = (int)(rect.X * ratioX);
                int realY = (int)(rect.Y * ratioY);
                int realWidth = (int)(rect.Width * ratioX);
                int realHeight = (int)(rect.Height * ratioY);

                // التأكد من عدم تجاوز حدود الصورة الحقيقية
                realX = Math.Max(0, Math.Min(realX, sourceBmp.Width - 1));
                realY = Math.Max(0, Math.Min(realY, sourceBmp.Height - 1));
                realWidth = Math.Min(realWidth, sourceBmp.Width - realX);
                realHeight = Math.Min(realHeight, sourceBmp.Height - realY);

                if (realWidth <= 10 || realHeight <= 10) return;

                Rectangle realRect = new Rectangle(realX, realY, realWidth, realHeight);

                // 2. قص الجزء المحدد بالماوس بدقة تامة باستخدام الـ Bitmap Clone
                using (Bitmap croppedBmp = sourceBmp.Clone(realRect, sourceBmp.PixelFormat))
                {
                    string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");

                    // تفريغ الصورة القديمة لمنع مشكلات الـ GDI+ ولينفتح الملف
                    pictureBoxAfter.Image.Dispose();
                    pictureBoxAfter.Image = null;

                    // حفظ الصورة المقصوصة في الملف المؤقت (لتدعم التعديل التراكمي بعد ذلك)
                    croppedBmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                    // 3. عرض الصورة المقصوصة في الـ PictureBox After
                    using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                    {
                        pictureBoxAfter.Image = new Bitmap(stream);
                    }
                }
            }

            // إعادة تعيين وضع الكروب وإغلاقه تلقائياً بعد الانتهاء
            isCropModeActive = false;
            btCrop.BackColor = SystemColors.Control;
            cropRectangle = Rectangle.Empty;
        }
        // 1. لما المستخدم يضغط كليك شمال عشان يبدأ يرسم مستطيل الـ Crop
        private void PictureBoxAfter_MouseDown(object sender, MouseEventArgs e)
        {
            // شغال فقط لو زرار الـ Crop مفعل أو المستخدم في وضع الـ Crop
            if (e.Button == MouseButtons.Left)
            {
                isSelecting = true;
                startPoint = e.Location;
                cropRectangle = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        // 2. وهو ماشي بالماوس (بيسحب عشان يوسع المستطيل)
        private void PictureBoxAfter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(startPoint.X - e.X);
                int height = Math.Abs(startPoint.Y - e.Y);

                cropRectangle = new Rectangle(x, y, width, height);

                // إعادة رسم الصورة عشان يظهر المستطيل فوقها مباشرة
                pictureBoxAfter.Invalidate();
            }
        }

        // 3. لما يشيل إيده من على الماوس (انتهى من تحديد المكان اللي عايز يقصه)
        private void PictureBoxAfter_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                isSelecting = false;

                if (cropRectangle.Width > 10 && cropRectangle.Height > 10) // التأكد أن المستطيل مش صغير جداً
                {
                    // تنفيذ القص الفعلي
                    CropImageAction(cropRectangle);
                }
            }
        }

        // 4. رسم المستطيل المنقط أو الشفاف فوق الصورة أثناء السحب
        private void PictureBoxAfter_Paint(object sender, PaintEventArgs e)
        {
            if (isSelecting || (cropRectangle.Width > 0 && cropRectangle.Height > 0))
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; // خط منقط للإيحاء بالتحديد
                    e.Graphics.DrawRectangle(pen, cropRectangle);
                }
            }
        }


        private async void ApplyFilterAndShow(int filterChoice, int extraParam = 0, string imagePath2 = "")
        {
            if (!string.IsNullOrEmpty(currentImagePath))
            {
                string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");

                if (pictureBoxAfter.Image != null)
                {
                    
                    using (Bitmap tempBmp = new Bitmap(pictureBoxAfter.Image))
                    {
                        
                        pictureBoxAfter.Image.Dispose();
                        pictureBoxAfter.Image = null;

                     
                        tempBmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                else
                {
                   
                    File.Copy(currentImagePath, targetPath, true);
                }

               
                await Task.Run(() =>
                {
                    applyFilter(targetPath, filterChoice, extraParam, imagePath2);
                });

                
                using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                {
                    pictureBoxAfter.Image = new Bitmap(stream);
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // تحديد أنواع الملفات المسموح بها (صور فقط)
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 2. حفظ المسار الصحيح في المتغير
                currentImagePath = openFileDialog1.FileName;

                // 3. عرض الصورة في الـ PictureBox Before بطريقة آمنة لا تقفل الملف
                if (pictureBoxBefore.Image != null)
                {
                    pictureBoxBefore.Image.Dispose();
                }

                using (var stream = new MemoryStream(File.ReadAllBytes(currentImagePath)))
                {
                    pictureBoxBefore.Image = new Bitmap(stream);
                }

                // مسح خانة الـ After عند اختيار صورة جديدة
                if (pictureBoxAfter.Image != null)
                {
                    pictureBoxAfter.Image.Dispose();
                    pictureBoxAfter.Image = null;
                }
            }

        }

        private void btCLear_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image != null)
            {
                pictureBoxAfter.Image.Dispose();
                pictureBoxAfter.Image = null;
            }

            if (!string.IsNullOrEmpty(currentImagePath))
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(currentImagePath)))
                {
                    pictureBoxAfter.Image = new Bitmap(stream);
                }
            }
        }

        private async void btGrayscale_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(1, 0);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image != null)
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    saveFileDialog1.Title = "Save Processed Image";
                    saveFileDialog1.FileName = "edited_image";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // الحل هنا: إنشاء Bitmap جديدة كنسخة مستقلة تماماً عن المصدر القديم لتجنب قفل GDI+
                            using (Bitmap bmp = new Bitmap(pictureBoxAfter.Image))
                            {
                                bmp.Save(saveFileDialog1.FileName);
                            }

                            MessageBox.Show("تم حفظ الصورة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حدث خطأ أثناء الحفظ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("لا توجد صورة معدلة لحفظها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btBlackWhite_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(2);
        }

        private void btInvert_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(3);
        }

        private void btOilPainting_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(18);
        }

        private void InfraredFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(16);
        }

        private void btPurpleFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(15);
        }

        private void TVEffect_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(14);
        }

        private void SunlightFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(13);
        }

        private void btFlipH_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(5, 0);
        }

        private void btFlipV_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image != null)
            {
                // 1. أخذ نسخة من الصورة الحالية
                using (Bitmap bmp = new Bitmap(pictureBoxAfter.Image))
                {
                    // 2. قلب الصورة رأسياً (RotateNoneFlipY)
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // 3. حفظها في الملف المؤقت لتظل تراكمية
                    string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");
                    pictureBoxAfter.Image.Dispose();
                    pictureBoxAfter.Image = null;
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                    // 4. عرضها في الـ PictureBox
                    using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                    {
                        pictureBoxAfter.Image = new Bitmap(stream);
                    }
                }
            }
        }

        

       

        private void btSkewFilter_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image == null)
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // إظهار نافذة صغيرة لإدخال قيمة الإمالة
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "أدخل زاوية الإمالة (مثل 15 أو 30):",
                "فلتر الإمالة - Skew",
                "15"
            );

            // إذا كتب المستخدم رقماً وضغط OK
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int skewValue))
                {
                    // إرسال الرقم المدخل للـ C++ عبر دالة المعالجة
                    ApplyFilterAndShow(17, skewValue);
                }
                else
                {
                    MessageBox.Show("من فضلك أدخل رقماً صحيحاً!", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btDetectEdges_Click(object sender, EventArgs e)
        {
            ApplyFilterAndShow(10);
        }

        private void btMergeImages_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentImagePath))
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "اختر الصورة الثانية للدمج";
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilterAndShow(9, 0, ofd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر الصورة الأساسية أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btResize_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image == null)
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. طلب العرض الجديد
            string wInput = Microsoft.VisualBasic.Interaction.InputBox("أدخل عرض الصورة الجديد (Width):", "تغيير الحجم - Resize", pictureBoxAfter.Image.Width.ToString());
            if (string.IsNullOrEmpty(wInput)) return;

            // 2. طلب الارتفاع الجديد
            string hInput = Microsoft.VisualBasic.Interaction.InputBox("أدخل ارتفاع الصورة الجديد (Height):", "تغيير الحجم - Resize", pictureBoxAfter.Image.Height.ToString());
            if (string.IsNullOrEmpty(hInput)) return;

            if (int.TryParse(wInput, out int newWidth) && int.TryParse(hInput, out int newHeight))
            {
                if (newWidth > 0 && newHeight > 0)
                {
                    // تنفيذ الـ Resize بـ GDI+ في C# لضمان الجودة والدقة العالية بدون تشوه
                    using (Bitmap originalBmp = new Bitmap(pictureBoxAfter.Image))
                    {
                        using (Bitmap resizedBmp = new Bitmap(newWidth, newHeight))
                        {
                            using (Graphics g = Graphics.FromImage(resizedBmp))
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                g.DrawImage(originalBmp, 0, 0, newWidth, newHeight);
                            }

                            // حفظ في الملف المؤقت لضمان التراكمية مع الفلاتر الأخرى
                            string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");
                            pictureBoxAfter.Image.Dispose();
                            pictureBoxAfter.Image = null;
                            resizedBmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                            using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                            {
                                pictureBoxAfter.Image = new Bitmap(stream);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("يجب أن تكون الأبعاد أكبر من الصفر!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("من فضلك أدخل أرقام صحيحة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btBrightness_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image == null)
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("أدخل نسبة التفتيح (من 1 إلى 100):", "تفتيح الصورة", "20");
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int val))
            {
                if (val > 0 && val <= 100)
                {
                    ApplyFilterAndShow(7, val); // إرسال القيمة للـ C++ للتفتيح
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة بين 1 و 100", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCrop_Click(object sender, EventArgs e)
        {
            isCropModeActive = !isCropModeActive; // تبديل الحالة (تشغيل / إيقاف)

            if (isCropModeActive)
            {
                MessageBox.Show("تم تفعيل وضع القص! اضغط واسحب بالماوس على الصورة لتحديد الجزء المطلوب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btCrop.BackColor = Color.LightGreen; // إعطاء لون مميز للزرار ليدل على أنه نشط
            }
            else
            {
                btCrop.BackColor = SystemColors.Control; // رجوع اللون الطبيعي
            }
        }

        private void Blur_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image == null)
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // نافذة إدخال تفاعلية تتيح لك كتابة قوة البلور بنفسك بدلاً من القيمة الثابتة
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "أدخل قوة الضبابية (Radius):",
                "فلتر الضبابية - Blur",
                "5"
            );

            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int blurStrength))
                {
                    if (blurStrength >= 0)
                    {
                        
                        ApplyFilterAndShow(12, blurStrength); 
            }
                    else
                    {
                        MessageBox.Show("يجب أن تكون القيمة أكبر من أو تساوي الصفر!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("من فضلك أدخل رقماً صحيحاً!", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btAddFrame_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image != null)
            {
                using (Bitmap bmp = new Bitmap(pictureBoxAfter.Image))
                {
                    int frameSize = 35; // سمك الإطار

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // رسم إطار خارجي عريض (لون أبيض كلاسيكي)
                        using (Pen outerPen = new Pen(Color.White, frameSize))
                        {
                            g.DrawRectangle(outerPen, frameSize / 2f, frameSize / 2f, bmp.Width - frameSize, bmp.Height - frameSize);
                        }

                        // رسم خط رفيع محيط للحدود ليعطي شكلاً جمالياً واضحاً
                        using (Pen innerPen = new Pen(Color.Black, 2))
                        {
                            g.DrawRectangle(innerPen, frameSize, frameSize, bmp.Width - (frameSize * 2), bmp.Height - (frameSize * 2));
                        }
                    }

                    // حفظ التعديل في الملف المؤقت ليدعم العمليات التراكمية
                    string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");
                    pictureBoxAfter.Image.Dispose();
                    pictureBoxAfter.Image = null;
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                    // عرض الصورة بعد التعديل
                    using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                    {
                        pictureBoxAfter.Image = new Bitmap(stream);
                    }
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ADDframe2_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image != null)
            {
                using (Bitmap bmp = new Bitmap(pictureBoxAfter.Image))
                {
                    int frameSize = 45; // سمك أكبر للإطار الثاني

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // إطار خارجي عريض
                        using (Pen outerPen = new Pen(Color.White, frameSize))
                        {
                            g.DrawRectangle(outerPen, frameSize / 2f, frameSize / 2f, bmp.Width - frameSize, bmp.Height - frameSize);
                        }

                        // خط فاصل مميز بلون مميز (مثل الأزرق الداكن أو الرمادي الفاخر)
                        using (Pen borderPen = new Pen(Color.DarkBlue, 4))
                        {
                            g.DrawRectangle(borderPen, frameSize - 6, frameSize - 6, bmp.Width - ((frameSize - 6) * 2), bmp.Height - ((frameSize - 6) * 2));
                        }
                    }

                    string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");
                    pictureBoxAfter.Image.Dispose();
                    pictureBoxAfter.Image = null;
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                    using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                    {
                        pictureBoxAfter.Image = new Bitmap(stream);
                    }
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBoxAfter_Click(object sender, EventArgs e)
        {

        }

        private void btCrop_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBoxAfter_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (!isCropModeActive) return;

            if (e.Button == MouseButtons.Left)
            {
                isSelecting = true;
                startPoint = e.Location;
                cropRectangle = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        private void btrotate_Click(object sender, EventArgs e)
        {
            if (cmbRotate.SelectedItem != null && int.TryParse(cmbRotate.SelectedItem.ToString(), out int degree))
            {
                ApplyFilterAndShow(6, degree);
            }
        }

        private void cmbRotate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btDarken_Click(object sender, EventArgs e)
        {
            if (pictureBoxAfter.Image == null)
            {
                MessageBox.Show("من فضلك اختر صورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("أدخل نسبة التغميق (من 1 إلى 100):", "تغميق الصورة", "20");
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int val))
            {
                if (val > 0 && val <= 100)
                {
                    float x = val / 100.0f;

                    using (Bitmap bmp = new Bitmap(pictureBoxAfter.Image))
                    {
                        
                        for (int i = 0; i < bmp.Width; i++)
                        {
                            for (int j = 0; j < bmp.Height; j++)
                            {
                                Color c = bmp.GetPixel(i, j);
                                int r = (int)(c.R * (1 - x));
                                int g = (int)(c.G * (1 - x));
                                int b = (int)(c.B * (1 - x));
                                bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                            }
                        }

                        // حفظ في الملف المؤقت لدعم العمليات التراكمية
                        string targetPath = Path.Combine(Path.GetTempPath(), "processed_temp_image.png");
                        pictureBoxAfter.Image.Dispose();
                        pictureBoxAfter.Image = null;
                        bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);

                        using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)))
                        {
                            pictureBoxAfter.Image = new Bitmap(stream);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة بين 1 و 100", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
