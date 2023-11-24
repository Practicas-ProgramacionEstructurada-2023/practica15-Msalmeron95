using System;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente { get; set; }
            public DateTime FechaCita { get; set; }
            public string? RazonConsulta { get; set; }
            public double CostoConsulta { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------CITAS PARA UNA CLINICA DENTISTA----------");
            Console.WriteLine("\nIngrese la cantidad de citas a crear: ");
            int cantidadCitas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= cantidadCitas; i++)
            {
                ConsultaMedica consulta = new ConsultaMedica();

                Console.WriteLine($"Ingrese los datos para la cita {i}: ");
                Console.WriteLine("Nombre del paciente: ");
                consulta.NombrePaciente = Console.ReadLine();

                Console.WriteLine("Fecha de la cita (DD/MM/YYYY HH:MM): ");
                consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Razon de la consulta: ");
                consulta.RazonConsulta = Console.ReadLine();

                Console.WriteLine("Costo de la consulta: ");
                consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

                //Crear el nombre del archivo segun el formato especifico
                string nombreArchivo = $"Cita{i:D3}";
                GuardarConsultaEnArchivo(consulta, nombreArchivo);
            }

            Console.WriteLine("Citas guardadas exitosamente \n");
        }

        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            //Agregar el numero de itereacion el nombre del archivo
            string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

            //Crear el contenido del archivo
            string contenido = $"Nombre del paciente: {consulta.NombrePaciente}\n" +
            $"Fecha de cita: {consulta.FechaCita}\n" +
            $"Razon de consulta: {consulta.RazonConsulta}\n" +
            $"Costo de consulta: ${consulta.CostoConsulta}";

            //Guardar el contendio en el archivo
            File.WriteAllText(nombreCompleto, contenido);

            Console.WriteLine($"\nCita guardada en el archivo: {nombreCompleto}");

        }
    }
}