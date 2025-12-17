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
    public override double GetRoomChargePerDay()
    {
        return 500;
    }
}

class IPDPatient : Patient
{
    public override double GetRoomChargePerDay()
    {
        return 2000;
    }
}

class EmergencyPatient : Patient
{
    public override double GetRoomChargePerDay()
    {
        return 3000;
    }

    public override double GetEmergencyCharge()
    {
        return 2000;
    }
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
        int id = int.Parse(Console.ReadLine());

        Console.Write("Patient Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Gender: ");
        string gender = Console.ReadLine();

        Console.Write("Days Admitted: ");
        int days = int.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect Patient Type");
        Console.WriteLine("1. OPD");
        Console.WriteLine("2. IPD");
        Console.WriteLine("3. Emergency");
        Console.Write("Choice: ");
        int choice = int.Parse(Console.ReadLine());

        Patient patient = choice switch
        {
            1 => new OPDPatient(),
            2 => new IPDPatient(),
            3 => new EmergencyPatient(),
            _ => new OPDPatient()
        };

        patient.PatientId = id;
        patient.Name = name;
        patient.Age = age;
        patient.Gender = gender;
        patient.DaysAdmitted = days;

        notification.Notify("Patient Admitted");
        notification.Notify("Department Assigned");

        CalculateAndGenerateBill(patient);
    }

    void CalculateAndGenerateBill(Patient patient)
    {
        Console.WriteLine("\n===== BILL CALCULATION =====");

        Console.Write("Enter Treatment Charges: ₹");
        double treatmentCharges = double.Parse(Console.ReadLine());

        double roomCharges =
            patient.GetRoomChargePerDay() * patient.DaysAdmitted;

        double emergencyCharges = patient.GetEmergencyCharge();

        double totalAmount =
            treatmentCharges + roomCharges + emergencyCharges;

        BillingStrategy strategy = ApplyHospitalDiscount;
        double finalAmount =
            billingService.CalculateFinalBill(totalAmount, strategy);

        GenerateBill(
            patient,
            treatmentCharges,
            roomCharges,
            emergencyCharges,
            finalAmount);
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
