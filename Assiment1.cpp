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
        for (int j = 0; j < img.width / 2; ++j) {


            int oppsite_j = img.width - 1 - j;
            //نلف ع الالوان التلاته عشان نبدلهم مره واحده 
            for (int c = 0;c < 3;c++) {
                int temp = img.getPixel(j, i, c);
                img.setPixel(j, i, c, img.getPixel(oppsite_j, i, c));
                img.setPixel(oppsite_j, i, c, temp);
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

void applySunlightFilter(Image& img) {
    for (int i = 0; i < img.width; ++i) {
        for (int j = 0; j < img.height; ++j) {

            int red = img.getPixel(i, j, 0);
            int green = img.getPixel(i, j, 1);
            int blue = img.getPixel(i, j, 2);

            // نظبط الالوان لاقرب حاجه بعنينا
            red = min(255, int(red * 1.1));
            green = min(255, int(green * 1.15));
            blue = min(255, int(blue * 0.75));



            img.setPixel(i, j, 0, red);
            img.setPixel(i, j, 1, green);
            img.setPixel(i, j, 2, blue);
        }
    }
}

void mergeImages(Image& img1, Image& img2, Image& resultImg) {

    int width = img1.width;
    int height = img1.height;

    resultImg.width = width;
    resultImg.height = height;

    for (int i = 0; i < width; ++i) {
        for (int j = 0; j < height; ++j) {
            for (int k = 0; k < 3; ++k) {  //بلف ع الالوان كلهم 
                int pixel1 = img1.getPixel(i, j, k);

                // بنجيب مكان البكسل المناسب ف الصوره التانيه
                int mapped_i = i * ((double)img2.width / img1.width);
                int mapped_j = j * ((double)img2.height / img1.height);

                int pixel2 = img2.getPixel(mapped_i, mapped_j, k);

                int mergedPixel = (pixel1 + pixel2) / 2;

                resultImg.setPixel(i, j, k, mergedPixel);
            }
        }
    }
}

int main()
{
    string ImageName;
    cout << "Please Write ImageName : ";
    cin >> ImageName;

    Image image(ImageName);
    if (image.width == 0 || image.height == 0) {
        cout << "Could not load image file!" << endl;
        return -1;
    }

   
    cout << "\n==============================\n";
    cout << "      IMAGE PROCESSING MENU     \n";
    cout << "==============================\n";
    cout << "1. Grayscale Filter\n";
    cout << "2. Flip Horizontally\n";
    cout << "3. Flip Vertically\n";
    cout << "4. Sunlight Filter\n";
    cout << "5. Merge Images\n";
    cout << "------------------------------\n";
    cout << "Enter your choice (1-5): ";

    int choice;
    cin >> choice;

    switch (choice) {
    case 1:
        applyGrayscale(image);
        image.saveImage("PhotoAfterFilter.jpg");
        break;

    case 2:
        ApllyFlipHorizontal(image);
        image.saveImage("PhotoAfterFilter.jpg");
        break;

    case 3:
        ApllyFlipVertically(image);
        image.saveImage("PhotoAfterFilter.jpg");
        break;

    case 4:
        applySunlightFilter(image);
        image.saveImage("PhotoAfterFilter.jpg");
        break;

    case 5: {
        string ImageName2;
        cout << "Please Write ImageName2 : ";
        cin >> ImageName2;
        Image image2(ImageName2);

        if (image2.width == 0 || image2.height == 0) {
            cout << "Could not load second image file!" << endl;
            return -1;
        }

        Image resultImg(image.width, image.height);

        mergeImages(image, image2, resultImg);
        resultImg.saveImage("PhotoAfterFilter.jpg");
        break;
    }

    default:
        cout << "Invalid choice! Please select a number from 1 to 5." << endl;
        return -1;
    }

    cout << "\nDone :-) Photo saved as PhotoAfterFilter.jpg\n";

    return 0;
}
