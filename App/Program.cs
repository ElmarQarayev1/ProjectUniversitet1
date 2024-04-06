using Core;
using Data;
using Service;
using Service.Extentions;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
AppointmentService appointmentService = new AppointmentService();
DoctorService doctorService = new DoctorService();
PatientService patientService = new PatientService();
AppDbContext appDbContext = new AppDbContext();
string opt;
do
{
    opt = ChooseOption();
    switch (opt)
    {
        case "1":
            CreateDoctor();
            break;
        case "2":
            GetSignInDoctor();
            break;
        case "3":
            DeleteDoctor();
            break;
        case "4":
            AllDoctors();
            break;
        case "5":
            EditDoctor();
            break;
        case "6":
            CreatePatient();
            break;
        case "7":
            getSignInPatient();
            break;
        case "8":
            DeletePatient();
            break;
        case "9":
            AllPatients();
            break;
        case "10":
            EditPatient();
            break;
        case "11":
            CreateAppointment();
            break;
        case "0":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nProgram Finished..");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWrong Option!");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
} while (opt != "0");

string ChooseOption()
{
    MainMenu();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\nChoose Option: ");
    Console.ForegroundColor = ConsoleColor.White;
    return Console.ReadLine();
}
void MainMenu()
{
    Console.WriteLine("\n-------------------------------MAIN MENU------------------------------");
    Console.WriteLine("1. Doctor Registr                                                    -");
    Console.WriteLine("2. Doctor Login                                                      -");
    Console.WriteLine("3. Doctor Logout                                                     -");
    Console.WriteLine("4. Show All Doctors                                                  -");
    Console.WriteLine("5. Doctor Edit                                                       -");
    Console.WriteLine("6. Patiet Registr                                                    -");
    Console.WriteLine("7. Patient Login                                                     -");
    Console.WriteLine("8. Patient Logout                                                    -");
    Console.WriteLine("9. Show All Patients                                                 -");
    Console.WriteLine("10.Patient Edit                                                      -");
    Console.WriteLine("11.Make Appointment                                                  -");
    Console.WriteLine("0. Program Finish                                                    -");
    Console.WriteLine("----------------------------------------------------------------------");
}
 
void GetSignInDoctor()
{
Email:
    Console.Write("\nEnter Email: ");
    string? email = Console.ReadLine();
    if (CheckEmail(email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid email..");
        Console.ForegroundColor = ConsoleColor.White;

        goto Email;
    }
    var doctor = appDbContext.Doctors.FirstOrDefault(x => x.Email == email);
    if (doctor != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nDoctor found: {doctor.FullName}\n\n");
        Console.ForegroundColor = ConsoleColor.White;
        AllDoctors();
        AllPatients();
        AllAppointments();   
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nDoctor not found. Please try again.");
        Console.ForegroundColor = ConsoleColor.White;
       
    }    
}
void getSignInPatient()
{
Email:
    Console.Write("\nEnter Email: ");
    string? email = Console.ReadLine();
    if (CheckEmail(email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid email..");
        Console.ForegroundColor = ConsoleColor.White;

        goto Email;
    }
    var patient = appDbContext.Patients.FirstOrDefault(x => x.Email == email);
    if (patient != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nPatient found: {patient.FullName}\n\n");
        Console.ForegroundColor = ConsoleColor.White;
        AllDoctors();
        AllPatients();
        AllAppointments();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nPatient not found. Please try again.");
        Console.ForegroundColor = ConsoleColor.White;

    }
}
void CreateAppointment()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t\t\t    --Creating Appointment--");
    Console.ForegroundColor = ConsoleColor.White;
    AllPatients();
    AllDoctors();
    var appointment = GetAppointment();
    try
    {
        appointmentService.Create(appointment);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void AllAppointments()
{
    var appointments = appointmentService.GetAppointments();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n\t\t\t--All Appointment--\n");
    Console.ForegroundColor = ConsoleColor.White;

    foreach (var item in appointments)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Id:{item.Id}-DoctorId:{item.DoctorId}-PatientId:{item.PatientId}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void CreateDoctor()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t--Creating Doctor--");
    Console.ForegroundColor = ConsoleColor.White;
    var doctor = GetDoctor();
    doctorService.Create(doctor);
}
void DeleteDoctor()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t--Deleting Doctor--");
    Console.ForegroundColor = ConsoleColor.White;
    AllDoctors();
    int id = GetId();
    try
    {
        doctorService.Delete(id);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
Appointment GetAppointment()
{
PatientId:
    Console.Write("\nEnter Patient Id: ");
    string? patientIdStr = Console.ReadLine();
    int patientId;
    if (!int.TryParse(patientIdStr, out patientId))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter correctly..");
        Console.ForegroundColor = ConsoleColor.White;
        goto PatientId;
    }
DoctorId:
    Console.Write("\nEnter Doctor Id: ");
    string? doctorIdStr = Console.ReadLine();
    int doctorId;
    if (!int.TryParse(doctorIdStr, out doctorId))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter correctly..");
        Console.ForegroundColor = ConsoleColor.White;
        goto DoctorId;
    }

    var appointment = new Appointment()
    {
        PatientId = patientId,
        DoctorId = doctorId,
    };
    return appointment;
}

void EditDoctor()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t\t\t     -----Edit Doctor-----");
    Console.ForegroundColor = ConsoleColor.White;
    AllDoctors();
    int id = GetId();
    var doctor = GetDoctor();
    try
    {
        doctorService.Update(doctor, id);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void AllDoctors()
{
    var doctors = doctorService.GetDoctors();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n\t\t\t\t\t\t--All Doctors--\n");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var doctor in doctors)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(doctor);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void CreatePatient()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t--Creating Patient--");
    Console.ForegroundColor = ConsoleColor.White;
    var patient = GetPatient();
    patientService.Create(patient);
}
void DeletePatient()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t--Deleting Patient--");
    Console.ForegroundColor = ConsoleColor.White;
    AllPatients();
    int id = GetId();
    try
    {
        patientService.Delete(id);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;

    }
}
void EditPatient()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\t\t\t\t\t     -----Edit Patient-----");
    Console.ForegroundColor = ConsoleColor.White;
    AllPatients();
    int id = GetId();
    var patient = GetPatient();
    try
    {
        patientService.Update(patient, id);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void AllPatients()
{
    var patients = patientService.GetPatients();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n\t\t\t\t\t\t--All Patient--\n");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var patient in patients)
    {
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(patient);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

Doctor GetDoctor()
{
FullName:
    Console.Write("\nEnter Fullname: ");
    string? fullname = Console.ReadLine();
    if (!CheckFullName(fullname))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid fullname..");
        Console.ForegroundColor = ConsoleColor.White;
        goto FullName;
    }
Email:
    Console.Write("\nEnter Email:");
    string? email = Console.ReadLine();
    if (CheckEmail(email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid email..");
        Console.ForegroundColor = ConsoleColor.White;
        goto Email;

    }
    if (appDbContext.Doctors.Any(x => x.Email == email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nemail already exists..");
        Console.ForegroundColor = ConsoleColor.White;
        goto Email;
    }
    var doctor = new Doctor()
    {
        FullName = fullname.ChangeToCaptalize(),
        Email = email
    };
    return doctor;
}
int GetId(string inputN = "\nId")
{
    Console.Write(inputN + ": ");
    string? idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter correctly..");
        Console.ForegroundColor = ConsoleColor.White;
    }
    return id;
}


Patient GetPatient()
{
FullName:
    Console.Write("\nEnter Fullname: ");
    string? fullname = Console.ReadLine();
    if (!CheckFullName(fullname))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid fullname..");
        Console.ForegroundColor = ConsoleColor.White;

        goto FullName;
    }
Email:
    Console.Write("\nEnter Email: ");
    string? email = Console.ReadLine();
    if (CheckEmail(email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nplease enter a valid email..");
        Console.ForegroundColor = ConsoleColor.White;

        goto Email;

    }
    if (appDbContext.Patients.Any(x => x.Email == email))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nemail already exists..");
        Console.ForegroundColor = ConsoleColor.White;
        goto Email;
    }
    var patient = new Patient()
    {
        FullName = fullname.ChangeToCaptalize(),
        Email = email
    };
    return patient;
}
bool CheckFullName(string fullname)
{
    if (String.IsNullOrWhiteSpace(fullname)) return true;
    if (fullname.CheckFullname()) return true;

    return false;
}
bool CheckEmail(string email)
{
    if (String.IsNullOrWhiteSpace(email)) return true;
    if (!email.isEmailValid()) return true;

    return false;
}

