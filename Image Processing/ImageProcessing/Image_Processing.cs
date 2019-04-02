using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MathNet.Numerics;
using System.Collections.Generic;


namespace ImageProcessing
{
    public partial class formImageProcessing : Form
    {
        public formImageProcessing()
        {
            InitializeComponent();
        }

        Bitmap bitmapImage;
        Color[,] ImageArray = new Color[320, 240];

        List<Bitmap> imageHistory = new List<Bitmap>();
        

        int historyPosition = 0;
        int iWidth = 320;
        int iHeight = 240;

        bool clicked;

        Point start = new Point();
        Point end = new Point();


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                Stream myStream = null;
                OpenFileDialog ofd = new OpenFileDialog();


                ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;
                ofd.Title = "Image Browser";


                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        Image newImage = Image.FromStream(myStream);
                        bitmapImage = new Bitmap(newImage, 320, 240);

                        //Clear the image history list and set the position back to 0
                        imageHistory.Clear();
                        historyPosition = 0;

                        //Add the image to the imageHistory List
                        addList();

                        

                        picImage.Image = bitmapImage;
                        myStream.Close();
                    }
                }
                //Undo set to false because first image addition shouldn't allow undo
                btnUndo.Enabled = false;
                SetArrayFromBitmap();
            } catch
            {
                MessageBox.Show("Unsupported file");

            }
            

        }
        private void SetBitmapFromArray()
        {
            for (int row = 0; row < 320; row++)
                for (int col = 0; col < 240; col++)
                {
                    bitmapImage.SetPixel(row, col, ImageArray[row, col]);
                }
        }

        private void SetArrayFromBitmap()
        {
            for (int row = 0; row < 320; row++)
                for (int col = 0; col < 240; col++)
                {
                    ImageArray[row, col] = bitmapImage.GetPixel(row, col);
                }
        }

        void addList()
        {
            //Undo always allowed after adding a new item to list except in intial add
            btnUndo.Enabled = true;

            //Redo always disallowed after adding new item list
            btnRedo.Enabled = false;

            //Adds the bitmap to image history list and sets index to the end of the list
            imageHistory.Add(new Bitmap(bitmapImage, 320, 240));

            //Clears the list from the index of the position to the end if in the middle of the list
            if ((historyPosition + 1) != imageHistory.Count)
                imageHistory.RemoveRange(historyPosition + 1, imageHistory.Count - historyPosition - 2);

            historyPosition = imageHistory.Count - 1;
        }


        private void grayScale()
        {
            //average value of RGB Sum
            int average;

            //Finds the average of each pixel and sets each pixel to their average
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];
                    
                    //Finds average of the the pixel
                    average = (col.R + col.G + col.B) / 3;
                    //Sets the pixel to the shade of grey
                    ImageArray[i, j] = Color.FromArgb(255, average, average, average);

                }
            }
        }

        private void sortArrayRow(int row, int startIndex, int endIndex)
        {
            //If the startindex is equal/greater to end, finish recursion
            if (startIndex >= endIndex)
                return;


            //Finds the average of the last pixel in the row of the array which will be set as pivot
            double pivot = (ImageArray[endIndex, row].R + ImageArray[endIndex, row].G + ImageArray[endIndex, row].B) / 3.0;


            //Code to find the index of the pivot
            int partionIndex = startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                double average = (ImageArray[i, row].R + ImageArray[i, row].G + ImageArray[i, row].B) / 3.0;

                if (average <= pivot)
                {
                    Color tempElement = ImageArray[i, row]; // Temporarily storing the element that swaps with the partionindex element
                    ImageArray[i, row] = ImageArray[partionIndex, row]; //Sets so the number lower/= to pivot is set to where the pivot index is
                    ImageArray[partionIndex, row] = tempElement; // Number > than pivot index is ahead of pivot index

                    partionIndex++; // Add 1 to partition index so its between the number behind it and the number ahead of it
                }

            }

            //Make partition at partition index
            Color temp = ImageArray[partionIndex, row]; // temporarily stores the element at partition index
            ImageArray[partionIndex, row] = ImageArray[endIndex, row]; //Sets so the number at pivotindex is set to pivot
            ImageArray[endIndex, row] = temp; // Number > than pivot index is ahead of pivot index


            //Recursively calls partitioned array lower/equal to pivot and greater than
            sortArrayRow(row, startIndex, partionIndex - 1);
            sortArrayRow(row, partionIndex + 1, endIndex);




        }

        private int[,] getGaussKernel(int size)
        {
            // 2d kernel of given size
            int[,] kernelGauss = new int[size, size];

            //The horizontal and vertical matrix which multiply to approximate a gaussian kernel
            int[] pascalMatrix = new int[size];

            //Creates the matrix of pascals triangle
            for (int i = 0; i < size; i++)
            {
                //n in nCr to find pascals triangle
                int n;

                //n = size-1 as pascals triangle is zero bases
                n = size - 1;

                //Finds the element in pascals triangle using Choose Function
                pascalMatrix[i] = (int)((SpecialFunctions.Factorial(n)) / (SpecialFunctions.Factorial(i) * SpecialFunctions.Factorial(n - i)));
            }


            //Multiplies the matrices to get the kernel
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernelGauss[i, j] = pascalMatrix[i] * pascalMatrix[j];
                }
            }

            return kernelGauss;
        }

        private double findSobelPixel(Color[,] tempArray, int row, int col)
        {
            
            // Kernel to check for vertical edges
                int[,] verticalSobelKernel = new int[,] {{ 1, 2, 1 },
                                                         { 0, 0, 0 },
                                                         {-1,-2,-1 }};
            // Kernel to check for horizontal edges
                int[,] horizontalSobelKernel = new int[,] { { -1, 0, 1 },
                                                            { -2, 0, 2 }, 
                                                            { -1, 0, 1 } };

            //Sum of the kernel convolution of x and y
                double sumX = 0, sumY = 0;
                double gradientSum;
                
            //Applies kernel convolution
                for (int j = -1; j <= 1; j++)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        sumX += tempArray[row + j, col + i].R * horizontalSobelKernel[j + 1, i + 1];
                        sumY += tempArray[row + j, col + i].R * verticalSobelKernel[j + 1, i + 1];
                    }
                }

                //Divides by 4 so range is in 0-255

                sumX /= 4;
                sumY /= 4;

                //Returns the magnitude of both the x and y
                gradientSum = Math.Sqrt((sumX * sumX) + (sumY * sumY));

                
                return gradientSum;
        }


        //Finds the kernel convolution when the kernel wraps around end of image
        private Color findGaussEdgePixel(Color[,] tempArray, int[,] kernel, int row, int col)
        {
            //sum of RGB during kernel convolution
            int sumR = 0, sumG = 0, sumB = 0;
            
            //Defaults to the regular limits on a 3*3 gaussian kernel
            int left = -1, right = 1, up = -1, down = 1;
            int localKernelSum = 0;

            //Sets the new limits dependent on how the limit is affected by its position in the image
            if ((col - 1) <= 0)
            {
                left -= (col - 1);

            }
            else if ((col + 1) >= 240)
            {
                right -= (col + 1) - 239;
            }

            if ((row - 1) <= 0)
            {
                up -= (row - 1);

            }
            else if ((row + 1) >= 320)
            {
                down -= (row + 1) - 319;
            }


            //Applies kernel convolution with new limits
            for (int i = up; i <= down; i++)
            {
                for (int j = left; j <= right; j++)
                {
                    sumR += tempArray[row + i, col + j].R * kernel[i + 1, j + 1];
                    sumG += tempArray[row + i, col + j].G * kernel[i + 1, j + 1];
                    sumB += tempArray[row + i, col + j].B * kernel[i + 1, j + 1];

                    //Adds the current kernel value to find the kernel sum with the new limits
                    localKernelSum += kernel[i + 1, j + 1];
                }
            }

            //Return the color divided by sum so image not brightened or darkened
            return Color.FromArgb(255, sumR / localKernelSum, sumG / localKernelSum, sumB / localKernelSum);


        }

        private Color findGaussPixel(Color[,] tempArray, int[,] kernel, int row, int col)
        {
                //Sum of RGB of each pixel after kernel convolution
                int sumR = 0, sumG = 0, sumB = 0;
            

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        sumR += tempArray[row + i, col + j].R * kernel[i + 1, j + 1];
                        sumG += tempArray[row + i, col + j].G * kernel[i + 1, j + 1];
                        sumB += tempArray[row + i, col + j].B * kernel[i + 1, j + 1];
                    }
                }

                //Returns colour divided by sum of kernel so image not lighter or darker
                return Color.FromArgb(255, sumR / 16, sumG / 16, sumB / 16);

        }

        private void findBitmap()
        {
            

            //Temp start point to store
            Point temp = new Point(start.X, start.Y);

            //Finds the beginning and end of the rectangle that's being zoomed on
            if (end.X < start.X)
            {
                start.X = end.X;
                end.X = temp.X;

            }

            if (end.Y < start.Y)
            {
                start.Y = end.Y;
                end.Y = temp.Y;
            }

            //Bitmap of Zoomed Rectangle
            Bitmap zoomedImage = new Bitmap(end.X - start.X, end.Y - start.Y);

            //Sets the zoomed image to a subset of the original image
            for (int i = 0; i < (end.X-start.X); i++)
            {
                for (int j = 0; j < (end.Y-start.Y); j++)
                {
                    zoomedImage.SetPixel(i,j,bitmapImage.GetPixel(i+start.X, j+start.Y));
                }
            }

            //Sets bitmapImage to the zoomes image to 320*240 dimensions
            bitmapImage = new Bitmap(zoomedImage, 320, 240);
            picImage.Image = bitmapImage;
            SetArrayFromBitmap();

            //Add the image to the imageHistory List
            addList();

        }
        private void btnTransform_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;
            
            Byte Green;


            //Extracts the green channel of a pixel and assign the color only to green channel

            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    //Get the green element of the color
                    Green = col.G;

                    Color newColor = Color.FromArgb(255, 0, Green, 0);
                    ImageArray[i, j] = newColor;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }


        private void Negative_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;
            
            int R, G, B;

            //Finds the negative of the RGB channels of each pixel
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    R = 255 - col.R;
                    G = 255 - col.G;
                    B = 255 - col.B;

                    ImageArray[i, j] = Color.FromArgb(R, G, B);

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void Lighten_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;


            int R, G, B;

            //Adds 20 to RGB of each pixel unless it increases past 255, then equals 255
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    if ((col.R + 20) < 255)
                        R = col.R + 20;
                    else
                        R = 255;
                    if ((col.G + 20) < 255)
                        G = col.G + 20;
                    else
                        G = 255;
                    if ((col.B + 20) < 255)
                        B = col.B + 20;
                    else
                        B = 255;


                    ImageArray[i, j] = Color.FromArgb(255, R, G, B);

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void Darken_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;


            int R, G, B;

            //Decreases each channel by 20 unless it would decrease past 0, then equals 0
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    if ((col.R - 20) > 0)
                        R = col.R - 20;
                    else
                        R = 0;
                    if ((col.G - 20) > 0)
                        G = col.G - 20;
                    else
                        G = 0;
                    if ((col.B - 20) > 0)
                        B = col.B - 20;
                    else
                        B = 0;


                    ImageArray[i, j] = Color.FromArgb(255, R, G, B);

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Traverses throughout the width and half the height
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight / 2; j++)
                {
                    //Sets a temp pixel of the current pixel
                    Color tempPixel = ImageArray[i, j];

                    //Set the current pixel to the equivalent pixel on the opposite horizontal and vertical side and sets that to temp pixel
                    ImageArray[i, j] = ImageArray[iWidth - i - 1, iHeight - j - 1];
                    ImageArray[iWidth - i - 1, iHeight - j - 1] = tempPixel;


                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Sets the image to grayscale
            grayScale();

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();

        }

        private void btnTransformRed_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;
            
            Byte Red;


            // The code extracts the red channel of a pixel and assign the color only to red channel
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    //Gets the red element of the color
                    Red = col.R;

                    Color newColor = Color.FromArgb(255, Red, 0, 0);
                    ImageArray[i, j] = newColor;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnTransformBlue_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            // Process the array data here

            Byte Blue;


            // The sample code extracts the blue channel of a pixel and assign the color only to blue channel

            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    //Get the blue element of the color
                    Blue = col.B;

                    Color newColor = Color.FromArgb(255, 0, 0, Blue);
                    ImageArray[i, j] = newColor;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnPolarize_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Average of the RGB of the whole image
            int Ravg = 0, Gavg = 0, Bavg = 0, R, B, G;

            //Finds the sum of the RGB channels of each pixel in the image
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    Ravg += col.R;
                    Gavg += col.G;
                    Bavg += col.B;

                }
            }

            //Finds the average of each value
            Ravg = Ravg / (iWidth * iHeight);
            Gavg = Gavg / (iWidth * iHeight);
            Bavg = Bavg / (iWidth * iHeight);



            //Checks if each pixel is less or greater than the image average, sets to 0 or 255 accordingly
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    if (col.R <= Ravg)
                        R = 0;
                    else
                        R = 255;

                    if (col.G <= Gavg)
                        G = 0;
                    else
                        G = 255;

                    if (col.B <= Bavg)
                        B = 0;
                    else
                        B = 255;

                    ImageArray[i, j] = Color.FromArgb(255, R, G, B);

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnSunset_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            
            double R, G, B;

            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    Color col = ImageArray[i, j];

                    //Multiplies the R channel to increase red value unless > 255, then equals 255
                    R = col.R * 1.54;

                    if (R > 255)
                    {
                        R = 255;
                    }
                    //G is left alone
                    G = col.G;

                    //B multiplies by 0.45 to limit blue of sky
                    B = col.B * 0.45;


                    ImageArray[i, j] = Color.FromArgb(255, (int)R, (int)G, (int)B);

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();


        }

        private void btnVerticalFlip_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Traverses throughout top half of image array
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight / 2; j++)
                {
                    //Stores current pixel
                    Color tempPixel = ImageArray[i, j];

                    //Sets the current pixel to the opposite bottom side and sets that to current pixel
                    ImageArray[i, j] = ImageArray[i, iHeight - j - 1];
                    ImageArray[i, iHeight - j - 1] = tempPixel;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnHorizontalFlip_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Traverses through left half of image
            for (int i = 0; i < iWidth / 2; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //Stores the current pixel
                    Color tempPixel = ImageArray[i, j];

                    //Sets the current pixel to the opposite right side and sets that to current pixel
                    ImageArray[i, j] = ImageArray[iWidth - i - 1, j];
                    ImageArray[iWidth - i - 1, j] = tempPixel;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Sets a temp array that isn't changed by the kernel
            Color[,] tempArray = new Color[320, 240];

            //Sets a temp array that's unaffected by kernel convolution
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    tempArray[i, j] = ImageArray[i, j];
                }
            }

            //Gets the gaussian kernel
            int[,] kernelGauss = new int[3, 3];
            kernelGauss = getGaussKernel(3);

            Color averageRGB = Color.FromArgb(255, 0, 0, 0);

           
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        /* If statement checking if the 3*3 kernel would wrap past the edge of the image
                     * Putting a try and catch in the method itself takes very long (~30ms each time method is called)
                     * 
                     */
                        if ((i == 0) || (i == iWidth - 1) || (j == 0) || (j == iHeight - 1))
                            ImageArray[i, j] = findGaussEdgePixel(tempArray, kernelGauss, i, j);
                        else
                            ImageArray[i, j] = findGaussPixel(tempArray, kernelGauss, i, j); 

                    }
                }
            


            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //The amount needed to go from top left to bottom right
            int widthAdd = iWidth / 2;
            int heightAdd = iHeight / 2;

            //Adds bottom right to top left

            for (int i = 0; i < widthAdd; i++)
            {
                for (int j = 0; j < heightAdd; j++)
                {

                    //The current pixel colours of a pixel in the top left
                    Color topRightInitial = ImageArray[i, j];

                    //Replaces the top left pixel with its bottom right equivalent
                    ImageArray[i, j] = ImageArray[(widthAdd + i), (heightAdd + j)];

                    //Replaces the the bottom right pixel with the previously stored top left pixel
                    ImageArray[(widthAdd + i), (heightAdd + j)] = topRightInitial;

                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnPixellate_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            //Finds the top left pixel of each 8*8 block and then sets each pixel to that block pixel
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {

                    ImageArray[i, j] = ImageArray[i - (i % 8), j - (j % 8)];
                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();

        }

        private void btnScrolling_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;
            
            //Left block of the image
            Color[,] leftSideBlock = new Color[40, 240];

            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //Adds the pixel to the left array if on first 40 columns of image
                    if (i < 40)
                    {
                        leftSideBlock[i, j] = ImageArray[i, j];
                    }

                    //If less than last 40 columns of image, just set current pixel to the pixel 40 columns away
                    if (i < 280)
                    {
                        ImageArray[i, j] = ImageArray[i + 40, j];
                    }
                    else
                    {
                        //If in last 40 columns, set pixel to corresponding pixel from left side
                        ImageArray[i, j] = leftSideBlock[i - 280, j];
                    }

                }
            }


            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;


            //Sorts each row
            for (int i = 0; i < iHeight; i++)
            {
                sortArrayRow(i, 0, iWidth - 1);
            }



            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();
        }

        private void btnEdgeDetection_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            // Make the image grayscale for edge detection
            grayScale();


            //Sets a temp array that isn't changed by the kernel
            Color[,] tempArray = new Color[320, 240];

            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    tempArray[i, j] = ImageArray[i, j];
                }
            }

            //Blur the image with a Gaussian blur to remove the noise
            int[,] kernelGauss = new int[3, 3];
            kernelGauss = getGaussKernel(3);

            Color averageRGB = Color.FromArgb(255, 0, 0, 0);


            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    /* If statement checking if the 3*3 kernel would wrap past the edge of the image
                 * Putting a try and catch in the method itself takes very long (~30ms each time method is called)
                 * 
                 */
                    if ((i == 0) || (i == iWidth - 1) || (j == 0) || (j == iHeight - 1))
                        ImageArray[i, j] = findGaussEdgePixel(tempArray, kernelGauss, i, j);
                    else
                        ImageArray[i, j] = findGaussPixel(tempArray, kernelGauss, i, j);

                }
            }




            //Creates and applies the sobel kernel for edge detection 

            double edgePixelValue;
            


            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    /* If statement checking if the 3*3 kernel would wrap past the edge of the image
                     * Putting a try and catch in the method itself takes very long (~30ms each time method is called)
                     * 
                     */
                    if ((i == 0) || (i == iWidth - 1) || (j == 0) || (j == iHeight - 1))
                        edgePixelValue = ImageArray[i, j].R;
                    else
                        edgePixelValue = findSobelPixel(tempArray, i, j);
                    

                    ImageArray[i, j] = Color.FromArgb(255, (int)edgePixelValue, (int)edgePixelValue, (int)edgePixelValue);

                    

                }
            }
            

            SetBitmapFromArray();
            picImage.Image = bitmapImage;

            //Add the image to the imageHistory List
            addList();


        }

        private void formImageProcessing_Load(object sender, EventArgs e)
        {

        }
        

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;

            
                picImage.Image = new Bitmap(imageHistory[historyPosition - 1]);
                bitmapImage = new Bitmap(imageHistory[historyPosition - 1]);
                SetArrayFromBitmap();

                historyPosition--;

                //If at end of image history, then can no longer undo
                if (historyPosition == 0)
                {
                    btnUndo.Enabled = false;
                }

            //If in middle of stream because of undo, redo allowed
            btnRedo.Enabled = true;
            

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            //Check against no image
            if (bitmapImage == null)
                return;


            picImage.Image = new Bitmap(imageHistory[historyPosition +1]);
            bitmapImage = new Bitmap(imageHistory[historyPosition + 1]);
            SetArrayFromBitmap();

            historyPosition++;

            //Redo always allowed after redoing something
            btnUndo.Enabled = true;

            //If at front of image history, then can no longer redo
            if (historyPosition == imageHistory.Count-1)
            {
                btnRedo.Enabled = false;
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            //Checks that there's an image and user wants to zoom
            if (bitmapImage == null || chBoxZoom.Checked == false)
                return;
            
            //Checking for first vs second click
                if (clicked == false)
                {
                    start = picImage.PointToClient(Cursor.Position);
                    clicked = true;

                lblZoomNotification.Text = "Zoom Started";
                }
                else
                {
                    end = picImage.PointToClient(Cursor.Position);

                //Check to make sure they're not zooming on a 0 by 0 part of the image
                    if (start.X != end.X)
                    {
                        clicked = false;
                        findBitmap();
                    lblZoomNotification.Text = "";
                    }
                }
            
        }

        private void chBoxZoom_CheckedChanged(object sender, EventArgs e)
        {
            //If checkbox not checked, defaults zoom values
            if (chBoxZoom.Checked == false)
            {
                clicked = false;
                lblZoomNotification.Text = "";
            }
        }

        private void btnZoomQuestion_Click(object sender, EventArgs e)
        {
            //Textreader to get instructions from file
            TextReader tr = new StreamReader("zoominstructions.txt");
            string instructions = tr.ReadToEnd();
            tr.Close();

            //Messagebox to show instructions
            MessageBox.Show(instructions);

            
        }
    }
}
