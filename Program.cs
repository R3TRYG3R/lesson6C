using System.Text.Json;

abstract class Transport
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Year { get; set; }
    public double MaxSpeed { get; set; }

    protected Transport(string type, string brand, string model, double year, double maxSpeed)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Year = year;
        MaxSpeed = maxSpeed;
    }

    public abstract void ShowInfo();
    public abstract void Move();
}

class Car : Transport
{
    public string FuelType {get; set;}
    
    public Car(string type, string brand, string model, double year, double maxSpeed, string fuel_type) : base(type, brand, model, year, maxSpeed)
    {
        FuelType = fuel_type;
        Type = "Car";
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Type: {0}", Type);
        Console.WriteLine("Brand: {0}", Brand);
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Year: {0}", Year);
        Console.WriteLine("Max Speed: {0}", MaxSpeed);
        Console.WriteLine("Fuel Type: {0}", FuelType);
    }

    public override void Move()
    {
        Console.WriteLine($"Car {Brand} {Model} is driving on the road until {MaxSpeed} km/h. ");
    }
}

class Truck : Transport
{
    public int LoadCapacity { get; set; }
    
    public Truck(string type, string brand, string model, double year, double maxSpeed, int load_capacity) : base(type, brand, model, year, maxSpeed)
    {
        LoadCapacity = load_capacity;
        Type = "Truck";
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Type: {0}", Type);
        Console.WriteLine("Brand: {0}", Brand);
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Year: {0}", Year);
        Console.WriteLine("Max Speed: {0}", MaxSpeed);
        Console.WriteLine("Load Capacity: {0}", LoadCapacity);
    }

    public override void Move()
    {
        Console.WriteLine($"Truck {Brand} {Model} care drop.");
    }
}

class Bike : Transport
{
    public bool HasSidecar { get; set; }
    
    public Bike(string type, string brand, string model, double year, double maxSpeed, bool has_side_car) : base(type, brand, model, year, maxSpeed)
    {
        HasSidecar = has_side_car;
        Type = "Bike";
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Type: {0}", Type);
        Console.WriteLine("Brand: {0}", Brand);
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Year: {0}", Year);
        Console.WriteLine("Max Speed: {0}", MaxSpeed);
        Console.WriteLine("Has Sidecar: {0}", HasSidecar);
    }

    public override void Move()
    {
        Console.WriteLine($"Bike {Brand} {Model} move on the road.");
    }
}

class Bus : Transport
{
    public int PassengerCapacity{get; set;}
    
    public Bus(string type, string brand, string model, double year, double maxSpeed, int passenger_capacity) : base(type, brand, model, year, maxSpeed)
    {
        PassengerCapacity = passenger_capacity;
        Type = "Bus";
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Type: {0}", Type);
        Console.WriteLine("Brand: {0}", Brand);
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Year: {0}", Year);
        Console.WriteLine("Max Speed: {0}", MaxSpeed);
        Console.WriteLine("Passenger Capacity: {0}", PassengerCapacity);
    }

    public override void Move()
    {
        Console.WriteLine($"Bike {Brand} {Model} is carrying passengers.");
    }
}



class Program
{
    
    static void Main(string[] args)
    {
        List<Transport> transports = new List<Transport>();
        string type, brand, model, fuel_type;
        bool has_sidecar = false, running = true;

        while (running)
        {
            Console.WriteLine("Choose a type of transport:");
            Console.WriteLine("1. Truck");
            Console.WriteLine("2. Bike");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Car");
            Console.WriteLine("5. Show all transports");
            Console.WriteLine("6. Launch transport");
            Console.WriteLine("7. Delete transport");
            Console.WriteLine("8. Filter transports by type");
            Console.WriteLine("9. Save to file");
            Console.WriteLine("10. Load from file");
            Console.WriteLine("11. Exit");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Invalid input. Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter the type of Truck:");
                    type = Console.ReadLine();
                    Console.WriteLine("Enter the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Enter the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter the year:");
                    if (int.TryParse(Console.ReadLine(), out int truck_year))
                    {
                        Console.WriteLine("Enter the max speed:");
                        if (double.TryParse(Console.ReadLine(), out double truck_max_speed))
                        {
                            Console.WriteLine("Enter the capacity:");
                            if (int.TryParse(Console.ReadLine(), out int truck_capacity))
                            {
                                transports.Add(new Truck(type, brand, model, truck_year, truck_max_speed,
                                    truck_capacity));
                                Console.WriteLine("Truck added successfully.");
                                break;
                            }
                        }
                    }

                    Console.WriteLine("Invalid input. Try again.");
                    break;
                case 2:
                    Console.WriteLine("Enter the type of bike:");
                    type = Console.ReadLine();
                    Console.WriteLine("Enter the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Enter the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter the year:");
                    if (int.TryParse(Console.ReadLine(), out int bike_year))
                    {
                        Console.WriteLine("Enter the max speed:");
                        if (int.TryParse(Console.ReadLine(), out int bike_max_speed))
                        {
                            Console.WriteLine("Has your bike have sidecar?[y/n]: ");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                has_sidecar = true;
                            }
                            else if (Console.ReadLine().ToLower() == "n")
                            {
                                has_sidecar = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Try again.");
                                break;
                            }

                            transports.Add(new Bike(type, brand, model, bike_year, bike_max_speed, has_sidecar));
                            Console.WriteLine("Bike added successfully.");
                            break;
                        }
                    }

                    Console.WriteLine("Invalid input. Try again.");
                    break;
                case 3:
                    Console.WriteLine("Enter the type of bus:");
                    type = Console.ReadLine();
                    Console.WriteLine("Enter the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Enter the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter the year:");
                    if (int.TryParse(Console.ReadLine(), out int bus_year))
                    {
                        Console.WriteLine("Enter the max speed:");
                        if (int.TryParse(Console.ReadLine(), out int bus_max_speed))
                        {
                            Console.WriteLine("Enter the passenger capacity:");
                            if (int.TryParse(Console.ReadLine(), out int passenger_capacity))
                            {
                                transports.Add(new Bus(type, brand, model, bus_year, bus_max_speed,
                                    passenger_capacity));
                                Console.WriteLine("Bus added successfully.");
                                break;
                            }
                        }
                    }

                    Console.WriteLine("Invalid input. Try again.");
                    break;
                case 4:
                    Console.WriteLine("Enter the type of car:");
                    type = Console.ReadLine();
                    Console.WriteLine("Enter the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Enter the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter the year:");
                    if (int.TryParse(Console.ReadLine(), out int car_year))
                    {
                        Console.WriteLine("Enter the max speed:");
                        if (int.TryParse(Console.ReadLine(), out int car_max_speed))
                        {
                            Console.WriteLine("Enter the fuel type:");
                            fuel_type = Console.ReadLine();
                            transports.Add(new Car(type, brand, model, car_year, car_max_speed, fuel_type));
                            Console.WriteLine("Car added successfully.");
                            break;
                        }
                    }

                    Console.WriteLine("Invalid input. Try again.");
                    break;
                case 5:
                    if (transports.Count > 0)
                    {
                        foreach (var transport in transports)
                        {
                            transport.ShowInfo();
                            Console.WriteLine();
                        }   
                        break;
                    }
                    Console.WriteLine("Empty transport. Try again.");
                    break;
                case 6:
                    int counter_for_launch = 0;
                    foreach (var transport in transports)
                    {
                        counter_for_launch++;
                        Console.WriteLine($"Transport №{counter_for_launch}:");
                        transport.ShowInfo();
                        Console.WriteLine();
                    }

                    if (transports.Count > 0)
                    {
                        Console.Write("Enter the number of transport you would like to run: ");
                        if (int.TryParse(Console.ReadLine(), out int user_choice_for_launch) && user_choice_for_launch > 0 && user_choice_for_launch <= transports.Count)
                        {
                            transports[user_choice_for_launch - 1].Move();
                            break;
                        }
                    
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }
                    
                    Console.WriteLine("Empty transports. Try again.");
                    break;
                case 7:
                    int counter_for_delete = 0, user_choice_for_delete;
                    foreach (var transport in transports)
                    {
                        counter_for_delete++;
                        Console.WriteLine($"Transport №{counter_for_delete}:");
                        transport.ShowInfo();
                        Console.WriteLine();
                    }

                    if (transports.Count > 0)
                    {
                        Console.WriteLine("Enter the number of transport you would like to delete: ");
                        if (int.TryParse(Console.ReadLine(), out user_choice_for_delete) && user_choice_for_delete > 0 && user_choice_for_delete <= transports.Count)
                        {
                            transports.RemoveAt(user_choice_for_delete - 1);
                            Console.WriteLine("Transport removed successfully.");
                            break;
                        }
                    
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }
                    
                    Console.WriteLine("Empty transports. Try again.");
                    break;
                case 8:
                    Console.WriteLine("Enter the type of transport to filter (e.g., Car, Truck, Bike, Bus):");
                    string filterType = Console.ReadLine();

                    var filteredTransports = transports.Where(t => t.GetType().Name.Equals(filterType, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (filteredTransports.Count > 0)
                    {
                        foreach (var transport in filteredTransports)
                        {
                            transport.ShowInfo();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No transports of type '{filterType}' found.");
                    }
                    break;
                case 9:
                    
                    if (transports.Count > 0)
                    {
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true // Для более читаемого JSON
                        };
                        var json_for_serialize = JsonSerializer.Serialize(transports, options);
                        File.WriteAllText("transports.json", json_for_serialize);
                        Console.WriteLine("Transports saved successfully.");
                        break;
                    }
                    Console.WriteLine("Empty transports. Try again.");
                    break;
                case 10:
                    if (File.Exists("transports.json"))
                    {
                        var json_for_deserialize = File.ReadAllText("transports.json");
                        var rawTransports = JsonSerializer.Deserialize<List<JsonElement>>(json_for_deserialize);

                        transports = new List<Transport>();
                        foreach (var element in rawTransports)
                        {
                            string TYPE = element.GetProperty("Type").GetString();
                            switch (TYPE)
                            {
                                case "Car":
                                    transports.Add(JsonSerializer.Deserialize<Car>(element.GetRawText()));
                                    break;
                                case "Truck":
                                    transports.Add(JsonSerializer.Deserialize<Truck>(element.GetRawText()));
                                    break;
                                case "Bike":
                                    transports.Add(JsonSerializer.Deserialize<Bike>(element.GetRawText()));
                                    break;
                                case "Bus":
                                    transports.Add(JsonSerializer.Deserialize<Bus>(element.GetRawText()));
                                    break;
                            }
                        }

                        Console.WriteLine("Transports loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File not found. Starting with an empty list.");
                        transports = new List<Transport>();
                    }
                    break;
                case 11:
                    running = false;
                    Console.WriteLine("Exiting the program...");
                    break;
            }
        }

        if (running)
        {
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        
    }
}