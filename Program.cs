using System;

class Program
{
    // Phương thức nhập liệu cho mảng
    public static int[] ReadArray()
    {
        int size;
        while (true)
        {
            Console.Write("Enter the number of elements in the array (max 100): ");
            if (Int32.TryParse(Console.ReadLine(), out size) && size > 0 && size <= 100)
            {
                break; // Thoát vòng lặp nếu đầu vào hợp lệ
            }
            Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
        }

        // Khởi tạo mảng và nhập các phần tử
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                Console.Write($"Enter element {i + 1}: ");
                if (Int32.TryParse(Console.ReadLine(), out arr[i]))
                {
                    break; // Thoát vòng lặp nếu đầu vào hợp lệ
                }
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        return arr;
    }

    // Phương thức in ra mảng
    public static void PrintArray(int[] array)
    {
        Console.WriteLine("Array elements:");
        Console.WriteLine(string.Join(" ", array));
    }

    // Phương thức tìm chỉ số của phần tử cần xoá
    public static int FindIndex(int[] array, int valueToDelete)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == valueToDelete)
            {
                return i;
            }
        }
        return -1; // Trả về -1 nếu không tìm thấy phần tử
    }

    // Phương thức thực hiện xoá phần tử khỏi mảng
    public static int[] DeleteElement(int[] array, int valueToDelete)
    {
        int index = FindIndex(array, valueToDelete);

        if (index == -1)
        {
            Console.WriteLine("Element not found in the array.");
            return array; // Trả về mảng không thay đổi nếu phần tử không được tìm thấy
        }

        // Tạo mảng mới với kích thước giảm 1
        int[] newArray = new int[array.Length - 1];
        
        // Sao chép các phần tử trước và sau vị trí cần xoá
        Array.Copy(array, 0, newArray, 0, index);
        Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);

        return newArray;
    }

    public static void Main(string[] args)
    {
        // Nhập dữ liệu cho mảng
        int[] arr = ReadArray();

        // In mảng trước khi xoá
        Console.WriteLine("Original array:");
        PrintArray(arr);

        // Nhập giá trị cần xoá và xử lý lỗi nhập liệu
        int valueToDelete;
        while (true)
        {
            Console.Write("Enter the element to delete: ");
            if (Int32.TryParse(Console.ReadLine(), out valueToDelete))
            {
                break; // Thoát vòng lặp nếu đầu vào hợp lệ
            }
            Console.WriteLine("Invalid input. Please enter an integer.");
        }

        // Xoá phần tử khỏi mảng
        int[] newArr = DeleteElement(arr, valueToDelete);

        // In mảng sau khi xoá
        Console.WriteLine("Array after deletion:");
        PrintArray(newArr);
    }
}

