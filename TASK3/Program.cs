
using System.Drawing;
using System.IO;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шлях до вхідної папки з зображеннями
            string inputPath = @"C:\InputImages\";

            // Шлях до вихідної папки з обробленими зображеннями
            string outputPath = @"C:\OutputImages\";

            // Розмір, до якого будуть змінюватися зображення
            int size = 500;

            // Функція для зміни розміру зображення
            Func<Bitmap, Bitmap> resizeFunction = (bitmap) =>
            {
                Bitmap resized = new Bitmap(bitmap, new Size(size, size));
                return resized;
            };

            // Функція для збереження зображення
            Action<Bitmap> saveFunction = (bitmap) =>
            {
                // Генеруємо унікальне ім'я файлу для збереження
                string fileName = Guid.NewGuid().ToString() + ".jpg";

                // Зберігаємо зображення у вихідну папку з унікальним іменем
                bitmap.Save(outputPath + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            };

            // Отримуємо список файлів з вхідної папки
            string[] files = Directory.GetFiles(inputPath);

            // Обробляємо кожен файл за допомогою делегатів
            foreach (string file in files)
            {
                // Завантажуємо зображення з файлу
                Bitmap image = new Bitmap(file);

                // Застосовуємо функцію для зміни розміру зображення
                Bitmap resizedImage = resizeFunction(image);

                // Застосовуємо функцію для збереження зображення
                saveFunction(resizedImage);
            }

            Console.WriteLine("Зображення успішно оброблені та збережені.");
        }
    }
}

