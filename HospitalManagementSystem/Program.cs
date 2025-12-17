using System;

// ================= PATIENT BASE CLASS =================
abstract class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int DaysAdmitted { get; set; }

    public abstract double GetRoomChargePerDay();
    public virtual double GetEmergencyCharge() => 0;
}

// ================= DERIVED CLASSES =================
class OPDPatient : Patient
{
    public override double GetRoomChargePerDay() => 500;
}

class IPDPatient : Patient
{
    public override double GetRoomChargePerDay() => 2000;
}

class EmergencyPatient : Patient
{
    public override double GetRoomChargePerDay() => 3000;
    public override double GetEmergencyCharge() => 2000;
}

// ================= DELEGATE =================
delegate double BillingStrategy(double amount);

// ================= BILLING SERVICE =================
class BillingService
{
    public double CalculateFinalBill(double amount, BillingStrategy strategy)
    {
        return strategy(amount);
    }
}

// ================= EVENTS =================
class HospitalNotification
{
    public event Action<string> NotifyDepartment;

    public void Notify(string message)
    {
        NotifyDepartment?.Invoke(message);
    }
}

// ================= HOSPITAL SYSTEM =================
class HospitalSystem
{
    BillingService billingService = new BillingService();
    HospitalNotification notification = new HospitalNotification();

    public HospitalSystem()
    {
        notification.NotifyDepartment +=
            msg => Console.WriteLine("📢 Department Alert: " + msg);
    }

    public void AdmitPatient()
    {
        Console.WriteLine("\n===== PATIENT ADMISSION =====");

        Console.Write("Patient ID: ");
        int patientId = ReadInt();

        Console.Write("Patient Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = ReadInt();

        Console.Write("Gender: ");
        string gender = Console.ReadLine();

        Console.Write("Days Admitted: ");
        int days = ReadInt();

        Console.WriteLine("\nSelect Patient Type");
        Console.WriteLine("1. OPD");
        Console.WriteLine("2. IPD");
        Console.WriteLine("3. Emergency");
        Console.Write("Choice (1/2/3 or opd/ipd/emergency): ");

        Patient patient = ReadPatientType();

        patient.PatientId = patientId;
        patient.Name = name;
        patient.Age = age;
        patient.Gender = gender;
        patient.DaysAdmitted = days;

        notification.Notify("Patient Admitted");
        notification.Notify("Department Assigned");

        CalculateAndGenerateBill(patient);
    }

    Patient ReadPatientType()
    {
        while (true)
        {
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "1" || input == "opd")
                return new OPDPatient();
            if (input == "2" || input == "ipd")
                return new IPDPatient();
            if (input == "3" || input == "emergency")
                return new EmergencyPatient();

            Console.Write("Invalid input. Enter again (1/2/3 or opd/ipd/emergency): ");
        }
    }

    void CalculateAndGenerateBill(Patient patient)
    {
        Console.WriteLine("\n===== BILL CALCULATION =====");

        Console.Write("Enter Treatment Charges: ₹");
        double treatmentCharges = ReadDouble();

        double roomCharges = patient.GetRoomChargePerDay() * patient.DaysAdmitted;
        double emergencyCharges = patient.GetEmergencyCharge();

        double totalAmount = treatmentCharges + roomCharges + emergencyCharges;

        BillingStrategy strategy = ApplyHospitalDiscount;
        double finalAmount = billingService.CalculateFinalBill(totalAmount, strategy);

        GenerateBill(patient, treatmentCharges, roomCharges, emergencyCharges, finalAmount);
    }

    double ApplyHospitalDiscount(double amount)
    {
        Console.WriteLine("Hospital Discount Applied (10%)");
        return amount * 0.90;
    }

    void GenerateBill(
        Patient patient,
        double treatmentCharges,
        double roomCharges,
        double emergencyCharges,
        double finalAmount)
    {
        Console.WriteLine("\n========= FINAL BILL =========");
        Console.WriteLine($"Patient ID      : {patient.PatientId}");
        Console.WriteLine($"Name            : {patient.Name}");
        Console.WriteLine($"Age             : {patient.Age}");
        Console.WriteLine($"Gender          : {patient.Gender}");
        Console.WriteLine($"Patient Type    : {patient.GetType().Name}");
        Console.WriteLine($"Days Admitted   : {patient.DaysAdmitted}");
        Console.WriteLine($"Treatment Cost  : ₹{treatmentCharges}");
        Console.WriteLine($"Room Charges    : ₹{roomCharges}");
        Console.WriteLine($"Emergency Fee   : ₹{emergencyCharges}");
        Console.WriteLine($"TOTAL BILL      : ₹{finalAmount}");
        Console.WriteLine("================================");

        notification.Notify("Billing Completed");
        notification.Notify("Accounts Department Notified");
        notification.Notify("Discharge Process Initiated");
    }

    // ===== SAFE INPUT METHODS =====
    int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.Write("Invalid number. Enter again: ");
        }
    }

    double ReadDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;

            Console.Write("Invalid amount. Enter again: ");
        }
    }
}

// ================= PROGRAM ENTRY =================
class Program
{
    static void Main()
    {
        HospitalSystem system = new HospitalSystem();
        system.AdmitPatient();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
