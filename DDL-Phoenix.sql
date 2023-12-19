CREATE DATABASE Phoenix
GO
USE Phoenix
CREATE TABLE Administrators (
  username VARCHAR(20) NOT NULL PRIMARY KEY,
  password VARCHAR(200) NOT NULL,
  job_title VARCHAR(50) NOT NULL
);

CREATE TABLE Guests (
  username VARCHAR(20) NOT NULL PRIMARY KEY,
  password VARCHAR(200) NOT NULL,
  first_name VARCHAR(50) NOT NULL,
  middle_name VARCHAR(50),
  last_name VARCHAR(50) NOT NULL,
  birth_date DATE NOT NULL,
  gender VARCHAR(1) NOT NULL,
  citizenship VARCHAR(50) NOT NULL,
  id_number VARCHAR(50) NOT NULL
);

CREATE TABLE Rooms (
  number VARCHAR(10) NOT NULL PRIMARY KEY,
  floor INT NOT NULL,
  room_type VARCHAR(3) NOT NULL,
  guest_limit INT NOT NULL,
  description VARCHAR(1000) NOT NULL,
  cost DECIMAL(12,2) NOT NULL
);

CREATE TABLE Inventories (
  name VARCHAR(50) NOT NULL,
  description VARCHAR(500) NOT NULL,
  stock INT NOT NULL
);

CREATE TABLE RoomServices (
  employee_number VARCHAR(20) NOT NULL PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL,
  middle_name VARCHAR(50),
  last_name VARCHAR(50) NOT NULL,
  outsourcing_company VARCHAR(50) NOT NULL,

  monday_roster_start TIME NOT NULL,
  monday_roster_finish TIME NOT NULL,
  tuesday_roster_start TIME NOT NULL,
  tuesday_roster_finish TIME NOT NULL,
  wednesday_roster_start TIME NOT NULL,
  wednesday_roster_finish TIME NOT NULL,
  thursday_roster_start TIME NOT NULL,
  thursday_roster_finish TIME NOT NULL,
  friday_roster_start TIME NOT NULL,
  friday_roster_finish TIME NOT NULL,
  saturday_roster_start TIME NOT NULL,
  saturday_roster_finish TIME NOT NULL,
  sunday_roster_start TIME NOT NULL,
  sunday_roster_finish TIME NOT NULL
);

CREATE TABLE RoomInventories (
  id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  room_number VARCHAR(10) NOT NULL,
  inventory_name VARCHAR(50) NOT NULL,
  quantity INT NOT NULL,
  FOREIGN KEY (room_number) REFERENCES Rooms(number),
);

CREATE TABLE Reservations (
  reservation_code VARCHAR(50) NOT NULL PRIMARY KEY,
  room_number VARCHAR(10) NOT NULL,
  guest_username VARCHAR(20) NOT NULL,
  book_date DATETIME NOT NULL,
  check_in DATETIME NOT NULL,
  check_out DATETIME NOT NULL,
  cost DECIMAL(12,2) NOT NULL,
  payment_date DATETIME,
  payment_method VARCHAR(5),
  remark VARCHAR(500),

  FOREIGN KEY (room_number) REFERENCES Rooms(number),
  FOREIGN KEY (guest_username) REFERENCES Guests(username)
);