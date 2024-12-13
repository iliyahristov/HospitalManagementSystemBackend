
CREATE DATABASE HospitalManagementSystem COLLATE Cyrillic_General_CI_AS;

USE HospitalManagementSystem;

CREATE TABLE Doctors
(
    DoctorID       INT PRIMARY KEY IDENTITY(1,1),
    FirstName      NVARCHAR(50) NOT NULL,
    LastName       NVARCHAR(50) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    ContactNumber  NVARCHAR(20),
    Email          NVARCHAR(100)
);

CREATE TABLE Patients
(
    PatientID     INT PRIMARY KEY IDENTITY(1,1),
    FirstName     NVARCHAR(50) NOT NULL,
    LastName      NVARCHAR(50) NOT NULL,
    DateOfBirth   DATE NOT NULL,
    Gender        NVARCHAR(10),
    ContactNumber NVARCHAR(20),
    Address       NVARCHAR(200)
);

CREATE TABLE Examinations
(
    ExaminationID   INT PRIMARY KEY IDENTITY(1,1),
    DoctorID        INT FOREIGN KEY REFERENCES Doctors(DoctorID),
    PatientID       INT FOREIGN KEY REFERENCES Patients(PatientID),
    ExaminationDate DATETIME NOT NULL,
    Diagnosis       NVARCHAR(500),
    Prescription    NVARCHAR(500)
);

CREATE TABLE MedicalSpecialties
(
    SpecialtyID   INT PRIMARY KEY IDENTITY(1,1),
    SpecialtyName NVARCHAR(100) NOT NULL
);

CREATE TABLE DoctorSpecialties
(
    DoctorID    INT,
    SpecialtyID INT,
    PRIMARY KEY (DoctorID, SpecialtyID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors (DoctorID),
    FOREIGN KEY (SpecialtyID) REFERENCES MedicalSpecialties (SpecialtyID)
);

INSERT INTO Doctors (FirstName, LastName, Specialization, ContactNumber, Email)
VALUES ('Иван', 'Петров', 'Кардиология', '0888123456', 'ivan.petrov@hospital.bg'),
       ('Мария', 'Иванова', 'Педиатрия', '0899234567', 'maria.ivanova@hospital.bg'),
       ('Георги', 'Стефанов', 'Педиатрия', '0877345678', 'georgi.stefanov@hospital.bg'),
       ('Анна', 'Николова', 'Неврология', '0889456789', 'anna.nikolova@hospital.bg'),
       ('Петър', 'Димитров', 'Ортопедия', '0878567890', 'petar.dimitrov@hospital.bg'),
       ('Елена', 'Колева', 'Ендокринология', '0886678901', 'elena.koleva@hospital.bg'),
       ('Христо', 'Тодоров', 'Психиатрия', '0899789012', 'hristo.todorov@hospital.bg'),
       ('Таня', 'Попова', 'Акушерство и гинекология', '0887890123', 'tanya.popova@hospital.bg'),
       ('Стефан', 'Маринов', 'Онкология', '0888901234', 'stefan.marinov@hospital.bg'),
       ('Радка', 'Герасимова', 'Пулмология', '0876012345', 'radka.gerasimova@hospital.bg');

INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Address)
VALUES ('Боян', 'Иванов', '1985-03-15', 'Мъж', '0889123456', 'ул. Витошка 45, София'),
       ('Мария', 'Петрова', '1990-07-22', 'Жена', '0876234567', 'бул. Цар Освободител 12, София'),
       ('Красимир', 'Стефанов', '1975-11-30', 'Мъж', '0899345678', 'ул. Граф Игнатиев 8, София'),
       ('Даниела', 'Христова', '1982-05-18', 'Жена', '0887456789', 'ул. Пиротска 33, София'),
       ('Николай', 'Николов', '1995-09-10', 'Мъж', '0888567890', 'бул. Черни връх 67, София'),
       ('Анна', 'Кирова', '1988-02-25', 'Жена', '0876678901', 'ул. Шишман 14, София'),
       ('Тодор', 'Попов', '1980-12-05', 'Мъж', '0899789012', 'ул. Аксаков 22, София'),
       ('Силвия', 'Димитрова', '1993-06-14', 'Жена', '0887890123', 'бул. Мария Луиза 56, София'),
       ('Емил', 'Георгиев', '1978-04-03', 'Мъж', '0888901234', 'ул. Солунска 19, София'),
       ('Калина', 'Иванова', '1987-10-20', 'Жена', '0876012345', 'ул. Цар Самуил 41, София'),
       ('Владимир', 'Петров', '1992-08-07', 'Мъж', '0889123567', 'бул. Стамболийски 78, София'),
       ('Радост', 'Стоянова', '1983-01-12', 'Жена', '0876234678', 'ул. Московска 25, София'),
       ('Румен', 'Маринов', '1977-06-28', 'Мъж', '0899345789', 'ул. Oпълченска 37, София'),
       ('Катя', 'Николова', '1991-11-15', 'Жена', '0887456890', 'бул. Васил Левски 104, София'),
       ('Христо', 'Тодоров', '1986-09-22', 'Мъж', '0888567901', 'ул. Dimitar Hadjikocev 16, София'),
       ('Десислава', 'Русева', '1994-03-07', 'Жена', '0876678912', 'ул. Добри Войников 29, София'),
       ('Иван', 'Стефанов', '1979-07-16', 'Мъж', '0899789123', 'бул. Никола Вапцаров 53, София'),
       ('Мила', 'Георгиева', '1989-05-30', 'Жена', '0887890234', 'ул. Позитано 38, София'),
       ('Борислав', 'Петков', '1976-12-11', 'Мъж', '0888901345', 'ул. Сердика 44, София'),
       ('Ралица', 'Кръстева', '1981-02-14', 'Жена', '0876012456', 'бул. Гоце Делчев 88, София');

INSERT INTO MedicalSpecialties (SpecialtyName)
VALUES ('Кардиология'),
       ('Педиатрия'),
       ('Хирургия'),
       ('Неврология'),
       ('Ортопедия'),
       ('Ендокринология'),
       ('Психиатрия'),
       ('Акушерство и гинекология'),
       ('Онкология'),
       ('Пулмология');

INSERT INTO DoctorSpecialties (DoctorID, SpecialtyID)
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (4, 4),
       (5, 5),
       (6, 6),
       (7, 7),
       (8, 8),
       (9, 9),
       (10, 10);

INSERT INTO Examinations (DoctorID, PatientID, ExaminationDate, Diagnosis, Prescription)
VALUES (1, 1, '2024-01-15 10:30:00', 'Повишено кръвно налягане', 'Лекарство за хипертония'),
       (2, 3, '2024-01-16 14:45:00', 'Остра респираторна инфекция', 'Антибиотик и почивка'),
       (3, 5, '2024-01-17 11:15:00', 'Необходимост от коремна операция', 'Подготовка за хирургична интервенция'),
       (4, 7, '2024-01-18 09:00:00', 'Главоболие и мигрена', 'Болкоуспокояващи и релаксанти'),
       (5, 9, '2024-01-19 13:20:00', 'Болки в ставите', 'Физиотерапия и противовъзпалителни'),
       (6, 11, '2024-01-20 15:30:00', 'Проблеми с щитовидната жлеза', 'Хормонална терапия'),
       (7, 13, '2024-01-21 16:45:00', 'Депресивно разстройство', 'Психотерапия и антидепресанти'),
       (8, 15, '2024-01-22 10:10:00', 'Годишен гинекологичен преглед', 'Профилактични препоръки'),
       (9, 17, '2024-01-23 14:00:00', 'Онкологичен скрининг', 'Допълнителни изследвания'),
       (10, 19, '2024-01-24 11:50:00', 'Дихателни проблеми', 'Инхалатор и антибиотици');