Create database Employee_Management;

use Employee_Management


CREATE TABLE Employee  ( 
Id int identity primary key, 
Name varchar(100) not null, 
Salary int  not null,
Email varchar(150)  not null
);

select * from Employee