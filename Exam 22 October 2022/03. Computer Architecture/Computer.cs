using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>(capacity);
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Count >= Capacity)
                return;

            Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
            => Multiprocessor.Remove(GetCPU(brand));

        public CPU MostPowerful()
            => Multiprocessor.OrderByDescending(cpu => cpu.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand)
            => Multiprocessor.FirstOrDefault(cpu => cpu.Brand == brand);

        public string Report()
            => $"CPUs in the Computer {Model}:\n" +
               string.Join(Environment.NewLine, Multiprocessor);
    }
}
