// Tumakov
using System;

namespace Dz5
{
    class Tumakov
    {
        public static void Main(string[] args)
        {
            /* #1 Написать программу, которая вычисляет число гласных и согласных букв в
            файле. Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            заносится в массив символов. Количество гласных и согласных букв определяется проходом
            по массиву. Предусмотреть метод, входным параметром которого является массив символов.
            Метод вычисляет количество гласных и согласных букв. */
            Console.WriteLine("Номер 1: ");
            string filePath = "Bykvs.txt";
            try
            {
                List<char> characters = new List<char>(File.ReadAllText(filePath));
                int vglasCount, soglasCount;
                CountGlasAndSoglas(characters, out vglasCount, out soglasCount);
                Console.WriteLine($"Количество гласных: {vglasCount}");
                Console.WriteLine($"Количество согласных: {soglasCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            Console.WriteLine();
            /* #2 Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица). */
            Console.WriteLine("Номер 2: ");
            int[,] matrixA =
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            int[,] matrixB =
            {
                {7, 8},
                {9, 10},
                {11, 12}
            };

            Console.WriteLine("Матрица A:");
            PrintMatrix(matrixA);

            Console.WriteLine("Матрица B:");
            PrintMatrix(matrixB);

            // Умножение матриц
            int[,] result = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(result);
            Console.WriteLine();
            /* #3 Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур. Полученный массив средних температур отсортировать по
            возрастанию. */
            Console.WriteLine("Номер 3: ");
            Random random = new Random();
            int[,] temperature = new int[12, 30]; 
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-30, 41);
                }
            }
            double[] monthlyAverages = CalculateMonthlyAverages(temperature);
            Console.WriteLine("Средние температуры для каждого месяца:");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {monthlyAverages[i]:F2}°C");
            }
            Array.Sort(monthlyAverages);
            Console.WriteLine("\nСредние температуры после сортировки:");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {monthlyAverages[i]:F2}°C");
            }
            Console.WriteLine();
        }
        // #1
        static void CountGlasAndSoglas(List<char> chars, out int glasCount, out int soglasCount)
        {
            glasCount = 0;
            soglasCount = 0;

            foreach (char ch in chars)
            {
                if (IsGlas(ch))
                    glasCount++;
                else if (IsSoglas(ch))
                    soglasCount++;
            }
        }
        static bool IsGlas(char ch)
        {
            return "АаЕеЁёУуЕеЫыЯяИиОоЭэЮю".Contains(ch);
        }
        static bool IsSoglas(char ch)
        {
            return "БбВвГгДдЖжЗзКкЛлМмНнПпРрСсТтФфХхЦцЧчШшЩщЪъЬь".Contains(ch);
        }
        // #2
        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);
            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Матрицы не могут быть умножены. Количество столбцов первой матрицы не равно количеству строк второй.");
            }
            int[,] result = new int[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
        // #3
        static double[] CalculateMonthlyAverages(int[,] temperature)
        {
            double[] averages = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double totalTemperature = 0;

                for (int day = 0; day < 30; day++)
                {
                    totalTemperature += temperature[month, day];
                }

                averages[month] = totalTemperature / 30.0; // Средняя температура месяца
            }

            return averages;
        }
    }
}
