/*CREATE DATABASE MessageBoard;
USE MessageBoard;

CREATE TABLE Messages (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50),
    MessageText TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);
DROP DATABASE MessageBoard*/


CREATE DATABASE `ReservationSystem`;
USE `ReservationSystem`;

-- 創建預約表
/*CREATE TABLE  Reservations ( 
    ID INT AUTO_INCREMENT PRIMARY KEY,         -- 自動增加的ID
    Username VARCHAR(255) NOT NULL,            -- 使用者名稱
    ReservationTime DATETIME NOT NULL,         -- 預約時間
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- 預約創建時間
);*/

CREATE TABLE Reservations (
    ReservationId INT  AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    ReservationTime DATETIME NOT NULL,
    Status VARCHAR(20) DEFAULT 'Pending'  -- 預設狀態為 "Pending"
);
-- 使用者帳密
CREATE TABLE Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(64) NOT NULL
);
-- 建立 Users 和 Reservations 的關聯
ALTER TABLE Reservations
ADD CONSTRAINT FK_Username FOREIGN KEY (Username) 
REFERENCES Users(Username) 
ON DELETE CASCADE;   -- 使用者的記錄被刪除時，與其相關的預約也會被自動刪除

SELECT *
FROM Reservations;	



-- 插入範例預約數據
INSERT INTO Reservations (Username, ReservationTime) 
VALUES ('Wei', '2024-10-16 13:11');

INSERT INTO Reservations (Username, ReservationTime) 
VALUES ('Ray', '2024-11-01 10:00');

INSERT INTO Reservations (Username, ReservationTime) 
VALUES ('Angelina', '2024-12-25 15:30');
