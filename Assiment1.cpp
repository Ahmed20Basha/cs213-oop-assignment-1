#include "Image_Class.h"
#include <iostream>
using namespace std;

void applyGrayscale(Image& img) {
    //هنلف ع البكسلات كلها  
    for (int i = 0; i < img.width; ++i) {
        for (int j = 0; j < img.height; ++j) {
            //  بنقرأ قيم الألوان الثلاثة (R, G, B) للبكسل الحالي
             int red = img.getPixel(i, j, 0);
             int green = img.getPixel(i, j, 1);
             int blue = img.getPixel(i, j, 2);

            //   متوسط الألوان عشان نجيب درجة الرمادي 
             int average = (red + green + blue) / 3;

            //  قيمة المتوسط ف كل الالوان
            img.setPixel(i, j, 0, average); // احمر
            img.setPixel(i, j, 1, average); // اخضر
            img.setPixel(i, j, 2, average); // ازرق
        }
    }
}

void  ApllyFlipHorizontal(Image& img) {
    //هنمشي لحد النص بس عشان منرجعش ننقل بكسلات مكانها تاني   
    for (int i = 0; i < img.height; ++i) {
        for (int j = 0; j < img.width/2; ++j) {

         
            int oppsite_j = img.width - 1 - j;
            //نلف ع الالوان التلاته عشان نبدلهم مره واحده 
            for (int c = 0;c < 3;c++) {
                int temp = img.getPixel(j, i, c);
                img.setPixel(j,i,c,img.getPixel(oppsite_j,i,c));
                img.setPixel(oppsite_j,i,c,temp);
            }
        }
    }


}

void ApllyFlipVertically(Image& img) {
    for (int i = 0;i < img.height / 2;i++) {
        int oppsite_i = img.height - 1 - i;
        for (int j = 0;j < img.width;j++) {

            for (int c = 0; c < 3; ++c) {
                int temp = img.getPixel(j, i, c);
                img.setPixel(j, i, c, img.getPixel(j, oppsite_i, c));
                img.setPixel(j, oppsite_i, c, temp);
            }
        }
    }
}


int main()
{
    string ImageName;
    cout << "Please Write ImageName  : ";
    cin >> ImageName;

    Image image(ImageName);

   // cout << "Image Width: " << image.width << " | Height: " << image.height << endl; // سطر للاختبار
    if (image.width == 0 || image.height == 0) {
        cout << "Could not load image file!" << endl;
        return -1;
    }
    //applyGrayscale(image);
    
     //ApllyFlipHorizontal(image);
   
    ApllyFlipVertically(image);
    
    //ممكن اغير اسم الملف والامتداد 
    image.saveImage("PhotoAfterFilter.jpg");

    cout << "Done :-) \n";

    return 0;
}
