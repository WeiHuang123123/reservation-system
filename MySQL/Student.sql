/* 創建/顯示/刪除資料庫
#CREATE DATABASE `sql_DB1`;
#SHOW DATABASES;
#DROP DATABASE `sql_db1`;
*/
USE `sql_DB1`;  -- 使用指定資料庫
/*  資料型態
INT          	-- 整數
DECIMAL(m,n) 	-- 浮點數 (m:幾位數 n:小數點後幾位); eg. 2.33 => DECIMAL(3,2)
VARCHAR(n)   	-- 字串
BLOB			-- 圖片.影片.檔案 (Binary Large Object)
DATE			-- 日期 	'YYYY-MM-DD' 
TIMESTAMP		-- 紀錄時間 'YYYY-MM-DD HH:MM:SS' 
*/


/*  -- 創表格 加屬性
CREATE TABLE `student`( -- 用``避免有特定字眼
		`student_id` INT PRIMARY KEY AUTO_INCREMENT,   
		-- 或多一行PRIMARY KEY `student_id`
        `name` VARCHAR(25) NOT NULL UNIQUE, -- NOT NULL避免null /UNIQUE避免重複
        `time` INT DEFAULT NULL,
        `major` VARCHAR(15) DEFAULT '數學'  
);
DESCRIBE `student`;
DROP TABLE `student`;
ALTER TABLE `student` ADD state VARCHAR(25) DEFAULT NULL;
ALTER TABLE `student` DROP COLUMN gpa ;  		*/

-- 新增資料 找資料
/*SELECT * FROM `student`;		-- 把`student`資料搜尋出來
INSERT INTO `student` VALUE(1,'Wei','20');

INSERT INTO `student`(`name`,`student_id`,`major`) 
VALUE('Wei',1,'數學老師'); -- 可以指定順序

INSERT INTO `student`(`name`) 
VALUE('Katerina'); -- 反正id用AUTO_INCREMENT會自動加 TIME預設是null
*/

-- 修改.刪除
SET SQL_SAFE_UPDATES =0; 	-- 把預設更新關掉，練習才不會被干擾
SELECT * FROM `student`;	-- 顯示資料庫
-- 修改
UPDATE `student` 						-- 哪個資料庫
SET `major` = '國文',`score`= -1 	-- 想改的
WHERE `name` = '格'or `name` = '障礙物';					-- 誰想改
-- 刪除
DELETE FROM `student`
WHERE `major`<>'數學' and `major`<>'數學老師'; -- 等於是= 不等於是<>

-- 取得資料 
SELECT *
FROM `student`					-- 可以多屬性(同個就比下個)
WHERE `major`IN('數學','數學老師')or `score` <> NULL 	-- IN(,)就是這幾個之一都算(or)
ORDER BY `student_id` DESC  	-- ASC是低到高
LIMIT 3			;				-- 前3(DESC就是最低的三個)

