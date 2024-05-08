use DoctorPatient;

CREATE TABLE Patients (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    ContactNumber NVARCHAR(20),
    Email VARCHAR(100)
);

CREATE TABLE Doctors (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Specialization VARCHAR(100),
    ContactNumber VARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Appointments (
    Id INT PRIMARY KEY,
    DoctorId INT,
    PatientId INT,
    AppointmentDateTime DATETIME,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id)
);
