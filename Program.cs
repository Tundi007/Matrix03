using MyData;
using MathNet.Numerics.Statistics;
using MathNet.Numerics;

string[][] csvRawData_String2DArray = IData.CSVDataRead_Function("weight-height.csv");

double[][] csvData_Double2DArray =
[
    [.. IData.Parse2Double_Function(csvRawData_String2DArray, 1).ToList().Order()],
    [.. IData.Parse2Double_Function(csvRawData_String2DArray, 2).ToList().Order()],
];

IEnumerable<double> height_DoubleIEnumerable = csvData_Double2DArray[0].AsEnumerable();

IEnumerable<double> weight_DoubleIEnumerable = csvData_Double2DArray[1].AsEnumerable();

Histogram histogram1 = new(height_DoubleIEnumerable,12);

Histogram histogram2 = new(weight_DoubleIEnumerable,12);

Console.Clear();

System.Console.WriteLine("Height Histogram Buckets:");

Console.WriteLine(histogram1);

System.Console.WriteLine("--------------------------------\n\nWeight Histogram Buckets:");

Console.WriteLine(histogram2);

System.Console.WriteLine("--------------------------------\n\nBest Fitted Line:");

(double c_Double,double d_Double) = Fit.Line(csvData_Double2DArray[0],csvData_Double2DArray[1]);

System.Console.WriteLine($"Intercept = {c_Double} & Slope = {d_Double}");

System.Console.WriteLine($"Line: {c_Double} + {d_Double}*t");

System.Console.WriteLine("--------------------------------\n\nBest Fitted Parabole:");

double[] bestFittingP_DoubleArray = Fit.Polynomial(csvData_Double2DArray[0],csvData_Double2DArray[1],2);

System.Console.WriteLine($"Constant = {bestFittingP_DoubleArray[0]} & 1st Order = {bestFittingP_DoubleArray[1]} & 2nd Order = {bestFittingP_DoubleArray[2]}");

System.Console.WriteLine($"Parabole: {bestFittingP_DoubleArray[0]} + {bestFittingP_DoubleArray[1]}*t + {bestFittingP_DoubleArray[2]}*t^2");