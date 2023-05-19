using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fieldSize = 10; // Размер поля
            const int bombCount = 15; // Количество мин

            char[,] field = GenerateField(fieldSize, bombCount);
            bool[,] revealed = new bool[fieldSize, fieldSize];

            bool gameOver = false;

            while (!gameOver)
            {
                PrintField(field, revealed);

                Console.WriteLine("Введите координаты клетки (строка, столбец):");
                string[] input = Console.ReadLine().Split();
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (field[row, col] == '*')
                {
                    Console.WriteLine("Бум! Вы проиграли.");
                    gameOver = true;
                }
                else
                {
                    RevealCell(row, col, field, revealed);
                    if (CheckWin(field, revealed, bombCount))
                    {
                        Console.WriteLine("Поздравляем! Вы выиграли!");
                        gameOver = true;
                    }
                }
            }

            Console.WriteLine("Игра окончена. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Функция для генерации игрового поля
        static char[,] GenerateField(int size, int bombs)
        {
            char[,] field = new char[size, size];

            // Заполняем поле пустыми клетками
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = ' ';
                }
            }

            // Расставляем мины на поле
            Random random = new Random();
            int bombsToPlace = bombs;
            while (bombsToPlace > 0)
            {
                int row = random.Next(size);
                int col = random.Next(size);

                if (field[row, col] == ' ')
                {
                    field[row, col] = '*';
                    bombsToPlace--;
                }
            }

            return field;
        }

        // Функция для печати игрового поля
        static void PrintField(char[,] field, bool[,] revealed)
        {
            int size = field.GetLength(0);

            Console.WriteLine();
            Console.WriteLine("    " + string.Join(" ", GetNumberRange(size)));

            for (int i = 0; i < size; i++)
            {
                Console.Write(i + " | ");
                for (int j = 0; j < size; j++)
                {
                    if (revealed[i, j])
                    {
                        Console.Write(field[i, j]);
                    }
                    else
                    {
                        Console.Write('#');
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Функция для получения диапазона чисел
        static int[] GetNumberRange(int size)
        {
            int[] range = new int[size];
            for (int i = 0; i < size; i++)
            {
                range[i] = i;
            }
            return range;
        }

        // Функция для открытия клетки
        static void RevealCell(int row, int col, char[,] field, bool[,] revealed)
        {
            int size = field.GetLength(0);

            if (row < 0 || row >= size || col < 0 || col >= size || revealed[row, col])
                return;

            revealed[row, col] = true;

            if (field[row, col] == ' ')
            {
                RevealCell(row - 1, col - 1, field, revealed);
                RevealCell(row - 1, col, field, revealed);
                RevealCell(row - 1, col + 1, field, revealed);
                RevealCell(row, col - 1, field, revealed);
                RevealCell(row, col + 1, field, revealed);
                RevealCell(row + 1, col - 1, field, revealed);
                RevealCell(row + 1, col, field, revealed);
                RevealCell(row + 1, col + 1, field, revealed);
            }
        }

        // Функция для проверки победы
        static bool CheckWin(char[,] field, bool[,] revealed, int bombCount)
        {
            int size = field.GetLength(0);
            int revealedCount = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (revealed[i, j])
                    {
                        revealedCount++;
                    }
                }
            }

            int totalCells = size * size;
            int nonBombCells = totalCells - bombCount;

            return revealedCount == nonBombCells;
        }
    }
}


